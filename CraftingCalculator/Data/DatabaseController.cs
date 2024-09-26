using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices;

namespace CraftingCalculator.Data;

public class DatabaseController
{
    public RecipeDTO? GetRecipe(uint itemId)
    {
        RecipeDTO? recipeDTO = null;
        using (CraftingDbContext dbContext = new CraftingDbContext()) {
            var recipe = dbContext.Recipes.Include(r => r.CraftType).Include(r => r.Item).Include(r => r.Ingredients).FirstOrDefault(r => r.ItemId == itemId);
            if (recipe == null) return null;

            recipeDTO = (RecipeDTO)recipe;
            var ingredients = recipe.Ingredients.Select((ingredient) =>
            {
                var item = dbContext.Items.First(i => i.Id == ingredient.ItemId);
                var ingredientDTO = (IngredientDTO)ingredient;
                ingredientDTO.ItemDTO = (ItemDTO)item;
                ingredientDTO.RecipeDTO = recipeDTO;
                return ingredientDTO;
            }).ToList();

            recipeDTO.Ingredients = ingredients;
        }

        return recipeDTO;
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

    public List<RecipeDTO> SearchRecipes(uint minRecipeLevel, uint maxRecipeLevel, string searchText)
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

            var searchResult = recipes.OrderBy(r => r.Id).Select(r => (RecipeDTO)r).ToList();

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

    public List<RecipeListEntryDTO>? GetRecipeListEntries(uint recipeListId)
    {
        List<RecipeListEntryDTO>? recipeListEntryDTOs = null;
        using (var dbContext = new CraftingDbContext())
        {
            recipeListEntryDTOs = dbContext.RecipeListEntries.Where(e => e.RecipeListId == recipeListId)
                .Include(e => e.RecipeList)
                .Include(e => e.Recipe)
                .Include(e => e.Recipe.CraftType)
                .Include(e => e.Recipe.Item)
                .Select(e => (RecipeListEntryDTO)e)
                .ToList();

            foreach (var entry in recipeListEntryDTOs)
            {
                var ingredients = GetRecipeIngredients(entry.RecipeDTO.Id, dbContext);
                entry.RecipeDTO.Ingredients = ingredients;
            }

        }

        return recipeListEntryDTOs;
    }

    public List<IngredientDTO> GetRecipeIngredients(uint recipeID)
    {
        using(var dbContext = new CraftingDbContext())
        {
            return GetRecipeIngredients(recipeID, dbContext);
        }
        
    }

    public List<IngredientDTO> GetRecipeIngredients(uint recipeID, CraftingDbContext dbContext)
    {

        var ingredients = dbContext.Ingredients.Where(i => i.RecipeId == recipeID)
            .Include(i => i.Recipe)
            .Include(i => i.Item)
            .Select(i => (IngredientDTO)i).ToList();

        return ingredients;
    }

    public List<RecipeList> GetAllRecipeLists()
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.RecipeLists.OrderBy(l => l.Id).ToList();
        }
    }

    public ValueTuple<RecipeListDTO, List<RecipeListEntryDTO>>? SaveNewRecipeList(string listName, List<RecipeListEntryDTO> recipeListEntries)
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

            entries = recipeListEntries.Select(e => new RecipeListEntry
                    {
                        Id = e.Id,
                        Count = e.Count,
                        RecipeId = e.RecipeDTO.Id,
                        RecipeListId = recipeList.Id
                    }).ToList();
  
            dbContext.RecipeListEntries.AddRange(entries);
            dbContext.SaveChanges();
        }

        List<RecipeListEntryDTO> recipeEntryDTOs = GetRecipeListEntries(recipeList.Id)!;
        RecipeListDTO recipeListDTO = (RecipeListDTO) recipeList;

        return (recipeListDTO, recipeEntryDTOs);

    }

    public bool UpdateRecipeList(uint recipeListId, string listName, List<RecipeListEntryDTO> recipeListEntries)
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

            var currentEntries = dbContext.RecipeListEntries.Where(e => e.RecipeListId == recipeListId).ToList();

            var toUpdate = currentEntries.Where(e => recipeListEntries.Any(f => f.Id == e.Id)).ToList();
            var toDelete = currentEntries.Where(e => !recipeListEntries.Any(f => f.Id == e.Id)).ToList();

            if (toUpdate != null && toUpdate.Count() > 0)
            {
                dbContext.RecipeListEntries.UpdateRange(toUpdate);
                dbContext.SaveChanges();
            }
            if (toDelete != null && toDelete.Count() > 0)
            {
                dbContext.RecipeListEntries.RemoveRange(toDelete);
                dbContext.SaveChanges();
            }

            List<RecipeListEntry> toAdd = recipeListEntries.Select(e => (RecipeListEntry)e).ToList();
            if (toUpdate != null)
            {
                toAdd = toAdd.Where(e => !toUpdate.Any(f => f.Id == e.Id)).Select(e =>
                    new RecipeListEntry
                    {
                        Id = e.Id,
                        Count = e.Count,
                        RecipeId = e.RecipeId,
                        RecipeListId = e.RecipeListId
                    }).ToList();
            }

            if (toAdd != null && toAdd.Count > 0)
            {
                dbContext.RecipeListEntries.AddRange(toAdd);
                dbContext.SaveChanges();
            }

        }

        return true;
    }
}
