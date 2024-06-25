namespace CraftingCalculator.Forms
{
    partial class ViewRecipesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            RecipesGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            yieldDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            craftTypeDTODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            itemDTODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            recipeDTOBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)RecipesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // RecipesGridView
            // 
            RecipesGridView.AllowUserToAddRows = false;
            RecipesGridView.AllowUserToDeleteRows = false;
            RecipesGridView.AllowUserToResizeColumns = false;
            RecipesGridView.AllowUserToResizeRows = false;
            RecipesGridView.AutoGenerateColumns = false;
            RecipesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecipesGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, yieldDataGridViewTextBoxColumn, craftTypeDTODataGridViewTextBoxColumn, itemDTODataGridViewTextBoxColumn });
            RecipesGridView.DataSource = recipeDTOBindingSource;
            RecipesGridView.Location = new Point(12, 12);
            RecipesGridView.MultiSelect = false;
            RecipesGridView.Name = "RecipesGridView";
            RecipesGridView.ReadOnly = true;
            RecipesGridView.RowHeadersVisible = false;
            RecipesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RecipesGridView.Size = new Size(455, 308);
            RecipesGridView.TabIndex = 0;
            RecipesGridView.CellClick += RecipesGridView_CellClick;
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
            // ViewRecipesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 387);
            Controls.Add(RecipesGridView);
            Name = "ViewRecipesForm";
            Text = "View Recipes";
            Load += ViewRecipesForm_Load;
            ((System.ComponentModel.ISupportInitialize)RecipesGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView RecipesGridView;
        private BindingSource recipeDTOBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn craftTypeDTODataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemDTODataGridViewTextBoxColumn;
    }
}