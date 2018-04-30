using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BridgeEngine
{
    public abstract class Module
    {
        private string name;
        private bool enabled = false;
        public Module(string name)
        {
            this.name = name;
            enabled = true;
        }

        public Module(string name, bool enabled)
        {
            this.name = name;
            this.enabled = enabled;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public void Disable()
        {
            enabled = false;
        }

        public void Enable()
        {
            enabled = true;
        }

        public String GetName()
        {
            return name;
        }


        public bool IsEnabled()
        {
            return enabled;
        }

        
      
    }
}