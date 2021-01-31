namespace VALDMapCreator
{
    partial class NewRandomTile
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
            this.label1 = new System.Windows.Forms.Label();
            this.input_TileName = new System.Windows.Forms.TextBox();
            this.btn_CancelNewTile = new System.Windows.Forms.Button();
            this.btn_CreateTile = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_NewRandomTile_DeleteSelectedTile = new System.Windows.Forms.Button();
            this.btn_NewRandomTile_OpenTiles = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tile Name:";
            // 
            // input_TileName
            // 
            this.input_TileName.Location = new System.Drawing.Point(167, 165);
            this.input_TileName.Name = "input_TileName";
            this.input_TileName.Size = new System.Drawing.Size(100, 20);
            this.input_TileName.TabIndex = 10;
            this.input_TileName.TextChanged += new System.EventHandler(this.input_TileName_TextChanged);
            // 
            // btn_CancelNewTile
            // 
            this.btn_CancelNewTile.Location = new System.Drawing.Point(111, 191);
            this.btn_CancelNewTile.Name = "btn_CancelNewTile";
            this.btn_CancelNewTile.Size = new System.Drawing.Size(75, 23);
            this.btn_CancelNewTile.TabIndex = 9;
            this.btn_CancelNewTile.Text = "Cancel";
            this.btn_CancelNewTile.UseVisualStyleBackColor = true;
            this.btn_CancelNewTile.Click += new System.EventHandler(this.btn_CancelNewTile_Click);
            // 
            // btn_CreateTile
            // 
            this.btn_CreateTile.Location = new System.Drawing.Point(192, 191);
            this.btn_CreateTile.Name = "btn_CreateTile";
            this.btn_CreateTile.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateTile.TabIndex = 8;
            this.btn_CreateTile.Text = "Add Tile";
            this.btn_CreateTile.UseVisualStyleBackColor = true;
            this.btn_CreateTile.Click += new System.EventHandler(this.btn_CreateTile_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 8);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(234, 95);
            this.listBox1.TabIndex = 12;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_NewRandomTile_DeleteSelectedTile
            // 
            this.btn_NewRandomTile_DeleteSelectedTile.Location = new System.Drawing.Point(123, 109);
            this.btn_NewRandomTile_DeleteSelectedTile.Name = "btn_NewRandomTile_DeleteSelectedTile";
            this.btn_NewRandomTile_DeleteSelectedTile.Size = new System.Drawing.Size(119, 23);
            this.btn_NewRandomTile_DeleteSelectedTile.TabIndex = 13;
            this.btn_NewRandomTile_DeleteSelectedTile.Text = "Delete Selected Tile";
            this.btn_NewRandomTile_DeleteSelectedTile.UseVisualStyleBackColor = true;
            this.btn_NewRandomTile_DeleteSelectedTile.Click += new System.EventHandler(this.btn_NewRandomTile_DeleteSelectedTile_Click);
            // 
            // btn_NewRandomTile_OpenTiles
            // 
            this.btn_NewRandomTile_OpenTiles.Location = new System.Drawing.Point(8, 109);
            this.btn_NewRandomTile_OpenTiles.Name = "btn_NewRandomTile_OpenTiles";
            this.btn_NewRandomTile_OpenTiles.Size = new System.Drawing.Size(75, 23);
            this.btn_NewRandomTile_OpenTiles.TabIndex = 14;
            this.btn_NewRandomTile_OpenTiles.Text = "Load Tiles";
            this.btn_NewRandomTile_OpenTiles.UseVisualStyleBackColor = true;
            this.btn_NewRandomTile_OpenTiles.Click += new System.EventHandler(this.btn_NewRandomTile_OpenTiles_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.btn_NewRandomTile_DeleteSelectedTile);
            this.panel1.Controls.Add(this.btn_NewRandomTile_OpenTiles);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(255, 147);
            this.panel1.TabIndex = 15;
            // 
            // NewRandomTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_TileName);
            this.Controls.Add(this.btn_CancelNewTile);
            this.Controls.Add(this.btn_CreateTile);
            this.Name = "NewRandomTile";
            this.Text = "NewRandomTile";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_TileName;
        private System.Windows.Forms.Button btn_CancelNewTile;
        private System.Windows.Forms.Button btn_CreateTile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_NewRandomTile_DeleteSelectedTile;
        private System.Windows.Forms.Button btn_NewRandomTile_OpenTiles;
        private System.Windows.Forms.Panel panel1;
    }
}