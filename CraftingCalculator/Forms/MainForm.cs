using CraftingCalculator.Data;
using CraftingCalculator.DataAccessor;

namespace CraftingCalculator.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var csvDataAccessor = new CSVDataAccessor();
        var recipeImporter = new RecipeImporter();
        var csvData = csvDataAccessor.Read("Recipes.csv");
        recipeImporter.ImportRecipesToDb(csvData);

    }
}
