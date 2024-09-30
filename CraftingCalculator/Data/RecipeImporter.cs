using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading;

namespace CraftingCalculator.Data;

class RecipeImporter : IImporter
{

    public event EventHandler<StatusUpdatedEventArgs>? StatusUpdated;

    public Task ImportRecipesToDb(List<ItemDTO> itemDTOs, List<CraftTypeDTO> craftTypeDTOs, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        var progressHandler = new Progress<StatusUpdatedEventArgs>(InvokeStatusUpdate);
        var progress = progressHandler as IProgress<StatusUpdatedEventArgs>;
        var task = new Task(() =>
        {
            SaveItemsToDb(progress, itemDTOs);
            SaveCraftTypesToDb(progress, craftTypeDTOs);
            SaveRecipesAndIngredientsToDb(progress, recipeDTOs, ingredientDTOs);

            progress.Report(new StatusUpdatedEventArgs
            {
                IsComplete = true,
                Progress = "Complete"
            });

        });
        task.Start();
        return task;
    }

    private void InvokeStatusUpdate(StatusUpdatedEventArgs e)
    {
        StatusUpdated?.Invoke(this, e);
    }

    private void SaveItemsToDb(IProgress<StatusUpdatedEventArgs> progress, List<ItemDTO> itemDTOs)
    {
        progress.Report(new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Items"
        });
        var dbController = new DatabaseController();
        var toAddItems = new List<Item>();
        
        foreach (var item in itemDTOs)
        {
            if (!dbController.IsItemNameExist(item.Name))
            {
                toAddItems.Add(new Item()
                {
                    Name = item.Name
                });
            }
        }

        if(toAddItems.Count > 0) dbController.AddItems(toAddItems);
        
    }

    private void SaveCraftTypesToDb(IProgress<StatusUpdatedEventArgs> progress, List<CraftTypeDTO> craftTypeDTOs)
    {
        progress.Report(new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Craft Types"
        });

        var dbController = new DatabaseController();
        var toAddCraftTypes = new List<CraftType>();

        foreach (var craftType in craftTypeDTOs)
        {
            if (!dbController.IsCraftNameExist(craftType.Name))
            {
                toAddCraftTypes.Add(new CraftType()
                {
                    Name = craftType.Name
                });
            }
        }

        if (toAddCraftTypes.Count > 0) dbController.AddCraftTypes(toAddCraftTypes);

    }

    private void SaveRecipesAndIngredientsToDb(IProgress<StatusUpdatedEventArgs> progress, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        var dbRecipes = SaveRecipesToDb(progress, recipeDTOs);
        SaveIngredientsToDb(progress, dbRecipes, recipeDTOs, ingredientDTOs);
    }

    private List<Recipe> SaveRecipesToDb(IProgress<StatusUpdatedEventArgs> progress, List<RecipeDTO> recipeDTOs)
    {
        var dbRecipes = new List<Recipe>();
        var dbController = new DatabaseController();
        var toAddRecipe = new List<Recipe>(); 
        
        progress.Report(new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Recipes"
        });        

        for (int i = 0; i < recipeDTOs.Count; i++)
        {
            var rawRecipe = recipeDTOs[i];
            var recipeItem = dbController.GetItem(rawRecipe.ItemDTO.Name);
            var craftType = dbController.GetCraftType(rawRecipe.CraftTypeDTO.Name);
            if (recipeItem != null && craftType != null)
            {
                var dbRecipe = dbController.GetRecipe(recipeItem.Id, craftType.Id);
                if (dbRecipe == null)
                {
                    dbRecipe = new Recipe
                    {
                        ItemId = recipeItem.Id,
                        CraftTypeId = craftType.Id,
                        Yield = rawRecipe.Yield,
                        RecipeLevel = rawRecipe.RecipeLevel
                    };
                    toAddRecipe.Add(dbRecipe);
                }
                dbRecipes.Add(dbRecipe);
            }
        }
        if (toAddRecipe.Count > 0) dbController.AddRecipes(toAddRecipe);

        return dbRecipes;
    }

    private void SaveIngredientsToDb(IProgress<StatusUpdatedEventArgs> progress, List<Recipe> dbRecipes, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs)
    {
        var dbController = new DatabaseController();
        var toAddIngredients = new List<Ingredient>();

        progress.Report(new StatusUpdatedEventArgs
        {
            IsComplete = false,
            Progress = "Ingredients"
        });

        for (int i = 0; i < recipeDTOs.Count; i++)
        {
            var recipeDTO = recipeDTOs[i];
            var recipe = dbRecipes[i];

            var recipeIngredientDTOs = ingredientDTOs.Where(i => i.RecipeDTO.Id == recipeDTO.Id).ToArray();

            foreach (var ingredientDTO in recipeIngredientDTOs)
            {
                Item item = dbController.GetItem(ingredientDTO.ItemDTO.Name)!;

                var dbIngredient = dbController.GetIngredient(item.Id, recipe.Id);

                if (dbIngredient == null)
                {
                    dbIngredient = new Ingredient
                    {
                        ItemId = item.Id,
                        RecipeId = recipe.Id,
                        Count = ingredientDTO.Count
                    };
                    toAddIngredients.Add(dbIngredient);
                }
            }
        }
        if (toAddIngredients.Count > 0) dbController.AddIngredients(toAddIngredients);
    }
}




public class StatusUpdatedEventArgs : EventArgs
{
    public bool IsComplete { get; set; }
    public string? Progress { get; set; }
    public string? Error { get; set; }
}