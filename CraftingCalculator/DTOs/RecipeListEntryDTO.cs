using CraftingCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.DTOs;

public class RecipeListEntryDTO
{
    public uint Id { get; set; }
    public uint Count { get; set; }
    public RecipeDTO RecipeDTO { get; set; }
}
