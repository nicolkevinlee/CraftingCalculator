using CraftingCalculator.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CraftingCalculator.Data;

class RecipeParser
{
    private List<ItemDTO> _itemDTOs;
    private List<CraftTypeDTO> _craftTypeDTOs;
    private List<RecipeDTO> _recipeDTOs;
    private List<IngredientDTO> _ingredientDTOs;

    public RecipeParser()
    {
        ResetDTOs();
    }

    private void ResetDTOs()
    {
        _itemDTOs = new List<ItemDTO>();
        _craftTypeDTOs = new List<CraftTypeDTO>();
        _recipeDTOs = new List<RecipeDTO>();
        _ingredientDTOs = new List<IngredientDTO>();
    }

    public Task<ParseResult> ParseCsvData(List<string[]> rawData, Action<ParseResult> OnParseComplete)
    {
        var progressHandler = new Progress<ParseResult>(OnParseComplete);
        var progress = progressHandler as IProgress<ParseResult>;
        var task = new Task<ParseResult>(() =>
        {
       
            foreach (var row in rawData)
            {
                var recipeItemName = row[1].Trim();
                var typeName = row[2].Trim();
                var recipeLevel = row[3].Trim();
                var yield = row[21].Trim();

                CraftTypeDTO craftTypeDTO = CreateCraftType(typeName);
                ItemDTO recipeItemDTO = CreateItem(recipeItemName);
                RecipeDTO recipeDTO = ParseRecipe(craftTypeDTO, recipeItemDTO, yield, recipeLevel);
                ParseIngredients(row, recipeDTO);                
            }

            ParseResult result = new ParseResult()
            {
                ItemDTOs = _itemDTOs!,
                CraftTypeDTOs = _craftTypeDTOs!,
                RecipeDTOs = _recipeDTOs!,
                IngredientDTOs = _ingredientDTOs!
            };

            ResetDTOs();

            progress.Report(result);

            return result;
        });

        task.Start();

        return task;
    }

    private CraftTypeDTO CreateCraftType(string craftTypeName)
    {
        var craftTypeDTO = _craftTypeDTOs!.FirstOrDefault(t => t.Name == craftTypeName);

        if (craftTypeDTO == null)
        {
            craftTypeDTO = new CraftTypeDTO
            {
                Id = (uint)_craftTypeDTOs!.Count,
                Name = craftTypeName
            };
            _craftTypeDTOs.Add(craftTypeDTO);
        }

        return craftTypeDTO;
    }

    private ItemDTO CreateItem(string itemName)
    {
        var itemDTO = _itemDTOs.FirstOrDefault(t => t.Name == itemName);

        if (itemDTO == null)
        {
            itemDTO = new ItemDTO
            {
                Id = (uint)_itemDTOs.Count,
                Name = itemName,
            };
            _itemDTOs.Add(itemDTO);
        }

        return itemDTO;
    }

    private RecipeDTO ParseRecipe(CraftTypeDTO craftTypeDTO, ItemDTO recipeItemDTO, string yield, string recipeLevel)
    {
        var recipeDTO = new RecipeDTO()
        {
            Id = (uint)_recipeDTOs.Count,
            CraftTypeDTO = craftTypeDTO,
            ItemDTO = recipeItemDTO,
            Yield = byte.Parse(yield),
            RecipeLevel = ushort.Parse(recipeLevel)
        };
        _recipeDTOs.Add(recipeDTO);

        return recipeDTO;
    }

    private void ParseIngredients(string[] row, RecipeDTO recipeDTO)
    {
        for (int i = 22, j = 0; i < row.Length && j < 8; i += 5, j++)
        {
            var itemName = row[i + 1].Trim();

            if (string.IsNullOrEmpty(itemName)) continue;

            var count = row[i + 4].Trim();

            ItemDTO ingredientItem = CreateItem(itemName);

            var ingredient = new IngredientDTO
            {
                Id = (uint)_ingredientDTOs.Count,
                RecipeDTO = recipeDTO,
                ItemDTO = ingredientItem,
                Count = byte.Parse(count)
            };

            _ingredientDTOs.Add(ingredient);
        }
    }
}
