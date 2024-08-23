using CraftingCalculator.DTOs;
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

    public static explicit operator RecipeList(RecipeListDTO recipeListDTO)
    {
        if (recipeListDTO == null) return null;

        var recipeList = new RecipeList();

        recipeList.Id = recipeListDTO.Id;
        recipeList.Name = recipeListDTO.Name;

        return recipeList;
    }
}
