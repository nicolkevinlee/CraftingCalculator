namespace CraftingCalculator.Forms
{
    partial class ImportForm
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
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            BrowseButton = new Button();
            FileNameTextBox = new TextBox();
            ChooseLabel = new Label();
            StatusLabel = new Label();
            CloseButton = new Button();
            ImportButton = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(198, 34);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(75, 23);
            BrowseButton.TabIndex = 0;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // FileNameTextBox
            // 
            FileNameTextBox.Enabled = false;
            FileNameTextBox.Location = new Point(12, 34);
            FileNameTextBox.Name = "FileNameTextBox";
            FileNameTextBox.Size = new Size(180, 23);
            FileNameTextBox.TabIndex = 1;
            // 
            // ChooseLabel
            // 
            ChooseLabel.AutoSize = true;
            ChooseLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChooseLabel.Location = new Point(12, 9);
            ChooseLabel.Name = "ChooseLabel";
            ChooseLabel.Size = new Size(105, 17);
            ChooseLabel.TabIndex = 2;
            ChooseLabel.Text = "Choose CSV File:";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusLabel.Location = new Point(12, 60);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(46, 17);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Status:";
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(66, 91);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ImportButton
            // 
            ImportButton.Location = new Point(147, 91);
            ImportButton.Name = "ImportButton";
            ImportButton.Size = new Size(75, 23);
            ImportButton.TabIndex = 5;
            ImportButton.Text = "Import";
            ImportButton.UseVisualStyleBackColor = true;
            ImportButton.Click += ImportButton_Click;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 126);
            Controls.Add(ImportButton);
            Controls.Add(CloseButton);
            Controls.Add(StatusLabel);
            Controls.Add(ChooseLabel);
            Controls.Add(FileNameTextBox);
            Controls.Add(BrowseButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ImportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Button BrowseButton;
        private TextBox FileNameTextBox;
        private Label ChooseLabel;
        private Label StatusLabel;
        private Button CloseButton;
        private Button ImportButton;
    }
}