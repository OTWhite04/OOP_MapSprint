using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MapSystemSprint_Owen
{
    /// <summary>
    /// The script for reading symbols from a text file and turning them into a tilemap,
    /// and generates the string of the map to keep it simple.
    /// </summary>
    internal class Tilemap
    {
        //Integers for the map width and height.
        int mapHeight;
        int mapWidth;

        
        public TileBase Wall;
        public TileBase Ground;


        //List for holding Tiles.
        public List<TileBase> TileMap;


        private string levelPath = $"Content/Level1.txt";
        Vector2 Cellposition;

        //declaring a character array and passing parameters into it.
        char walls = '%';
        char ground = '@';

        //Creating the x and y sizes of the map
        int width;
        int height;
        char[,] Map;

        //Tilemap constructor.
        public Tilemap()
        {
            TileMap = new List<TileBase>();
            Map = LoadPremadeMap(levelPath);
            SymbolsToTiles(Map);
        }



        //The method for generating the string of the map.
        void GenerateMap(int width, int height)
        {

            //Runs for every iteration of inside width loop and draws the width.
            for (int y = 0; y < height; y++)
            {
                //runs for every iteration of the outer height loop.
                for (int x = 0; x < width; x++)
                {
                    
                    Map[x, y] = ground;

                    //conditional statement/rule that generates walls around the border of the play area.
                    if (x == width - 1 || y == height - 1 || y == 0 || x == 0)
                    {
                        //Assigns and draws the wall characters around the borders of the ground.
                        Map[x, y] = walls;
                    }

                }

            }

        }

        //Method for drawing the tilemap by using a for each loop.
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (TileBase tile in TileMap)
            {
                Draw(spriteBatch);
            }

        }


        //Method for converting the symbols to the tiles.
        public void SymbolsToTiles(char[,] Map)
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    char symbol = Map[x, y];

                    switch (symbol)
                    {
                        case '%':
                            TileMap.Add(new WallTile(TileManager.wallTexture));
                            break;

                        case '@':
                            TileMap.Add(new GroundTile(TileManager.groundTexture));
                            break;




                    }
                }

            }


        }

        //Assigning a character to the multidimensional array's width and height.
        public char[,] multidimensionalArray = new char[15, 10];

        //Method that loads a premade map from a text file.
        public char[,] LoadPremadeMap(string MyPath)
        {

            //Allows the text file to be read.
            string[] myLines = File.ReadAllLines(MyPath);

            //Looping through an array giving the length and width of the map to the text file.
            for (int y = 0; y < myLines.Length; y++)
            {
                for (int x = 0; x < myLines[y].Length; x++)
                {
                    //Appends each character of the map to a string.
                    char symbol = myLines[y][x];
                    Map[x, y] = symbol;
                }
            }

            return Map;

        }

    }

    //Class for the tilebase that can be inherited from the map tiles.
    public abstract class TileBase
    {
        public TileBase(Texture2D texture)
        {
            sprite = texture;
        }

        private int height = 16;
        public Rectangle rectangle;

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        private int width = 16;

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public Texture2D sprite
        {
            get { return sprite; }
            private set { sprite = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, rectangle, Color.White);
        }

    }

    public class WallTile : TileBase
    {
        public WallTile(Texture2D texture) : base(texture)
        {
        }
    }

    public class GroundTile : TileBase
    {
        public GroundTile(Texture2D texture) : base(texture)
        {
        }
    }

}
