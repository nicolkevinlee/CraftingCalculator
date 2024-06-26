using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using System.ComponentModel;

namespace CraftingCalculator.Controls;

public partial class RecipePicker : UserControl
{
    private BindingList<RecipeDTO> _filteredRecipes;
    private List<RecipeDTO>? _allRecipes;
    private RecipeDTO? _selectedRecipe;
    private uint _minRecipeLevel;
    private uint _maxRecipeLevel;
    public event EventHandler<RecipeSelectedEventArgs> RecipeSelected;

    public RecipePicker()
    {
        _selectedRecipe = null;
        _allRecipes = null;
        _filteredRecipes = new BindingList<RecipeDTO>();
        _minRecipeLevel = 0;
        _maxRecipeLevel = 0;
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
                    RecipeLevel = r.RecipeLevel,
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
            foreach (var ingredient in ingredientsToDelete)
            {
                dbContext.Ingredients.Remove(ingredient);
            }
            dbContext.Recipes.Remove(dbContext.Recipes.Single(r => r.Id == recipe.Id));
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

        List<RecipeDTO>? searchResult = null;

        if (_minRecipeLevel > 0)
        {
            searchResult = _allRecipes!.Where(r => r.RecipeLevel >= _minRecipeLevel).ToList();
        }
        else
        {
            searchResult = _allRecipes!.ToList();
        }

        if (_maxRecipeLevel > 0)
        {
            searchResult = searchResult!.Where(r => r.RecipeLevel <= _maxRecipeLevel).ToList();
        }
        else
        {
            searchResult = searchResult!.ToList();
        }

        if (string.IsNullOrWhiteSpace(searchText))
        {
            searchResult!.ForEach(i =>
            {
                _filteredRecipes.Add(i);
            });
        }
        else
        {
            searchResult = searchResult!.Where(i => i.ItemDTO.Name.ToLower().Contains(searchText.ToLower())).ToList();
            searchResult.ForEach(i =>
            {
                _filteredRecipes.Add(i);
            });
        }
    }

    private void SearchButton_Click(object sender, EventArgs e)
    {
        var recipeLevelText = MinRecipeLevelTextBox.Text;
        uint recipeLevel;
        var success = uint.TryParse(recipeLevelText, out recipeLevel);
        if (!success) recipeLevel = 0;
        _minRecipeLevel = recipeLevel;

        recipeLevelText = MaxRecipeLevelTextBox.Text;
        success = uint.TryParse(recipeLevelText, out recipeLevel);
        if (!success) recipeLevel = 0;
        _maxRecipeLevel = recipeLevel;

        RefreshList();
    }
}

public class RecipeSelectedEventArgs : EventArgs
{
    public RecipeDTO? SelectedRecipe { get; set; }
}