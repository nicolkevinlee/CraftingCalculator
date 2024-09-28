using CraftingCalculator.Enums;
using CraftingCalculator.Models;

namespace CraftingCalculator.Data;

public class CraftCalculator
{

    private static uint[]? _shardIds;

    public CraftCalculator() 
    {
        if (_shardIds != null) return;

        var dbController = new DatabaseController();
        var allCrystals = dbController.GetAllCrystals();
        var crystalCount = Enum.GetNames(typeof(Crystal)).Length;
        var elementCount = Enum.GetNames(typeof(Element)).Length - 1;

        _shardIds = new uint[crystalCount * elementCount];
        var shardIndex = 0;
        foreach( var crystals in allCrystals )
        {
            foreach( var item in crystals.Value ) 
            {
                _shardIds[shardIndex] = item.Value.Id;
                shardIndex++;
            }
        }
    }

    public CalculatorResult CalculateTotalIngredients(List<RecipeListEntry> recipeListEntries)
    {

        var result = GetSubCrafts(recipeListEntries);
        var subRecipeEntries = GetSuperSubCrafts(result.Item1);
        var totalIngredients = GetSubCraftIngredients(result.Item1, result.Item2);
        var totalShards = GetTotalShards(totalIngredients);

        return new CalculatorResult 
        { 
            SubRecipeListEntries = subRecipeEntries, 
            TotalIngredients = totalIngredients, 
            TotalShards = totalShards
        };
    }

    private ValueTuple<List<RecipeListEntry>, List<TotalIngredient>> GetSubCrafts(List<RecipeListEntry> recipeListEntries)
    {
        List<RecipeListEntry> subRecipeEntries = new List<RecipeListEntry>();
        List<TotalIngredient> totalIngredients = new List<TotalIngredient>();
        var dbController = new DatabaseController();

        foreach (var recipeEntry in recipeListEntries)
        {
            var recipe = recipeEntry.Recipe;
            var ingredients = recipeEntry.Recipe.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var subCraftRecipe = dbController.GetRecipe(ingredient.ItemId);
                if (subCraftRecipe == null)
                {
                    var totalIngredient = totalIngredients.FirstOrDefault(i => i.Item.Id == ingredient.ItemId);
                    if (totalIngredient == null)
                    {
                        totalIngredient = CreateNewTotalIngredient(ingredient);
                        totalIngredients.Add(totalIngredient);
                    }
                    totalIngredient.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
                else
                {
                    var subRecipeEntry = subRecipeEntries.FirstOrDefault(r => r.RecipeId == subCraftRecipe.Id);
                    if (subRecipeEntry == null)
                    {
                        subRecipeEntry = CreateNewRecipeListEntry(subCraftRecipe);
                        subRecipeEntries.Add(subRecipeEntry);
                    }
                    subRecipeEntry.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        return (subRecipeEntries, totalIngredients);
    }

    private List<RecipeListEntry> GetSuperSubCrafts(List<RecipeListEntry> subRecipeEntries)
    {
        var dbController = new DatabaseController();

        for (int i = 0; i < subRecipeEntries.Count; i++)
        {
            var recipeEntry = subRecipeEntries[i];
            var recipe = recipeEntry.Recipe;
            var ingredients = recipeEntry.Recipe.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var subCraftRecipe = dbController.GetRecipe(ingredient.Item.Id);
                if (subCraftRecipe != null)
                {
                    var subRecipeEntry = subRecipeEntries.FirstOrDefault(r => r.Recipe.Id == subCraftRecipe.Id);
                    if (subRecipeEntry == null)
                    {
                        subRecipeEntry = CreateNewRecipeListEntry(subCraftRecipe);
                        subRecipeEntries.Add(subRecipeEntry);
                    }
                    subRecipeEntry.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        return subRecipeEntries;
    }

    private List<TotalIngredient> GetSubCraftIngredients(List<RecipeListEntry> subRecipeEntries, List<TotalIngredient> totalIngredients)
    {
        var dbController = new DatabaseController();

        for (int i = 0; i < subRecipeEntries.Count; i++)
        {
            var recipeEntry = subRecipeEntries[i];
            var recipe = recipeEntry.Recipe;
            var ingredients = recipeEntry.Recipe.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.Item.Id);
                if (recipeDTO == null)
                {
                    var totalIngredient = totalIngredients.FirstOrDefault(i => i.Item.Id == ingredient.Item.Id);
                    if (totalIngredient == null)
                    {
                        totalIngredient = CreateNewTotalIngredient(ingredient);
                        totalIngredients.Add(totalIngredient);
                    }
                    totalIngredient.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        return totalIngredients;
    }

    private RecipeListEntry CreateNewRecipeListEntry(Recipe recipe)
    {
        return new RecipeListEntry
        {
            Id = 0,
            RecipeId = recipe.Id,
            Recipe = recipe,
            Count = 0
        };
    }

    private TotalIngredient CreateNewTotalIngredient(Ingredient ingredient)
    {
        return new TotalIngredient
        {
            Item = ingredient.Item,
            Count = 0
        };
    }

    private List<TotalCrystals> GetTotalShards(List<TotalIngredient> totalIngredients)
    {
        
        var crystals = Enum.GetValues(typeof(Crystal)).Cast<Crystal>();
        List<TotalCrystals> totalShards = crystals.Select(c => new TotalCrystals(c)).ToList();

        var shards = totalIngredients.Where(i => _shardIds!.Contains(i.Item.Id)).ToList();

        foreach (var item in shards)
        {
            totalIngredients.Remove(item);
            foreach (var totalShard in totalShards)
            {
                totalShard.SetShardCount(item);
            }
        }

        return totalShards;
    }
}
