using CraftingCalculator.DTOs;

namespace CraftingCalculator.Models;

public class Ingredient
{
    public uint Id { get; set; }
    public byte Count { get; set; }
    public uint RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public uint ItemId { get; set; }
    public Item Item { get; set; }

    public static explicit operator Ingredient(IngredientDTO ingredientDTO)
    {
        if (ingredientDTO == null) return null;

        var ingredient = new Ingredient();

        ingredient.Id = ingredientDTO.Id;
        ingredient.Count = ingredientDTO.Count;

        if(ingredientDTO.RecipeDTO != null)
        {
            var recipeDTO = ingredientDTO.RecipeDTO;
            ingredient.RecipeId = recipeDTO.Id;
            ingredient.Recipe = (Recipe)recipeDTO;
        }

        if (ingredientDTO.ItemDTO != null)
        {
            var itemDTO = ingredientDTO.ItemDTO;
            ingredient.ItemId = itemDTO.Id;
            ingredient.Item = (Item)itemDTO;
        }


        return ingredient;
    }
}
