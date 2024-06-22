namespace CraftingCalculator.Models;

public class Recipe
{
    public uint Id { get; set; }
    public uint Yield { get; set; }
    public uint CraftTypeId { get; set; }
    public virtual CraftType CraftType { get; set; }
    public uint ItemId { get; set; }
    public virtual Item Item { get; set; }
    public ICollection<Ingredient> Ingredients { get; }
}
