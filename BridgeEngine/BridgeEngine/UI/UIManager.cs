using BridgeEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Input;

namespace BridgeEngine.UI
{
    public class UIManager : Module
    {
        public static string name = "UIManager";

        private List<UIComponent> components;
        private BridgeEngine bridgeEngine;
        
        public UIManager(BridgeEngine bridgeEngine, bool enabled) : base(name, enabled)
        {
            this.bridgeEngine = bridgeEngine;
            components = new List<UIComponent>();
        }

        public void AddUIComponent(UIComponent component)
        {
            components.Add(component);
        }

        public void AddUIComponents(params UIComponent[] component)
        {
            foreach(UIComponent comp in component)
                components.Add(comp);
        }

        public void ClearComponents()
        {
            components.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            InputManager inputManager = bridgeEngine.GetInputManager();

            if (inputManager.HasLeftClicked())
            {
                ClearFocus();

                foreach (UIComponent c in components)
                {
                    if (c.GetPosition().Contains(inputManager.GetMousePosition()) && c.GetType() != typeof(Frame))
                    {
                        c.SetFocus(true);
                        break;
                    }
                }
            }

            for (int i = 0; i < components.Count; i ++)//
            {
                if (components[i].HasFocus())
                    components[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (UIComponent c in components)
            {
                c.Draw(spriteBatch);
            }
        }

        public void ClearFocus()
        {
            components.ForEach(c => c.SetFocus(false));
        }

        public UIComponent FindComponentWithFocus()
        {
            foreach(UIComponent component in components)
            {
                if (component.HasFocus())
                    return component;
            }
            return null;
        }
        public void EnteredKey(Char c)
        {
            UIComponent focussed = FindComponentWithFocus();
            if(focussed!= null)
            {
                if(focussed.GetType() == typeof(TextBox)){                    
                    TextBox textBox = focussed as TextBox;

                    switch (c)
                    {
                        case (char)8:
                            textBox.Backspace();
                            break;

                        case (char)13:
                            textBox.OnEnterPressed();
                            break;

                        case (char)9:
                            textBox.OnTabPressed();
                            break;
                        default:
                            textBox.AddToText(c.ToString());
                            break;
                    }             
                }
            }
        }
    }
}
