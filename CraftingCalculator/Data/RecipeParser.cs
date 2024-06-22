using CraftingCalculator.DTOs;

namespace CraftingCalculator.Data;

class RecipeParser
{

    public ParseResult ParseCsvData(List<string[]> rawData)
    {
        List<ItemDTO> itemDTOs = new List<ItemDTO>();
        List<CraftTypeDTO> craftTypeDTOs = new List<CraftTypeDTO>();
        List<RecipeDTO> recipeDTOs = new List<RecipeDTO>();
        List<IngredientDTO> ingredientDTOs = new List<IngredientDTO>();

        foreach (var row in rawData)
        {

            var typeName = row[2].Trim();
            var recipeItemName = row[4].Trim();
            var yield = row[5].Trim();

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
                    Name = recipeItemName
                };
                itemDTOs.Add(recipeItemDTO);
            }

            RecipeDTO recipeDTO = new RecipeDTO()
            {
                Id = (uint)recipeDTOs.Count,
                CraftTypeDTO = craftTypeDTO,
                ItemDTO = recipeItemDTO,
                Yield = uint.Parse(yield)
            };

            recipeDTOs.Add(recipeDTO);

            for (int i = 6; i < row.Length; i += 2)
            {
                var itemName = row[i].Trim();

                if (string.IsNullOrEmpty(itemName)) break;

                var count = row[i + 1].Trim();

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
                    Count = uint.Parse(count)
                };

                ingredientDTOs.Add(ingredient);
            }
        }

        return new ParseResult()
        {
            ItemDTOs = itemDTOs,
            CraftTypeDTOs = craftTypeDTOs,
            RecipeDTOs = recipeDTOs,
            IngredientDTOs = ingredientDTOs
        };
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
