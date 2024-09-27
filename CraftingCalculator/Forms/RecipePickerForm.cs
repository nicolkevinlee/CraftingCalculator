using CraftingCalculator.Controls;
using CraftingCalculator.Data;
using CraftingCalculator.Models;

namespace CraftingCalculator.Forms
{
    public partial class RecipePickerForm : Form
    {
        private Recipe? _selectedRecipe;

        public event EventHandler<RecipeAddedEventArgs> RecipeAdded;

        public RecipePickerForm()
        {
            _selectedRecipe = null;
            InitializeComponent();
            RecipePicker.RecipeSelected += RecipePickerControlDidSelectRecipe;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string countText = CraftCountTextBox.Text;
            uint count = 0;
            var success = uint.TryParse(countText, out count);

            if (success && count > 0 && _selectedRecipe != null)
            {
                if (_selectedRecipe.Ingredients == null)
                {
                    var dbController = new DatabaseController();
                    _selectedRecipe.Ingredients = dbController.GetRecipeIngredients(_selectedRecipe.Id);
                }

                RecipeAdded?.Invoke(this, new RecipeAddedEventArgs()
                {
                    Count = count,
                    SelectedRecipe = _selectedRecipe
                });
            }
        }

        private void RecipePickerControlDidSelectRecipe(Object sender, RecipeSelectedEventArgs e)
        {
            _selectedRecipe = e.SelectedRecipe;
        }
    }
}

public class RecipeAddedEventArgs : EventArgs
{
    public uint Count { get; set; }
    public Recipe? SelectedRecipe { get; set; }
}
