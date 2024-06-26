namespace CraftingCalculator.DTOs;

public record RecipeDTO
{
    public uint Id { get; set; }
    public byte Yield { get; set; }
    public ushort RecipeLevel { get; set; }
    public CraftTypeDTO CraftTypeDTO { get; set; }
    public ItemDTO ItemDTO { get; set; }
    public override string ToString() => ItemDTO.Name;
}
