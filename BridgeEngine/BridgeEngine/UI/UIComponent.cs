using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.UI
{
    public abstract class UIComponent
    {
        protected Color backgroundColor = Color.White;
        protected Color foregroundColor = Color.Black;

        protected string text = "";
        protected Vector2 textPosition;
        protected int borderThickness = 2;
        protected Color borderColor = Color.Black;

        protected bool hasFocus = false;
        protected Rectangle position;
        protected Rectangle borderPosition;

        protected BridgeEngine bridgeEngine;
        public UIComponent(BridgeEngine bridgeEngine)
        {
            this.bridgeEngine = bridgeEngine;

        }

        public bool HasFocus()
        {
            return hasFocus;
        }

        public virtual void SetFocus(bool focus)
        {
            hasFocus = focus;
        }

        public Rectangle GetPosition()
        {
            return position;
        }

        public abstract void Update(GameTime gameTime);

        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, position);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Rectangle position)
        {
            Texture2D tex = bridgeEngine.GetAssetManager().Get1PXTexure();
            SpriteFont font = bridgeEngine.GetAssetManager().GetDefaultFont();

            if (!String.IsNullOrEmpty(text))
            {
                RecalcTextPosition(font);
            }

            borderPosition = position;
            borderPosition.Inflate(borderThickness, borderThickness);

            if(borderThickness > 0)
                DrawBorder(spriteBatch);
            
            spriteBatch.DrawDefaultUI(tex, position, backgroundColor);

            if (!String.IsNullOrEmpty(text))
                spriteBatch.DrawUIText(font, text, textPosition, foregroundColor);
        }

        private void DrawBorder(SpriteBatch spriteBatch)
        {
            Texture2D tex = bridgeEngine.GetAssetManager().Get1PXTexure();
            spriteBatch.DrawDefaultUI(tex, new Rectangle(position.X - borderThickness, position.Y - borderThickness, position.Width + (borderThickness * 2), borderThickness), borderColor);
            spriteBatch.DrawDefaultUI(tex, new Rectangle(position.X - borderThickness, position.Y + position.Height, position.Width + (borderThickness * 2), borderThickness), borderColor);
            spriteBatch.DrawDefaultUI(tex, new Rectangle(position.X - borderThickness, position.Y, borderThickness, position.Height), borderColor);
            spriteBatch.DrawDefaultUI(tex, new Rectangle(position.X + position.Width, position.Y, borderThickness, position.Height), borderColor);
        }

        public void RecalcTextPosition(SpriteFont font)
        {
            textPosition = new Vector2(position.X + 3,(position.Y + position.Height / 2) - font.MeasureString(text).Y / 2 );
        }
    }
}