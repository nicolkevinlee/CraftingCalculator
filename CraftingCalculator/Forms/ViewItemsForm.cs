using CraftingCalculator.Data;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CraftingCalculator.Forms;


public partial class ViewItemsForm : Form
{
    private BindingList<Item> _filteredItems;
    private List<Item>? _allItems;
    private Item? _selectedItem;
    public ViewItemsForm()
    {
        _selectedItem = null;
        _allItems = null;
        _filteredItems = new BindingList<Item>();
        InitializeComponent();
    }

    private void ViewItemsForm_Load(object sender, EventArgs e)
    {
        using (var dbContext = new CraftingDbContext())
        {
            _allItems = dbContext.Items.ToList();
        }
        _filteredItems = new BindingList<Item>(_allItems.ToList());
        ItemsGridView.DataSource = _filteredItems;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        var addItemForm = new AddItemForm();
        addItemForm.ShowDialog();
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (_selectedItem == null) return;

        DialogResult result = MessageBox.Show($"Delete {_selectedItem.Name}?", "Warning", MessageBoxButtons.YesNo);

        if (result == DialogResult.Yes)
        {
            _filteredItems.Remove(_selectedItem);
            _allItems.Remove(_selectedItem);
            using (var dbContext = new CraftingDbContext())
            {
                dbContext.Items.Remove(_selectedItem);
                dbContext.SaveChanges();
            }
            _selectedItem = null;
        }
    }

    private void ItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedItem = _filteredItems[e.RowIndex] as Item;
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
        var searchText = SearchBox.Text.Trim();

        _filteredItems.Clear();

        if(string.IsNullOrWhiteSpace(searchText))
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
}


