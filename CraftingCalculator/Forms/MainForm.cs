using CraftingCalculator.Data;
using CraftingCalculator.DataAccessor;

namespace CraftingCalculator.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
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
}
