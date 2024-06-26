namespace CraftingCalculator.DTOs;

public record IngredientDTO
{
    public uint Id { get; set; }
    public byte Count { get; set; }
    public RecipeDTO RecipeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }
}
