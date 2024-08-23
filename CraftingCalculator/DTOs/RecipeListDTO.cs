using CraftingCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.DTOs;

public class RecipeListDTO
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeListEntryDTO> RecipeListEntries { get; set; }

    public static explicit operator RecipeListDTO(RecipeList recipeList)
    {
        if (recipeList == null) return null;

        var recipeListDTO = new RecipeListDTO()
        {
            Id = recipeList.Id,
            Name = recipeList.Name
        };

        return recipeListDTO;

    }
}
