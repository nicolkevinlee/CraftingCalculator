using CraftingCalculator.Controls;
using CraftingCalculator.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftingCalculator.Forms
{
    public partial class RecipePickerForm : Form
    {
        private RecipeDTO? _selectedRecipe;

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
    public RecipeDTO SelectedRecipe { get; set; }
}
