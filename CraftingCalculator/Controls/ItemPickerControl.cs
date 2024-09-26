using CraftingCalculator.Data;
using CraftingCalculator.Models;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;

namespace CraftingCalculator.Controls;

public partial class ItemPickerControl : UserControl
{
    private BindingList<Item> _filteredItems;
    private Item? _selectedItem;
    public event EventHandler<ItemSelectedEventArgs> ItemSelected;
    public ItemPickerControl()
    {
        _selectedItem = null;
        _filteredItems = new BindingList<Item>();
        InitializeComponent();
        ItemsGridView.DataSource = _filteredItems;
    }

    public void DeleteItem(Item itemToDelete)
    {
        var dbController = new DatabaseController();
        var success = dbController.DeleteItem(itemToDelete);
        if(success)
        {
            _filteredItems.Remove(itemToDelete);
        }
    }

    private void ItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedItem = _filteredItems[e.RowIndex];
        ItemSelected?.Invoke(this, new ItemSelectedEventArgs()
        {
            SelectedItem = _selectedItem
        });
    }

    private void SearchItem()
    {
        var searchText = SearchTextBox.Text.Trim();

        _filteredItems.Clear();

        var dbController = new DatabaseController();
        var searchResult = dbController.SearchItems(searchText);
        searchResult.ForEach(i =>
        {
            _filteredItems.Add(i);
        });
    }

    private void SearchButton_Click(object sender, EventArgs e)
    {
        SearchItem();
    }
}

public class ItemSelectedEventArgs : EventArgs
{
    public Item? SelectedItem { get; set; }
}