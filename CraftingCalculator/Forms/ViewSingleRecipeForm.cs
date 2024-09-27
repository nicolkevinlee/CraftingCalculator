using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using System.ComponentModel;
using System.Data;

namespace CraftingCalculator.Forms
{
    public partial class ViewSingleRecipeForm : Form
    {
        public ViewSingleRecipeForm(Recipe recipe)
        {
            InitializeComponent();
            ItemNameLabel.Text = recipe.Item.Name;
            RecipeLevelLabel.Text = $"{recipe.RecipeLevel}";
            YieldLabel.Text = $"{recipe.Yield}";
            CraftTypeLabel.Text = recipe.CraftType.Name;

            IngredientsDataGrid.DataSource = new BindingList<Ingredient>(recipe.Ingredients.ToList());
        }
    }
}
