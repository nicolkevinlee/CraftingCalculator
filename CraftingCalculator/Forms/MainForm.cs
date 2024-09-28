using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CraftingCalculator.Forms;

public partial class MainForm : Form
{
    private BindingList<RecipeListEntry> _recipeListEntries;
    private BindingList<RecipeListEntry> _subRecipeEntries;
    private BindingList<TotalIngredient> _totalIngredients;
    private BindingList<TotalCrystals> _totalShards;

    private RecipeListEntry? _selectedRecipeListEntry;
    private RecipeList? _currentRecipeList;

    public MainForm()
    {
        _selectedRecipeListEntry = null;
        _currentRecipeList = null;
        _recipeListEntries = new BindingList<RecipeListEntry>();
        _subRecipeEntries = new BindingList<RecipeListEntry>();
        _totalIngredients = new BindingList<TotalIngredient>();
        _totalShards = new BindingList<TotalCrystals>();

        InitializeComponent();

        RecipeListEntryGridView.DataSource = _recipeListEntries;
        SubRecipeListGridView.DataSource = _subRecipeEntries;
        TotalIngredientsListView.DataSource = _totalIngredients;
        TotalShardsGridView.DataSource = _totalShards;
    }

    private void importToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var importForm = new ImportForm();
        importForm.ShowDialog();
    }

    private void addToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var viewItemsForm = new ViewItemsForm();
        viewItemsForm.ShowDialog();
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var viewRecipesForm = new ViewRecipesForm();
        viewRecipesForm.ShowDialog();
    }

    private void RecipeAdded(object sender, RecipeAddedEventArgs e)
    {
        if (e.SelectedRecipe == null) return;

        var recipeListEntry = _recipeListEntries.FirstOrDefault(r => r.RecipeId == e.SelectedRecipe.Id);

        if (recipeListEntry == null)
        {
            recipeListEntry = CreateNewRecipeListEntry(_currentRecipeList, e.SelectedRecipe, e.Count);
            _recipeListEntries.Add(recipeListEntry);
        }
        else
        {
            recipeListEntry.Count += e.Count;
        }

        RecipeListEntryGridView.Update();
        RecipeListEntryGridView.Refresh();

        GetTotalIngredients();
    }

    private RecipeListEntry CreateNewRecipeListEntry(RecipeList? recipeList, Recipe recipe, uint count)
    {
        var recipeListEntry = new RecipeListEntry
        {
            Id = 0,
            RecipeListId = (recipeList != null) ? recipeList.Id : 0,
            RecipeList = recipeList ?? null,
            RecipeId = recipe.Id,
            Recipe = recipe,
            Count = count
        };

        return recipeListEntry;
    }

    private void GetTotalIngredients()
    {

        var calculator = new CraftCalculator();
        var result = calculator.CalculateTotalIngredients(_recipeListEntries.ToList());

        _subRecipeEntries.Clear();
        _totalIngredients.Clear();
        _totalShards.Clear();

        _subRecipeEntries = new BindingList<RecipeListEntry>(result.SubRecipeListEntries);
        _totalIngredients = new BindingList<TotalIngredient>(result.TotalIngredients);
        _totalShards = new BindingList<TotalCrystals>(result.TotalShards);

        SubRecipeListGridView.DataSource = _subRecipeEntries;
        TotalIngredientsListView.DataSource = _totalIngredients;
        TotalShardsGridView.DataSource = _totalShards;

        TotalShardsGridView.Refresh();

    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        var recipePickerForm = new RecipePickerForm();
        recipePickerForm.RecipeAdded += RecipeAdded;
        recipePickerForm.ShowDialog();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        RecipeListEntryGridView.ClearSelection();
        SubRecipeListGridView.ClearSelection();
        TotalIngredientsListView.ClearSelection();
        TotalShardsGridView.ClearSelection();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        
        if(_currentRecipeList == null)
        {
            SaveNewRecipeList();
        }
        else
        {
            OverwriteRecipeList();
        }

    }

    private void SaveNewRecipeList()
    {

        var listName = ListNameTextBox.Text.Trim();

        if (string.IsNullOrEmpty(listName) || _recipeListEntries.Count == 0)
        {
            return;
        }

        var dbController = new DatabaseController();
        var result = dbController.SaveNewRecipeList(listName, _recipeListEntries.ToList());

        if(result != null)
        {
            _currentRecipeList = result.Value.Item1;
            _recipeListEntries.Clear();
            _recipeListEntries = new BindingList<RecipeListEntry>(result.Value.Item2);
            RecipeListEntryGridView.DataSource = _recipeListEntries;
        }

    }

    private void OverwriteRecipeList()
    {
        if (_currentRecipeList == null) return;

        var listName = ListNameTextBox.Text.Trim();

        if (string.IsNullOrEmpty(listName) || _recipeListEntries.Count == 0)
        {
            return;
        }


        var dbController = new DatabaseController();
        var result = dbController.UpdateRecipeList(_currentRecipeList.Id, listName, _recipeListEntries.ToList());

        if (result)
        {
            _currentRecipeList.Name = listName;
        }

    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        var listSelectorForm = new ListSelectorForm();
        listSelectorForm.ListSelected += RecipeListSelected;
        listSelectorForm.ShowDialog();
    }

    private void GridView_SelectionChanged(object sender, EventArgs e)
    {
        DataGridView datagridView = (DataGridView)sender;
        datagridView.ClearSelection();
    }

    private void RecipeListEntryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _selectedRecipeListEntry = _recipeListEntries[e.RowIndex];
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (_selectedRecipeListEntry == null) return;

        DialogResult toRemove = MessageBox.Show($"Remove {_selectedRecipeListEntry.Recipe}?", "Warning", MessageBoxButtons.YesNo);

        if (toRemove == DialogResult.Yes)
        {
            _recipeListEntries.Remove( _selectedRecipeListEntry );
            _selectedRecipeListEntry = null;
            RecipeListEntryGridView.ClearSelection();
            GetTotalIngredients();
        }
    }

    private void RecipeListSelected(object sender, RecipeListSelectedEventArgs e)
    {
        _currentRecipeList = e.SelectedRecipeList;
        ListNameTextBox.Text = _currentRecipeList.Name;

        _recipeListEntries.Clear();

        var dbController = new DatabaseController();
        var entries = dbController.GetRecipeListEntries(_currentRecipeList.Id);
        if (entries != null)
        {
            _recipeListEntries = new BindingList<RecipeListEntry>(entries);
            RecipeListEntryGridView.DataSource = _recipeListEntries;
        }

        RecipeListEntryGridView.Update();
        RecipeListEntryGridView.Refresh();

        GetTotalIngredients();
        RecipeListEntryGridView.ClearSelection();
    }
}
