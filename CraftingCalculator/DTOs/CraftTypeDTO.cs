namespace CraftingCalculator.DTOs;

public record CraftTypeDTO
{
    public uint Id { get; set; }
    public required string Name { get; set; }

    public override string ToString() => Name;
}