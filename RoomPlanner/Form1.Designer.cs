namespace RoomPlanner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.AddFurniture = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CoffeeTableButton = new System.Windows.Forms.Button();
            this.TableButton = new System.Windows.Forms.Button();
            this.SofaButton = new System.Windows.Forms.Button();
            this.BedButton = new System.Windows.Forms.Button();
            this.WallButton = new System.Windows.Forms.Button();
            this.CreatedFurniture = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.językToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.angielskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.AddFurniture.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.CreatedFurniture.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Name = "panel1";
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.AddFurniture);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.CreatedFurniture);
            this.splitContainer2.TabStop = false;
            // 
            // AddFurniture
            // 
            this.AddFurniture.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.AddFurniture, "AddFurniture");
            this.AddFurniture.Name = "AddFurniture";
            this.AddFurniture.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.CoffeeTableButton);
            this.flowLayoutPanel1.Controls.Add(this.TableButton);
            this.flowLayoutPanel1.Controls.Add(this.SofaButton);
            this.flowLayoutPanel1.Controls.Add(this.BedButton);
            this.flowLayoutPanel1.Controls.Add(this.WallButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // CoffeeTableButton
            // 
            this.CoffeeTableButton.BackColor = System.Drawing.Color.White;
            this.CoffeeTableButton.BackgroundImage = global::RoomPlanner.Properties.Resources.coffee_table;
            resources.ApplyResources(this.CoffeeTableButton, "CoffeeTableButton");
            this.CoffeeTableButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CoffeeTableButton.Name = "CoffeeTableButton";
            this.CoffeeTableButton.UseVisualStyleBackColor = false;
            this.CoffeeTableButton.Click += new System.EventHandler(this.CoffeeTableButton_Click);
            // 
            // TableButton
            // 
            this.TableButton.BackColor = System.Drawing.Color.White;
            this.TableButton.BackgroundImage = global::RoomPlanner.Properties.Resources.table;
            resources.ApplyResources(this.TableButton, "TableButton");
            this.TableButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TableButton.Name = "TableButton";
            this.TableButton.UseVisualStyleBackColor = false;
            this.TableButton.Click += new System.EventHandler(this.TableButton_Click);
            // 
            // SofaButton
            // 
            this.SofaButton.BackColor = System.Drawing.Color.White;
            this.SofaButton.BackgroundImage = global::RoomPlanner.Properties.Resources.sofa;
            resources.ApplyResources(this.SofaButton, "SofaButton");
            this.SofaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SofaButton.Name = "SofaButton";
            this.SofaButton.UseVisualStyleBackColor = false;
            this.SofaButton.Click += new System.EventHandler(this.SofaButton_Click);
            // 
            // BedButton
            // 
            this.BedButton.BackColor = System.Drawing.Color.White;
            this.BedButton.BackgroundImage = global::RoomPlanner.Properties.Resources.double_bed;
            resources.ApplyResources(this.BedButton, "BedButton");
            this.BedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BedButton.Name = "BedButton";
            this.BedButton.UseVisualStyleBackColor = false;
            this.BedButton.Click += new System.EventHandler(this.BedButton_Click);
            // 
            // WallButton
            // 
            this.WallButton.BackColor = System.Drawing.Color.White;
            this.WallButton.BackgroundImage = global::RoomPlanner.Properties.Resources.wall;
            resources.ApplyResources(this.WallButton, "WallButton");
            this.WallButton.Name = "WallButton";
            this.WallButton.UseVisualStyleBackColor = false;
            this.WallButton.Click += new System.EventHandler(this.WallButton_Click);
            // 
            // CreatedFurniture
            // 
            this.CreatedFurniture.Controls.Add(this.listBox1);
            resources.ApplyResources(this.CreatedFurniture, "CreatedFurniture");
            this.CreatedFurniture.Name = "CreatedFurniture";
            this.CreatedFurniture.TabStop = false;
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlueprintToolStripMenuItem,
            this.openBlueprintToolStripMenuItem,
            this.saveBlueprintToolStripMenuItem,
            this.językToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newBlueprintToolStripMenuItem
            // 
            this.newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            resources.ApplyResources(this.newBlueprintToolStripMenuItem, "newBlueprintToolStripMenuItem");
            this.newBlueprintToolStripMenuItem.Click += new System.EventHandler(this.newBlueprintToolStripMenuItem_Click);
            // 
            // openBlueprintToolStripMenuItem
            // 
            this.openBlueprintToolStripMenuItem.Name = "openBlueprintToolStripMenuItem";
            resources.ApplyResources(this.openBlueprintToolStripMenuItem, "openBlueprintToolStripMenuItem");
            this.openBlueprintToolStripMenuItem.Click += new System.EventHandler(this.openBlueprintToolStripMenuItem_Click);
            // 
            // saveBlueprintToolStripMenuItem
            // 
            this.saveBlueprintToolStripMenuItem.Name = "saveBlueprintToolStripMenuItem";
            resources.ApplyResources(this.saveBlueprintToolStripMenuItem, "saveBlueprintToolStripMenuItem");
            this.saveBlueprintToolStripMenuItem.Click += new System.EventHandler(this.saveBlueprintToolStripMenuItem_Click);
            // 
            // językToolStripMenuItem
            // 
            this.językToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.angielskiToolStripMenuItem,
            this.polskiToolStripMenuItem});
            this.językToolStripMenuItem.Name = "językToolStripMenuItem";
            resources.ApplyResources(this.językToolStripMenuItem, "językToolStripMenuItem");
            // 
            // angielskiToolStripMenuItem
            // 
            this.angielskiToolStripMenuItem.Name = "angielskiToolStripMenuItem";
            resources.ApplyResources(this.angielskiToolStripMenuItem, "angielskiToolStripMenuItem");
            this.angielskiToolStripMenuItem.Click += new System.EventHandler(this.angielskiToolStripMenuItem_Click);
            // 
            // polskiToolStripMenuItem
            // 
            this.polskiToolStripMenuItem.Name = "polskiToolStripMenuItem";
            resources.ApplyResources(this.polskiToolStripMenuItem, "polskiToolStripMenuItem");
            this.polskiToolStripMenuItem.Click += new System.EventHandler(this.polskiToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.AddFurniture.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.CreatedFurniture.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox AddFurniture;
        private System.Windows.Forms.GroupBox CreatedFurniture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBlueprintToolStripMenuItem;
        private System.Windows.Forms.Button BedButton;
        private System.Windows.Forms.Button SofaButton;
        private System.Windows.Forms.Button TableButton;
        private System.Windows.Forms.Button CoffeeTableButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button WallButton;
        private System.Windows.Forms.ToolStripMenuItem openBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem językToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem angielskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polskiToolStripMenuItem;
    }
}

