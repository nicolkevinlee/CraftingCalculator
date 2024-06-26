namespace CraftingCalculator.Controls
{
    partial class ItemPickerControl
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
            ItemsGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            itemDTOBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextBox.Location = new Point(3, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(407, 23);
            SearchTextBox.TabIndex = 0;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // ItemsGridView
            // 
            ItemsGridView.AllowUserToAddRows = false;
            ItemsGridView.AllowUserToDeleteRows = false;
            ItemsGridView.AllowUserToResizeColumns = false;
            ItemsGridView.AllowUserToResizeRows = false;
            ItemsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ItemsGridView.AutoGenerateColumns = false;
            ItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            ItemsGridView.DataSource = itemDTOBindingSource;
            ItemsGridView.Location = new Point(3, 32);
            ItemsGridView.MultiSelect = false;
            ItemsGridView.Name = "ItemsGridView";
            ItemsGridView.ReadOnly = true;
            ItemsGridView.RowHeadersVisible = false;
            ItemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemsGridView.Size = new Size(407, 394);
            ItemsGridView.TabIndex = 1;
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
            // ItemPickerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ItemsGridView);
            Controls.Add(SearchTextBox);
            Name = "ItemPickerControl";
            Size = new Size(413, 429);
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemDTOBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private DataGridView ItemsGridView;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource itemDTOBindingSource;
    }
}
