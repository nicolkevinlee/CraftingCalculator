using CraftingCalculator.DTOs;

namespace CraftingCalculator.Models;

public class Recipe
{
    public uint Id { get; set; }
    public byte Yield { get; set; }
    public ushort RecipeLevel { get; set; }
    public uint CraftTypeId { get; set; }
    public virtual CraftType CraftType { get; set; }
    public uint ItemId { get; set; }
    public virtual Item Item { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }

    public override string ToString() => (Item != null) ? Item.Name : "";

    public static explicit operator Recipe(RecipeDTO recipeDTO)
    {
        if (recipeDTO == null) return null;

        var recipe = new Recipe();

        recipe.Id = recipeDTO.Id;
        recipe.Yield = recipeDTO.Yield;
        recipe.RecipeLevel = recipeDTO.RecipeLevel;

        if(recipeDTO.CraftTypeDTO != null)
        {
            var craftTypeDTO = recipeDTO.CraftTypeDTO;
            recipe.CraftTypeId = craftTypeDTO.Id;
            recipe.CraftType = (CraftType)craftTypeDTO;
        }

        if (recipeDTO.ItemDTO != null)
        {
            var itemDTO = recipeDTO.ItemDTO;
            recipe.ItemId = itemDTO.Id;
            recipe.Item = (Item)itemDTO;
        }

        return recipe;

    }
}
