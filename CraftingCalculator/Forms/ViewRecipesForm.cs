using CraftingCalculator.Controls;
using CraftingCalculator.DTOs;

namespace CraftingCalculator.Forms;

public partial class ViewRecipesForm : Form
{
    private RecipeDTO? _selectedRecipe;
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

        var viewSingleRecipeForm = new ViewSingleRecipeForm(_selectedRecipe);
        viewSingleRecipeForm.ShowDialog();
    }
}
