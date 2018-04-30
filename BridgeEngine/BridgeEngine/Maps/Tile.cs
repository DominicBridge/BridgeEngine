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
    public abstract class Tile
    {
        public abstract void Draw(SpriteBatch spriteBatch, CameraManager cameraManager, Texture2D tilesheet, Rectangle position);
        public abstract void Update(GameTime gameTime);

        public virtual Rectangle GetSourceRectangle(Texture2D texture, int i)
        {
            int x = (i % (texture.Width / 32)) * 32;
            int y = (i / (texture.Width / 32) * 32);
            return new Rectangle(x,y, 32, 32);
        }
    }
}
