﻿namespace CraftingCalculator.Forms
{
    partial class ListSelectorForm
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
            recipeListPickerControl1 = new Controls.RecipeListPickerControl();
            RecipeListControl = new Controls.RecipeListPickerControl();
            button1 = new Button();
            SuspendLayout();
            // 
            // recipeListPickerControl1
            // 
            recipeListPickerControl1.Location = new Point(12, 12);
            recipeListPickerControl1.Name = "recipeListPickerControl1";
            recipeListPickerControl1.Size = new Size(366, 339);
            recipeListPickerControl1.TabIndex = 0;
            // 
            // RecipeListControl
            // 
            RecipeListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RecipeListControl.Location = new Point(12, 12);
            RecipeListControl.Name = "RecipeListControl";
            RecipeListControl.Size = new Size(461, 341);
            RecipeListControl.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(398, 359);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            // 
            // ListSelectorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 391);
            Controls.Add(button1);
            Controls.Add(RecipeListControl);
            Controls.Add(recipeListPickerControl1);
            Name = "ListSelectorForm";
            Text = "ListSelectorForm";
            Load += ListSelectorForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Controls.RecipeListPickerControl recipeListPickerControl1;
        private Controls.RecipeListPickerControl RecipeListControl;
        private Button button1;
    }
}