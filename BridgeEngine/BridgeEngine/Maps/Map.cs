using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BridgeEngine.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BridgeEngine.Cameras;

namespace BridgeEngine.Maps
{
    public class Map
    {
        public static readonly int MAPWIDTH = 64;
        public static readonly int MAPHEIGHT= 64;

        private string name;
        private int id;
        private Texture2D tilesheet;

        private int up, down, left, right;
        
        List<Layer> layers = new List<Layer>();     

        public Map(string name, int id, Texture2D tilesheet, int up, int down, int left, int right, List<Layer> layers)
        {
            this.name = name;
            this.id = id;
            this.tilesheet = tilesheet;
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;

            this.layers = layers;
        }

        public void Draw(SpriteBatch spriteBatch, CameraManager cameraManager)
        {
            foreach(Layer layer in layers)
            {
                layer.Draw(spriteBatch, cameraManager, tilesheet);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Layer layer in layers)
            {
                layer.Update(gameTime);
            }
        }        
    }
}
