using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.UI
{
    public class Window : UIComponent
    {
        private List<UIComponent> components;

        public Window(BridgeEngine bridgeEngine, params UIComponent[] components) : base(bridgeEngine)
        {
            this.components = new List<UIComponent>();
            this.components.AddRange(components);
        }

        public override void Update(GameTime gameTime)
        {
            if (hasFocus)
            {              
                foreach (UIComponent c in components)
                {
                    if (c.GetPosition().Contains(bridgeEngine.GetInputManager().GetMousePosition()) && c.GetType() != typeof(Frame))
                    {
                        c.SetFocus(true);
                        break;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Draw(spriteBatch, new Rectangle(position.X +components[i].GetPosition().X, position.Y + components[i].GetPosition().Y, components[i].GetPosition().Width, components[i].GetPosition().Height));
            }
        }

        public override void SetFocus(bool focus)
        {
            if (!focus)
            {
                components.ForEach(c => c.SetFocus(focus));
            }
            hasFocus = focus;
        }
    }
}
