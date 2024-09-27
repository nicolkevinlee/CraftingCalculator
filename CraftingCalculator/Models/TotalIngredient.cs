namespace CraftingCalculator.Models;

public record TotalIngredient
{
    public ushort Count { get; set; }
    public Item Item { get; set; }
}

