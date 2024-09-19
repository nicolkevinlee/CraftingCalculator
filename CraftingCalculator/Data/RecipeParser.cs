using CraftingCalculator.DTOs;

namespace CraftingCalculator.Data;

class RecipeParser
{

    public Task<ParseResult> ParseCsvData(List<string[]> rawData, Action<ParseResult> OnParseComplete)
    {
        var progressHandler = new Progress<ParseResult>(OnParseComplete);
        var progress = progressHandler as IProgress<ParseResult>;
        var task = new Task<ParseResult>(() =>
        {
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            List<CraftTypeDTO> craftTypeDTOs = new List<CraftTypeDTO>();
            List<RecipeDTO> recipeDTOs = new List<RecipeDTO>();
            List<IngredientDTO> ingredientDTOs = new List<IngredientDTO>();

            foreach (var row in rawData)
            {
                var recipeItemName = row[1].Trim();
                var typeName = row[2].Trim();
                var recipeLevel = row[3].Trim();
                var yield = row[21].Trim();

                CraftTypeDTO? craftTypeDTO = GetCraftTypeDTOWithName(craftTypeDTOs, typeName);
                ItemDTO? recipeItemDTO = GetItemDTOWithName(itemDTOs, recipeItemName);

                if (craftTypeDTO == null)
                {
                    craftTypeDTO = new CraftTypeDTO
                    {
                        Id = (uint)craftTypeDTOs.Count,
                        Name = typeName
                    };
                    craftTypeDTOs.Add(craftTypeDTO);
                }

                if (recipeItemDTO == null)
                {
                    recipeItemDTO = new ItemDTO
                    {
                        Id = (uint)itemDTOs.Count,
                        Name = recipeItemName,
                    };
                    itemDTOs.Add(recipeItemDTO);
                }

                RecipeDTO recipeDTO = new RecipeDTO()
                {
                    Id = (uint)recipeDTOs.Count,
                    CraftTypeDTO = craftTypeDTO,
                    ItemDTO = recipeItemDTO,
                    Yield = byte.Parse(yield),
                    RecipeLevel = ushort.Parse(recipeLevel)
                };

                recipeDTOs.Add(recipeDTO);

                for (int i = 22, j = 0; i < row.Length && j < 8; i += 5, j++)
                {
                    var itemName = row[i + 1].Trim();

                    if (string.IsNullOrEmpty(itemName)) continue;

                    var count = row[i + 4].Trim();

                    ItemDTO? ingredientItem = GetItemDTOWithName(itemDTOs, itemName);

                    if (ingredientItem == null)
                    {
                        ingredientItem = new ItemDTO
                        {
                            Id = (uint)itemDTOs.Count,
                            Name = itemName
                        };
                        itemDTOs.Add(ingredientItem);
                    }

                    var ingredient = new IngredientDTO
                    {
                        Id = (uint)ingredientDTOs.Count,
                        RecipeDTO = recipeDTO,
                        ItemDTO = ingredientItem,
                        Count = byte.Parse(count)
                    };

                    ingredientDTOs.Add(ingredient);
                }
            }

            ParseResult result = new ParseResult()
            {
                ItemDTOs = itemDTOs,
                CraftTypeDTOs = craftTypeDTOs,
                RecipeDTOs = recipeDTOs,
                IngredientDTOs = ingredientDTOs
            };

            progress.Report(result);

            return result;
        });

        task.Start();

        return task;
    }

    private CraftTypeDTO? GetCraftTypeDTOWithName(List<CraftTypeDTO> craftTypes, string craftTypeName)
    {
        return craftTypes.FirstOrDefault(t => t.Name == craftTypeName);
    }

    private ItemDTO? GetItemDTOWithName(List<ItemDTO> items, string itemName)
    {
        return items.FirstOrDefault(t => t.Name == itemName);
    }
}
