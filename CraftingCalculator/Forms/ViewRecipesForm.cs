using CraftingCalculator.Controls;
using CraftingCalculator.Data;
using CraftingCalculator.Models;

namespace CraftingCalculator.Forms;

public partial class ViewRecipesForm : Form
{
    private Recipe? _selectedRecipe;
    public ViewRecipesForm()
    {
        _selectedRecipe = null;
        InitializeComponent();
        RecipePicker.RecipeSelected += RecipePickerDidSelectIRecipe;
    }

    private void RecipePickerDidSelectIRecipe(object sender, RecipeSelectedEventArgs e)
    {
        _selectedRecipe = e.SelectedRecipe;
    }

    private void ViewButton_Click(object sender, EventArgs e)
    {

        if (_selectedRecipe == null) return;

        if(_selectedRecipe.Ingredients == null)
        {
            var dbController = new DatabaseController();
            _selectedRecipe.Ingredients = dbController.GetRecipeIngredients(_selectedRecipe.Id);
        }

        var viewSingleRecipeForm = new ViewSingleRecipeForm(_selectedRecipe);
        viewSingleRecipeForm.ShowDialog();
    }
}
