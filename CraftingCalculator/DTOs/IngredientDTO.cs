using CraftingCalculator.Models;

namespace CraftingCalculator.DTOs;

public record IngredientDTO
{
    public uint Id { get; set; }
    public byte Count { get; set; }
    public RecipeDTO RecipeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }

    public static explicit operator IngredientDTO(Ingredient ingredient)
    {
        if (ingredient == null) return null;

        var ingredientDTO = new IngredientDTO();

        ingredientDTO.Id = ingredient.Id;
        ingredientDTO.Count = ingredient.Count;

        if(ingredient.Recipe != null)
        {
            ingredientDTO.RecipeDTO = (RecipeDTO)ingredient.Recipe;
        }

        if (ingredient.Item != null)
        {
            ingredientDTO.ItemDTO = (ItemDTO)ingredient.Item;
        }

        return ingredientDTO;

    }
}
