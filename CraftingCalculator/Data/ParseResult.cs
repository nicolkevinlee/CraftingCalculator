using CraftingCalculator.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Data;

public record ParseResult
{
    public List<ItemDTO> ItemDTOs { get; init; }
    public List<CraftTypeDTO> CraftTypeDTOs { get; init; }
    public List<RecipeDTO> RecipeDTOs { get; init; }
    public List<IngredientDTO> IngredientDTOs { get; init; }
}
