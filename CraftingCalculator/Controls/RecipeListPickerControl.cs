using CraftingCalculator.Data;
using CraftingCalculator.Models;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;

namespace CraftingCalculator.Controls;

public partial class RecipeListPickerControl : UserControl
{
    private BindingList<RecipeList> _filteredLists;
    private List<RecipeList> _allLists;
    private RecipeList? _selectedList;
    public event EventHandler<RecipeListControlSelectedEventArgs> RecipeListSelected;

    public RecipeListPickerControl()
    {
        _selectedList = null;
        _filteredLists = new BindingList<RecipeList>();
        InitializeComponent();
    }

    public void LoadLists()
    {
        var dbController = new DatabaseController();
        _allLists = dbController.GetAllRecipeLists();
        RefreshList();
        ListGridView.DataSource = _filteredLists;
        ListGridView.ClearSelection();
    }

    private void ListGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedList = _filteredLists[e.RowIndex];
        RecipeListSelected?.Invoke(this, new RecipeListControlSelectedEventArgs()
        {
            SelectedRecipeList = _selectedList
        });
    }

    private void RefreshList()
    {
        var searchText = SearchTextBox.Text.Trim();

        _filteredLists.Clear();

        var searchResult = _allLists;
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            searchResult = searchResult.Where(i => i.Name.ToLower().Contains(searchText.ToLower())).ToList();
            
        }
        searchResult.ForEach(i =>
        {
            _filteredLists.Add(i);
        });
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshList();
    }
}

public class RecipeListControlSelectedEventArgs : EventArgs
{
    public RecipeList? SelectedRecipeList { get; set; }
}
