namespace CraftingCalculator.Forms
{
    partial class ViewItemsForm
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
            ItemsGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            itemDTOBindingSource = new BindingSource(components);
            craftingDbContextBindingSource = new BindingSource(components);
            SearchBox = new TextBox();
            AddButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            CloseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemDTOBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)craftingDbContextBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ItemsGridView
            // 
            ItemsGridView.AllowUserToAddRows = false;
            ItemsGridView.AllowUserToDeleteRows = false;
            ItemsGridView.AllowUserToResizeColumns = false;
            ItemsGridView.AllowUserToResizeRows = false;
            ItemsGridView.AutoGenerateColumns = false;
            ItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            ItemsGridView.DataSource = itemDTOBindingSource;
            ItemsGridView.Location = new Point(12, 43);
            ItemsGridView.Name = "ItemsGridView";
            ItemsGridView.ReadOnly = true;
            ItemsGridView.RowHeadersVisible = false;
            ItemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemsGridView.Size = new Size(427, 194);
            ItemsGridView.TabIndex = 0;
            ItemsGridView.CellClick += ItemsGridView_CellClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemDTOBindingSource
            // 
            itemDTOBindingSource.DataSource = typeof(DTOs.ItemDTO);
            // 
            // craftingDbContextBindingSource
            // 
            craftingDbContextBindingSource.DataSource = typeof(Data.CraftingDbContext);
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(12, 12);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(426, 23);
            SearchBox.TabIndex = 1;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 243);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(121, 243);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 23);
            EditButton.TabIndex = 3;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(242, 243);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(363, 243);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // ViewItemsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 354);
            Controls.Add(CloseButton);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(SearchBox);
            Controls.Add(ItemsGridView);
            Name = "ViewItemsForm";
            Text = "View Items";
            Load += ViewItemsForm_Load;
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemDTOBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)craftingDbContextBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ItemsGridView;
        private BindingSource craftingDbContextBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource itemDTOBindingSource;
        private TextBox SearchBox;
        private Button AddButton;
        private Button EditButton;
        private Button DeleteButton;
        private Button CloseButton;
    }
}