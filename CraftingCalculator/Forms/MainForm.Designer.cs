using CraftingCalculator.Models;

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
        totalShardsBindingSource1 = new BindingSource(components);
        SubRecipeListGridView = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        recipeListEntryBindingSource = new BindingSource(components);
        label4 = new Label();
        AddButton = new Button();
        RemoveButton = new Button();
        LoadButton = new Button();
        SaveButton = new Button();
        RecipeListEntryGridView = new DataGridView();
        Recipe = new DataGridViewTextBoxColumn();
        countDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        label2 = new Label();
        label3 = new Label();
        ListNameTextBox = new TextBox();
        TotalIngredientsListView = new DataGridView();
        itemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        itemDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        totalIngredientBindingSource1 = new BindingSource(components);
        label1 = new Label();
        totalShardsBindingSource = new BindingSource(components);
        totalIngredientBindingSource = new BindingSource(components);
        recipeListEntryDTOBindingSource = new BindingSource(components);
        ingredientDTOBindingSource = new BindingSource(components);
        menuStrip1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)TotalShardsGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)totalShardsBindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)SubRecipeListGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)recipeListEntryBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)RecipeListEntryGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)TotalIngredientsListView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)totalIngredientBindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)totalShardsBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)totalIngredientBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)recipeListEntryDTOBindingSource).BeginInit();
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
        tableLayoutPanel1.Size = new Size(560, 574);
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
        tableLayoutPanel1.SetColumnSpan(TotalShardsGridView, 6);
        TotalShardsGridView.DataSource = totalShardsBindingSource1;
        TotalShardsGridView.Enabled = false;
        TotalShardsGridView.Location = new Point(3, 466);
        TotalShardsGridView.Name = "TotalShardsGridView";
        TotalShardsGridView.ReadOnly = true;
        TotalShardsGridView.RowHeadersVisible = false;
        TotalShardsGridView.Size = new Size(554, 105);
        TotalShardsGridView.TabIndex = 11;
        TotalShardsGridView.SelectionChanged += GridView_SelectionChanged;
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
        SubRecipeListGridView.DataSource = recipeListEntryBindingSource;
        SubRecipeListGridView.Location = new Point(3, 205);
        SubRecipeListGridView.Name = "SubRecipeListGridView";
        SubRecipeListGridView.ReadOnly = true;
        SubRecipeListGridView.RowHeadersVisible = false;
        SubRecipeListGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        SubRecipeListGridView.Size = new Size(554, 106);
        SubRecipeListGridView.TabIndex = 10;
        SubRecipeListGridView.SelectionChanged += GridView_SelectionChanged;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewTextBoxColumn1.DataPropertyName = "Recipe";
        dataGridViewTextBoxColumn1.HeaderText = "Recipe";
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.DataPropertyName = "Count";
        dataGridViewTextBoxColumn2.HeaderText = "Total";
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        dataGridViewTextBoxColumn2.Width = 75;
        // 
        // recipeListEntryBindingSource
        // 
        recipeListEntryBindingSource.DataSource = typeof(RecipeListEntry);
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label4.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(label4, 6);
        label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label4.Location = new Point(3, 172);
        label4.Name = "label4";
        label4.Size = new Size(554, 30);
        label4.TabIndex = 7;
        label4.Text = "Precrafts";
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
        RemoveButton.Click += RemoveButton_Click;
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
        RecipeListEntryGridView.Columns.AddRange(new DataGridViewColumn[] { Recipe, countDataGridViewTextBoxColumn1 });
        tableLayoutPanel1.SetColumnSpan(RecipeListEntryGridView, 6);
        RecipeListEntryGridView.DataSource = recipeListEntryBindingSource;
        RecipeListEntryGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        RecipeListEntryGridView.Location = new Point(3, 63);
        RecipeListEntryGridView.Name = "RecipeListEntryGridView";
        RecipeListEntryGridView.ReadOnly = true;
        RecipeListEntryGridView.RowHeadersVisible = false;
        RecipeListEntryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        RecipeListEntryGridView.Size = new Size(554, 106);
        RecipeListEntryGridView.TabIndex = 4;
        RecipeListEntryGridView.CellClick += RecipeListEntryGridView_CellClick;
        // 
        // Recipe
        // 
        Recipe.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        Recipe.DataPropertyName = "Recipe";
        Recipe.HeaderText = "Recipe";
        Recipe.Name = "Recipe";
        Recipe.ReadOnly = true;
        // 
        // countDataGridViewTextBoxColumn1
        // 
        countDataGridViewTextBoxColumn1.DataPropertyName = "Count";
        countDataGridViewTextBoxColumn1.HeaderText = "Total";
        countDataGridViewTextBoxColumn1.Name = "countDataGridViewTextBoxColumn1";
        countDataGridViewTextBoxColumn1.ReadOnly = true;
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
        TotalIngredientsListView.Columns.AddRange(new DataGridViewColumn[] { itemDataGridViewTextBoxColumn, itemDataGridViewTextBoxColumn1 });
        tableLayoutPanel1.SetColumnSpan(TotalIngredientsListView, 6);
        TotalIngredientsListView.DataSource = totalIngredientBindingSource1;
        TotalIngredientsListView.Location = new Point(3, 347);
        TotalIngredientsListView.Name = "TotalIngredientsListView";
        TotalIngredientsListView.ReadOnly = true;
        TotalIngredientsListView.RowHeadersVisible = false;
        TotalIngredientsListView.Size = new Size(554, 113);
        TotalIngredientsListView.TabIndex = 5;
        TotalIngredientsListView.SelectionChanged += GridView_SelectionChanged;
        // 
        // itemDataGridViewTextBoxColumn
        // 
        itemDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
        itemDataGridViewTextBoxColumn.HeaderText = "Item";
        itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
        itemDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // itemDataGridViewTextBoxColumn1
        // 
        itemDataGridViewTextBoxColumn1.DataPropertyName = "Count";
        itemDataGridViewTextBoxColumn1.HeaderText = "Total";
        itemDataGridViewTextBoxColumn1.Name = "itemDataGridViewTextBoxColumn1";
        itemDataGridViewTextBoxColumn1.ReadOnly = true;
        itemDataGridViewTextBoxColumn1.Width = 75;
        // 
        // totalIngredientBindingSource1
        // 
        totalIngredientBindingSource1.DataSource = typeof(TotalIngredient);
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label1.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(label1, 6);
        label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.Location = new Point(3, 314);
        label1.Name = "label1";
        label1.Size = new Size(554, 30);
        label1.TabIndex = 6;
        label1.Text = "Total Ingredients";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // recipeListEntryDTOBindingSource
        // 
        recipeListEntryDTOBindingSource.DataSource = typeof(DTOs.RecipeListEntryDTO);
        // 
        // ingredientDTOBindingSource
        // 
        ingredientDTOBindingSource.DataSource = typeof(DTOs.IngredientDTO);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(584, 613);
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
        ((System.ComponentModel.ISupportInitialize)totalShardsBindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)SubRecipeListGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)recipeListEntryBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)RecipeListEntryGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)TotalIngredientsListView).EndInit();
        ((System.ComponentModel.ISupportInitialize)totalIngredientBindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)totalShardsBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)totalIngredientBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)recipeListEntryDTOBindingSource).EndInit();
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
    private BindingSource recipeListEntryDTOBindingSource;
    private DataGridViewTextBoxColumn itemDTODataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
    private DataGridView SubRecipeListGridView;
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
    private DataGridViewTextBoxColumn Recipe;
    private DataGridViewTextBoxColumn countDataGridViewTextBoxColumn1;
    private BindingSource recipeListEntryBindingSource;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private BindingSource totalShardsBindingSource1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private BindingSource totalIngredientBindingSource1;
    private DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn1;
}
