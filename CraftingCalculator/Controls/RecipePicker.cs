using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using System.ComponentModel;

namespace CraftingCalculator.Controls;

public partial class RecipePicker : UserControl
{
    private BindingList<RecipeDTO> _filteredRecipes;
    private RecipeDTO? _selectedRecipe;
    private uint _minRecipeLevel;
    private uint _maxRecipeLevel;
    public event EventHandler<RecipeSelectedEventArgs> RecipeSelected;

    public RecipePicker()
    {
        _selectedRecipe = null;
        _filteredRecipes = new BindingList<RecipeDTO>();
        _minRecipeLevel = 0;
        _maxRecipeLevel = 0;
        InitializeComponent();
        RecipedGridView.DataSource = _filteredRecipes;
    }
    public void LoadRecipes()
    {
        SearchRecipe();
    }

    public void DeleteRecipe(RecipeDTO recipe)
    {
        var dbController = new DatabaseController();
        if (dbController.DeleteRecipe(recipe.Id))
        {
            _filteredRecipes.Remove(recipe);
        }
    }

    private void RecipeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedRecipe = _filteredRecipes[e.RowIndex];
        RecipeSelected?.Invoke(this, new RecipeSelectedEventArgs()
        {
            SelectedRecipe = _selectedRecipe
        });
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

        SearchRecipe();
    }

    private void SearchRecipe()
    {
        var searchText = SearchTextBox.Text.Trim();

        _filteredRecipes.Clear();

        var dbController = new DatabaseController();
        List<RecipeDTO> searchResult = dbController.SearchRecipes(_minRecipeLevel, _maxRecipeLevel, searchText);
        searchResult.ForEach(i =>
        {
            _filteredRecipes.Add(i);
        });
    }
}

public class RecipeSelectedEventArgs : EventArgs
{
    public RecipeDTO? SelectedRecipe { get; set; }
}