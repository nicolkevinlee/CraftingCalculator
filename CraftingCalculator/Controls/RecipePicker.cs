using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using System.ComponentModel;

namespace CraftingCalculator.Controls;

public partial class RecipePicker : UserControl
{
    private BindingList<RecipeDTO> _filteredRecipes;
    private List<RecipeDTO>? _allRecipes;
    private RecipeDTO? _selectedRecipe;
    public event EventHandler<RecipeSelectedEventArgs> RecipeSelected;

    public RecipePicker()
    {
        _selectedRecipe = null;
        _allRecipes = null;
        _filteredRecipes = new BindingList<RecipeDTO>();
        InitializeComponent();
    }
    public void LoadRecipes()
    {
        using (var dbContext = new CraftingDbContext())
        {
            _allRecipes = dbContext.Recipes.OrderBy(r => r.Id).Select(r =>
                new RecipeDTO
                {
                    Id = r.Id,
                    Yield = r.Yield,
                    CraftTypeDTO = new CraftTypeDTO()
                    {
                        Id = r.CraftTypeId,
                        Name = r.CraftType.Name
                    },
                    ItemDTO = new ItemDTO()
                    {
                        Id = r.ItemId,
                        Name = r.Item.Name
                    }
                }
            ).ToList();
        }
        RefreshList();
        RecipedGridView.DataSource = _filteredRecipes;
    }

    public void DeleteRecipe(RecipeDTO recipe)
    {
        using (var dbContext = new CraftingDbContext())
        {
            var ingredientsToDelete = dbContext.Ingredients.Where(i => i.RecipeId == recipe.Id);
            foreach(var ingredient in ingredientsToDelete)
            {
                dbContext.Ingredients.Remove(ingredient);
            }
            dbContext.Recipes.Remove(dbContext.Recipes.Single(r=>r.Id == recipe.Id));
            dbContext.SaveChanges();
            _allRecipes.Remove(recipe);
        }
        RefreshList();
    }

    private void RecipeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedRecipe = _filteredRecipes[e.RowIndex];
        RecipeSelected?.Invoke(this, new RecipeSelectedEventArgs()
        {
            SelectedRecipe = _selectedRecipe
        });
    }

    private void RefreshList()
    {
        var searchText = SearchTextBox.Text.Trim();

        _filteredRecipes.Clear();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            _allRecipes!.ForEach(i =>
            {
                _filteredRecipes.Add(i);
            });
        }
        else
        {
            var searchResult = _allRecipes!.Where(i => i.ItemDTO.Name.ToLower().Contains(searchText.ToLower())).ToList();
            searchResult.ForEach(i =>
            {
                _filteredRecipes.Add(i);
            });
        }
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshList();
    }
}

public class RecipeSelectedEventArgs : EventArgs
{
    public RecipeDTO? SelectedRecipe { get; set; }
}