using CraftingCalculator.Data;
using CraftingCalculator.Models;
using System.ComponentModel;
using System.Data;

namespace CraftingCalculator.Controls;

public partial class ItemPickerControl : UserControl
{
    private BindingList<Item> _filteredItems;
    private List<Item>? _allItems;
    private Item? _selectedItem;
    public event EventHandler<ItemSelectedEventArgs> ItemSelected;
    public ItemPickerControl()
    {
        _selectedItem = null;
        _allItems = null;
        _filteredItems = new BindingList<Item>();
        InitializeComponent();
    }
    
    public void LoadItems()
    {
        using (var dbContext = new CraftingDbContext())
        {
            _allItems = dbContext.Items.ToList();
        }
        RefreshList();
        ItemsGridView.DataSource = _filteredItems;
    }

    public void DeleteItem(Item itemToDelete)
    {
        using (var dbContext = new CraftingDbContext())
        {
            dbContext.Items.Remove(itemToDelete);
            dbContext.SaveChanges();
            _allItems = dbContext.Items.ToList();
        }
        RefreshList();
    }
    
    private void ItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedItem = _filteredItems[e.RowIndex];
        ItemSelected?.Invoke(this, new ItemSelectedEventArgs()
        {
            SelectedItem = _selectedItem
        });
    }

    private void RefreshList()
    {
        var searchText = SearchTextBox.Text.Trim();

        _filteredItems.Clear();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            _allItems!.ForEach(i =>
            {
                _filteredItems.Add(i);
            });
        }
        else
        {
            var searchResult = _allItems!.Where(i => i.Name.ToLower().Contains(searchText.ToLower())).ToList();
            searchResult.ForEach(i =>
            {
                _filteredItems.Add(i);
            });
        }
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshList();
    }
}

public class ItemSelectedEventArgs : EventArgs
{
    public Item? SelectedItem { get; set; }
}