namespace CraftingCalculator.DTOs;

public class IngredientDTO
{
    public uint Id { get; set; }
    public uint Count { get; set; }
    public RecipeDTO RecipeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }
}
