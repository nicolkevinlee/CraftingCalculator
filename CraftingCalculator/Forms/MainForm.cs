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
            recipeListEntry = new RecipeListEntryDTO
            {
                Id = 0,
                RecipeListDTO = (_currentRecipeListDTO != null)? _currentRecipeListDTO : null,
                RecipeDTO = e.SelectedRecipe,
                Count = e.Count
            };

            using (var dbContext = new CraftingDbContext())
            {
                var ingredients = dbContext.Ingredients.Include(i=>i.Recipe)
                                                       .Include(i=>i.Item)
                                                       .Where(i => i.RecipeId == recipeListEntry.RecipeDTO.Id)
                                                       .Select(i => (IngredientDTO)i).ToList();
                recipeListEntry.RecipeDTO.Ingredients = ingredients;
            }

            _recipeListEntries.Add(recipeListEntry);
        }
        else
        {
            recipeListEntry.Count += e.Count;
        }

        RecipeListEntryGridView.Update();
        RecipeListEntryGridView.Refresh();

        CalculateTotalIngredients();
    }

    private void CalculateTotalIngredients()
    {
        _totalIngredients.Clear();
        _subRecipeEntries.Clear();

        foreach (var totalShard in _totalShards)
        {
            totalShard.Clear();
        }

        var dbController = new DatabaseController();

        foreach (var recipeEntry in _recipeListEntries)
        {
            var recipe = recipeEntry.RecipeDTO;
            var ingredients = recipeEntry.RecipeDTO.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.ItemDTO.Id);
                if (recipeDTO == null)
                {
                    var totalIngredient = _totalIngredients.FirstOrDefault(i => i.ItemDTO.Id == ingredient.ItemDTO.Id);
                    if (totalIngredient == null)
                    {
                        totalIngredient = new TotalIngredient
                        {
                            Id = ingredient.Id,
                            ItemDTO = ingredient.ItemDTO,
                            Count = 0
                        };
                        _totalIngredients.Add(totalIngredient);
                    }
                    totalIngredient.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
                else
                {
                    var subRecipeEntry = _subRecipeEntries.FirstOrDefault(r => r.RecipeDTO.Id == recipeDTO.Id);
                    if (subRecipeEntry == null)
                    {
                        subRecipeEntry = new RecipeListEntryDTO
                        {
                            Id = 0,
                            RecipeDTO = recipeDTO,
                            Count = 0
                        };
                        _subRecipeEntries.Add(subRecipeEntry);
                    }
                    subRecipeEntry.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        for (int i = 0; i < _subRecipeEntries.Count; i++)
        {
            var recipeEntry = _subRecipeEntries[i];
            var recipe = recipeEntry.RecipeDTO;
            var ingredients = recipeEntry.RecipeDTO.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.ItemDTO.Id);
                if (recipeDTO != null)
                {
                    var subRecipeEntry = _subRecipeEntries.FirstOrDefault(r => r.RecipeDTO.Id == recipeDTO.Id);
                    if (subRecipeEntry == null)
                    {
                        subRecipeEntry = new RecipeListEntryDTO
                        {
                            Id = 0,
                            RecipeDTO = recipeDTO,
                            Count = 0
                        };
                        _subRecipeEntries.Add(subRecipeEntry);
                    }
                    subRecipeEntry.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        for (int i = 0; i < _subRecipeEntries.Count; i++)
        {
            var recipeEntry = _subRecipeEntries[i];
            var recipe = recipeEntry.RecipeDTO;
            var ingredients = recipeEntry.RecipeDTO.Ingredients;
            var totalCount = (decimal)recipeEntry.Count;
            var yield = (decimal)recipe.Yield;
            var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

            foreach (var ingredient in ingredients)
            {
                var recipeDTO = dbController.GetRecipe(ingredient.ItemDTO.Id);
                if (recipeDTO == null)
                {
                    var totalIngredient = _totalIngredients.FirstOrDefault(i => i.ItemDTO.Id == ingredient.ItemDTO.Id);
                    if (totalIngredient == null)
                    {
                        totalIngredient = new TotalIngredient
                        {
                            Id = ingredient.Id,
                            ItemDTO = ingredient.ItemDTO,
                            Count = 0
                        };
                        _totalIngredients.Add(totalIngredient);
                    }
                    totalIngredient.Count += (ushort)(numberOfCrafts * ingredient.Count);
                }
            }
        }

        var shards = _totalIngredients.Where(i => _shardIds.Contains(i.ItemDTO.Id)).ToList();

        foreach (var item in shards)
        {
            _totalIngredients.Remove(item);
            foreach (var totalShard in _totalShards)
            {
                totalShard.SetShardCount(item);
            }
        }
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

    //Move to Controller
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

    //Move to Controller
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
            CalculateTotalIngredients();
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

        CalculateTotalIngredients();
    }
}
