using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Models;

public class Ingredient
{
    public uint Id { get; set; }
    public uint Count { get; set; }
    public uint RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public uint ItemId { get; set; }
    public Item Item { get; set; }
}
