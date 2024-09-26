namespace CraftingCalculator.Forms
{
    partial class RecipePickerForm
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
            RecipePicker = new Controls.RecipePicker();
            label1 = new Label();
            AddButton = new Button();
            CraftCountTextBox = new TextBox();
            SuspendLayout();
            // 
            // RecipePicker
            // 
            RecipePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RecipePicker.Location = new Point(12, 12);
            RecipePicker.Name = "RecipePicker";
            RecipePicker.Size = new Size(633, 484);
            RecipePicker.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(414, 505);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 1;
            label1.Text = "Count";
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddButton.Location = new Point(546, 501);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(99, 33);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CraftCountTextBox
            // 
            CraftCountTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CraftCountTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CraftCountTextBox.Location = new Point(472, 501);
            CraftCountTextBox.Name = "CraftCountTextBox";
            CraftCountTextBox.Size = new Size(68, 33);
            CraftCountTextBox.TabIndex = 3;
            CraftCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // RecipePickerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 546);
            Controls.Add(CraftCountTextBox);
            Controls.Add(AddButton);
            Controls.Add(label1);
            Controls.Add(RecipePicker);
            Name = "RecipePickerForm";
            Text = "RecipePickerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.RecipePicker RecipePicker;
        private Label label1;
        private Button AddButton;
        private TextBox CraftCountTextBox;
    }
}