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
    public class AnimatedTile : Tile
    {

        private List<int> sequence = new List<int>();
        private int index;
        private double elapsed;
        private double delay;
        public AnimatedTile(string mapData)
        {
            //1,2,3,4%500
            delay = double.Parse(mapData.Split(new string[] { "%" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            string[] animatedTiles = mapData.Split(new string[] { "%" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tile in animatedTiles)
                sequence.Add(int.Parse(tile));
        }

        public override void Draw(SpriteBatch spriteBatch, CameraManager cameraManager, Texture2D tilesheet, Rectangle position)
        {
            spriteBatch.Draw(tilesheet, position, GetSourceRectangle(tilesheet, sequence[index]), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                index++;
                if (index >= sequence.Count)
                    index = 0;
                elapsed = 0;
            }
        }
    }
}
