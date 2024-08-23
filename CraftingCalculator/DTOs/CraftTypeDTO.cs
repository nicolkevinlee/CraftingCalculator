using CraftingCalculator.Models;

namespace CraftingCalculator.DTOs;

public record CraftTypeDTO
{
    public uint Id { get; set; }
    public required string Name { get; set; }

    public override string ToString() => Name;

    public static explicit operator CraftTypeDTO(CraftType craftType)
    {
        if (craftType == null) return null;

        var craftTypeDTO = new CraftTypeDTO()
        {
            Id = craftType.Id,
            Name = craftType.Name
        };

        return craftTypeDTO;

    }
}