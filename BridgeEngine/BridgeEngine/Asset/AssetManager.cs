using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BridgeEngine.Maps;
using System.IO;
using BridgeEngine.Maps.Tiles;

namespace BridgeEngine.Asset
{
    public class AssetManager : Module
    {
        public static String name = "AssetManager";
        private ContentManager content;
        Texture2D onePixelTexture;
        SpriteFont defaultFont;

        public AssetManager(bool enabled, ContentManager content) : base(name, enabled)
        {
            this.content = content;
            onePixelTexture = LoadTexture("Images/1px");
            defaultFont = LoadFont("Fonts/General");
        }

        public SpriteFont LoadFont(string name)
        {
            return content.Load<SpriteFont>(name);
        }

        public Texture2D LoadTexture(string name)
        {
            return content.Load<Texture2D>(name);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
        }

        public ContentManager GetContentManager()
        {
            return content; 
        }

        public Map LoadMap(string mapFileName)
        {
            string mapFile = "";
            using (StreamReader sr = new StreamReader(mapFileName))
            {
                mapFile = sr.ReadToEnd();
                sr.Close();
            }

            Dictionary<string, string> mapData = new Dictionary<string, string>();
            string[] mapfiles = mapFile.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string map in mapfiles)
            {
                mapData.Add(map.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0], map.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            string name = mapData["name"];
            string tilesheet = mapData["tilesheet"];
            int id = int.Parse(mapData["id"]);
            int up = int.Parse(mapData["up"]);
            int down = int.Parse(mapData["down"]);
            int right = int.Parse(mapData["right"]);
            int left = int.Parse(mapData["left"]);

            List<Layer> layers = new List<Layer>();

            string layerData = mapData["layers"];
            string[] strLayers = layerData.Split(new string[] { "`" }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string layer in strLayers)
            {
                string layerTypeStr = layer.Split(new string[] { "$" }, StringSplitOptions.RemoveEmptyEntries)[0];
                string layerTileData = layer.Split(new string[] { "$" }, StringSplitOptions.RemoveEmptyEntries)[1];
                LayerType layerType = LayerType.FromId(int.Parse(layerTypeStr));

                string[] tiles = layerTileData.Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                List<List<Tile>> finalTiles = new List<List<Tile>>();
                for (int y = 0; y < Map.MAPHEIGHT; y++)
                {
                    finalTiles.Add(new List<Tile>());
                    for (int x = 0; x < Map.MAPWIDTH; x++)
                    {
                        int tileType = int.Parse(tiles[y + x].Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        string tileData = tiles[y + x].Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        switch (tileType)
                        {
                            case 0:
                                finalTiles[y].Add(new StandardTile(tileData));
                                break;
                            case 1:
                                finalTiles[y].Add(new AnimatedTile(tileData));
                                break;
                            case 2:
                                //House Tile
                                break;                                
                        }
                        
                    }
                }         
                layers.Add(new Layer(layerType, finalTiles));


            }
            //layers: 0$tiledata 

            return new Map(name, id, content.Load<Texture2D>("Images/Tilesheets/"+ tilesheet), up, down, left, right, layers);
        }

        public override void Update(GameTime gameTime)
        {
        }

        public Texture2D Get1PXTexure()
        {
            return onePixelTexture;
        }

        public SpriteFont GetDefaultFont()
        {
            return defaultFont;
        }
    }
}
