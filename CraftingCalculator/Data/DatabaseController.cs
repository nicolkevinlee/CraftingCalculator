using CraftingCalculator.DTOs;
using CraftingCalculator.Enums;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices;
using static Azure.Core.HttpHeader;

namespace CraftingCalculator.Data;

public class DatabaseController
{
    private static Dictionary<Crystal, Dictionary<Element, Item>>? _allCrystals = null;

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

    public Recipe? GetRecipe(uint itemId, uint craftTypeId)
    {
        using (CraftingDbContext dbContext = new CraftingDbContext())
        {
            return dbContext.Recipes.FirstOrDefault(r => r.ItemId == itemId && r.CraftTypeId == craftTypeId);
        }
    }

    public List<Recipe> AddRecipes(List<Recipe> recipes)
    {
        using (CraftingDbContext dbContext = new CraftingDbContext())
        {
            dbContext.Recipes.AddRange(recipes);
            dbContext.SaveChanges();
        }
        return recipes;
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

    public bool IsItemNameExist(string name)
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.Items.Any(t => t.Name == name);
        }
    }
    public Item? GetItem(string name)
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.Items.FirstOrDefault(i => i.Name == name);
        }
    }

    public List<Item> AddItems(List<Item> items)
    {
        using (var dbContext = new CraftingDbContext())
        {
            dbContext.Items.AddRange(items);
            dbContext.SaveChanges();
            return items;
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

    public bool IsCraftNameExist(string name)
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.CraftTypes.Any(t => t.Name == name);
        }
    }
    public CraftType? GetCraftType(string name)
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.CraftTypes.FirstOrDefault(i => i.Name == name);
        }
    }

    public List<CraftType> AddCraftTypes(List<CraftType> craftTypes)
    {
        using (var dbContext = new CraftingDbContext())
        {
            dbContext.CraftTypes.AddRange(craftTypes);
            dbContext.SaveChanges();
            return craftTypes;
        }
    }

    public Dictionary<Crystal, Dictionary<Element, Item>> GetAllCrystals()
    {
        if (_allCrystals != null) return _allCrystals;

        var elements = Enum.GetValues(typeof(Element)).Cast<Element>();
        var crystals = Enum.GetValues(typeof(Crystal)).Cast<Crystal>();

        Dictionary<Crystal, Dictionary<Element, string>> crystalNames = new Dictionary<Crystal, Dictionary<Element, string>>();

        foreach (var crystal in crystals)
        {
            var names = new Dictionary<Element, string>();
            foreach(var element in elements)
            {
                if (element == Element.None) continue;
                names.Add(element, $"{element} {crystal}");
            }
            crystalNames.Add(crystal, names);
        }

        Dictionary<Crystal, Dictionary<Element, Item>> result = new Dictionary<Crystal, Dictionary<Element, Item>>();
        using(var dbContext = new CraftingDbContext())
        {
            foreach(KeyValuePair<Crystal, Dictionary<Element, string>> ckvp in crystalNames)
            {
                var items = new Dictionary<Element, Item>();
                foreach (KeyValuePair<Element, string> ekvp in ckvp.Value)
                {
                    var item = dbContext.Items.FirstOrDefault(i => i.Name == ekvp.Value);
                    if(item != null) items[ekvp.Key] = item;
                }
                result.Add(ckvp.Key, items);
            }
        }

        _allCrystals = result;

        return result;
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

    public Ingredient? GetIngredient(uint itemId, uint recipeId)
    {
        using (var dbContext = new CraftingDbContext())
        {
            return dbContext.Ingredients.FirstOrDefault(i => i.ItemId == itemId && i.RecipeId == recipeId);
        }
    }

    public List<Ingredient> GetRecipeIngredients(uint recipeID)
    {
        using(var dbContext = new CraftingDbContext())
        {
            return GetRecipeIngredients(recipeID, dbContext);
        }
        
    }

    public List<Ingredient> AddIngredients(List<Ingredient> ingredients)
    {
        using (CraftingDbContext dbContext = new CraftingDbContext())
        {
            dbContext.Ingredients.AddRange(ingredients);
            dbContext.SaveChanges();
        }
        return ingredients;
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
