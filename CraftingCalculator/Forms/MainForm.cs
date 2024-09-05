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


        using (var dbContext = new CraftingDbContext())
        {
            foreach (var recipeEntry in _recipeListEntries)
            {
                var recipe = recipeEntry.RecipeDTO;
                var ingredients = recipeEntry.RecipeDTO.Ingredients;
                var totalCount = (decimal)recipeEntry.Count;
                var yield = (decimal)recipe.Yield;
                var numberOfCrafts = (ushort)Math.Ceiling(totalCount / yield);

                foreach (var ingredient in ingredients)
                {
                    var recipeDTO = GetRecipe(dbContext, ingredient.ItemDTO.Id);
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
                    var recipeDTO = GetRecipe(dbContext, ingredient.ItemDTO.Id);
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
                    var recipeDTO = GetRecipe(dbContext, ingredient.ItemDTO.Id);
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
    }

    private RecipeDTO? GetRecipe(CraftingDbContext dbContext, uint itemId)
    {
        var recipe = dbContext.Recipes.Include(r => r.CraftType).Include(r => r.Item).Include(r => r.Ingredients).FirstOrDefault(r => r.ItemId == itemId);
        if (recipe == null) return null;

        var recipeDTO = new RecipeDTO
        {
            Id = recipe.Id,
            Yield = recipe.Yield,
            CraftTypeDTO = new CraftTypeDTO
            {
                Id = recipe.CraftTypeId,
                Name = recipe.CraftType.Name,
            },
            ItemDTO = new ItemDTO
            {
                Id = recipe.ItemId,
                Name = recipe.Item.Name
            }
        };
        var ingredients = new IngredientDTO[recipe.Ingredients.Count];

        for (int i = 0; i < recipe.Ingredients.Count; i++)
        {
            var ingredient = recipe.Ingredients.ElementAt(i);
            var item = dbContext.Items.First(i => i.Id == ingredient.ItemId);
            ingredients[i] = new IngredientDTO
            {
                Id = ingredient.Id,
                ItemDTO = new ItemDTO
                {
                    Id = ingredient.ItemId,
                    Name = item.Name
                },
                RecipeDTO = recipeDTO,
                Count = ingredient.Count
            };
        }

        recipeDTO.Ingredients = ingredients;

        return recipeDTO;
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

        RecipeList recipeList = new RecipeList
        {
            Name = listName
        };

        List<RecipeListEntry> entries = _recipeListEntries.Select(e => (RecipeListEntry)e).ToList();

        using (var dbContext = new CraftingDbContext())
        {
            dbContext.RecipeLists.Add(recipeList);
            dbContext.SaveChanges();

            foreach (var entry in entries)
            {
                entry.RecipeListId = recipeList.Id;
                dbContext.RecipeListEntries.Add(entry);
            }
            dbContext.SaveChanges();
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

        _currentRecipeListDTO.Name = listName;

        using (var dbContext = new CraftingDbContext())
        {
            var currentEntries = dbContext.RecipeListEntries.Where(e => e.RecipeListId == _currentRecipeListDTO.Id).ToList();

            var toUpdate = currentEntries.Where(e => _recipeListEntries.Any(f => f.Id == e.Id)).ToList();
            var toDelete = currentEntries.Where(e => !_recipeListEntries.Any(f => f.Id == e.Id)).ToList();

            if (toUpdate != null && toUpdate.Count() > 0)
            {
                dbContext.RecipeListEntries.UpdateRange(toUpdate);
                dbContext.SaveChanges();
            }
            if (toDelete != null && toDelete.Count() > 0)
            {
                dbContext.RecipeListEntries.RemoveRange(toDelete);
                dbContext.SaveChanges();
            }

            List<RecipeListEntry> toAdd = _recipeListEntries.Select(e => (RecipeListEntry)e).ToList();
            if (toUpdate != null)
            {
                toAdd = toAdd.Where(e => !toUpdate.Any(f => f.Id == e.Id)).Select(e =>
                    new RecipeListEntry
                    {
                        Id = e.Id,
                        Count = e.Count,
                        RecipeId = e.RecipeId,
                        RecipeListId = e.RecipeListId
                    }).ToList();
            }

            if(toAdd != null && toAdd.Count > 0)
            {
                dbContext.RecipeListEntries.AddRange(toAdd);
                dbContext.SaveChanges();
            }

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

        _recipeListEntries.Clear();

        using (var dbContext = new CraftingDbContext())
        {
            var recipeListEntryDTOs = dbContext.RecipeListEntries.Where(e => e.RecipeListId == _currentRecipeListDTO.Id)
                .Include(e => e.RecipeList)
                .Include(e => e.Recipe)
                .Include(e => e.Recipe.CraftType)
                .Include(e => e.Recipe.Item).ToList().Select(e=>(RecipeListEntryDTO)e);

            foreach (var entry in recipeListEntryDTOs)
            {
                var ingredients = dbContext.Ingredients.Where(i => i.RecipeId == entry.RecipeDTO.Id)
                    .Include(i => i.Recipe)
                    .Include(i => i.Item)
                    .Select(i => (IngredientDTO)i).ToList();
                entry.RecipeDTO.Ingredients = ingredients;
                _recipeListEntries.Add(entry);
            }

        }
        ListNameTextBox.Text = _currentRecipeListDTO.Name;

        RecipeListEntryGridView.Update();
        RecipeListEntryGridView.Refresh();

        CalculateTotalIngredients();
    }
}
