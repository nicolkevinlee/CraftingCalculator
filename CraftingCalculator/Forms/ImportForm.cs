using CraftingCalculator.Data;
using CraftingCalculator.DataAccessor;

namespace CraftingCalculator.Forms
{
    public partial class ImportForm : Form
    {
        private string? _filePath;

        public ImportForm()
        {
            _filePath = null;
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CSV Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileNameTextBox.Text = Path.GetFileName(openFileDialog.FileName);
                _filePath = openFileDialog.FileName;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if(_filePath == null)
            {
                MessageBox.Show("No CSV file selected.");
                return;
            }

            SetButtonsEnabled(false);

            var csvDataAccessor = new CSVDataAccessor();
            var recipeParser = new RecipeParser();
            var recipeImporter = new RecipeImporter();
            var csvData = csvDataAccessor.Read(_filePath);

            recipeImporter.StatusUpdated += ImportUpdated;

            StatusLabel.Visible = true;
            StatusLabel.Text = "Parsing CSV Data...";

            var result = recipeParser.ParseCsvData(csvData);

            recipeImporter.ImportRecipesToDb(result.ItemDTOs, result.CraftTypeDTOs, result.RecipeDTOs, result.IngredientDTOs);

        }

        private void ImportUpdated(object sender, StatusUpdatedEventArgs e)
        {
            if(e.IsComplete)
            {
                MessageBox.Show("Import Complete");
                _filePath = null;
                FileNameTextBox.Text = "";
                SetButtonsEnabled(true);
            }
            else
            {
                if(e.Error != null)
                {
                    //Handle Error
                }
                else if (e.Progress != null)
                {
                    StatusLabel.Text = $"Saving {e.Progress} to Database...";
                }
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            BrowseButton.Enabled = enabled;
            CloseButton.Enabled = enabled;
            ImportButton.Enabled = enabled;
        }
    }
}
