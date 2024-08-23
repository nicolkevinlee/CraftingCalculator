using CraftingCalculator.Models;

namespace CraftingCalculator.DTOs;

public record ItemDTO
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public override string ToString() => Name;

    public static explicit operator ItemDTO(Item item)
    {
        if (item == null) return null;

        var itemDTO = new ItemDTO()
        {
            Id = item.Id,
            Name = item.Name
        };
        return itemDTO;

    }
}
