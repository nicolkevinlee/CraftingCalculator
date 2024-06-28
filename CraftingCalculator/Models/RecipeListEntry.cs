using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Models;

public class RecipeListEntry
{
    public uint Id { get; set; }
    public uint Count { get; set; }
    public uint RecipeListId { get; set; }
    public RecipeList RecipeList { get; set; }
    public uint RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}
