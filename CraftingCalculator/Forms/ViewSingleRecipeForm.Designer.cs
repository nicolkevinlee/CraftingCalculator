namespace CraftingCalculator.Forms
{
    partial class ViewSingleRecipeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            CraftTypeLabel = new Label();
            label4 = new Label();
            YieldLabel = new Label();
            RecipeLevelLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ItemNameLabel = new Label();
            label5 = new Label();
            IngredientsDataGrid = new DataGridView();
            ingredientDTOBindingSource = new BindingSource(components);
            ingredientBindingSource = new BindingSource(components);
            ItemDTO = new DataGridViewTextBoxColumn();
            countDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredientDTOBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredientBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(CraftTypeLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(YieldLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(RecipeLevelLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(ItemNameLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(404, 150);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // CraftTypeLabel
            // 
            CraftTypeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CraftTypeLabel.AutoSize = true;
            CraftTypeLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CraftTypeLabel.Location = new Point(103, 90);
            CraftTypeLabel.Name = "CraftTypeLabel";
            CraftTypeLabel.Size = new Size(298, 30);
            CraftTypeLabel.TabIndex = 8;
            CraftTypeLabel.Text = "crafttype";
            CraftTypeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(94, 30);
            label4.TabIndex = 6;
            label4.Text = "Type";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // YieldLabel
            // 
            YieldLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            YieldLabel.AutoSize = true;
            YieldLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YieldLabel.Location = new Point(103, 60);
            YieldLabel.Name = "YieldLabel";
            YieldLabel.Size = new Size(298, 30);
            YieldLabel.TabIndex = 5;
            YieldLabel.Text = "yield";
            YieldLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RecipeLevelLabel
            // 
            RecipeLevelLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RecipeLevelLabel.AutoSize = true;
            RecipeLevelLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RecipeLevelLabel.Location = new Point(103, 30);
            RecipeLevelLabel.Name = "RecipeLevelLabel";
            RecipeLevelLabel.Size = new Size(298, 30);
            RecipeLevelLabel.TabIndex = 4;
            RecipeLevelLabel.Text = "recipelevel";
            RecipeLevelLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 30);
            label1.TabIndex = 0;
            label1.Text = "Item Name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 1;
            label2.Text = "Recipe Level";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(94, 30);
            label3.TabIndex = 2;
            label3.Text = "Yield";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(103, 0);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(298, 30);
            ItemNameLabel.TabIndex = 3;
            ItemNameLabel.Text = "itemname";
            ItemNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label5, 2);
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.Location = new Point(3, 120);
            label5.Name = "label5";
            label5.Size = new Size(398, 30);
            label5.TabIndex = 7;
            label5.Text = "Ingredients";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // IngredientsDataGrid
            // 
            IngredientsDataGrid.AllowUserToAddRows = false;
            IngredientsDataGrid.AllowUserToDeleteRows = false;
            IngredientsDataGrid.AllowUserToResizeColumns = false;
            IngredientsDataGrid.AllowUserToResizeRows = false;
            IngredientsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IngredientsDataGrid.AutoGenerateColumns = false;
            IngredientsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IngredientsDataGrid.Columns.AddRange(new DataGridViewColumn[] { ItemDTO, countDataGridViewTextBoxColumn });
            IngredientsDataGrid.DataSource = ingredientBindingSource;
            IngredientsDataGrid.Location = new Point(12, 168);
            IngredientsDataGrid.Name = "IngredientsDataGrid";
            IngredientsDataGrid.ReadOnly = true;
            IngredientsDataGrid.RowHeadersVisible = false;
            IngredientsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IngredientsDataGrid.Size = new Size(404, 364);
            IngredientsDataGrid.TabIndex = 1;
            // 
            // ingredientDTOBindingSource
            // 
            ingredientDTOBindingSource.DataSource = typeof(DTOs.IngredientDTO);
            // 
            // ingredientBindingSource
            // 
            ingredientBindingSource.DataSource = typeof(Models.Ingredient);
            // 
            // ItemDTO
            // 
            ItemDTO.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ItemDTO.DataPropertyName = "Item";
            ItemDTO.HeaderText = "Item Name";
            ItemDTO.Name = "ItemDTO";
            ItemDTO.ReadOnly = true;
            // 
            // countDataGridViewTextBoxColumn
            // 
            countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            countDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            countDataGridViewTextBoxColumn.HeaderText = "Total";
            countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            countDataGridViewTextBoxColumn.ReadOnly = true;
            countDataGridViewTextBoxColumn.Width = 75;
            // 
            // ViewSingleRecipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 544);
            Controls.Add(IngredientsDataGrid);
            Controls.Add(tableLayoutPanel1);
            Name = "ViewSingleRecipeForm";
            Text = "Recipe";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredientDTOBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredientBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label ItemNameLabel;
        private Label YieldLabel;
        private Label RecipeLevelLabel;
        private DataGridView IngredientsDataGrid;
        private BindingSource ingredientBindingSource;
        private Label CraftTypeLabel;
        private Label label4;
        private Label label5;
        private BindingSource ingredientDTOBindingSource;
        private DataGridViewTextBoxColumn ItemDTO;
        private DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
    }
}