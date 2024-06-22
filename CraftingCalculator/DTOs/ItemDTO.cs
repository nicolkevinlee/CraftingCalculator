namespace CraftingCalculator.DTOs;

public record ItemDTO
{
    public uint Id { get; set; }
    public required string Name { get; set; }
}
