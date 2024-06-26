namespace CraftingCalculator.Controls
{
    partial class RecipePicker
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
            RecipedGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            yieldDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            craftTypeDTODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            itemDTODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            recipeDTOBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)RecipedGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextBox.Location = new Point(3, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(316, 23);
            SearchTextBox.TabIndex = 0;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // RecipedGridView
            // 
            RecipedGridView.AllowUserToAddRows = false;
            RecipedGridView.AllowUserToDeleteRows = false;
            RecipedGridView.AllowUserToResizeColumns = false;
            RecipedGridView.AllowUserToResizeRows = false;
            RecipedGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RecipedGridView.AutoGenerateColumns = false;
            RecipedGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecipedGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, yieldDataGridViewTextBoxColumn, craftTypeDTODataGridViewTextBoxColumn, itemDTODataGridViewTextBoxColumn });
            RecipedGridView.DataSource = recipeDTOBindingSource;
            RecipedGridView.Location = new Point(3, 32);
            RecipedGridView.MultiSelect = false;
            RecipedGridView.Name = "RecipedGridView";
            RecipedGridView.ReadOnly = true;
            RecipedGridView.RowHeadersVisible = false;
            RecipedGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RecipedGridView.Size = new Size(316, 335);
            RecipedGridView.TabIndex = 1;
            RecipedGridView.CellClick += RecipeGridView_CellClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // yieldDataGridViewTextBoxColumn
            // 
            yieldDataGridViewTextBoxColumn.DataPropertyName = "Yield";
            yieldDataGridViewTextBoxColumn.HeaderText = "Yield";
            yieldDataGridViewTextBoxColumn.Name = "yieldDataGridViewTextBoxColumn";
            yieldDataGridViewTextBoxColumn.ReadOnly = true;
            yieldDataGridViewTextBoxColumn.Width = 50;
            // 
            // craftTypeDTODataGridViewTextBoxColumn
            // 
            craftTypeDTODataGridViewTextBoxColumn.DataPropertyName = "CraftTypeDTO";
            craftTypeDTODataGridViewTextBoxColumn.HeaderText = "Type";
            craftTypeDTODataGridViewTextBoxColumn.Name = "craftTypeDTODataGridViewTextBoxColumn";
            craftTypeDTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemDTODataGridViewTextBoxColumn
            // 
            itemDTODataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            itemDTODataGridViewTextBoxColumn.DataPropertyName = "ItemDTO";
            itemDTODataGridViewTextBoxColumn.HeaderText = "Item Name";
            itemDTODataGridViewTextBoxColumn.Name = "itemDTODataGridViewTextBoxColumn";
            itemDTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recipeDTOBindingSource
            // 
            recipeDTOBindingSource.DataSource = typeof(DTOs.RecipeDTO);
            // 
            // RecipePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RecipedGridView);
            Controls.Add(SearchTextBox);
            Name = "RecipePicker";
            Size = new Size(322, 370);
            ((System.ComponentModel.ISupportInitialize)RecipedGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private DataGridView RecipedGridView;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn craftTypeDTODataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemDTODataGridViewTextBoxColumn;
        private BindingSource recipeDTOBindingSource;
    }
}
