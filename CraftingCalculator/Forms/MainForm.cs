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

    private void itemToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var addItemForm = new AddItemForm();
        addItemForm.ShowDialog();
    }
}
