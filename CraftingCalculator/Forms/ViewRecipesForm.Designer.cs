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
            recipeDTOBindingSource = new BindingSource(components);
            AddButton = new Button();
            DeleteButton = new Button();
            CloseButton = new Button();
            RecipePicker = new Controls.RecipePicker();
            tableLayoutPanel1 = new TableLayoutPanel();
            ViewButton = new Button();
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // recipeDTOBindingSource
            // 
            recipeDTOBindingSource.DataSource = typeof(DTOs.RecipeDTO);
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.None;
            AddButton.Location = new Point(172, 4);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.None;
            DeleteButton.Location = new Point(312, 4);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.None;
            CloseButton.Location = new Point(452, 4);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // RecipePicker
            // 
            RecipePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RecipePicker.Location = new Point(12, 12);
            RecipePicker.Name = "RecipePicker";
            RecipePicker.Size = new Size(560, 405);
            RecipePicker.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(CloseButton, 3, 0);
            tableLayoutPanel1.Controls.Add(DeleteButton, 2, 0);
            tableLayoutPanel1.Controls.Add(AddButton, 1, 0);
            tableLayoutPanel1.Controls.Add(ViewButton, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 423);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(560, 31);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // ViewButton
            // 
            ViewButton.Anchor = AnchorStyles.None;
            ViewButton.Location = new Point(32, 4);
            ViewButton.Name = "ViewButton";
            ViewButton.Size = new Size(75, 23);
            ViewButton.TabIndex = 5;
            ViewButton.Text = "View";
            ViewButton.UseVisualStyleBackColor = true;
            ViewButton.Click += ViewButton_Click;
            // 
            // ViewRecipesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(RecipePicker);
            MinimumSize = new Size(600, 500);
            Name = "ViewRecipesForm";
            Text = "View Recipes";
            ((System.ComponentModel.ISupportInitialize)recipeDTOBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private BindingSource recipeDTOBindingSource;
        private Button AddButton;
        private Button DeleteButton;
        private Button CloseButton;
        private Controls.RecipePicker RecipePicker;
        private TableLayoutPanel tableLayoutPanel1;
        private Button ViewButton;
    }
}