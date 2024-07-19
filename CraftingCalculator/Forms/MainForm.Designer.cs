namespace CraftingCalculator.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip1 = new MenuStrip();
        dataToolStripMenuItem = new ToolStripMenuItem();
        addToolStripMenuItem = new ToolStripMenuItem();
        editToolStripMenuItem = new ToolStripMenuItem();
        importToolStripMenuItem = new ToolStripMenuItem();
        tableLayoutPanel1 = new TableLayoutPanel();
        TotalShardsGridView = new DataGridView();
        nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        fireCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        earthCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        iceCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        windCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        lightningCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        waterCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        totalShardsBindingSource = new BindingSource(components);
        SubRecipeListGridView = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        recipeListEntryDTOBindingSource = new BindingSource(components);
        label4 = new Label();
        AddButton = new Button();
        RemoveButton = new Button();
        LoadButton = new Button();
        SaveButton = new Button();
        RecipeListEntryGridView = new DataGridView();
        recipeDTODataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        countDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        label2 = new Label();
        label3 = new Label();
        ListNameTextBox = new TextBox();
        TotalIngredientsListView = new DataGridView();
        itemDTODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        countDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        totalIngredientBindingSource = new BindingSource(components);
        label1 = new Label();
        ingredientDTOBindingSource = new BindingSource(components);
        menuStrip1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)TotalShardsGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)totalShardsBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)SubRecipeListGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)recipeListEntryDTOBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)RecipeListEntryGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)TotalIngredientsListView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)totalIngredientBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ingredientDTOBindingSource).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { dataToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(584, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // dataToolStripMenuItem
        // 
        dataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, editToolStripMenuItem, importToolStripMenuItem });
        dataToolStripMenuItem.Name = "dataToolStripMenuItem";
        dataToolStripMenuItem.Size = new Size(43, 20);
        dataToolStripMenuItem.Text = "Data";
        // 
        // addToolStripMenuItem
        // 
        addToolStripMenuItem.Name = "addToolStripMenuItem";
        addToolStripMenuItem.Size = new Size(114, 22);
        addToolStripMenuItem.Text = "Items";
        addToolStripMenuItem.Click += addToolStripMenuItem_Click;
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(114, 22);
        editToolStripMenuItem.Text = "Recipes";
        editToolStripMenuItem.Click += editToolStripMenuItem_Click;
        // 
        // importToolStripMenuItem
        // 
        importToolStripMenuItem.Name = "importToolStripMenuItem";
        importToolStripMenuItem.Size = new Size(114, 22);
        importToolStripMenuItem.Text = "Import";
        importToolStripMenuItem.Click += importToolStripMenuItem_Click;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel1.ColumnCount = 6;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
        tableLayoutPanel1.Controls.Add(TotalShardsGridView, 0, 7);
        tableLayoutPanel1.Controls.Add(SubRecipeListGridView, 0, 4);
        tableLayoutPanel1.Controls.Add(label4, 0, 3);
        tableLayoutPanel1.Controls.Add(AddButton, 5, 0);
        tableLayoutPanel1.Controls.Add(RemoveButton, 4, 0);
        tableLayoutPanel1.Controls.Add(LoadButton, 3, 0);
        tableLayoutPanel1.Controls.Add(SaveButton, 2, 0);
        tableLayoutPanel1.Controls.Add(RecipeListEntryGridView, 0, 2);
        tableLayoutPanel1.Controls.Add(label2, 0, 1);
        tableLayoutPanel1.Controls.Add(label3, 0, 0);
        tableLayoutPanel1.Controls.Add(ListNameTextBox, 1, 0);
        tableLayoutPanel1.Controls.Add(TotalIngredientsListView, 0, 6);
        tableLayoutPanel1.Controls.Add(label1, 0, 5);
        tableLayoutPanel1.Location = new Point(12, 27);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 8;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 32.6732674F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 32.6732674F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.6534653F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
        tableLayoutPanel1.Size = new Size(560, 568);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // TotalShardsGridView
        // 
        TotalShardsGridView.AllowUserToAddRows = false;
        TotalShardsGridView.AllowUserToDeleteRows = false;
        TotalShardsGridView.AllowUserToResizeColumns = false;
        TotalShardsGridView.AllowUserToResizeRows = false;
        TotalShardsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        TotalShardsGridView.AutoGenerateColumns = false;
        TotalShardsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        TotalShardsGridView.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, fireCountDataGridViewTextBoxColumn, earthCountDataGridViewTextBoxColumn, iceCountDataGridViewTextBoxColumn, windCountDataGridViewTextBoxColumn, lightningCountDataGridViewTextBoxColumn, waterCountDataGridViewTextBoxColumn });
        tableLayoutPanel1.SetColumnSpan(TotalShardsGridView, 6);
        TotalShardsGridView.DataSource = totalShardsBindingSource;
        TotalShardsGridView.Enabled = false;
        TotalShardsGridView.Location = new Point(3, 460);
        TotalShardsGridView.Name = "TotalShardsGridView";
        TotalShardsGridView.ReadOnly = true;
        TotalShardsGridView.RowHeadersVisible = false;
        TotalShardsGridView.Size = new Size(554, 105);
        TotalShardsGridView.TabIndex = 11;
        // 
        // nameDataGridViewTextBoxColumn
        // 
        nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
        nameDataGridViewTextBoxColumn.HeaderText = "Name";
        nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
        nameDataGridViewTextBoxColumn.ReadOnly = true;
        nameDataGridViewTextBoxColumn.Width = 80;
        // 
        // fireCountDataGridViewTextBoxColumn
        // 
        fireCountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        fireCountDataGridViewTextBoxColumn.DataPropertyName = "FireCount";
        fireCountDataGridViewTextBoxColumn.HeaderText = "Fire";
        fireCountDataGridViewTextBoxColumn.Name = "fireCountDataGridViewTextBoxColumn";
        fireCountDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // earthCountDataGridViewTextBoxColumn
        // 
        earthCountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        earthCountDataGridViewTextBoxColumn.DataPropertyName = "EarthCount";
        earthCountDataGridViewTextBoxColumn.HeaderText = "Earth";
        earthCountDataGridViewTextBoxColumn.Name = "earthCountDataGridViewTextBoxColumn";
        earthCountDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // iceCountDataGridViewTextBoxColumn
        // 
        iceCountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        iceCountDataGridViewTextBoxColumn.DataPropertyName = "IceCount";
        iceCountDataGridViewTextBoxColumn.HeaderText = "Ice";
        iceCountDataGridViewTextBoxColumn.Name = "iceCountDataGridViewTextBoxColumn";
        iceCountDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // windCountDataGridViewTextBoxColumn
        // 
        windCountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        windCountDataGridViewTextBoxColumn.DataPropertyName = "WindCount";
        windCountDataGridViewTextBoxColumn.HeaderText = "Wind";
        windCountDataGridViewTextBoxColumn.Name = "windCountDataGridViewTextBoxColumn";
        windCountDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // lightningCountDataGridViewTextBoxColumn
        // 
        lightningCountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        lightningCountDataGridViewTextBoxColumn.DataPropertyName = "LightningCount";
        lightningCountDataGridViewTextBoxColumn.HeaderText = "Lightning";
        lightningCountDataGridViewTextBoxColumn.Name = "lightningCountDataGridViewTextBoxColumn";
        lightningCountDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // waterCountDataGridViewTextBoxColumn
        // 
        waterCountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        waterCountDataGridViewTextBoxColumn.DataPropertyName = "WaterCount";
        waterCountDataGridViewTextBoxColumn.HeaderText = "Water";
        waterCountDataGridViewTextBoxColumn.Name = "waterCountDataGridViewTextBoxColumn";
        waterCountDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // totalShardsBindingSource
        // 
        totalShardsBindingSource.DataSource = typeof(DTOs.TotalShards);
        // 
        // SubRecipeListGridView
        // 
        SubRecipeListGridView.AllowUserToAddRows = false;
        SubRecipeListGridView.AllowUserToDeleteRows = false;
        SubRecipeListGridView.AllowUserToResizeColumns = false;
        SubRecipeListGridView.AllowUserToResizeRows = false;
        SubRecipeListGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        SubRecipeListGridView.AutoGenerateColumns = false;
        SubRecipeListGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        SubRecipeListGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
        tableLayoutPanel1.SetColumnSpan(SubRecipeListGridView, 6);
        SubRecipeListGridView.DataSource = recipeListEntryDTOBindingSource;
        SubRecipeListGridView.Enabled = false;
        SubRecipeListGridView.Location = new Point(3, 203);
        SubRecipeListGridView.Name = "SubRecipeListGridView";
        SubRecipeListGridView.RowHeadersVisible = false;
        SubRecipeListGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        SubRecipeListGridView.Size = new Size(554, 104);
        SubRecipeListGridView.TabIndex = 10;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewTextBoxColumn1.DataPropertyName = "RecipeDTO";
        dataGridViewTextBoxColumn1.HeaderText = "Recipe";
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.DataPropertyName = "Count";
        dataGridViewTextBoxColumn2.HeaderText = "Total";
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.Width = 75;
        // 
        // recipeListEntryDTOBindingSource
        // 
        recipeListEntryDTOBindingSource.DataSource = typeof(DTOs.RecipeListEntryDTO);
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label4.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(label4, 6);
        label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label4.Location = new Point(3, 170);
        label4.Name = "label4";
        label4.Size = new Size(554, 30);
        label4.TabIndex = 7;
        label4.Text = "Sub Crafts";
        label4.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // AddButton
        // 
        AddButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        AddButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AddButton.Location = new Point(493, 3);
        AddButton.Name = "AddButton";
        AddButton.Size = new Size(64, 24);
        AddButton.TabIndex = 0;
        AddButton.Text = "Add";
        AddButton.UseVisualStyleBackColor = true;
        AddButton.Click += AddButton_Click;
        // 
        // RemoveButton
        // 
        RemoveButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        RemoveButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        RemoveButton.Location = new Point(423, 3);
        RemoveButton.Name = "RemoveButton";
        RemoveButton.Size = new Size(64, 24);
        RemoveButton.TabIndex = 1;
        RemoveButton.Text = "Remove";
        RemoveButton.UseVisualStyleBackColor = true;
        // 
        // LoadButton
        // 
        LoadButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        LoadButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        LoadButton.Location = new Point(353, 3);
        LoadButton.Name = "LoadButton";
        LoadButton.Size = new Size(64, 24);
        LoadButton.TabIndex = 2;
        LoadButton.Text = "Load";
        LoadButton.UseVisualStyleBackColor = true;
        LoadButton.Click += LoadButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        SaveButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        SaveButton.Location = new Point(283, 3);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(64, 24);
        SaveButton.TabIndex = 3;
        SaveButton.Text = "Save";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // RecipeListEntryGridView
        // 
        RecipeListEntryGridView.AllowUserToAddRows = false;
        RecipeListEntryGridView.AllowUserToDeleteRows = false;
        RecipeListEntryGridView.AllowUserToResizeColumns = false;
        RecipeListEntryGridView.AllowUserToResizeRows = false;
        RecipeListEntryGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        RecipeListEntryGridView.AutoGenerateColumns = false;
        RecipeListEntryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        RecipeListEntryGridView.Columns.AddRange(new DataGridViewColumn[] { recipeDTODataGridViewTextBoxColumn1, countDataGridViewTextBoxColumn1 });
        tableLayoutPanel1.SetColumnSpan(RecipeListEntryGridView, 6);
        RecipeListEntryGridView.DataSource = recipeListEntryDTOBindingSource;
        RecipeListEntryGridView.Location = new Point(3, 63);
        RecipeListEntryGridView.Name = "RecipeListEntryGridView";
        RecipeListEntryGridView.RowHeadersVisible = false;
        RecipeListEntryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        RecipeListEntryGridView.Size = new Size(554, 104);
        RecipeListEntryGridView.TabIndex = 4;
        // 
        // recipeDTODataGridViewTextBoxColumn1
        // 
        recipeDTODataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        recipeDTODataGridViewTextBoxColumn1.DataPropertyName = "RecipeDTO";
        recipeDTODataGridViewTextBoxColumn1.HeaderText = "Recipe";
        recipeDTODataGridViewTextBoxColumn1.Name = "recipeDTODataGridViewTextBoxColumn1";
        // 
        // countDataGridViewTextBoxColumn1
        // 
        countDataGridViewTextBoxColumn1.DataPropertyName = "Count";
        countDataGridViewTextBoxColumn1.HeaderText = "Total";
        countDataGridViewTextBoxColumn1.Name = "countDataGridViewTextBoxColumn1";
        countDataGridViewTextBoxColumn1.Width = 75;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label2.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(label2, 6);
        label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.Location = new Point(3, 30);
        label2.Name = "label2";
        label2.Size = new Size(554, 30);
        label2.TabIndex = 7;
        label2.Text = "Recipes";
        label2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label3.Location = new Point(3, 0);
        label3.Name = "label3";
        label3.Size = new Size(94, 30);
        label3.TabIndex = 8;
        label3.Text = "List Name";
        label3.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // ListNameTextBox
        // 
        ListNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ListNameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ListNameTextBox.Location = new Point(103, 3);
        ListNameTextBox.Name = "ListNameTextBox";
        ListNameTextBox.Size = new Size(174, 27);
        ListNameTextBox.TabIndex = 9;
        // 
        // TotalIngredientsListView
        // 
        TotalIngredientsListView.AllowUserToAddRows = false;
        TotalIngredientsListView.AllowUserToDeleteRows = false;
        TotalIngredientsListView.AllowUserToResizeColumns = false;
        TotalIngredientsListView.AllowUserToResizeRows = false;
        TotalIngredientsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        TotalIngredientsListView.AutoGenerateColumns = false;
        TotalIngredientsListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        TotalIngredientsListView.Columns.AddRange(new DataGridViewColumn[] { itemDTODataGridViewTextBoxColumn, countDataGridViewTextBoxColumn });
        tableLayoutPanel1.SetColumnSpan(TotalIngredientsListView, 6);
        TotalIngredientsListView.DataSource = totalIngredientBindingSource;
        TotalIngredientsListView.Enabled = false;
        TotalIngredientsListView.Location = new Point(3, 343);
        TotalIngredientsListView.Name = "TotalIngredientsListView";
        TotalIngredientsListView.ReadOnly = true;
        TotalIngredientsListView.RowHeadersVisible = false;
        TotalIngredientsListView.Size = new Size(554, 111);
        TotalIngredientsListView.TabIndex = 5;
        // 
        // itemDTODataGridViewTextBoxColumn
        // 
        itemDTODataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        itemDTODataGridViewTextBoxColumn.DataPropertyName = "ItemDTO";
        itemDTODataGridViewTextBoxColumn.HeaderText = "Ingredient";
        itemDTODataGridViewTextBoxColumn.Name = "itemDTODataGridViewTextBoxColumn";
        itemDTODataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // countDataGridViewTextBoxColumn
        // 
        countDataGridViewTextBoxColumn.DataPropertyName = "Count";
        countDataGridViewTextBoxColumn.HeaderText = "Total";
        countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
        countDataGridViewTextBoxColumn.ReadOnly = true;
        countDataGridViewTextBoxColumn.Width = 75;
        // 
        // totalIngredientBindingSource
        // 
        totalIngredientBindingSource.DataSource = typeof(DTOs.TotalIngredient);
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label1.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(label1, 6);
        label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.Location = new Point(3, 310);
        label1.Name = "label1";
        label1.Size = new Size(554, 30);
        label1.TabIndex = 6;
        label1.Text = "Total Ingredients";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // ingredientDTOBindingSource
        // 
        ingredientDTOBindingSource.DataSource = typeof(DTOs.IngredientDTO);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(584, 607);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MinimumSize = new Size(600, 550);
        Name = "MainForm";
        Text = "Main";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)TotalShardsGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)totalShardsBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)SubRecipeListGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)recipeListEntryDTOBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)RecipeListEntryGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)TotalIngredientsListView).EndInit();
        ((System.ComponentModel.ISupportInitialize)totalIngredientBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)ingredientDTOBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem dataToolStripMenuItem;
    private ToolStripMenuItem addToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem importToolStripMenuItem;
    private Button AddButton;
    private TableLayoutPanel tableLayoutPanel1;
    private Button RemoveButton;
    private Button LoadButton;
    private Button SaveButton;
    private DataGridView RecipeListEntryGridView;
    private DataGridView TotalIngredientsListView;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox ListNameTextBox;
    private BindingSource ingredientDTOBindingSource;
    private DataGridViewTextBoxColumn recipeDTODataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn countDataGridViewTextBoxColumn1;
    private BindingSource recipeListEntryDTOBindingSource;
    private DataGridViewTextBoxColumn itemDTODataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
    private DataGridView SubRecipeListGridView;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private Label label4;
    private DataGridView TotalShardsGridView;
    private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn fireCountDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn earthCountDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn iceCountDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn windCountDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn lightningCountDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn waterCountDataGridViewTextBoxColumn;
    private BindingSource totalShardsBindingSource;
    private BindingSource totalIngredientBindingSource;
}
