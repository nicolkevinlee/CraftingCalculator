using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Data;

public record CalculatorResult
{
    public required List<RecipeListEntry> SubRecipeListEntries { get; init; }
    public required List<TotalIngredient> TotalIngredients { get; init; }
    public required List<TotalCrystals> TotalShards { get; init; }
}
