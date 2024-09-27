using CraftingCalculator.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CraftingCalculator.Models;

public class RecipeListEntry
{
    public uint Id { get; set; }
    public uint Count { get; set; }
    public uint RecipeListId { get; set; }
    public RecipeList RecipeList { get; set; }
    public uint RecipeId { get; set; }
    public Recipe Recipe { get; set; }


    public static explicit operator RecipeListEntry(RecipeListEntryDTO recipeListEntryDTO){
        if (recipeListEntryDTO == null) return null;

        var recipeListEntry = new RecipeListEntry();

        recipeListEntry.Id = recipeListEntryDTO.Id;
        recipeListEntry.Count = recipeListEntryDTO.Count;

        if (recipeListEntryDTO.RecipeListDTO != null)
        {
            var recipeListDTO = recipeListEntryDTO.RecipeListDTO;
            recipeListEntry.RecipeListId = recipeListDTO.Id;
            recipeListEntry.RecipeList = (RecipeList)recipeListDTO;
        }

        if (recipeListEntryDTO.RecipeDTO != null)
        {
            var recipeDTO = recipeListEntryDTO.RecipeDTO;
            recipeListEntry.RecipeId = recipeDTO.Id;
            recipeListEntry.Recipe = (Recipe)recipeDTO;
        }

        return recipeListEntry;

    }

    public RecipeListEntry ToDatabaseEntry()
    {
        return new RecipeListEntry
        {
            Id = Id,
            Count = Count,
            RecipeId = RecipeId,
            RecipeListId = RecipeListId
        };
    }

    public RecipeListEntry ToDatabaseEntry(uint recipeListId)
    {
        return new RecipeListEntry
        {
            Id = Id,
            Count = Count,
            RecipeId = RecipeId,
            RecipeListId = recipeListId
        };
    }
}
