using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Models;

public class CraftType
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Recipe> Recipes { get; }
}
