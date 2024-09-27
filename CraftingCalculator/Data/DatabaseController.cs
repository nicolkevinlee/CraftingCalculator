using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices;

namespace CraftingCalculator.Data;

public class DatabaseController
{
    public Recipe? GetRecipe(uint itemId)
    {
        Recipe? recipe = null;
        using (CraftingDbContext dbContext = new CraftingDbContext()) {
            recipe = dbContext.Recipes
                .Include(r => r.CraftType)
                .Include(r => r.Item)
                .FirstOrDefault(r => r.ItemId == itemId);
            if (recipe == null) return null;

            var ingredients = GetRecipeIngredients(recipe.Id, dbContext);

            recipe.Ingredients = ingredients;
        }

        return recipe;
    }

    public bool DeleteRecipe(uint recipeId)
    {
        try
        {
            using (var dbContext = new CraftingDbContext())
            {
                var ingredientsToDelete = dbContext.Ingredients.Where(i => i.RecipeId == recipeId);
                foreach (var ingredient in ingredientsToDelete)
                {
                    dbContext.Ingredients.Remove(ingredient);
                }
                dbContext.Recipes.Remove(dbContext.Recipes.Single(r => r.Id == recipeId));
                dbContext.SaveChanges();
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public List<Recipe> SearchRecipes(uint minRecipeLevel, uint maxRecipeLevel, string searchText)
    {
        using (var dbContext = new CraftingDbContext())
        {
            IEnumerable<Recipe> recipes = dbContext.Recipes
                .Include(r => r.Item)
                .Include(r => r.CraftType);

            if (minRecipeLevel > 0)
            {
                recipes = recipes.Where(r => r.RecipeLevel >= minRecipeLevel);
            }

            if (maxRecipeLevel > 0)
            {
                recipes = recipes!.Where(r => r.RecipeLevel <= maxRecipeLevel);
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                recipes = recipes.Where(i => i.Item.Name.ToLower().Contains(searchText.ToLower()));
            }

            var searchResult = recipes.OrderBy(r => r.Id).ToList();

            return searchResult;
        }
    }
    public bool DeleteItem(Item item)
    {
        using (var dbContext = new CraftingDbContext())
        {
            dbContext.Items.Remove(item);
            dbContext.SaveChanges();
            return true;
        }
    }

    public List<Item> SearchItems(string searchText)
    {
        using (var dbContext = new CraftingDbContext())
        {
            IEnumerable<Item> items = dbContext.Items;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                items = items.Where(i => i.Name.ToLower().Contains(searchText.ToLower()));
            }
            var searchResult = items.OrderBy(i => i.Id).ToList();

            return searchResult;
        }
    }

    public List<RecipeListEntry>? GetRecipeListEntries(uint recipeListId)
    {
        List<RecipeListEntry>? recipeListEntries = null;
        using (var dbContext = new CraftingDbContext())
        {
            recipeListEntries = dbContext.RecipeListEntries.Where(e => e.RecipeListId == recipeListId)
                .Include(e => e.RecipeList)
                .Include(e => e.Recipe)
                .Include(e => e.Recipe.CraftType)
                .Include(e => e.Recipe.Item)
                .ToList();
            
            foreach (var entry in recipeListEntries)
            {
                var ingredients = GetRecipeIngredients(entry.Recipe.Id, dbContext);
                entry.Recipe.Ingredients = ingredients;
            }

        }

        return recipeListEntries;
    }

    public List<Ingredient> GetRecipeIngredients(uint recipeID)
    {
        using(var dbContext = new CraftingDbContext())
        {
            return GetRecipeIngredients(recipeID, dbContext);
        }
        
    }

    public List<Ingredient> GetRecipeIngredients(uint recipeID, CraftingDbContext dbContext)
    {

        var ingredients = dbContext.Ingredients.Where(i => i.RecipeId == recipeID)
            .Include(i => i.Recipe)
            .Include(i => i.Item)
            .ToList();

        return ingredients;
    }

    public List<RecipeList> GetAllRecipeLists()
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.RecipeLists.OrderBy(l => l.Id).ToList();
        }
    }

    public ValueTuple<RecipeList, List<RecipeListEntry>>? SaveNewRecipeList(string listName, List<RecipeListEntry> recipeListEntries)
    {

        if (string.IsNullOrEmpty(listName) || recipeListEntries.Count == 0)
        {
            return null;
        }

        RecipeList recipeList = new RecipeList
        {
            Name = listName
        };

        List<RecipeListEntry>? entries = null;

        using (var dbContext = new CraftingDbContext())
        {
            dbContext.RecipeLists.Add(recipeList);
            dbContext.SaveChanges();

            recipeListEntries.ForEach(e => e.RecipeListId = recipeList.Id);
            entries = recipeListEntries.Select(e => e.ToDatabaseEntry()).ToList();
  
            dbContext.RecipeListEntries.AddRange(entries);
            dbContext.SaveChanges();
        }

        return (recipeList, recipeListEntries);

    }

    public bool UpdateRecipeList(uint recipeListId, string listName, List<RecipeListEntry> recipeListEntries)
    {

        if (string.IsNullOrEmpty(listName) || recipeListEntries.Count == 0)
        {
            return false;
        }

        RecipeList recipeList = new RecipeList
        {
            Id = recipeListId,
            Name = listName
        };

        using (var dbContext = new CraftingDbContext())
        {
            dbContext.RecipeLists.Update(recipeList);
            dbContext.SaveChanges();

            recipeListEntries.ForEach(e => e.RecipeListId = recipeList.Id);
            var updatedEntries = recipeListEntries.Select(e => e.ToDatabaseEntry());

            var currentEntries = dbContext.RecipeListEntries.Where(e => e.RecipeListId == recipeListId).ToList();

            var toUpdate = currentEntries.Where(e => updatedEntries.Any(f => f.Id == e.Id)).ToList();
            var toDelete = currentEntries.Where(e => !updatedEntries.Any(f => f.Id == e.Id)).ToList();

            if (toUpdate.Count() > 0)
            {
                dbContext.RecipeListEntries.UpdateRange(toUpdate);
                dbContext.SaveChanges();
            }
            if (toDelete.Count() > 0)
            {
                dbContext.RecipeListEntries.RemoveRange(toDelete);
                dbContext.SaveChanges();
            }

            List<RecipeListEntry> toAdd = new List<RecipeListEntry>(updatedEntries);
            if (toUpdate != null)
            {
                toAdd = toAdd.Where(e => !toUpdate.Any(f => f.Id == e.Id)).ToList();
            }

            if (toAdd.Count > 0)
            {
                dbContext.RecipeListEntries.AddRange(toAdd);
                dbContext.SaveChanges();
            }

        }

        return true;
    }
}
