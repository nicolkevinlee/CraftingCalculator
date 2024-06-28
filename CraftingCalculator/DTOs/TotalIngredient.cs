using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.DTOs;

public record TotalIngredient
{
    public uint Id { get; set; }
    public ushort Count { get; set; }
    public ItemDTO ItemDTO { get; set; }
}

