namespace CraftingCalculator.Models;

public class Ingredient
{
    public uint Id { get; set; }
    public uint Count { get; set; }
    public uint RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public uint ItemId { get; set; }
    public Item Item { get; set; }
}
