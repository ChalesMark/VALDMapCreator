using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VALDMapCreator
{
    class JSONTileData
    {
        public int x, y, f,i;
        public string mod;
        public JSONTileData(int _x, int _y, int _f, int _i, string _mod)
        {
            x = _x;
            y = _y;
            f = _f;
            i = _i;
            mod = _mod;
        }
    }

    static class FileManager
    {
        static public void SaveTile(string selectedTile, Tile tile)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to save " + selectedTile + "?", "Confirm Save", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string file = selectedTile + "\n";
                switch (tile.GetTileType())
                {
                    case TileType.Normal:
                        {
                            file += "NORMAL\n" + tile.GetImageFilePaths()[0];
                            break;
                        }
                    case TileType.Random:
                        {
                            file += "RANDOM\n" + string.Join("|", tile.GetImageFilePaths());
                            break;
                        }
                    case TileType.Smart:
                        {
                            file += "SMART\n" + string.Join("|", tile.GetImageFilePaths());
                            break;
                        }
                }

                System.IO.FileInfo path = new System.IO.FileInfo("Tiles\\" + selectedTile + ".valdTile");
                path.Directory.Create();
                File.WriteAllText(path.FullName, file);
            }
        }

        static public string[] LoadTile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Browse VALD Tile Files";
            openFile.Filter = "vald tile files (*.valdTile)|*.valdTile";
            openFile.InitialDirectory = Directory.GetCurrentDirectory()+ "\\Tiles";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                List<string> file = new List<string>();
                foreach (var l in File.ReadLines(openFile.FileName))
                {
                    file.Add(l);
                }
                return file.ToArray();
            }

            return null;
        }

        static public ImageLoad LoadResImage(string path)
        {
            string properPath = Directory.GetCurrentDirectory() + path;
            if (File.Exists(properPath)) {
                return new ImageLoad(new Bitmap(properPath), path);
            }
            return null;                      
        }

        static public ImageLoad LoadResImageButReturnAbsolute(string path)
        {
            string properPath = Directory.GetCurrentDirectory() + path;
            if (File.Exists(properPath))
            {
                return new ImageLoad(new Bitmap(properPath), properPath);
            }
            return null;
        }

        static public ImageLoad LoadImageAbsolute(string path)
        {
            if (File.Exists(path))
            {
                return new ImageLoad(new Bitmap(path), path);
            }
            else
            {
                MessageBox.Show(path + "\nThe image for this tile is no longer in its original location.\nIt might have been moved or deleted. A new replacement file has been created.", "Image missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string missing = Directory.GetCurrentDirectory() + "\\Res\\Question.bmp";
                if (File.Exists(missing))
                {
                    Bitmap replacement = new Bitmap(missing);
                    Bitmap newIcon = new Bitmap(32, 32);
                    using (Graphics g = Graphics.FromImage(newIcon))
                    {
                        g.DrawImage(replacement, new Point(0, 0));
                    }
                    replacement.Dispose();
                    newIcon.Save(path);
                    return new ImageLoad(new Bitmap(path), path);
                }
                else
                    return null; ;
            }
        }

        static public void BuildVALD(string name,int width, int height,int floors, Dictionary<string, Tile> pallette,List<Dictionary<Point, string>> mapData)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to build " + name + "?", "Confirm Build", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string file = name.Trim() + "," + width.ToString() + "," + height.ToString() + "," + floors + "\n";

                List<string> palletteStringed = new List<string>();
                Dictionary<string, int> palletteNum = new Dictionary<string, int>();
                int counter = 0;
                foreach (var p in pallette)
                {
                    palletteStringed.Add(p.Key + "," + counter);
                    palletteNum.Add(p.Key, counter);
                    counter++;
                }

                file += String.Join(".", palletteStringed.ToArray()) + "\n";

                List<string> allTiles = new List<string>();
                int floorCounter = 0;
                foreach (var floor in mapData)
                {
                    foreach (var tile in floor)
                    {
                        if (!tile.Value.Equals("Void"))
                        {
                            string modification = "NOR";
                            switch (pallette[tile.Value].GetTileType())
                            {
                                case (TileType.Smart):
                                    {
                                        modification = GetSmartType(tile.Key, tile.Value, floor);
                                        break;
                                    }
                            }

                            allTiles.Add(palletteNum[tile.Value] + "," + modification + "," + floorCounter + "," + tile.Key.X + "," + tile.Key.Y);
                        }
                    }
                    floorCounter++;
                }

                file += String.Join(".", allTiles.ToArray());

                System.IO.FileInfo path = new System.IO.FileInfo("Build\\" + name + ".vald");
                path.Directory.Create();
                File.WriteAllText(path.FullName, file);
            }
        }

        static public void BuildJSON(string name, int width, int height, int floors, Dictionary<string, Tile> pallette, List<Dictionary<Point, string>> mapData)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to build " + name + "?", "Confirm Build", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Dictionary<string,int> palletteDictionary = new Dictionary<string,int>();
                for (int i = 0; i < pallette.Count; i++)
                    palletteDictionary.Add(pallette.ElementAt(i).Key,i);

                List<JSONTileData> tiles = new List<JSONTileData>();
                int floorCounter = 0;
                foreach (var floor in mapData)
                {
                    foreach (var tile in floor)
                    {
                        if (!tile.Value.Equals("Void"))
                        {
                            string modification = "NOR";
                            switch (pallette[tile.Value].GetTileType())
                            {
                                case (TileType.Smart):
                                    {
                                        modification = GetSmartType(tile.Key, tile.Value, floor);
                                        break;
                                    }
                            }

                            tiles.Add(new JSONTileData(tile.Key.X,tile.Key.Y,floorCounter, palletteDictionary[tile.Value],modification));
                        }
                    }
                    floorCounter++;
                }

                JObject file = new JObject();
                file.Add(new JProperty("Map Name", name));
                file.Add(new JProperty("Width", width));
                file.Add(new JProperty("Height", height));
                file.Add(new JProperty("Floors", floors));

                file.Add(new JProperty("Pallette",
                        new JArray(
                            from p in palletteDictionary
                            select new JObject(
                                new JProperty("Index", p.Key),
                                new JProperty("Name", p.Value)
                                )
                            )
                    ));

                file.Add(new JProperty("Tiles",
                        new JArray(
                            from m in tiles
                            select new JObject(
                                new JProperty("Position X", m.x),
                                new JProperty("Position Y", m.y),
                                new JProperty("Floor", m.f),
                                new JProperty("Tile Index", m.i),
                                new JProperty("Tile Type", m.mod)
                                )
                            )
                    ));

                System.IO.FileInfo path = new System.IO.FileInfo("Build\\" + name + ".JSON");
                path.Directory.Create();
                File.WriteAllText(path.FullName, JsonConvert.SerializeObject(file));
            }
        }

        public static void SaveVALDProjFile(string name, int width, int height, Dictionary<string, Tile> pallette, List<Dictionary<Point, string>> mapData)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to save the " + name + " project?", "Confirm Project Save", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string file = name + "|" + width + "|" + height + "|" + mapData.Count + "\n";

                List<string> tileImagePaths = new List<string>();
                foreach (var p in pallette.Skip(6))
                {
                    switch (p.Value.GetTileType())
                    {
                        case TileType.Smart:
                            {
                                List<string> imagePaths = p.Value.GetImageFilePaths();
                                tileImagePaths.Add(p.Key + "," + "SMART" + "," + string.Join("~", imagePaths.ToArray()));
                                break;
                            }
                        case TileType.Normal:
                            {
                                tileImagePaths.Add(p.Key + "," + "NORMAL" + "," + p.Value.GetImageFilePaths()[0]);
                                break;
                            }
                    }

                }
                file += string.Join("|", tileImagePaths) + "\n";

                List<string> tileInfo = new List<string>();
                int floorCounter = 0;
                foreach (var floor in mapData)
                {
                    foreach (var tile in floor)
                    {
                        if (!tile.Value.Equals("Void"))
                            tileInfo.Add(tile.Value + "," + tile.Key.X + "," + tile.Key.Y + "," + floorCounter);
                    }
                    floorCounter++;
                }
                file += string.Join(".", tileInfo) + "\n";

                System.IO.FileInfo path = new System.IO.FileInfo("Projects\\" + name + ".valdproj");
                path.Directory.Create();
                File.WriteAllText(path.FullName, file);
            }
        }

        public static string[] LoadVALDProjFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Browse VALD Project Files";
            openFile.Filter = "vald project files (*.valdproj)|*.valdproj";
            openFile.InitialDirectory = Directory.GetCurrentDirectory() + "\\Projects";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                List<string> file = new List<string>();
                foreach (var l in File.ReadLines(openFile.FileName))
                {
                    file.Add(l);
                }
                return file.ToArray();
            }

            return null;
        }

        private static string GetSmartType(Point value, string name,Dictionary<Point,string>floor)
        {
            bool up = false;
            bool down = false;
            bool right = false;
            bool left = false;

            if (floor.ContainsKey(new Point(value.X, value.Y - 1)) && floor[new Point(value.X, value.Y - 1)].Equals(name))
                up = true;
            if (floor.ContainsKey(new Point(value.X + 1, value.Y)) && floor[new Point(value.X + 1, value.Y)].Equals(name))
                right = true;
            if (floor.ContainsKey(new Point(value.X, value.Y + 1)) && floor[new Point(value.X, value.Y + 1)].Equals(name))
                down = true;
            if (floor.ContainsKey(new Point(value.X - 1, value.Y)) && floor[new Point(value.X - 1, value.Y)].Equals(name))
                left = true;

            if (up && down && right && left)
                return "SURROUNDED";
            else if (!up && !down && !right && !left)
                return "ISLAND";
            else if (up && down && !right && !left)
                return "VERTICAL";
            else if (!up && !down && right && left)
                return "HORZONTAL";

            else if (!up && down && !right && left)
                return "CORNER0";
            else if (up && !down && !right && left)
                return "CORNER1";
            else if (up && !down && right && !left)
                return "CORNER2";
            else if (!up && down && right && !left)
                return "CORNER3";

            else if (up && down && !right && left)
                return "FORK0";
            else if (up && !down && right && left)
                return "FORK1";
            else if (!up && down && right && left)
                return "FORK2";
            else if (up && down && right && !left)
                return "FORK3";

            else if (up && !down && !right && !left)
                return "ENDDOWN";
            else if (!up && down && !right && !left)
                return "ENDUP";
            else if (!up && !down && right && !left)
                return "ENDLEFT";
            else if (!up && !down && !right && left)
                return "ENDRIGHT";
            else
                return "ISLAND";
        }
    }
}
