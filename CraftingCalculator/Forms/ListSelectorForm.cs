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
        public ListSelectorForm()
        {
            InitializeComponent();
        }

        private void ListSelectorForm_Load(object sender, EventArgs e)
        {
            RecipeListControl.LoadLists();
        }
    }
}
