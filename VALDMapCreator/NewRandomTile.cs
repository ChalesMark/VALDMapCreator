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
    public partial class NewRandomTile : Form
    {
        public string newTileName = "";
        public Dictionary<string,string> images;
        public ListBox.SelectedObjectCollection selectedTiles;

        public NewRandomTile()
        {
            InitializeComponent();
            newTileName = "New Random Tile";
            input_TileName.Text = newTileName;
            images = new Dictionary<string,string>();
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        private void btn_NewRandomTile_OpenTiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    if (!images.ContainsKey(System.IO.Path.GetFileName(file)))
                        images.Add(System.IO.Path.GetFileName(file),file);
                    else
                    {
                        MessageBox.Show(System.IO.Path.GetFileName(file) + " is already present!", "Image Already Present", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var i in images)
            {
                listBox1.Items.Add(i.Key);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTiles = listBox1.SelectedItems;
        }

        private void btn_NewRandomTile_DeleteSelectedTile_Click(object sender, EventArgs e)
        {
            foreach(var s in selectedTiles)
            {
                images.Remove(s.ToString());
            }
            UpdateListBox();
        }

        private void input_TileName_TextChanged(object sender, EventArgs e)
        {
            newTileName = input_TileName.Text;
        }

        private void btn_CancelNewTile_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("Tile name already exsists. Two tiles can not have the same name", "Pallette Already Contains " + newTileName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (newTileName.Contains('|') || newTileName.Contains(',') || newTileName.Contains('.'))
            {
                MessageBox.Show("Tile can not contain '|' , ',' , or '.' . Those characters will effect the VALD file.", "Name Contains Illegal Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else return false;
        }

        private void btn_CreateTile_Click(object sender, EventArgs e)
        {
            if (images.Count < 2)
            {
                MessageBox.Show("Tile must at least contain 2 images!", "Missing Images", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
