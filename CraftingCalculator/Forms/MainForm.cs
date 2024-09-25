using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CraftingCalculator.Forms;

public partial class MainForm : Form
{
    private static readonly uint[] _shardIds = { 4, 1395, 1427, 7, 1400, 1430, 231, 1455, 1487, 357, 1515, 1538, 508, 1597, 1628, 975, 1758, 1771 };

    private BindingList<RecipeListEntryDTO> _recipeListEntries;
    private BindingList<RecipeListEntryDTO> _subRecipeEntries;
    private BindingList<TotalIngredient> _totalIngredients;
    private BindingList<TotalShards> _totalShards;

    private RecipeListEntryDTO? _selectedRecipeListEntryDTO;
    private RecipeListDTO? _currentRecipeListDTO;

    public MainForm()
    {
        _selectedRecipeListEntryDTO = null;
        _currentRecipeListDTO = null;
        _recipeListEntries = new BindingList<RecipeListEntryDTO>();
        _subRecipeEntries = new BindingList<RecipeListEntryDTO>();
        _totalIngredients = new BindingList<TotalIngredient>();
        _totalShards = new BindingList<TotalShards>();

        for (int i = 0; i < 3; i++)
        {
            _totalShards.Add(new TotalShards(i));
        }

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
        var recipeListEntry = _recipeListEntries.FirstOrDefault(r => r.RecipeDTO.Id == e.SelectedRecipe.Id);

        if (recipeListEntry == null)
        {
            recipeListEntry = CreateNewRecipeListEntry(_currentRecipeListDTO, e.SelectedRecipe, e.Count);
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

    private RecipeListEntryDTO CreateNewRecipeListEntry(RecipeListDTO? recipeListDTO, RecipeDTO recipeDTO, uint count)
    {
        var recipeListEntry = new RecipeListEntryDTO
        {
            Id = 0,
            RecipeListDTO = recipeListDTO ?? null,
            RecipeDTO = recipeDTO,
            Count = count
        };
        var dbController = new DatabaseController();
        var ingredients = dbController.GetRecipeIngredients(recipeDTO.Id);
        recipeListEntry.RecipeDTO.Ingredients = ingredients;

        return recipeListEntry;
    }

    private void GetTotalIngredients()
    {

        var calculator = new CraftCalculator();
        var result = calculator.CalculateTotalIngredients(_recipeListEntries.ToList());

        _subRecipeEntries.Clear();
        _totalIngredients.Clear();
        _totalShards.Clear();

        _subRecipeEntries = new BindingList<RecipeListEntryDTO>(result.SubRecipeListEntries);
        _totalIngredients = new BindingList<TotalIngredient>(result.TotalIngredients);
        _totalShards = new BindingList<TotalShards>(result.TotalShards);

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
        
        if(_currentRecipeListDTO == null)
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
            _currentRecipeListDTO = result.Value.Item1;
            _recipeListEntries.Clear();
            _recipeListEntries = new BindingList<RecipeListEntryDTO>(result.Value.Item2);
            RecipeListEntryGridView.DataSource = _recipeListEntries;
        }

    }

    private void OverwriteRecipeList()
    {
        if (_currentRecipeListDTO == null) return;

        var listName = ListNameTextBox.Text.Trim();

        if (string.IsNullOrEmpty(listName) || _recipeListEntries.Count == 0)
        {
            return;
        }


        var dbController = new DatabaseController();
        var result = dbController.UpdateRecipeList(_currentRecipeListDTO.Id, listName, _recipeListEntries.ToList());

        if (result)
        {
            _currentRecipeListDTO.Name = listName;
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
        _selectedRecipeListEntryDTO = _recipeListEntries[e.RowIndex];
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (_selectedRecipeListEntryDTO == null) return;

        DialogResult toRemove = MessageBox.Show($"Remove {_selectedRecipeListEntryDTO.RecipeDTO.ItemDTO.Name}?", "Warning", MessageBoxButtons.YesNo);

        if (toRemove == DialogResult.Yes)
        {
            _recipeListEntries.Remove( _selectedRecipeListEntryDTO );
            _selectedRecipeListEntryDTO = null;
            RecipeListEntryGridView.ClearSelection();
            GetTotalIngredients();
        }
    }

    private void RecipeListSelected(object sender, RecipeListSelectedEventArgs e)
    {
        _currentRecipeListDTO = (RecipeListDTO)e.SelectedRecipeList!;
        ListNameTextBox.Text = _currentRecipeListDTO.Name;

        _recipeListEntries.Clear();

        var dbController = new DatabaseController();
        var entries = dbController.GetRecipeListEntries(_currentRecipeListDTO.Id);
        if (entries != null)
        {
            _recipeListEntries = new BindingList<RecipeListEntryDTO>(entries);
            RecipeListEntryGridView.DataSource = _recipeListEntries;
        }

        RecipeListEntryGridView.Update();
        RecipeListEntryGridView.Refresh();

        GetTotalIngredients();
    }
}
