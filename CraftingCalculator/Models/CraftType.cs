using CraftingCalculator.DTOs;

namespace CraftingCalculator.Models;

public class CraftType
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Recipe> Recipes { get; }

    public static explicit operator CraftType(CraftTypeDTO craftTypeDTO)
    {
        if (craftTypeDTO == null) return null;

        var craftType = new CraftType()
        {
            Id = craftTypeDTO.Id,
            Name = craftTypeDTO.Name
        };

        return craftType;

    }
}
