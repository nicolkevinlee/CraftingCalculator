using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using CraftingCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftingCalculator.Forms;

public partial class ViewRecipesForm : Form
{
    private BindingList<RecipeDTO> _filteredRecipes;
    private List<RecipeDTO>? _allRecipes;
    private Recipe? _selectedRecipe;
    public ViewRecipesForm()
    {
        _selectedRecipe = null;
        _allRecipes = null;
        _filteredRecipes = new BindingList<RecipeDTO>();
        InitializeComponent();
    }
    private void ViewRecipesForm_Load(object sender, EventArgs e)
    {
        using (var dbContext = new CraftingDbContext())
        {
            _allRecipes = dbContext.Recipes.OrderBy(r => r.Id).Select(r =>
                new RecipeDTO{
                    Id = r.Id,
                    Yield = r.Yield,
                    CraftTypeDTO = new CraftTypeDTO()
                    {
                        Id = r.CraftTypeId,
                        Name = r.CraftType.Name
                    },
                    ItemDTO = new ItemDTO()
                    {
                        Id = r.ItemId,
                        Name = r.Item.Name
                    }
                }
            ).ToList();
        }
        _filteredRecipes = new BindingList<RecipeDTO>(_allRecipes.ToList());
        RecipesGridView.DataSource = _filteredRecipes;
    }

    private void RecipesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }

}
