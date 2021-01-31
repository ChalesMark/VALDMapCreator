namespace VALDMapCreator
{
    partial class MainProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.input_width = new System.Windows.Forms.NumericUpDown();
            this.label_width = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.input_height = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btn_NewMap = new System.Windows.Forms.ToolStripMenuItem();
            this.loadVALDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.buildVALDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsBMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_pallette = new System.Windows.Forms.ListBox();
            this.img_selectedTileImg = new System.Windows.Forms.PictureBox();
            this.btn_AddNewTile = new System.Windows.Forms.Button();
            this.input_MapName = new System.Windows.Forms.TextBox();
            this.label_MapName = new System.Windows.Forms.Label();
            this.btn_AddFloor = new System.Windows.Forms.Button();
            this.btn_DeleteFloor = new System.Windows.Forms.Button();
            this.btn_FloorDown = new System.Windows.Forms.Button();
            this.btn_FloorUp = new System.Windows.Forms.Button();
            this.txt_FloorNumber = new System.Windows.Forms.Label();
            this.btn_AddNewSmartTile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_BrushToggle = new System.Windows.Forms.Button();
            this.btn_loadTileFile = new System.Windows.Forms.Button();
            this.btn_saveTileFile = new System.Windows.Forms.Button();
            this.btn_DeleteSelectedTile = new System.Windows.Forms.Button();
            this.panel_viewPort = new VALDMapCreator.MapViewPort();
            this.pb_mapPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.input_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_height)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_selectedTileImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_viewPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mapPB)).BeginInit();
            this.SuspendLayout();
            // 
            // input_width
            // 
            this.input_width.Location = new System.Drawing.Point(563, 56);
            this.input_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_width.Name = "input_width";
            this.input_width.Size = new System.Drawing.Size(52, 20);
            this.input_width.TabIndex = 2;
            this.input_width.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input_width.ValueChanged += new System.EventHandler(this.ChangeMapSize);
            // 
            // label_width
            // 
            this.label_width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_width.AutoSize = true;
            this.label_width.Location = new System.Drawing.Point(522, 58);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(35, 13);
            this.label_width.TabIndex = 3;
            this.label_width.Text = "Width";
            // 
            // label_height
            // 
            this.label_height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(642, 58);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(38, 13);
            this.label_height.TabIndex = 5;
            this.label_height.Text = "Height";
            // 
            // input_height
            // 
            this.input_height.Location = new System.Drawing.Point(686, 56);
            this.input_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_height.Name = "input_height";
            this.input_height.Size = new System.Drawing.Size(52, 20);
            this.input_height.TabIndex = 4;
            this.input_height.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input_height.ValueChanged += new System.EventHandler(this.ChangeMapSize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_NewMap,
            this.loadVALDToolStripMenuItem,
            this.saveWorkspaceToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // btn_NewMap
            // 
            this.btn_NewMap.Name = "btn_NewMap";
            this.btn_NewMap.Size = new System.Drawing.Size(161, 22);
            this.btn_NewMap.Text = "New Map";
            this.btn_NewMap.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // loadVALDToolStripMenuItem
            // 
            this.loadVALDToolStripMenuItem.Name = "loadVALDToolStripMenuItem";
            this.loadVALDToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.loadVALDToolStripMenuItem.Text = "Load Workspace";
            this.loadVALDToolStripMenuItem.Click += new System.EventHandler(this.loadVALDToolStripMenuItem_Click);
            // 
            // saveWorkspaceToolStripMenuItem
            // 
            this.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem";
            this.saveWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveWorkspaceToolStripMenuItem.Text = "Save Workspace";
            this.saveWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.saveWorkspaceToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildVALDToolStripMenuItem,
            this.buildJSONToolStripMenuItem,
            this.saveAsBMPToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(47, 22);
            this.toolStripDropDownButton2.Text = "Build";
            // 
            // buildVALDToolStripMenuItem
            // 
            this.buildVALDToolStripMenuItem.Name = "buildVALDToolStripMenuItem";
            this.buildVALDToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.buildVALDToolStripMenuItem.Text = "Build as VALD";
            this.buildVALDToolStripMenuItem.Click += new System.EventHandler(this.buildVALDToolStripMenuItem_Click);
            // 
            // buildJSONToolStripMenuItem
            // 
            this.buildJSONToolStripMenuItem.Name = "buildJSONToolStripMenuItem";
            this.buildJSONToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.buildJSONToolStripMenuItem.Text = "Build as JSON";
            this.buildJSONToolStripMenuItem.Click += new System.EventHandler(this.buildJSONToolStripMenuItem_Click);
            // 
            // saveAsBMPToolStripMenuItem
            // 
            this.saveAsBMPToolStripMenuItem.Name = "saveAsBMPToolStripMenuItem";
            this.saveAsBMPToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsBMPToolStripMenuItem.Text = "Save as bmp";
            this.saveAsBMPToolStripMenuItem.Click += new System.EventHandler(this.saveAsBMPToolStripMenuItem_Click);
            // 
            // lb_pallette
            // 
            this.lb_pallette.FormattingEnabled = true;
            this.lb_pallette.Location = new System.Drawing.Point(5, 118);
            this.lb_pallette.Name = "lb_pallette";
            this.lb_pallette.Size = new System.Drawing.Size(208, 238);
            this.lb_pallette.TabIndex = 8;
            this.lb_pallette.SelectedIndexChanged += new System.EventHandler(this.lb_pallette_SelectedIndexChanged);
            // 
            // img_selectedTileImg
            // 
            this.img_selectedTileImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img_selectedTileImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_selectedTileImg.Location = new System.Drawing.Point(3, 3);
            this.img_selectedTileImg.Name = "img_selectedTileImg";
            this.img_selectedTileImg.Size = new System.Drawing.Size(80, 80);
            this.img_selectedTileImg.TabIndex = 9;
            this.img_selectedTileImg.TabStop = false;
            // 
            // btn_AddNewTile
            // 
            this.btn_AddNewTile.Location = new System.Drawing.Point(5, 367);
            this.btn_AddNewTile.Name = "btn_AddNewTile";
            this.btn_AddNewTile.Size = new System.Drawing.Size(210, 23);
            this.btn_AddNewTile.TabIndex = 10;
            this.btn_AddNewTile.Text = "Add New Tile";
            this.btn_AddNewTile.UseVisualStyleBackColor = true;
            this.btn_AddNewTile.Click += new System.EventHandler(this.btn_AddNewTile_Click);
            // 
            // input_MapName
            // 
            this.input_MapName.Location = new System.Drawing.Point(587, 28);
            this.input_MapName.Name = "input_MapName";
            this.input_MapName.Size = new System.Drawing.Size(151, 20);
            this.input_MapName.TabIndex = 11;
            this.input_MapName.TextChanged += new System.EventHandler(this.input_MapName_TextChanged);
            // 
            // label_MapName
            // 
            this.label_MapName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MapName.AutoSize = true;
            this.label_MapName.Location = new System.Drawing.Point(522, 31);
            this.label_MapName.Name = "label_MapName";
            this.label_MapName.Size = new System.Drawing.Size(59, 13);
            this.label_MapName.TabIndex = 12;
            this.label_MapName.Text = "Map Name";
            // 
            // btn_AddFloor
            // 
            this.btn_AddFloor.Location = new System.Drawing.Point(12, 519);
            this.btn_AddFloor.Name = "btn_AddFloor";
            this.btn_AddFloor.Size = new System.Drawing.Size(75, 23);
            this.btn_AddFloor.TabIndex = 14;
            this.btn_AddFloor.Text = "Add Floor";
            this.btn_AddFloor.UseVisualStyleBackColor = true;
            this.btn_AddFloor.Click += new System.EventHandler(this.btn_AddFloor_Click);
            // 
            // btn_DeleteFloor
            // 
            this.btn_DeleteFloor.Location = new System.Drawing.Point(93, 519);
            this.btn_DeleteFloor.Name = "btn_DeleteFloor";
            this.btn_DeleteFloor.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteFloor.TabIndex = 15;
            this.btn_DeleteFloor.Text = "Delete Floor";
            this.btn_DeleteFloor.UseVisualStyleBackColor = true;
            this.btn_DeleteFloor.Click += new System.EventHandler(this.btn_DeleteFloor_Click);
            // 
            // btn_FloorDown
            // 
            this.btn_FloorDown.Location = new System.Drawing.Point(437, 519);
            this.btn_FloorDown.Name = "btn_FloorDown";
            this.btn_FloorDown.Size = new System.Drawing.Size(75, 23);
            this.btn_FloorDown.TabIndex = 16;
            this.btn_FloorDown.Text = "Floor Down";
            this.btn_FloorDown.UseVisualStyleBackColor = true;
            this.btn_FloorDown.Click += new System.EventHandler(this.btn_FloorDown_Click);
            // 
            // btn_FloorUp
            // 
            this.btn_FloorUp.Location = new System.Drawing.Point(356, 519);
            this.btn_FloorUp.Name = "btn_FloorUp";
            this.btn_FloorUp.Size = new System.Drawing.Size(75, 23);
            this.btn_FloorUp.TabIndex = 17;
            this.btn_FloorUp.Text = "Floor Up";
            this.btn_FloorUp.UseVisualStyleBackColor = true;
            this.btn_FloorUp.Click += new System.EventHandler(this.btn_FloorUp_Click);
            // 
            // txt_FloorNumber
            // 
            this.txt_FloorNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FloorNumber.AutoSize = true;
            this.txt_FloorNumber.Location = new System.Drawing.Point(245, 524);
            this.txt_FloorNumber.Name = "txt_FloorNumber";
            this.txt_FloorNumber.Size = new System.Drawing.Size(35, 13);
            this.txt_FloorNumber.TabIndex = 18;
            this.txt_FloorNumber.Text = "label1";
            // 
            // btn_AddNewSmartTile
            // 
            this.btn_AddNewSmartTile.Location = new System.Drawing.Point(5, 396);
            this.btn_AddNewSmartTile.Name = "btn_AddNewSmartTile";
            this.btn_AddNewSmartTile.Size = new System.Drawing.Size(210, 23);
            this.btn_AddNewSmartTile.TabIndex = 19;
            this.btn_AddNewSmartTile.Text = "Add New Smart Tile";
            this.btn_AddNewSmartTile.UseVisualStyleBackColor = true;
            this.btn_AddNewSmartTile.Click += new System.EventHandler(this.btn_AddNewSmartTile_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_BrushToggle);
            this.panel1.Controls.Add(this.img_selectedTileImg);
            this.panel1.Controls.Add(this.btn_loadTileFile);
            this.panel1.Controls.Add(this.btn_saveTileFile);
            this.panel1.Controls.Add(this.btn_DeleteSelectedTile);
            this.panel1.Controls.Add(this.lb_pallette);
            this.panel1.Controls.Add(this.btn_AddNewSmartTile);
            this.panel1.Controls.Add(this.btn_AddNewTile);
            this.panel1.Location = new System.Drawing.Point(518, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 426);
            this.panel1.TabIndex = 21;
            // 
            // btn_BrushToggle
            // 
            this.btn_BrushToggle.BackColor = System.Drawing.SystemColors.Info;
            this.btn_BrushToggle.Location = new System.Drawing.Point(3, 89);
            this.btn_BrushToggle.Name = "btn_BrushToggle";
            this.btn_BrushToggle.Size = new System.Drawing.Size(80, 23);
            this.btn_BrushToggle.TabIndex = 24;
            this.btn_BrushToggle.Text = "Paint";
            this.btn_BrushToggle.UseVisualStyleBackColor = false;
            this.btn_BrushToggle.Click += new System.EventHandler(this.btn_BrushToggle_Click);
            // 
            // btn_loadTileFile
            // 
            this.btn_loadTileFile.Location = new System.Drawing.Point(89, 32);
            this.btn_loadTileFile.Name = "btn_loadTileFile";
            this.btn_loadTileFile.Size = new System.Drawing.Size(122, 23);
            this.btn_loadTileFile.TabIndex = 23;
            this.btn_loadTileFile.Text = "📂 Load Tile";
            this.btn_loadTileFile.UseVisualStyleBackColor = true;
            this.btn_loadTileFile.Click += new System.EventHandler(this.btn_loadTileFile_Click);
            // 
            // btn_saveTileFile
            // 
            this.btn_saveTileFile.Location = new System.Drawing.Point(89, 3);
            this.btn_saveTileFile.Name = "btn_saveTileFile";
            this.btn_saveTileFile.Size = new System.Drawing.Size(122, 23);
            this.btn_saveTileFile.TabIndex = 22;
            this.btn_saveTileFile.Text = "💾 Save Tile";
            this.btn_saveTileFile.UseVisualStyleBackColor = true;
            this.btn_saveTileFile.Click += new System.EventHandler(this.btn_saveTileFile_Click);
            // 
            // btn_DeleteSelectedTile
            // 
            this.btn_DeleteSelectedTile.Location = new System.Drawing.Point(89, 60);
            this.btn_DeleteSelectedTile.Name = "btn_DeleteSelectedTile";
            this.btn_DeleteSelectedTile.Size = new System.Drawing.Size(122, 23);
            this.btn_DeleteSelectedTile.TabIndex = 21;
            this.btn_DeleteSelectedTile.Text = "🗑️ Delete Tile";
            this.btn_DeleteSelectedTile.UseVisualStyleBackColor = true;
            this.btn_DeleteSelectedTile.Click += new System.EventHandler(this.btn_DeleteSelectedTile_Click);
            // 
            // panel_viewPort
            // 
            this.panel_viewPort.AutoScroll = true;
            this.panel_viewPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_viewPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_viewPort.Controls.Add(this.pb_mapPB);
            this.panel_viewPort.Location = new System.Drawing.Point(12, 23);
            this.panel_viewPort.Name = "panel_viewPort";
            this.panel_viewPort.Size = new System.Drawing.Size(500, 485);
            this.panel_viewPort.TabIndex = 1;
            // 
            // pb_mapPB
            // 
            this.pb_mapPB.Location = new System.Drawing.Point(0, 0);
            this.pb_mapPB.Name = "pb_mapPB";
            this.pb_mapPB.Size = new System.Drawing.Size(100, 50);
            this.pb_mapPB.TabIndex = 0;
            this.pb_mapPB.TabStop = false;
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_FloorNumber);
            this.Controls.Add(this.btn_FloorUp);
            this.Controls.Add(this.btn_FloorDown);
            this.Controls.Add(this.btn_DeleteFloor);
            this.Controls.Add(this.btn_AddFloor);
            this.Controls.Add(this.label_MapName);
            this.Controls.Add(this.input_MapName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.input_width);
            this.Controls.Add(this.panel_viewPort);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.input_height);
            this.Controls.Add(this.label_height);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainProgram";
            this.Text = "VALD Map Creator";
            this.Load += new System.EventHandler(this.MainProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.input_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_height)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_selectedTileImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel_viewPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_mapPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown input_width;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.NumericUpDown input_height;
        private System.Windows.Forms.PictureBox pb_mapPB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btn_NewMap;
        private System.Windows.Forms.ToolStripMenuItem loadVALDToolStripMenuItem;
        private System.Windows.Forms.ListBox lb_pallette;
        private System.Windows.Forms.PictureBox img_selectedTileImg;
        private System.Windows.Forms.Button btn_AddNewTile;
        private System.Windows.Forms.TextBox input_MapName;
        private System.Windows.Forms.Label label_MapName;
        private System.Windows.Forms.Button btn_AddFloor;
        private System.Windows.Forms.Button btn_DeleteFloor;
        private System.Windows.Forms.Button btn_FloorDown;
        private System.Windows.Forms.Button btn_FloorUp;
        private System.Windows.Forms.Label txt_FloorNumber;
        private System.Windows.Forms.Button btn_AddNewSmartTile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_DeleteSelectedTile;
        private MapViewPort panel_viewPort;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem buildVALDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsBMPToolStripMenuItem;
        private System.Windows.Forms.Button btn_loadTileFile;
        private System.Windows.Forms.Button btn_saveTileFile;
        private System.Windows.Forms.ToolStripMenuItem buildJSONToolStripMenuItem;
        private System.Windows.Forms.Button btn_BrushToggle;
    }
}

