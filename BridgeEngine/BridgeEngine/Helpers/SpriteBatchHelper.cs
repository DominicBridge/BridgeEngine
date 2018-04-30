using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Helpers
{
    public static class SpriteBatchHelper
    {
        public static void DrawBackground(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Rectangle sourceRect, Color color)
        {
            spriteBatch.Draw(texture, position, sourceRect, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public static void DrawBackground(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Color color)
        {
            spriteBatch.Draw(texture, position, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public static void DrawBackground(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position2, Color color)
        {
            spriteBatch.Draw(texture, position2, null, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            
        }

        public static void DrawAtBack(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Rectangle sourceRect, Color color)
        {
            spriteBatch.Draw(texture, position, sourceRect, color, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
        }

        public static void DrawAtBack(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Color color)
        {
            spriteBatch.Draw(texture, position, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
        }

        public static void DrawDefaultUI(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Rectangle sourceRect, Color color)
        {
            spriteBatch.Draw(texture, position, sourceRect, color, 0f, Vector2.Zero, SpriteEffects.None, 0.8f);
        }

        public static void DrawDefaultUI(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Color color)
        {
            spriteBatch.Draw(texture, position, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.8f);
        }

        public static void DrawUIText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, text, position, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.81f);
        }

        public static void DrawDefault(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Color color)
        {
            spriteBatch.Draw(texture, position, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
        }

        public static void DrawDefault(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Rectangle sourceRect, Color color)
        {
            spriteBatch.Draw(texture, position, sourceRectangle: sourceRect, color: color, rotation: 0f, origin: Vector2.Zero, effects: SpriteEffects.None, layerDepth: 0.5f);
        }

        public static void DrawDefaultAddition(this SpriteBatch spriteBatch, Texture2D texture, Rectangle position, Rectangle sourceRect, Color color, float addition)
        {
            spriteBatch.Draw(texture, position, sourceRectangle: sourceRect, color: color, rotation: 0f, origin: Vector2.Zero, effects: SpriteEffects.None, layerDepth: 0.5f + addition);
        }

        public static void DrawBorderString(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color color, int borderThickness, Color borderColor, float layer)
        {
            spriteBatch.DrawString(font, text, position, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer);
            Vector2 borderposition = new Vector2(position.X - borderThickness, position.Y - borderThickness);            
            spriteBatch.DrawString(font, text, borderposition, borderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer - 0.1f);
            borderposition = new Vector2(position.X - borderThickness, position.Y + borderThickness);
            spriteBatch.DrawString(font, text, borderposition, borderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer - 0.1f);
            borderposition = new Vector2(position.X + borderThickness, position.Y - borderThickness);
            spriteBatch.DrawString(font, text, borderposition, borderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer - 0.1f);
            borderposition = new Vector2(position.X + borderThickness, position.Y + borderThickness);
            spriteBatch.DrawString(font, text, borderposition, borderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer - 0.1f);
        }
    }
}
