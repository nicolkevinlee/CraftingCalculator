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
            CloseButton = new Button();
            ItemPicker = new Controls.ItemPickerControl();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(371, 351);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // ItemPicker
            // 
            ItemPicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ItemPicker.Location = new Point(12, 12);
            ItemPicker.Name = "ItemPicker";
            ItemPicker.Size = new Size(434, 333);
            ItemPicker.TabIndex = 6;
            // 
            // ViewItemsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 385);
            Controls.Add(CloseButton);
            Controls.Add(ItemPicker);
            Name = "ViewItemsForm";
            Text = "View Items";
            ResumeLayout(false);
        }

        #endregion
        private Button CloseButton;
        private Controls.ItemPickerControl ItemPicker;
    }
}