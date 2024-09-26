using CraftingCalculator.DTOs;

namespace CraftingCalculator.Data;

public class CraftCalculator
{

    private static readonly uint[] _shardIds = { 4, 1395, 1427, 7, 1400, 1430, 231, 1455, 1487, 357, 1515, 1538, 508, 1597, 1628, 975, 1758, 1771 };

    public CalculatorResult CalculateTotalIngredients(List<RecipeListEntryDTO> recipeListEntries)
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

    private ValueTuple<List<RecipeListEntryDTO>, List<TotalIngredient>> GetSubCrafts(List<RecipeListEntryDTO> recipeListEntries)
    {
        List<RecipeListEntryDTO> subRecipeEntries = new List<RecipeListEntryDTO>();
        List<TotalIngredient> totalIngredients = new List<TotalIngredient>();
        var dbController = new DatabaseController();

        foreach (var recipeEntry in recipeListEntries)
        {
            var recipe = recipeEntry.RecipeDTO;
            var ingredients = recipeEntry.RecipeDTO.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.ItemDTO.Id);
                if (recipeDTO == null)
                {
                    var totalIngredient = totalIngredients.FirstOrDefault(i => i.ItemDTO.Id == ingredient.ItemDTO.Id);
                    if (totalIngredient == null)
                    {
                        totalIngredient = CreateNewTotalIngredient(ingredient);
                        totalIngredients.Add(totalIngredient);
                    }
                    totalIngredient.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
                else
                {
                    var subRecipeEntry = subRecipeEntries.FirstOrDefault(r => r.RecipeDTO.Id == recipeDTO.Id);
                    if (subRecipeEntry == null)
                    {
                        subRecipeEntry = CreateNewRecipeListEntry(recipeDTO);
                        subRecipeEntries.Add(subRecipeEntry);
                    }
                    subRecipeEntry.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        return (subRecipeEntries, totalIngredients);
    }

    private List<RecipeListEntryDTO> GetSuperSubCrafts(List<RecipeListEntryDTO> subRecipeEntries)
    {
        var dbController = new DatabaseController();

        for (int i = 0; i < subRecipeEntries.Count; i++)
        {
            var recipeEntry = subRecipeEntries[i];
            var recipe = recipeEntry.RecipeDTO;
            var ingredients = recipeEntry.RecipeDTO.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.ItemDTO.Id);
                if (recipeDTO != null)
                {
                    var subRecipeEntry = subRecipeEntries.FirstOrDefault(r => r.RecipeDTO.Id == recipeDTO.Id);
                    if (subRecipeEntry == null)
                    {
                        subRecipeEntry = CreateNewRecipeListEntry(recipeDTO);
                        subRecipeEntries.Add(subRecipeEntry);
                    }
                    subRecipeEntry.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        return subRecipeEntries;
    }

    private List<TotalIngredient> GetSubCraftIngredients(List<RecipeListEntryDTO> subRecipeEntries, List<TotalIngredient> totalIngredients)
    {
        var dbController = new DatabaseController();

        for (int i = 0; i < subRecipeEntries.Count; i++)
        {
            var recipeEntry = subRecipeEntries[i];
            var recipe = recipeEntry.RecipeDTO;
            var ingredients = recipeEntry.RecipeDTO.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.ItemDTO.Id);
                if (recipeDTO == null)
                {
                    var totalIngredient = totalIngredients.FirstOrDefault(i => i.ItemDTO.Id == ingredient.ItemDTO.Id);
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

    private RecipeListEntryDTO CreateNewRecipeListEntry(RecipeDTO recipeDTO)
    {
        return new RecipeListEntryDTO
        {
            Id = 0,
            RecipeDTO = recipeDTO,
            Count = 0
        };
    }

    private TotalIngredient CreateNewTotalIngredient(IngredientDTO ingredientDTO)
    {
        return new TotalIngredient
        {
            Id = ingredientDTO.Id,
            ItemDTO = ingredientDTO.ItemDTO,
            Count = 0
        };
    }

    private List<TotalShards> GetTotalShards(List<TotalIngredient> totalIngredients)
    {
        List<TotalShards> totalShards = new List<TotalShards>();

        for (int i = 0; i < 3; i++)
        {
            totalShards.Add(new TotalShards(i));
        }
        var shards = totalIngredients.Where(i => _shardIds.Contains(i.ItemDTO.Id)).ToList();

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
