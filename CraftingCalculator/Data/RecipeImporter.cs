using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftingCalculator.Data;

class RecipeImporter : IImporter
{

    public event EventHandler<StatusUpdatedEventArgs> StatusUpdated;

    public void ImportRecipesToDb(List<ItemDTO> itemDTOs, List<CraftTypeDTO> craftTypeDTOs, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        using (var dbContext = new CraftingDbContext())
        {
            SaveItemsToDb(dbContext, itemDTOs);
            SaveCraftTypesToDb(dbContext, craftTypeDTOs);
            SaveRecipesToDb(dbContext, recipeDTOs, ingredientDTOs);
        }
    }

    private void SaveItemsToDb(CraftingDbContext dbContext, List<ItemDTO> itemDTOs)
    {
        StatusUpdated?.Invoke(this, new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Items"
        });

        foreach (var item in itemDTOs)
        {
            if (!dbContext.Items.AnyAsync(i => i.Name == item.Name).Result)
            {
                dbContext.Items.AddAsync(new Item { Name = item.Name });
            }
        }
        dbContext.SaveChangesAsync();
        
    }

    private void SaveCraftTypesToDb(CraftingDbContext dbContext, List<CraftTypeDTO> craftTypeDTOs)
    {
        StatusUpdated?.Invoke(this, new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "CraftTypes"
        });
        foreach (var type in craftTypeDTOs)
        {
            if (!dbContext.CraftTypes.AnyAsync(t => t.Name == type.Name).Result)
            {
                dbContext.CraftTypes.AddAsync(new CraftType { Name = type.Name });
            }
        }
        dbContext.SaveChangesAsync();
    }

    private void SaveRecipesToDb(CraftingDbContext dbContext, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        StatusUpdated?.Invoke(this, new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Recipes"
        });

        var dbRecipes = new List<Recipe>();

        for(int i = 0; i < recipeDTOs.Count; i++)
        {
            var rawRecipe = recipeDTOs[i];
            var recipeItem = dbContext.Items.FirstOrDefaultAsync(i => i.Name == rawRecipe.ItemDTO.Name).Result;
            var craftType = dbContext.CraftTypes.FirstOrDefaultAsync(t => t.Name == rawRecipe.CraftTypeDTO.Name).Result;
            if (recipeItem != null && craftType != null) {
                var dbRecipe = dbContext.Recipes.FirstOrDefaultAsync(r => r.ItemId == recipeItem.Id && r.CraftTypeId == craftType.Id).Result;
                if (dbRecipe == null)
                {
                    dbRecipe = new Recipe
                    {
                        ItemId = recipeItem.Id,
                        CraftTypeId = craftType.Id,
                        Yield = rawRecipe.Yield
                    };
                    dbContext.Recipes.AddAsync(dbRecipe);
                }
                dbRecipes.Add(dbRecipe);
            }
        }
        dbContext.SaveChangesAsync();

        StatusUpdated?.Invoke(this, new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Ingredients"
        });

        for (int i = 0; i < recipeDTOs.Count; i++)
        {
            var recipeDTO = recipeDTOs[i];
            var recipe = dbRecipes[i];

            var recipeIngredientDTOs = ingredientDTOs.Where( i => i.RecipeDTO.Id == recipeDTO.Id).ToArray();

            foreach(var ingredientDTO in recipeIngredientDTOs)
            {
                Item item = dbContext.Items.FirstAsync(i => i.Name == ingredientDTO.ItemDTO.Name).Result;

                var dbIngredient = dbContext.Ingredients.FirstOrDefaultAsync(i => i.ItemId == item.Id && i.RecipeId == recipe.Id).Result;

                if(dbIngredient == null)
                {
                    dbIngredient = new Ingredient
                    {
                        ItemId = item.Id,
                        RecipeId = recipe.Id,
                        Count = ingredientDTO.Count
                    };

                    dbContext.Ingredients.AddAsync(dbIngredient);
                }
            }
        }
        dbContext.SaveChangesAsync();

        StatusUpdated?.Invoke(this, new StatusUpdatedEventArgs
        {
            IsComplete = true,
            Progress = "Complete"
        });
    }
}


public class StatusUpdatedEventArgs : EventArgs
{
    public bool IsComplete { get; set; }
    public string? Progress { get; set; }
    public string? Error { get; set; }
}