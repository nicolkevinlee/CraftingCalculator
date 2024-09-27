using CraftingCalculator.DTOs;

namespace CraftingCalculator.Models;

public class Item
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Recipe> Recipes { get; }
    public override string ToString() => Name;

    public static explicit operator Item(ItemDTO itemDTO)
    {
        if (itemDTO == null) return null;

        var item = new Item()
        {
            Id = itemDTO.Id,
            Name = itemDTO.Name
        };
        return item;
    }
}
