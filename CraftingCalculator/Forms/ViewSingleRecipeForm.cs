using CraftingCalculator.Data;
using CraftingCalculator.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftingCalculator.Forms
{
    public partial class ViewSingleRecipeForm : Form
    {
        public ViewSingleRecipeForm(RecipeDTO recipeDTO)
        {
            InitializeComponent();
            ItemNameLabel.Text = recipeDTO.ItemDTO.Name;
            RecipeLevelLabel.Text = $"{recipeDTO.RecipeLevel}";
            YieldLabel.Text = $"{recipeDTO.Yield}";
            CraftTypeLabel.Text = recipeDTO.CraftTypeDTO.Name;
            LoadIngredients(recipeDTO);
        }

        private void LoadIngredients(RecipeDTO recipeDTO)
        {
            using(var dbContext = new CraftingDbContext())
            {
                var ingredients = dbContext.Ingredients.Where(i => i.RecipeId == recipeDTO.Id).Select(i => new IngredientDTO
                {
                    Id = i.Id,
                    RecipeDTO = recipeDTO,
                    ItemDTO = new ItemDTO
                    {
                        Id = i.Item.Id,
                        Name = i.Item.Name,
                    },
                    Count = i.Count
                }).ToList();

                IngredientsDataGrid.DataSource = new BindingList<IngredientDTO>(ingredients);
            }
        }
    }
}
