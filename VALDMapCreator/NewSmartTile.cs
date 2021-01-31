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
    public partial class NewSmartTile : Form
    {
        ImageLoad[] defaultTiles;
        public ImageLoad[] tileImages;
        public string newTileName = "";

        public NewSmartTile()
        {
            InitializeComponent();
            defaultTiles = LoadDefaultTiles();
            tileImages = (ImageLoad[])defaultTiles.Clone();
            ResetTileImages();
        }

        private ImageLoad[] LoadDefaultTiles()
        {
            return new ImageLoad[]
            {
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Horizontal.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Vertical.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Island.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Surrounded.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Corner_0.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Corner_1.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Corner_2.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Corner_3.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Fork_0.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Fork_1.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Fork_2.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_Fork_3.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_End_Down.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_End_Up.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_End_Right.bmp"),
                FileManager.LoadResImageButReturnAbsolute("\\Res\\SmartWall_End_Left.bmp")
            };
        }

        private void btn_smart_reset_Click(object sender, EventArgs e)
        {
            ResetTileImages();
        }

        private void ResetTileImages()
        {
            tileImages = (ImageLoad[])defaultTiles.Clone();
            newTileName = "New Smart Tile";
            input_TileName.Text = newTileName;
            btn_smart_hor.Image = defaultTiles[0].image;
            btn_smart_ver.Image = defaultTiles[1].image;
            btn_smart_isl.Image = defaultTiles[2].image;
            btn_smart_sur.Image = defaultTiles[3].image;
            btn_smart_c0.Image = defaultTiles[4].image;
            btn_smart_c1.Image = defaultTiles[5].image;
            btn_smart_c2.Image = defaultTiles[6].image;
            btn_smart_c3.Image = defaultTiles[7].image;
            btn_smart_f0.Image = defaultTiles[8].image;
            btn_smart_f1.Image = defaultTiles[9].image;
            btn_smart_f2.Image = defaultTiles[10].image;
            btn_smart_f3.Image = defaultTiles[11].image;
            btn_smart_ed.Image = defaultTiles[12].image;
            btn_smart_eu.Image = defaultTiles[13].image;
            btn_smart_er.Image = defaultTiles[14].image;
            btn_smart_el.Image = defaultTiles[15].image;
        }

        private void btn_CancelNewTile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CreateTile_Click(object sender, EventArgs e)
        {
            if (!NameNotValid())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void input_TileName_TextChanged(object sender, EventArgs e)
        {
            newTileName = input_TileName.Text;
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

        private void btn_smart_hor_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[0] = new ImageLoad(new Bitmap(fileName),fileName);
            }
            btn_smart_hor.Image = tileImages[0].image;
        }

        private void btn_smart_ver_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[1] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_ver.Image = tileImages[1].image;
        }

        private void btn_smart_isl_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[2] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_isl.Image = tileImages[2].image;
        }

        private void btn_smart_sur_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[3] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_sur.Image = tileImages[3].image;
        }

        private void btn_smart_c0_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[4] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_c0.Image = tileImages[4].image;
        }

        private void btn_smart_c1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[5] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_c1.Image = tileImages[5].image;
        }

        private void btn_smart_c2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[6] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_c2.Image = tileImages[6].image;
        }

        private void btn_smart_c3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[7] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_c3.Image = tileImages[7].image;
        }

        private void btn_smart_f0_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[8] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_f0.Image = tileImages[8].image;
        }

        private void btn_smart_f1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[9] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_f1.Image = tileImages[9].image;
        }

        private void btn_smart_f2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[10] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_f2.Image = tileImages[10].image;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[11] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_f3.Image = tileImages[11].image;
        }

        private void btn_smart_ed_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[12] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_ed.Image = tileImages[12].image;
        }

        private void btn_smart_eu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[13] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_eu.Image = tileImages[13].image;
        }

        private void btn_smart_er_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[14] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_er.Image = tileImages[14].image;
        }

        private void btn_smart_el_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse BMP Files";

            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tileImages[15] = new ImageLoad(new Bitmap(fileName), fileName);
            }
            btn_smart_el.Image = tileImages[15].image;
        }
    }
}
