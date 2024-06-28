using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Models;

public class RecipeList
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeListEntry> Recipes { get; }
}
