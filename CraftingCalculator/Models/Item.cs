namespace CraftingCalculator.Models;

public class Item
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Recipe> Recipes { get; }

}
