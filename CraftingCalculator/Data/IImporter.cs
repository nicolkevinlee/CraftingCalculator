using CraftingCalculator.DTOs;

namespace CraftingCalculator.Data;

public interface IImporter
{
    Task ImportRecipesToDb(List<ItemDTO> itemDTOs, List<CraftTypeDTO> craftTypeDTOs, List<RecipeDTO> recipeDTOs, List<IngredientDTO> ingredientDTOs);
}