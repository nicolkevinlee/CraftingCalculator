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

    private void ItemPickerDidSelectItem(object sender, ItemSelectedEventArgs e)
    {
        _selectedItem = e.SelectedItem;
    }

}


