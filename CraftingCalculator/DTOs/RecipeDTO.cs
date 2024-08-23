using CraftingCalculator.Models;

namespace CraftingCalculator.DTOs;

public record RecipeDTO
{
    public uint Id { get; set; }
    public byte Yield { get; set; }
    public ushort RecipeLevel { get; set; }
    public CraftTypeDTO CraftTypeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }
    public ICollection<IngredientDTO> Ingredients { get; set; }
    public override string ToString() => ItemDTO.Name;

    public static explicit operator RecipeDTO(Recipe recipe)
    {
        if (recipe == null) return null;

        var recipeDTO = new RecipeDTO();

        recipeDTO.Id = recipe.Id;
        recipeDTO.Yield = recipe.Yield;
        recipeDTO.RecipeLevel = recipe.RecipeLevel;

        if (recipe.CraftType != null) recipeDTO.CraftTypeDTO = (CraftTypeDTO)recipe.CraftType;
        if (recipe.Item != null) recipeDTO.ItemDTO = (ItemDTO)recipe.Item;

        return recipeDTO;

    }
}
