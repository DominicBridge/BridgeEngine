using BridgeEngine.Asset;
using BridgeEngine.Characters.Parts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeEngine.Helpers;

namespace BridgeEngine.Characters
{
    public abstract class Entity
    {
        protected int id;
        protected string name;
        protected Vector2 position;
        protected int drawHeight;
        protected int drawWidth;

        private AssetManager assetManager;
        protected Body Body { get; set; }
        public Entity(AssetManager assetManager)
        {
            this.assetManager = assetManager;
            Body = Body.LIGHT;
            Body.ReloadTextures(assetManager);
        }

        public virtual void Update(SpriteBatch spriteBatch)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Body.Draw(spriteBatch, position, drawHeight, drawWidth, GetSourceRectangle());
        }

        public virtual Rectangle GetSourceRectangle()
        {
            return new Rectangle(0, 128, Body.DEFAULTWIDTH, Body.DEFAULTHEIGHT);
        }

        public void SetGender(Gender gender)
        {
            Body.Gender = gender;
        }

        public Body GetBody()
        {
            return Body;
        }

        public void SetBody(Body body)
        {
            this.Body = body;
            body.ReloadTextures(assetManager);
        }

        public int GetId()
        {
            return id;
        }
    }
}