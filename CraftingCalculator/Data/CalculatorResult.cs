using CraftingCalculator.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Data;

public record CalculatorResult
{
    public required List<RecipeListEntryDTO> SubRecipeListEntries { get; init; }
    public required List<TotalIngredient> TotalIngredients { get; init; }
    public required List<TotalShards> TotalShards { get; init; }
}
