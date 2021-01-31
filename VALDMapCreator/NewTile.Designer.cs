namespace VALDMapCreator
{
    partial class NewTile
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
            this.components = new System.ComponentModel.Container();
            this.btn_CreateTile = new System.Windows.Forms.Button();
            this.btn_CancelNewTile = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.input_TileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Icon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CreateTile
            // 
            this.btn_CreateTile.Location = new System.Drawing.Point(171, 50);
            this.btn_CreateTile.Name = "btn_CreateTile";
            this.btn_CreateTile.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateTile.TabIndex = 0;
            this.btn_CreateTile.Text = "Add Tile";
            this.btn_CreateTile.UseVisualStyleBackColor = true;
            this.btn_CreateTile.Click += new System.EventHandler(this.btn_CreateTile_Click);
            // 
            // btn_CancelNewTile
            // 
            this.btn_CancelNewTile.Location = new System.Drawing.Point(85, 50);
            this.btn_CancelNewTile.Name = "btn_CancelNewTile";
            this.btn_CancelNewTile.Size = new System.Drawing.Size(75, 23);
            this.btn_CancelNewTile.TabIndex = 1;
            this.btn_CancelNewTile.Text = "Cancel";
            this.btn_CancelNewTile.UseVisualStyleBackColor = true;
            this.btn_CancelNewTile.Click += new System.EventHandler(this.btn_CancelNewTile_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // input_TileName
            // 
            this.input_TileName.Location = new System.Drawing.Point(146, 9);
            this.input_TileName.Name = "input_TileName";
            this.input_TileName.Size = new System.Drawing.Size(100, 20);
            this.input_TileName.TabIndex = 5;
            this.input_TileName.TextChanged += new System.EventHandler(this.input_TileName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tile Name:";
            // 
            // btn_Icon
            // 
            this.btn_Icon.Location = new System.Drawing.Point(12, 9);
            this.btn_Icon.Name = "btn_Icon";
            this.btn_Icon.Size = new System.Drawing.Size(64, 64);
            this.btn_Icon.TabIndex = 7;
            this.btn_Icon.UseVisualStyleBackColor = true;
            this.btn_Icon.Click += new System.EventHandler(this.btn_Icon_Click);
            // 
            // NewTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 90);
            this.Controls.Add(this.btn_Icon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_TileName);
            this.Controls.Add(this.btn_CancelNewTile);
            this.Controls.Add(this.btn_CreateTile);
            this.Name = "NewTile";
            this.Text = "New Tile";
            this.Load += new System.EventHandler(this.NewTile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateTile;
        private System.Windows.Forms.Button btn_CancelNewTile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox input_TileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Icon;
    }
}