using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.Data;

public class DatabaseController
{
    public RecipeDTO? GetRecipe(uint itemId)
    {
        RecipeDTO? recipeDTO = null;
        using (CraftingDbContext dbContext = new CraftingDbContext()) {
            var recipe = dbContext.Recipes.Include(r => r.CraftType).Include(r => r.Item).Include(r => r.Ingredients).FirstOrDefault(r => r.ItemId == itemId);
            if (recipe == null) return null;

            recipeDTO = (RecipeDTO)recipe;
            var ingredients = recipe.Ingredients.Select((ingredient) =>
            {
                var item = dbContext.Items.First(i => i.Id == ingredient.ItemId);
                var ingredientDTO = (IngredientDTO)ingredient;
                ingredientDTO.ItemDTO = (ItemDTO)item;
                ingredientDTO.RecipeDTO = recipeDTO;
                return ingredientDTO;
            }).ToList();

            recipeDTO.Ingredients = ingredients;
        }

        return recipeDTO;
    }

    public List<RecipeListEntryDTO>? GetRecipeListEntries(uint recipeListId)
    {
        List<RecipeListEntryDTO>? recipeListEntryDTOs = null;
        using (var dbContext = new CraftingDbContext())
        {
            recipeListEntryDTOs = dbContext.RecipeListEntries.Where(e => e.RecipeListId == recipeListId)
                .Include(e => e.RecipeList)
                .Include(e => e.Recipe)
                .Include(e => e.Recipe.CraftType)
                .Include(e => e.Recipe.Item)
                .Select(e => (RecipeListEntryDTO)e)
                .ToList();

            foreach (var entry in recipeListEntryDTOs)
            {
                var ingredients = dbContext.Ingredients.Where(i => i.RecipeId == entry.RecipeDTO.Id)
                    .Include(i => i.Recipe)
                    .Include(i => i.Item)
                    .Select(i => (IngredientDTO)i).ToList();
                entry.RecipeDTO.Ingredients = ingredients;
            }

        }

        return recipeListEntryDTOs;
    }

    public ValueTuple<RecipeListDTO, List<RecipeListEntryDTO>>? SaveNewRecipeList(string listName, List<RecipeListEntryDTO> recipeListEntries)
    {

        if (string.IsNullOrEmpty(listName) || recipeListEntries.Count == 0)
        {
            return null;
        }

        RecipeList recipeList = new RecipeList
        {
            Name = listName
        };

        List<RecipeListEntry>? entries = null;

        using (var dbContext = new CraftingDbContext())
        {
            dbContext.RecipeLists.Add(recipeList);
            dbContext.SaveChanges();

            entries = recipeListEntries.Select(e => new RecipeListEntry
                    {
                        Id = e.Id,
                        Count = e.Count,
                        RecipeId = e.RecipeDTO.Id,
                        RecipeListId = recipeList.Id
                    }).ToList();
  
            dbContext.RecipeListEntries.AddRange(entries);
            dbContext.SaveChanges();
        }

        List<RecipeListEntryDTO> recipeEntryDTOs = GetRecipeListEntries(recipeList.Id)!;
        RecipeListDTO recipeListDTO = (RecipeListDTO) recipeList;

        return (recipeListDTO, recipeEntryDTOs);

    }

    public bool UpdateRecipeList(uint recipeListId, string listName, List<RecipeListEntryDTO> recipeListEntries)
    {

        if (string.IsNullOrEmpty(listName) || recipeListEntries.Count == 0)
        {
            return false;
        }

        RecipeList recipeList = new RecipeList
        {
            Id = recipeListId,
            Name = listName
        };

        using (var dbContext = new CraftingDbContext())
        {
            dbContext.RecipeLists.Update(recipeList);
            dbContext.SaveChanges();

            var currentEntries = dbContext.RecipeListEntries.Where(e => e.RecipeListId == recipeListId).ToList();

            var toUpdate = currentEntries.Where(e => recipeListEntries.Any(f => f.Id == e.Id)).ToList();
            var toDelete = currentEntries.Where(e => !recipeListEntries.Any(f => f.Id == e.Id)).ToList();

            if (toUpdate != null && toUpdate.Count() > 0)
            {
                dbContext.RecipeListEntries.UpdateRange(toUpdate);
                dbContext.SaveChanges();
            }
            if (toDelete != null && toDelete.Count() > 0)
            {
                dbContext.RecipeListEntries.RemoveRange(toDelete);
                dbContext.SaveChanges();
            }

            List<RecipeListEntry> toAdd = recipeListEntries.Select(e => (RecipeListEntry)e).ToList();
            if (toUpdate != null)
            {
                toAdd = toAdd.Where(e => !toUpdate.Any(f => f.Id == e.Id)).Select(e =>
                    new RecipeListEntry
                    {
                        Id = e.Id,
                        Count = e.Count,
                        RecipeId = e.RecipeId,
                        RecipeListId = e.RecipeListId
                    }).ToList();
            }

            if (toAdd != null && toAdd.Count > 0)
            {
                dbContext.RecipeListEntries.AddRange(toAdd);
                dbContext.SaveChanges();
            }

        }

        return true;
    }
}
