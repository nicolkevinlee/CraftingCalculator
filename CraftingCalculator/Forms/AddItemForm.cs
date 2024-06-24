using CraftingCalculator.Data;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class AddItemForm : Form
    {
        public AddItemForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false);

            var itemName = ItemNameTextBox.Text;

            itemName = itemName.Trim();
            if (string.IsNullOrEmpty(itemName))
            {
                MessageBox.Show("No Item Name Entered");
                SetButtonsEnabled(true);
                return;
            }


            using(var dbContext = new CraftingDbContext())
            {
                if(dbContext.Items.AnyAsync(x => x.Name == itemName).Result)
                {
                    MessageBox.Show("Item Name already exists.");
                    SetButtonsEnabled(true);
                    return;
                }

                dbContext.Items.AddAsync(new Item { Name = itemName });
                dbContext.SaveChangesAsync();

                MessageBox.Show("Item Added.");
                SetButtonsEnabled(true);
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            CloseButton.Enabled = enabled;
            AddButton.Enabled = enabled;
        }
    }
}
