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
        menuStrip1 = new MenuStrip();
        dataToolStripMenuItem = new ToolStripMenuItem();
        addToolStripMenuItem = new ToolStripMenuItem();
        itemToolStripMenuItem = new ToolStripMenuItem();
        recipeToolStripMenuItem = new ToolStripMenuItem();
        editToolStripMenuItem = new ToolStripMenuItem();
        itemToolStripMenuItem1 = new ToolStripMenuItem();
        recipeToolStripMenuItem1 = new ToolStripMenuItem();
        importToolStripMenuItem = new ToolStripMenuItem();
        button1 = new Button();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { dataToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
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
        addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemToolStripMenuItem, recipeToolStripMenuItem });
        addToolStripMenuItem.Name = "addToolStripMenuItem";
        addToolStripMenuItem.Size = new Size(180, 22);
        addToolStripMenuItem.Text = "Add";
        // 
        // itemToolStripMenuItem
        // 
        itemToolStripMenuItem.Name = "itemToolStripMenuItem";
        itemToolStripMenuItem.Size = new Size(109, 22);
        itemToolStripMenuItem.Text = "Item";
        // 
        // recipeToolStripMenuItem
        // 
        recipeToolStripMenuItem.Name = "recipeToolStripMenuItem";
        recipeToolStripMenuItem.Size = new Size(109, 22);
        recipeToolStripMenuItem.Text = "Recipe";
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemToolStripMenuItem1, recipeToolStripMenuItem1 });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(180, 22);
        editToolStripMenuItem.Text = "Edit";
        // 
        // itemToolStripMenuItem1
        // 
        itemToolStripMenuItem1.Name = "itemToolStripMenuItem1";
        itemToolStripMenuItem1.Size = new Size(109, 22);
        itemToolStripMenuItem1.Text = "Item";
        // 
        // recipeToolStripMenuItem1
        // 
        recipeToolStripMenuItem1.Name = "recipeToolStripMenuItem1";
        recipeToolStripMenuItem1.Size = new Size(109, 22);
        recipeToolStripMenuItem1.Text = "Recipe";
        // 
        // importToolStripMenuItem
        // 
        importToolStripMenuItem.Name = "importToolStripMenuItem";
        importToolStripMenuItem.Size = new Size(180, 22);
        importToolStripMenuItem.Text = "Import";
        importToolStripMenuItem.Click += importToolStripMenuItem_Click;
        // 
        // button1
        // 
        button1.Location = new Point(12, 51);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 1;
        button1.Text = "Import";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "Main";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem dataToolStripMenuItem;
    private ToolStripMenuItem addToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem importToolStripMenuItem;
    private ToolStripMenuItem itemToolStripMenuItem;
    private ToolStripMenuItem recipeToolStripMenuItem;
    private ToolStripMenuItem itemToolStripMenuItem1;
    private ToolStripMenuItem recipeToolStripMenuItem1;
    private Button button1;
}
