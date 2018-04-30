using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeEngine.Cameras;
using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.Maps.Tiles
{
    public class StandardTile : Tile
    {
        int tileNumber;

        public StandardTile(string data)
        {
            tileNumber = int.Parse(data);
        }
        public override void Draw(SpriteBatch spriteBatch, CameraManager cameraManager, Texture2D tilesheet, Rectangle position)
        {
            spriteBatch.Draw(tilesheet, position, GetSourceRectangle(tilesheet,tileNumber), Color.White);

        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
