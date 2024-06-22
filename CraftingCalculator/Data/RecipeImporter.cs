using CraftingCalculator.DataAccessor;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Data;

class RecipeImporter : IImporter
{
    private List<Item> _items;
    private List<CraftType> _craftTypes;
    private List<Recipe> _recipes;
    private List<Ingredient> _ingredients;

    public void ImportRecipesToDb(List<string[]> rawData)
    {
        _items = new List<Item>();
        _craftTypes = new List<CraftType>();
        _recipes = new List<Recipe>();
        _ingredients = new List<Ingredient>();

        ParseCsvData(rawData);

        using(var dbContext = new CraftingDbContext())
        {
            SaveItemsToDb(dbContext);
            SaveCraftTypesToDb(dbContext);
            SaveRecipesToDb(dbContext);
        }
        

        
    }

    private void ParseCsvData(List<string[]> rawData)
    {
        foreach (var row in rawData)
        {

            var typeName = row[2].Trim();
            var recipeItemName = row[4].Trim();
            var yield = row[5].Trim();

            CraftType? craftType = GetCraftTypeWithName(_craftTypes, typeName);
            Item? recipeItem = GetItemWithName(_items, recipeItemName);

            if (craftType == null)
            {
                craftType = new CraftType
                {
                    Id = (uint)_craftTypes.Count,
                    Name = typeName
                };
                _craftTypes.Add(craftType);
            }

            if (recipeItem == null)
            {
                recipeItem = new Item
                {
                    Id = (uint)_items.Count,
                    Name = recipeItemName
                };
                _items.Add(recipeItem);
            }

            Recipe currentRecipe = new Recipe()
            {
                Id = (uint)_recipes.Count,
                CraftTypeId = craftType.Id,
                CraftType = craftType,
                ItemId = recipeItem.Id,
                Item = recipeItem,
                Yield = uint.Parse(yield)
            };

            _recipes.Add(currentRecipe);

            for (int i = 6; i < row.Length; i += 2)
            {
                var itemName = row[i].Trim();

                if (string.IsNullOrEmpty(itemName)) break;

                var count = row[i + 1].Trim();

                Item? ingredientItem = GetItemWithName(_items, itemName);

                if (ingredientItem == null)
                {
                    ingredientItem = new Item
                    {
                        Id = (uint)_items.Count,
                        Name = itemName
                    };
                    _items.Add(ingredientItem);
                }

                var ingredient = new Ingredient
                {
                    Id = (uint)_ingredients.Count,
                    RecipeId = currentRecipe.Id,
                    Recipe = currentRecipe,
                    ItemId = ingredientItem.Id,
                    Item = ingredientItem,
                    Count = uint.Parse(count)
                };

                _ingredients.Add(ingredient);
            }
        }
    }

    private void SaveItemsToDb(CraftingDbContext dbContext)
    {
        foreach(var item in _items )
        {
            if(!dbContext.Items.Any(i => i.Name == item.Name))
            {
                dbContext.Items.Add(new Item { Name = item.Name});
            }
        }
        dbContext.SaveChanges();
    }

    private void SaveCraftTypesToDb(CraftingDbContext dbContext)
    {
        foreach (var type in _craftTypes)
        {
            if (!dbContext.CraftTypes.Any(t => t.Name ==  type.Name))
            {
                dbContext.CraftTypes.Add(new CraftType { Name = type.Name });
            }
        }
        dbContext.SaveChanges();
    }

    private void SaveRecipesToDb(CraftingDbContext dbContext)
    {
        var dbRecipes = new List<Recipe>();

        for(int i = 0; i < _recipes.Count; i++)
        {
            var rawRecipe = _recipes[i];
            var recipeItem = dbContext.Items.FirstOrDefault(i => i.Name == rawRecipe.Item.Name);
            var craftType = dbContext.CraftTypes.FirstOrDefault(t => t.Name == rawRecipe.CraftType.Name);
            if (recipeItem != null && craftType != null) {
                var dbRecipe = dbContext.Recipes.FirstOrDefault(r => r.ItemId == recipeItem.Id && r.CraftTypeId == craftType.Id);
                if (dbRecipe == null)
                {
                    dbRecipe = new Recipe
                    {
                        ItemId = recipeItem.Id,
                        CraftTypeId = craftType.Id,
                        Yield = rawRecipe.Yield
                    };
                    dbContext.Recipes.Add(dbRecipe);
                }
                dbRecipes.Add(dbRecipe);
            }
        }
        dbContext.SaveChanges();

        for(int i = 0; i < _recipes.Count; i++)
        {
            var localRecipe = _recipes[i];
            var dbRecipe = dbRecipes[i];

            var ingredients = _ingredients.Where( i => i.RecipeId == localRecipe.Id).ToArray();

            foreach(var ingredient in ingredients)
            {
                Item item = dbContext.Items.First( i => i.Name == ingredient.Item.Name );

                var dbIngredient = dbContext.Ingredients.FirstOrDefault(i => i.ItemId == item.Id && i.RecipeId == dbRecipe.Id);

                if(dbIngredient == null)
                {
                    dbIngredient = new Ingredient
                    {
                        ItemId = item.Id,
                        RecipeId = dbRecipe.Id,
                        Count = ingredient.Count
                    };

                    dbContext.Ingredients.Add(dbIngredient);
                }
            }
        }
        dbContext.SaveChanges();
    }

    private CraftType? GetCraftTypeWithName(List<CraftType> craftTypes, string craftTypeName)
    {
        return craftTypes.FirstOrDefault(t => t.Name ==  craftTypeName);
    }

    private Item? GetItemWithName(List<Item> items, string itemName)
    {
        return items.FirstOrDefault(t => t.Name == itemName);
    }

    private bool ContainsCraftTypeName(List<CraftType> types, string craftTypeName)
    {
        return !types.Any(t => t.Name == craftTypeName);
    }

    private bool ContainsItemName(List<Item> items, string itemName) {
        return !items.Any(i => i.Name == itemName);
    }

    private bool IsSameRecipe(Recipe a, Recipe b)
    {
        if (IsSameCraftType(a.CraftType, b.CraftType) && 
            IsSameItem(a.Item, b.Item)) return true;
        return false;
    }

    private bool IsSameCraftType(CraftType a, CraftType b)
    {
        if (a.Name == b.Name) return true;
        return false;
    }

    private bool IsSameItem(Item a, Item b)
    {
        if (a.Name == b.Name) return true;
        return false;
    }
}
