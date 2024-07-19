namespace CraftingCalculator.Controls
{
    partial class RecipeListPickerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SearchTextBox = new TextBox();
            ListGridView = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            recipeListBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)ListGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recipeListBindingSource).BeginInit();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextBox.Location = new Point(3, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(350, 23);
            SearchTextBox.TabIndex = 0;
            // 
            // ListGridView
            // 
            ListGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ListGridView.AutoGenerateColumns = false;
            ListGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListGridView.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn });
            ListGridView.DataSource = recipeListBindingSource;
            ListGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            ListGridView.Location = new Point(3, 32);
            ListGridView.MultiSelect = false;
            ListGridView.Name = "ListGridView";
            ListGridView.ReadOnly = true;
            ListGridView.RowHeadersVisible = false;
            ListGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListGridView.Size = new Size(350, 355);
            ListGridView.TabIndex = 1;
            ListGridView.CellClick += ListGridView_CellClick;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recipeListBindingSource
            // 
            recipeListBindingSource.DataSource = typeof(Models.RecipeList);
            // 
            // RecipeListPickerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ListGridView);
            Controls.Add(SearchTextBox);
            Name = "RecipeListPickerControl";
            Size = new Size(356, 390);
            ((System.ComponentModel.ISupportInitialize)ListGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)recipeListBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private DataGridView ListGridView;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource recipeListBindingSource;
    }
}
