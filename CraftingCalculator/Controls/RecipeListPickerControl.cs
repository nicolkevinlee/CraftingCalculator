using CraftingCalculator.Data;
using CraftingCalculator.Models;
using System.ComponentModel;
using System.Data;

namespace CraftingCalculator.Controls;

public partial class RecipeListPickerControl : UserControl
{
    private BindingList<RecipeList> _filteredLists;
    private List<RecipeList>? _allLists;
    private RecipeList? _selectedList;
    public event EventHandler<RecipeListControlSelectedEventArgs> RecipeListSelected;

    public RecipeListPickerControl()
    {
        _selectedList = null;
        _allLists = null;
        _filteredLists = new BindingList<RecipeList>();
        InitializeComponent();
    }

    public void LoadLists()
    {
        using (var dbContext = new CraftingDbContext())
        {
            _allLists = dbContext.RecipeLists.ToList();
        }
        RefreshList();
        ListGridView.DataSource = _filteredLists;
        ListGridView.ClearSelection();
    }


    public void DeleteItem(RecipeList recipeListToDelete)
    {
        using (var dbContext = new CraftingDbContext())
        {
            dbContext.RecipeLists.Remove(recipeListToDelete);
            dbContext.RecipeListEntries.RemoveRange(dbContext.RecipeListEntries.Where(l => l.Id == recipeListToDelete.Id));
            dbContext.SaveChanges();
            _allLists = dbContext.RecipeLists.ToList();
        }
        RefreshList();
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

        if (string.IsNullOrWhiteSpace(searchText))
        {
            _allLists!.ForEach(i =>
            {
                _filteredLists.Add(i);
            });
        }
        else
        {
            var searchResult = _allLists!.Where(i => i.Name.ToLower().Contains(searchText.ToLower())).ToList();
            searchResult.ForEach(i =>
            {
                _filteredLists.Add(i);
            });
        }
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
