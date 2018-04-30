using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeEngine.Asset;
using BridgeEngine.Characters.Parts;
using Microsoft.Xna.Framework;

namespace BridgeEngine.Characters
{
    public class Character : Entity
    {              
        public Character(AssetManager assetManager, Gender gender, Body body, Eyes eyes, Ears ears, Nose nose, string name, int id ) : base(assetManager)
        {
            Body = new Body(body, gender, eyes, ears, nose);
            this.name = name;
            body.ReloadTextures(assetManager);
            this.id = id;
        }

        public Character(AssetManager assetManager, Gender gender, Body body, Eyes eyes, Ears ears, Nose nose, Vector2 position) : base(assetManager)
        {
            this.position = position;
            drawHeight = Body.DEFAULTHEIGHT;
            drawWidth = Body.DEFAULTWIDTH;
            
        }


        public Character(AssetManager assetManager, Gender gender, Body body, Eyes eyes, Ears ears, Nose nose, Rectangle position) : base(assetManager)
        {       
            this.position = new Vector2(position.X, position.Y);
            drawHeight = position.Height;
            drawWidth = position.Width;         
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string v)
        {
            name = v;
        }

        public void SetPosition(Rectangle position)
        {
            this.position = new Vector2(position.X, position.Y);
            this.drawHeight = position.Height;
            this.drawWidth = position.Width;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
