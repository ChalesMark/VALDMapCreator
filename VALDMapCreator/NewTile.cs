using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VALDMapCreator
{
    public partial class NewTile : Form
    {
        public Image selectedImage;
        public string newTileName = "";
        public string newTilePath = "";

        public NewTile()
        {
            InitializeComponent();
        }

        private void NewTile_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btn_CancelNewTile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CreateTile_Click(object sender, EventArgs e)
        {
            if (selectedImage == null)
            {
                MessageBox.Show("Tile can not be blank. Please click the icon button to load in a bmp.", "Missing An Icon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NameNotValid())
            {

            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private bool NameNotValid()
        {
            if (newTileName.Trim() == "")
            {
                MessageBox.Show("Tile name can not be left blank.", "Name Is Blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (MainProgram.PalletContains(newTileName))
            {
                MessageBox.Show("Tile name already exsists. Two tiles can not have the same name", "Pallette Already Contains "+newTileName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (newTileName.Contains('|') || newTileName.Contains(',') || newTileName.Contains('.'))
            {
                MessageBox.Show("Tile can not contain '|' , ',' , or '.' . Those characters will effect the VALD file.", "Name Contains Illegal Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else return false;
        }

        private void btn_Icon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                newTilePath = fileName;
                selectedImage = new Bitmap(fileName);
                if (newTileName == "")
                {
                    newTileName = openFileDialog1.SafeFileName.Replace(".bmp","");
                    input_TileName.Text = newTileName;
                }
            }
            btn_Icon.Image = selectedImage;
        }

        private void input_TileName_TextChanged(object sender, EventArgs e)
        {
            newTileName = input_TileName.Text;
        }
    }
}
