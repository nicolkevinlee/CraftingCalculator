using CraftingCalculator.Controls;
using CraftingCalculator.Models;
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
    public partial class ListSelectorForm : Form
    {
        private RecipeList? _selectedRecipeList;
        public event EventHandler<RecipeListSelectedEventArgs> ListSelected;
        public ListSelectorForm()
        {
            _selectedRecipeList = null;
            InitializeComponent();
        }

        private void ListSelectorForm_Load(object sender, EventArgs e)
        {
            RecipeListControl.LoadLists();
        }

        private void RecipeListSelected(object sender, RecipeListSelectedEventArgs e)
        {
            _selectedRecipeList = e.SelectedRecipeList;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (_selectedRecipeList == null) return;
            ListSelected?.Invoke(this, new RecipeListSelectedEventArgs()
            {
                SelectedRecipeList = _selectedRecipeList
            });
            Close();
        }
    }
}

public class RecipeListSelectedEventArgs : EventArgs
{
    public RecipeList? SelectedRecipeList { get; set; }
}
