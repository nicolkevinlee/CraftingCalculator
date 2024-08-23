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
    public RecipeListDTO RecipeListDTO { get; set; }
    public RecipeDTO RecipeDTO { get; set; }

    public static explicit operator RecipeListEntryDTO(RecipeListEntry recipeListEntry)
    {
        if (recipeListEntry == null) return null;

        var recipeListEntryDTO = new RecipeListEntryDTO();

        recipeListEntryDTO.Id = recipeListEntry.Id;
        recipeListEntryDTO.Count = recipeListEntry.Count;

        if (recipeListEntry.RecipeList != null) recipeListEntryDTO.RecipeListDTO = (RecipeListDTO)recipeListEntry.RecipeList;
        if (recipeListEntry.Recipe != null) recipeListEntryDTO.RecipeDTO = (RecipeDTO)recipeListEntry.Recipe;

        return recipeListEntryDTO;

    }
}
