﻿using CraftingCalculator.DTOs;
using CraftingCalculator.Models;

namespace CraftingCalculator.Data;

class RecipeImporter : IImporter
{
    public void ImportRecipesToDb(List<ItemDTO> itemDTOs, List<CraftTypeDTO> craftTypeDTOs, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        using(var dbContext = new CraftingDbContext())
        {
            SaveItemsToDb(dbContext, itemDTOs);
            SaveCraftTypesToDb(dbContext, craftTypeDTOs);
            SaveRecipesToDb(dbContext, recipeDTOs, ingredientDTOs);
        }
    }

    private void SaveItemsToDb(CraftingDbContext dbContext, List<ItemDTO> itemDTOs)
    {
        foreach(var item in itemDTOs)
        {
            if(!dbContext.Items.Any(i => i.Name == item.Name))
            {
                dbContext.Items.Add(new Item { Name = item.Name});
            }
        }
        dbContext.SaveChanges();
    }

    private void SaveCraftTypesToDb(CraftingDbContext dbContext, List<CraftTypeDTO> craftTypeDTOs)
    {
        foreach (var type in craftTypeDTOs)
        {
            if (!dbContext.CraftTypes.Any(t => t.Name ==  type.Name))
            {
                dbContext.CraftTypes.Add(new CraftType { Name = type.Name });
            }
        }
        dbContext.SaveChanges();
    }

    private void SaveRecipesToDb(CraftingDbContext dbContext, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        var dbRecipes = new List<Recipe>();

        for(int i = 0; i < recipeDTOs.Count; i++)
        {
            var rawRecipe = recipeDTOs[i];
            var recipeItem = dbContext.Items.FirstOrDefault(i => i.Name == rawRecipe.ItemDTO.Name);
            var craftType = dbContext.CraftTypes.FirstOrDefault(t => t.Name == rawRecipe.CraftTypeDTO.Name);
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

        for(int i = 0; i < recipeDTOs.Count; i++)
        {
            var recipeDTO = recipeDTOs[i];
            var recipe = dbRecipes[i];

            var recipeIngredientDTOs = ingredientDTOs.Where( i => i.RecipeDTO.Id == recipeDTO.Id).ToArray();

            foreach(var ingredientDTO in recipeIngredientDTOs)
            {
                Item item = dbContext.Items.First( i => i.Name == ingredientDTO.ItemDTO.Name );

                var dbIngredient = dbContext.Ingredients.FirstOrDefault(i => i.ItemId == item.Id && i.RecipeId == recipe.Id);

                if(dbIngredient == null)
                {
                    dbIngredient = new Ingredient
                    {
                        ItemId = item.Id,
                        RecipeId = recipe.Id,
                        Count = ingredientDTO.Count
                    };

                    dbContext.Ingredients.Add(dbIngredient);
                }
            }
        }
        dbContext.SaveChanges();
    }
}
