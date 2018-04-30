using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.Cameras
{
    public abstract class Camera
    {
        public static readonly int TILEWIDTH = 32;
        public static readonly int TILEHEIGHT = 32;

        protected float zoom = 1f;

        protected int height;
        protected int width;
                
        public abstract void Update(GameTime gameTime);        
        public abstract void Draw(SpriteBatch spriteBatch);

        public int TilesToDrawX()
        {
            return width / (int)(zoom * TILEWIDTH);
        }

        public int TilesToDrawY()
        {
            return height / (int)(zoom * TILEHEIGHT);
        }

        public int GetDrawSize()
        {
            return (int)(zoom* TILEWIDTH);
        }
    }
}
