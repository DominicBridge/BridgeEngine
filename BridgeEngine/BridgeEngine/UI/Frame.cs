using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BridgeEngine.Helpers;

namespace BridgeEngine.UI
{
    public class Frame : UIComponent
    {

        
        Color outerBorderColor;
        int outerBorderThickness;
        
        Rectangle borderRectangle;
        Texture2D texture;
        public Frame(BridgeEngine bridgeEngine, Rectangle position, Color color, Color borderColor, int borderThickness, Color outerBorderColor, int outerBorderThickness) : base(bridgeEngine)
        {
            this.position = position;
            backgroundColor = color;
            this.borderColor = borderColor;
            this.borderThickness = borderThickness;
            this.outerBorderThickness = outerBorderThickness;
            this.outerBorderColor = outerBorderColor;
            texture = bridgeEngine.GetAssetManager().Get1PXTexure();

            CalculateBorderPositions(position, borderThickness, outerBorderThickness);
        }

        public Frame(BridgeEngine bridgeEngine, Rectangle position, Color color, Color borderColor, int borderThickness): base(bridgeEngine)
        {
            this.position = position;
            backgroundColor = color;
            this.borderColor = borderColor;
            this.borderThickness = borderThickness;
            texture = bridgeEngine.GetAssetManager().Get1PXTexure();

            CalculateBorderPositions(position, borderThickness, outerBorderThickness);
        }

        private void CalculateBorderPositions(Rectangle position, int borderThickness, int outerBorderThickness)
        {
            borderRectangle = position;
            borderRectangle.Inflate(borderThickness, borderThickness);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawOuterBorder(spriteBatch);
            DrawBorder(spriteBatch);
            spriteBatch.DrawAtBack(texture, position, backgroundColor);
        }

        private void DrawOuterBorder(SpriteBatch spriteBatch)
        {
            if (outerBorderThickness == 0 || outerBorderColor == null)
                return;


            Rectangle temp = position;
            temp.Inflate(borderThickness, borderThickness);

            spriteBatch.DrawAtBack(texture, new Rectangle(position.X - outerBorderThickness, position.Y - outerBorderThickness, position.Width + (outerBorderThickness * 2), outerBorderThickness), outerBorderColor);
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X - outerBorderThickness, position.Y + position.Height, position.Width + (outerBorderThickness * 2), outerBorderThickness), outerBorderColor);
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X - outerBorderThickness, position.Y, outerBorderThickness, position.Height), outerBorderColor);
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X + position.Width, position.Y, outerBorderThickness, position.Height), outerBorderColor);
        }

        private void DrawBorder(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X - borderThickness, position.Y - borderThickness, position.Width + (borderThickness * 2), borderThickness), borderColor);
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X - borderThickness, position.Y + position.Height, position.Width + (borderThickness * 2), borderThickness), borderColor);
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X - borderThickness, position.Y, borderThickness, position.Height), borderColor);
            spriteBatch.DrawAtBack(texture, new Rectangle(position.X + position.Width, position.Y, borderThickness, position.Height), borderColor);
        }

        public override void Update(GameTime gameTime){}

        public void SetOuterBorderThickness(int v)
        {
            outerBorderThickness = v;
        }
    }
}
