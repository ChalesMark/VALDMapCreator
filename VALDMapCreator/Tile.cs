using System;
using System.Collections.Generic;
using System.Drawing;

namespace VALDMapCreator
{
    public class ImageLoad
    {
        public ImageLoad(Image _image, string _path)
        {
            image = _image;
            path = _path;
        }

        public Image image;
        public string path;
    }

    public enum TileType { Normal, Smart, Random }
    public enum SmartType { Horizontal,Vertical,Island,Surrounded,Corner0,Corner1,Corner2,Corner3,Fork0,Fork1,Fork2,Fork3,EndDown,EndUp,EndRight,EndLeft }
    class Tile
    {
        TileType tileType;
        private Image image;
        private List<string> imageFilePaths;

        public List<string> GetImageFilePaths()
        {
            return imageFilePaths;
        }

        public TileType GetTileType()
        {
            return tileType;
        }

        public Tile(ImageLoad i)
        {
            tileType = TileType.Normal;
            image = i.image;
            imageFilePaths = new List<string>() { i.path};
        }

        public Image GetImage()
        {
            if (tileType == TileType.Normal)
                return image;
            return null;
        }

        private Image horizontal, vertical, island, surrounded, corner0, corner1, corner2, corner3, fork0, fork1, fork2, fork3, endDown, endUp, endRight, endLeft;

        public Tile(ImageLoad h, ImageLoad v, ImageLoad i, ImageLoad s, ImageLoad c0, ImageLoad c1, ImageLoad c2, ImageLoad c3, ImageLoad f0, ImageLoad f1, ImageLoad f2, ImageLoad f3, ImageLoad ed, ImageLoad eu, ImageLoad er, ImageLoad el)
        {
            tileType = TileType.Smart;
            imageFilePaths = new List<string>();

            horizontal = h.image;
            imageFilePaths.Add(h.path);
            vertical = v.image;
            imageFilePaths.Add(v.path);
            island = i.image;
            imageFilePaths.Add(i.path);
            surrounded = s.image;
            imageFilePaths.Add(s.path);
            corner0 = c0.image;
            imageFilePaths.Add(c0.path);
            corner1 = c1.image;
            imageFilePaths.Add(c1.path);
            corner2 = c2.image;
            imageFilePaths.Add(c2.path);
            corner3 = c3.image;
            imageFilePaths.Add(c3.path);
            fork0 = f0.image;
            imageFilePaths.Add(f0.path);
            fork1 = f1.image;
            imageFilePaths.Add(f1.path);
            fork2 = f2.image;
            imageFilePaths.Add(f2.path);
            fork3 = f3.image;
            imageFilePaths.Add(f3.path);
            endDown = ed.image;
            imageFilePaths.Add(ed.path);
            endUp = eu.image;
            imageFilePaths.Add(eu.path);
            endRight = er.image;
            imageFilePaths.Add(er.path);
            endLeft = el.image;
            imageFilePaths.Add(el.path);
        }

        public Image GetSmartImage(SmartType smartType)
        {
            if (tileType == TileType.Smart)
                switch (smartType)
                {
                    case (SmartType.Horizontal):
                        {
                            return horizontal;
                        }
                    case (SmartType.Vertical):
                        {
                            return vertical;
                        }
                    case (SmartType.Island):
                        {
                            return island;
                        }
                    case (SmartType.Surrounded):
                        {
                            return surrounded;
                        }

                    case (SmartType.Corner0):
                        {
                            return corner0;
                        }
                    case (SmartType.Corner1):
                        {
                            return corner1;
                        }
                    case (SmartType.Corner2):
                        {
                            return corner2;
                        }
                    case (SmartType.Corner3):
                        {
                            return corner3;
                        }

                    case (SmartType.Fork0):
                        {
                            return fork0;
                        }
                    case (SmartType.Fork1):
                        {
                            return fork1;
                        }
                    case (SmartType.Fork2):
                        {
                            return fork2;
                        }
                    case (SmartType.Fork3):
                        {
                            return fork3;
                        }

                    case (SmartType.EndDown):
                        {
                            return endDown;
                        }
                    case (SmartType.EndUp):
                        {
                            return endUp;
                        }
                    case (SmartType.EndLeft):
                        {
                            return endLeft;
                        }
                    case (SmartType.EndRight):
                        {
                            return endRight;
                        }
                }
            return null;
        }

        private List<Image> randomList;

        public Tile(List<ImageLoad> l)
        {
            tileType = TileType.Random;
            randomList = new List<Image>();

            imageFilePaths = new List<string>();
            foreach (var i in l)
            {
                randomList.Add(i.image);
                imageFilePaths.Add(i.path);
            }
        }

        public Image GetRandomImage()
        {
            if (tileType == TileType.Random)
                return randomList[new Random().Next(0, randomList.Count)];
            return null;
        }
    }
}
