using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VALDMapCreator
{
    public partial class MainProgram : Form
    {
        int width, height;
        string mapName = "New Map";
        List<Dictionary<Point, string>> mapData;
        static Dictionary<string, Tile> pallette;
        string selectedTile = "";

        Point mousePos;
        bool mouseDown;

        int tileSize = 32;
        int currentFloor = 0;

        bool bucket;
        
        public MainProgram()
        {
            InitializeComponent();
        }

        static public bool PalletContains(string name)
        {
            if (pallette.ContainsKey(name))
                return true;
            return false;
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ResetPallette();
             
            img_selectedTileImg.Image = pallette[selectedTile].GetImage();
            img_selectedTileImg.SizeMode = PictureBoxSizeMode.StretchImage;

            pb_mapPB.MouseMove += new MouseEventHandler(UpdateMousePosition);
            pb_mapPB.MouseUp += new MouseEventHandler(MouseUpEvent);
            pb_mapPB.MouseDown += new MouseEventHandler(MouseDownEvent);
            MouseWheel += new MouseEventHandler(MouseWheelEvent);

            NewMap();
            CheckLayerButtons();
            UpdatePallete();
            lb_pallette.SelectedIndex = 0;

            bucket = false;

            input_MapName.Text = mapName;
        }

        private void ResetPallette()
        {
            pallette = new Dictionary<string, Tile>
            {
                { "Void", new Tile(FileManager.LoadResImage("\\Res\\void.bmp")) },
                { "Walkable", new Tile(FileManager.LoadResImage("\\Res\\walkable.bmp")) },
                { "Enemy", new Tile(FileManager.LoadResImage("\\Res\\monster.bmp")) },
                { "Player Spawn", new Tile(FileManager.LoadResImage("\\Res\\playerSpawn.bmp")) },
                { "Goal", new Tile(FileManager.LoadResImage("\\Res\\goal.bmp")) },
                {
                    "Smart Wall",
                    new Tile(
                FileManager.LoadResImage("\\Res\\SmartWall_Horizontal.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Vertical.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Island.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Surrounded.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Corner_0.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Corner_1.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Corner_2.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Corner_3.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Fork_0.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Fork_1.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Fork_2.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_Fork_3.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_End_Down.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_End_Up.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_End_Right.bmp"),
                FileManager.LoadResImage("\\Res\\SmartWall_End_Left.bmp"))
                }
            };
            selectedTile = "Void";
            UpdatePallete();
            lb_pallette.SelectedIndex = 0;
        }

        private void CheckLayerButtons()
        {
            if (currentFloor == 0)
                btn_FloorDown.Enabled = false;
            else
                btn_FloorDown.Enabled = true;

            if (currentFloor == mapData.Count-1)
                btn_FloorUp.Enabled = false;
            else
                btn_FloorUp.Enabled = true;

            if (mapData.Count != 1)
                btn_DeleteFloor.Enabled = true;
            else
                btn_DeleteFloor.Enabled = false;

            txt_FloorNumber.Text = "Floor " + (currentFloor+1) + "/" + mapData.Count;
        }

        #region Menu Bar
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPallette();            
            NewMap();
        }

        private void saveAsBMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to save this project as BMP images?", "Confirm Export", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int floorNum = 0;
                foreach (var floor in mapData)
                {
                    Bitmap floorImage = new Bitmap(width * tileSize, height * tileSize);
                    using (Graphics g = Graphics.FromImage(floorImage))
                    {
                        foreach (var v in mapData[currentFloor])
                        {
                            switch (pallette[v.Value].GetTileType())
                            {
                                case (TileType.Normal):
                                    {
                                        g.DrawImage(pallette[v.Value].GetImage(), new Point(v.Key.X * tileSize, v.Key.Y * tileSize));
                                        break;
                                    }
                                case (TileType.Smart):
                                    {
                                        SmartType smartType = GetSmartType(v.Key, v.Value);
                                        g.DrawImage(pallette[v.Value].GetSmartImage(smartType), new Point(v.Key.X * tileSize, v.Key.Y * tileSize));
                                        break;
                                    }
                            }
                        }
                    }

                    System.IO.FileInfo path = new System.IO.FileInfo("Image Exports\\" + mapName + "_" + floorNum.ToString().PadLeft(1, '0') + ".bmp");
                    path.Directory.Create();
                    floorImage.Save(path.ToString());
                    floorNum++;
                }
            }
        }

        private void loadVALDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] loadedProj = FileManager.LoadVALDProjFile();
            if (loadedProj != null)
            {
                LoadProject(loadedProj);
            }
        }

        private void LoadProject(string[] loadedProj)
        {
            ResetPallette();

            string[] mapInfo = loadedProj[0].Split('|');
            string[] noneStandardPallette = loadedProj[1].Split('|');
            string[] tileInfo = loadedProj[2].Split('.');

            mapName = mapInfo[0];
            width = int.Parse(mapInfo[1].Trim());
            height = int.Parse(mapInfo[2].Trim());
            input_MapName.Text = mapName;
            input_width.Value = width;
            input_height.Value = height;

            if (noneStandardPallette != null || noneStandardPallette.Length != 0)
            {
                foreach(var newTile in noneStandardPallette)
                {
                    if (newTile != "")
                    {
                        string[] tileData = newTile.Split(',');
                        string[] imagePaths = tileData[2].Split('~');

                        switch (tileData[1])
                        {
                            case "NORMAL":
                                {
                                    pallette.Add(tileData[0], new Tile(FileManager.LoadImageAbsolute(imagePaths[0])));
                                    break;
                                }
                            case "SMART":
                                {
                                    pallette.Add(tileData[0],
                                        new Tile(
                                            FileManager.LoadImageAbsolute(imagePaths[0]),
                                            FileManager.LoadImageAbsolute(imagePaths[1]),
                                            FileManager.LoadImageAbsolute(imagePaths[2]),
                                            FileManager.LoadImageAbsolute(imagePaths[3]),

                                            FileManager.LoadImageAbsolute(imagePaths[4]),
                                            FileManager.LoadImageAbsolute(imagePaths[5]),
                                            FileManager.LoadImageAbsolute(imagePaths[6]),
                                            FileManager.LoadImageAbsolute(imagePaths[7]),

                                            FileManager.LoadImageAbsolute(imagePaths[8]),
                                            FileManager.LoadImageAbsolute(imagePaths[9]),
                                            FileManager.LoadImageAbsolute(imagePaths[10]),
                                            FileManager.LoadImageAbsolute(imagePaths[11]),

                                            FileManager.LoadImageAbsolute(imagePaths[12]),
                                            FileManager.LoadImageAbsolute(imagePaths[13]),
                                            FileManager.LoadImageAbsolute(imagePaths[14]),
                                            FileManager.LoadImageAbsolute(imagePaths[15])
                                    ));
                                    break;
                                }
                        }
                    }
                }
            }

            mapData = new List<Dictionary<Point, string>>();
            int numberOfFloors = int.Parse(mapInfo[3].Trim());
            for (int i = 0; i < numberOfFloors; i++)
            {
                mapData.Add(new Dictionary<Point, string>());
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        mapData[i].Add(new Point(x, y), "Void");
                    }
            }

            if (tileInfo != null)
            {
                foreach(var tile in tileInfo)
                {
                    string[] tileData = tile.Split(',');
                    if (!tileData[0].Equals("Void"))
                        mapData[int.Parse(tileData[3].Trim())][new Point(int.Parse(tileData[1].Trim()), int.Parse(tileData[2].Trim()))] = tileData[0];
                }
            }

            UpdatePallete();
            pb_mapPB.Width = width * tileSize;
            pb_mapPB.Height = height * tileSize;
            RefreshMap();
        }
        #endregion

        private void NewMap()
        {
            width = (int)input_width.Value;
            height = (int)input_height.Value;

            pb_mapPB.Width = width * tileSize;
            pb_mapPB.Height = height * tileSize;
            mapData = new List<Dictionary<Point, string>>();
            mapData.Add(new Dictionary<Point, string>());
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    mapData[currentFloor].Add(new Point(x, y), "Void");
                }

            RefreshMap();
        }

        private void ChangeMapSize(object sender, EventArgs e)
        {
            width = (int)input_width.Value;
            height = (int)input_height.Value;

            pb_mapPB.Width = width * tileSize;
            pb_mapPB.Height = height * tileSize;
            List<Dictionary<Point, string>> newMap = new List<Dictionary<Point, string>>();
            
            int floorNum = 0;
            foreach (var floor in mapData)
            {
                newMap.Add(new Dictionary<Point, string>());
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        newMap[floorNum].Add(new Point(x, y), "Void");
                    }
                floorNum++;
            }

            floorNum = 0;
            foreach(var floor in mapData)
            {                
                foreach(var tile in floor)
                {
                    if (tile.Key.X < width && tile.Key.Y < height)
                        newMap[floorNum][tile.Key] = tile.Value;
                }
                floorNum++;
            }

            mapData = newMap;

            RefreshMap();

        }

        private void RefreshMap()
        {
            Bitmap empty = new Bitmap(width * tileSize, height * tileSize);
            using (Graphics g = Graphics.FromImage(empty))
            {
                foreach (var v in mapData[currentFloor])
                {
                    switch (pallette[v.Value.Trim()].GetTileType())
                    {
                        case (TileType.Normal):
                        {
                            Image i = pallette[v.Value].GetImage();
                            if (i != null)
                                g.DrawImage(i, new Point(v.Key.X * tileSize, v.Key.Y * tileSize));
                            break;
                        }
                        case (TileType.Smart):
                        {
                            SmartType smartType = GetSmartType(v.Key,v.Value);
                            Image i = pallette[v.Value].GetSmartImage(smartType);
                            if (i != null)
                                    g.DrawImage(i, new Point(v.Key.X * tileSize, v.Key.Y * tileSize));
                            break;
                        }                        
                    }                    
                }
            }
            pb_mapPB.Image = empty;
            pb_mapPB.Refresh();
            pb_mapPB.Visible = true;
        }

        private SmartType GetSmartType(Point value,string name)
        {
            bool up = false;
            bool down = false;
            bool right = false;
            bool left = false;

            if (mapData[currentFloor].ContainsKey(new Point(value.X, value.Y - 1)) && mapData[currentFloor][new Point(value.X, value.Y - 1)].Equals(name))
                up = true;
            if (mapData[currentFloor].ContainsKey(new Point(value.X+1, value.Y)) && mapData[currentFloor][new Point(value.X + 1, value.Y)].Equals(name))
                right = true;
            if (mapData[currentFloor].ContainsKey(new Point(value.X, value.Y + 1)) && mapData[currentFloor][new Point(value.X, value.Y + 1)].Equals(name))
                down = true;
            if (mapData[currentFloor].ContainsKey(new Point(value.X-1, value.Y)) && mapData[currentFloor][new Point(value.X - 1, value.Y)].Equals(name))
                left = true;

            if (up && down && right && left)
                return SmartType.Surrounded;
            else if (!up && !down && !right && !left)
                return SmartType.Island;
            else if (up && down && !right && !left)
                return SmartType.Vertical;
            else if (!up && !down && right && left)
                return SmartType.Horizontal;

            else if (!up && down && !right && left)
                return SmartType.Corner0;
            else if (up && !down && !right && left)
                return SmartType.Corner1;
            else if (up && !down && right && !left)
                return SmartType.Corner2;
            else if (!up && down && right && !left)
                return SmartType.Corner3;

            else if (up && down && !right && left)
                return SmartType.Fork0;
            else if (up && !down && right && left)
                return SmartType.Fork1;
            else if (!up && down && right && left)
                return SmartType.Fork2;
            else if (up && down && right && !left)
                return SmartType.Fork3;

            else if (up && !down && !right && !left)
                return SmartType.EndDown;
            else if (!up && down && !right && !left)
                return SmartType.EndUp;
            else if (!up && !down && right && !left)
                return SmartType.EndLeft;
            else if (!up && !down && !right && left)
                return SmartType.EndRight;
            else
                return SmartType.Island;
        }

        #region Tile Pallette Code
        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                int newPallettePos = lb_pallette.SelectedIndex - 1;
                if (newPallettePos < 0)
                    newPallettePos = lb_pallette.Items.Count - 1;
                lb_pallette.SelectedIndex = newPallettePos;
                SelectedItemChange();
            }
            else if (e.Delta < 0)
            {
                int newPallettePos = lb_pallette.SelectedIndex + 1;
                if (newPallettePos > lb_pallette.Items.Count - 1)
                    newPallettePos = 0;
                lb_pallette.SelectedIndex = newPallettePos;
                SelectedItemChange();
            }

        }

        private void UpdatePallete()
        {
            lb_pallette.Items.Clear();
            foreach (var p in pallette)
            {
                switch (p.Value.GetTileType())
                {
                    case TileType.Normal:
                        {
                            lb_pallette.Items.Add("  " + p.Key);
                            break;
                        }
                    case TileType.Smart:
                        {
                            lb_pallette.Items.Add("❗ " + p.Key);
                            break;
                        }
                    case TileType.Random:
                        {
                            lb_pallette.Items.Add("🎲 " + p.Key);
                            break;
                        }
                }
            }

            lb_pallette.Refresh();
        }

        private void lb_pallette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_pallette.SelectedItem != null)
            {
                SelectedItemChange();
            }
        }

        private void SelectedItemChange()
        {
            string dataIn = lb_pallette.SelectedItem.ToString();
            selectedTile = dataIn.Substring(2, dataIn.Length - 2);
            switch (pallette[selectedTile.Trim()].GetTileType())
            {
                case TileType.Normal:
                    {
                        img_selectedTileImg.Image = pallette[selectedTile].GetImage();
                        break;
                    }
                case TileType.Smart:
                    {
                        img_selectedTileImg.Image = pallette[selectedTile].GetSmartImage(SmartType.Island);
                        break;
                    }
                case TileType.Random:
                    {
                        img_selectedTileImg.Image = pallette[selectedTile.Trim()].GetRandomImage();
                        break;
                    }
            }
        }

        private void btn_DeleteSelectedTile_Click(object sender, EventArgs e)
        {
            if (selectedTile != "Void" && selectedTile != "Walkable" && selectedTile != "Smart Wall" && selectedTile != "Enemy" && selectedTile != "Goal" && selectedTile != "Player Spawn")
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete " + selectedTile + "?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {

                    foreach (var floor in mapData)
                    {
                        for (int i = 0; i < floor.Count; i++)
                        {
                            if (floor.ElementAt(i).Value == selectedTile)
                                floor[floor.ElementAt(i).Key] = "Void";
                        }
                    }
                    int newPallettePos = lb_pallette.SelectedIndex - 1;
                    pallette.Remove(selectedTile);
                    UpdatePallete();
                    lb_pallette.SelectedIndex = newPallettePos;
                    SelectedItemChange();
                    RefreshMap();
                }
            }
            else
            {
                MessageBox.Show(selectedTile + " is part of the default tiles and can not be deleted.", "Selected Tile Can Not Be Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void btn_AddNewTile_Click(object sender, EventArgs e)
        {
            NewTile newTile = new NewTile();

            if (newTile.ShowDialog() == DialogResult.OK)
            {
                pallette.Add(newTile.newTileName, new Tile(new ImageLoad(newTile.selectedImage, newTile.newTilePath)));
                
                UpdatePallete();
            }
        }
        #endregion

        #region Interacting with the picturebox
        private void UpdateMousePosition(object sender, MouseEventArgs e)
        {
            mousePos.X = e.Location.X;
            mousePos.Y = e.Location.Y;

            if (mouseDown)
                ChangeTile();
        }
        private void ChangeTile()
        {
            Point tileClicked = new Point(mousePos.X/tileSize, mousePos.Y/tileSize);

            if (tileClicked.X > -1 && tileClicked.X < width && tileClicked.Y > -1 && tileClicked.Y < height)
            {
                if (bucket)
                    Fill(tileClicked);
                else
                    mapData[currentFloor][tileClicked] = selectedTile;
                RefreshMap();
            }
        }

        private void Fill(Point tileClicked)
        {
            string fillingTIle = mapData[currentFloor][tileClicked];
            if (!selectedTile.Equals(fillingTIle))
            {
                List<Point> spacesToCheck = new List<Point>();
                List<Point> newSpacesToCheck = new List<Point>();
                spacesToCheck.Add(tileClicked);

                do
                {
                    foreach (var s in spacesToCheck)
                    {
                        mapData[currentFloor][s] = selectedTile;
                        if (mapData[currentFloor].ContainsKey(new Point(s.X + 1, s.Y)) && mapData[currentFloor][new Point(s.X + 1, s.Y)].Equals(fillingTIle))
                        {
                            newSpacesToCheck.Add(new Point(s.X + 1, s.Y));
                        }
                        if (mapData[currentFloor].ContainsKey(new Point(s.X, s.Y + 1)) && mapData[currentFloor][new Point(s.X, s.Y + 1)].Equals(fillingTIle))
                        {
                            newSpacesToCheck.Add(new Point(s.X, s.Y + 1));
                        }
                        if (mapData[currentFloor].ContainsKey(new Point(s.X - 1, s.Y)) && mapData[currentFloor][new Point(s.X - 1, s.Y)].Equals(fillingTIle))
                        {
                            newSpacesToCheck.Add(new Point(s.X - 1, s.Y));
                        }
                        if (mapData[currentFloor].ContainsKey(new Point(s.X, s.Y - 1)) && mapData[currentFloor][new Point(s.X, s.Y - 1)].Equals(fillingTIle))
                        {
                            newSpacesToCheck.Add(new Point(s.X, s.Y - 1));
                        }
                    }
                    spacesToCheck.Clear();
                    foreach (var t in newSpacesToCheck)
                        spacesToCheck.Add(t);
                    newSpacesToCheck.Clear();
                } while (spacesToCheck.Count != 0);
            }
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDown = true;
        }

        private void input_MapName_TextChanged(object sender, EventArgs e)
        {
            mapName = input_MapName.Text;
        }

        private void buildVALDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.BuildVALD(mapName, width, height, mapData.Count,pallette,mapData);
        }

        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to save this workspace?", "Confirm Save", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                FileManager.SaveVALDProjFile(mapName, width, height, pallette, mapData);
            }
        }

        private void btn_AddFloor_Click(object sender, EventArgs e)
        {
            Dictionary<Point, string> newFloor = new Dictionary<Point, string>();

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    newFloor.Add(new Point(x, y), "Void");
                }

            mapData.Insert(currentFloor+1, newFloor);
            currentFloor++;
            CheckLayerButtons();
            RefreshMap();
        }

        private void btn_FloorUp_Click(object sender, EventArgs e)
        {
            currentFloor++;
            CheckLayerButtons();
            RefreshMap();
        }

        private void btn_FloorDown_Click(object sender, EventArgs e)
        {
            currentFloor--;
            CheckLayerButtons();
            RefreshMap();
        }

        private void btn_DeleteFloor_Click(object sender, EventArgs e)
        {
            mapData.RemoveAt(currentFloor);
            if (currentFloor != 0)
                currentFloor--;
            CheckLayerButtons();
            RefreshMap();
        }

        private void btn_AddNewSmartTile_Click(object sender, EventArgs e)
        {
            NewSmartTile newTile = new NewSmartTile();

            if (newTile.ShowDialog() == DialogResult.OK)
            {
                pallette.Add(newTile.newTileName, 
                    new Tile(
                        newTile.tileImages[0],
                        newTile.tileImages[1],
                        newTile.tileImages[2],
                        newTile.tileImages[3],
                        newTile.tileImages[4],
                        newTile.tileImages[5],
                        newTile.tileImages[6],
                        newTile.tileImages[7],
                        newTile.tileImages[8],
                        newTile.tileImages[9],
                        newTile.tileImages[10],
                        newTile.tileImages[11],
                        newTile.tileImages[12],
                        newTile.tileImages[13],
                        newTile.tileImages[14],
                        newTile.tileImages[15]
                        ));

                UpdatePallete();
            }
        }

        private void btn_saveTileFile_Click(object sender, EventArgs e)
        {
            if (selectedTile != "Void" && selectedTile != "Walkable" && selectedTile != "Smart Wall" && selectedTile != "Enemy" && selectedTile != "Goal" && selectedTile != "Player Spawn")
            {
                FileManager.SaveTile(selectedTile,pallette[selectedTile]);
            }
            else
            {
                MessageBox.Show(selectedTile + " is a default tile so there is no need to save it. It will always be here.", "Selected Tile Can Not Be Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_loadTileFile_Click(object sender, EventArgs e)
        {
            string[] loadedTileString = FileManager.LoadTile();
            if (loadedTileString != null)
            {
                switch (loadedTileString[1])
                {
                    case "NORMAL":
                        {
                            pallette.Add(loadedTileString[0], new Tile(FileManager.LoadImageAbsolute(loadedTileString[2])));
                            break;
                        }
                    case "SMART":
                        {
                            string[] images = loadedTileString[2].Split('|');
                            pallette.Add(loadedTileString[0], new Tile(
                                FileManager.LoadImageAbsolute(images[0]),
                                FileManager.LoadImageAbsolute(images[1]),
                                FileManager.LoadImageAbsolute(images[2]),
                                FileManager.LoadImageAbsolute(images[3]),
                                FileManager.LoadImageAbsolute(images[4]),
                                FileManager.LoadImageAbsolute(images[5]),
                                FileManager.LoadImageAbsolute(images[6]),
                                FileManager.LoadImageAbsolute(images[7]),
                                FileManager.LoadImageAbsolute(images[8]),
                                FileManager.LoadImageAbsolute(images[9]),
                                FileManager.LoadImageAbsolute(images[10]),
                                FileManager.LoadImageAbsolute(images[11]),
                                FileManager.LoadImageAbsolute(images[12]),
                                FileManager.LoadImageAbsolute(images[13]),
                                FileManager.LoadImageAbsolute(images[14]),
                                FileManager.LoadImageAbsolute(images[15])
                                ));
                            break;
                        }
                }
                UpdatePallete();
            }            
        }

        private void btn_AddNewRandomTile_Click(object sender, EventArgs e)
        {
            NewRandomTile newTile = new NewRandomTile();

            if (newTile.ShowDialog() == DialogResult.OK)
            {
                List<ImageLoad> images = new List<ImageLoad>();
                foreach (var i in newTile.images)
                    images.Add(FileManager.LoadImageAbsolute(i.Value));
                pallette.Add(newTile.newTileName.Trim(),new Tile(images));

                UpdatePallete();
            }
        }

        private void buildJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.BuildJSON(mapName, width, height, mapData.Count, pallette, mapData);
        }

        private void btn_BrushToggle_Click(object sender, EventArgs e)
        {
            bucket = !bucket;
            if (bucket)
                btn_BrushToggle.Text = "Fill";
            else
                btn_BrushToggle.Text = "Paint";
        }

        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDown = false;
        }
        #endregion
    }
}
