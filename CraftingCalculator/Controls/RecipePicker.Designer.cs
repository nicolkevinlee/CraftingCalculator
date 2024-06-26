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
            RecipeLevel = new DataGridViewTextBoxColumn();
            itemDTODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            recipeDTOBindingSource = new BindingSource(components);
            RecipeLevelLabel = new Label();
            MinRecipeLevelTextBox = new TextBox();
            DashLabel = new Label();
            MaxRecipeLevelTextBox = new TextBox();
            ItemNameLabel = new Label();
            SearchButton = new Button();
            ((System.ComponentModel.ISupportInitialize)RecipedGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchTextBox.Location = new Point(357, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(160, 25);
            SearchTextBox.TabIndex = 0;
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
            RecipedGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, yieldDataGridViewTextBoxColumn, craftTypeDTODataGridViewTextBoxColumn, RecipeLevel, itemDTODataGridViewTextBoxColumn });
            RecipedGridView.DataSource = recipeDTOBindingSource;
            RecipedGridView.Location = new Point(3, 32);
            RecipedGridView.MultiSelect = false;
            RecipedGridView.Name = "RecipedGridView";
            RecipedGridView.ReadOnly = true;
            RecipedGridView.RowHeadersVisible = false;
            RecipedGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RecipedGridView.Size = new Size(598, 437);
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
            craftTypeDTODataGridViewTextBoxColumn.Width = 75;
            // 
            // RecipeLevel
            // 
            RecipeLevel.DataPropertyName = "RecipeLevel";
            RecipeLevel.HeaderText = "Recipe Level";
            RecipeLevel.Name = "RecipeLevel";
            RecipeLevel.ReadOnly = true;
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
            // RecipeLevelLabel
            // 
            RecipeLevelLabel.AutoSize = true;
            RecipeLevelLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RecipeLevelLabel.Location = new Point(3, 4);
            RecipeLevelLabel.Name = "RecipeLevelLabel";
            RecipeLevelLabel.Size = new Size(92, 20);
            RecipeLevelLabel.TabIndex = 2;
            RecipeLevelLabel.Text = "Recipe Level";
            // 
            // MinRecipeLevelTextBox
            // 
            MinRecipeLevelTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinRecipeLevelTextBox.Location = new Point(101, 3);
            MinRecipeLevelTextBox.Name = "MinRecipeLevelTextBox";
            MinRecipeLevelTextBox.Size = new Size(63, 25);
            MinRecipeLevelTextBox.TabIndex = 3;
            // 
            // DashLabel
            // 
            DashLabel.AutoSize = true;
            DashLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DashLabel.Location = new Point(170, 6);
            DashLabel.Name = "DashLabel";
            DashLabel.Size = new Size(15, 20);
            DashLabel.TabIndex = 4;
            DashLabel.Text = "-";
            // 
            // MaxRecipeLevelTextBox
            // 
            MaxRecipeLevelTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaxRecipeLevelTextBox.Location = new Point(191, 3);
            MaxRecipeLevelTextBox.Name = "MaxRecipeLevelTextBox";
            MaxRecipeLevelTextBox.Size = new Size(63, 25);
            MaxRecipeLevelTextBox.TabIndex = 5;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(268, 4);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(83, 20);
            ItemNameLabel.TabIndex = 6;
            ItemNameLabel.Text = "Item Name";
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchButton.Location = new Point(526, 3);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 25);
            SearchButton.TabIndex = 7;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // RecipePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SearchButton);
            Controls.Add(ItemNameLabel);
            Controls.Add(MaxRecipeLevelTextBox);
            Controls.Add(DashLabel);
            Controls.Add(MinRecipeLevelTextBox);
            Controls.Add(RecipeLevelLabel);
            Controls.Add(RecipedGridView);
            Controls.Add(SearchTextBox);
            Name = "RecipePicker";
            Size = new Size(604, 472);
            ((System.ComponentModel.ISupportInitialize)RecipedGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private DataGridView RecipedGridView;
        private BindingSource recipeDTOBindingSource;
        private Label RecipeLevelLabel;
        private TextBox MinRecipeLevelTextBox;
        private Label DashLabel;
        private TextBox MaxRecipeLevelTextBox;
        private Label ItemNameLabel;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn craftTypeDTODataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn RecipeLevel;
        private DataGridViewTextBoxColumn itemDTODataGridViewTextBoxColumn;
        private Button SearchButton;
    }
}
