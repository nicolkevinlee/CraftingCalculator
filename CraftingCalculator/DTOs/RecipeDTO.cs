namespace CraftingCalculator.DTOs;

public class RecipeDTO
{
    public uint Id { get; set; }
    public uint Yield { get; set; }
    public CraftTypeDTO CraftTypeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }
}
