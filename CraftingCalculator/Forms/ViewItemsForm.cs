using CraftingCalculator.Controls;
using CraftingCalculator.Models;

namespace CraftingCalculator.Forms;

public partial class ViewItemsForm : Form
{
    private Item? _selectedItem;
    public ViewItemsForm()
    {
        _selectedItem = null;
        InitializeComponent();
        ItemPicker.ItemSelected += ItemPickerDidSelectItem;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        var addItemForm = new AddItemForm();
        addItemForm.ShowDialog();
    }

    private void ItemPickerDidSelectItem(object sender, ItemSelectedEventArgs e)
    {
        _selectedItem = e.SelectedItem;
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (_selectedItem == null) return;

        DialogResult result = MessageBox.Show($"Delete {_selectedItem.Name}?", "Warning", MessageBoxButtons.YesNo);

        if (result == DialogResult.Yes)
        {
            ItemPicker.DeleteItem( _selectedItem );

            MessageBox.Show($"Item, {_selectedItem.Name}, has been deleted");
            _selectedItem = null;

        }
    }

}


