using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.Display
{

    public class DisplayManager : Module
    {
        public static String name = "DisplayManager";
        private readonly GraphicsDevice graphicsDevice;
        private readonly GameWindow window;

        private int windowWidth;
        private int windowHeight;
        public DisplayManager(bool enabled, GraphicsDevice graphicsDevice, GameWindow window) : base(name, enabled)
        {
            this.graphicsDevice = graphicsDevice;
            this.window = window;
            window.ClientSizeChanged += WindowResized;
            windowHeight = window.ClientBounds.Height;
            windowWidth = window.ClientBounds.Width;
        }

        private void WindowResized(object sender, EventArgs e){
            windowWidth = window.ClientBounds.Width;
            windowHeight = window.ClientBounds.Height;
        }

        public Rectangle GetFullScreenRectangle()
        {
            return new Rectangle(0, 0, GetWindowWidth(), GetWindowHeight());
        }

        public Rectangle GetCenterRectangle(int width, int height)
        {
            return new Rectangle(GetCenterX() - (width / 2), GetCenterY() - (height / 2), width, height);
        }

        public int GetWindowWidth()
        {
            return windowWidth;
        }

        public int GetWindowHeight()
        {
            return windowHeight;
        }

        public int GetCenterX()
        {
            return GetWindowWidth() / 2;
        }


        public int GetCenterY()
        {
            return GetWindowHeight() / 2;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(GetCenterX(), GetCenterY());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}