namespace CraftingCalculator.DTOs;

public record RecipeDTO
{
    public uint Id { get; set; }
    public uint Yield { get; set; }
    public CraftTypeDTO CraftTypeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }
}
