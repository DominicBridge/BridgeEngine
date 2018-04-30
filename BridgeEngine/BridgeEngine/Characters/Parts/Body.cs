using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeEngine.Asset;

namespace BridgeEngine.Characters.Parts
{
    public class Body
    {
        public static readonly Body LIGHT = new Body("Light", 0, "light", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body DARK = new Body("Dark", 1, "dark", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body DARK2 = new Body("Dark 2", 2, "dark2", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body DARKELF = new Body("Dark Elf", 3, "darkelf", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body DARKELF2 = new Body("Dark Elf 2", 4, "darkelf2", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body ORC = new Body("Orc", 5, "orc", Gender.BOTH, new Eyes[] { }, new Ears[] { }, new Nose[] { });
        public static readonly Body REDORC = new Body("Red Orc", 6, "red_orc", Gender.BOTH, new Eyes[] { }, new Ears[] { }, new Nose[] { });
        public static readonly Body TANNED = new Body("Tanned", 7, "tanned", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body TANNED2 = new Body("Tanned 2", 8, "tanned2", Gender.BOTH, Eyes.Values.ToArray(), Ears.Values.ToArray(), Nose.Values.ToArray());
        public static readonly Body SKELETON = new Body("Skeleton", 9, "skeleton", Gender.MALE, new Eyes[] { Eyes.GLOWING }, new Ears[] { }, new Nose[] { });
        public static readonly int DEFAULTHEIGHT = 64;
        public static readonly int DEFAULTWIDTH = 64;

        private readonly string description;
        private readonly int id;
        private readonly string textureName;
        private readonly Gender gendersAvailable;
        public static readonly string path = "Images/Characters/body/";

        private Eyes[] availableEyes;
        private Ears[] availableEars;
        private Nose[] availableNoses;


        protected Gender gender = Gender.MALE;
        protected Ears ears = Ears.BIG;
        protected Eyes eyes = Eyes.BLUE;
        protected Nose nose = Nose.BUTTON;

        protected Texture2D bodyTexture;
        protected Texture2D earsTexture;
        protected Texture2D eyesTexture;
        protected Texture2D noseTexture;

        AssetManager assetManager;
        private Body body;

        public Gender Gender { get => gender; set => gender = value; }

        public Ears Ears
        {
            get => ears; set
            {
                ears = value;
                ReloadEarsTexture();
            }
        }
        public Eyes Eyes
        {
            get => eyes; set
            {
                eyes = value;
                ReloadEyesTexture();
            }
        }
        public Nose Nose
        {
            get => nose; set
            {
                nose = value;
                ReloadNoseTexture();
            }
        }

        public static IEnumerable<Body> Values
        {
            get
            {
                yield return LIGHT;
                yield return DARK;
                yield return DARK2;
                yield return DARKELF;
                yield return DARKELF2;
                yield return ORC;
                yield return REDORC;
                yield return TANNED;
                yield return TANNED2;
                yield return SKELETON;
            }
        }
        public Body(string description, int id, string textureName, Gender gendersAvailable, Eyes[] availableEyes, Ears[] availableEars, Nose[] availableNoses)
        {
            this.description = description;
            this.id = id;
            this.textureName = textureName;
            this.gendersAvailable = gendersAvailable;
            this.availableEars = availableEars;
            this.availableEyes = availableEyes;
            this.availableNoses = availableNoses;
            this.body = this;
            ReloadBody();
        }

        public Body(Body body, Gender gender, Eyes eyes, Ears ears, Nose nose)
        {
            this.body = body;
            availableEars = body.availableEars;
            availableEyes = body.availableEyes;
            availableNoses = body.availableNoses;
            this.gender = gender;
            this.eyes = eyes;
            this.ears = ears;
            this.nose = nose;
            ReloadBody();
        }

        public string GetDescription()
        {
            return description;
        }

        public int GetId()
        {
            return id;
        }

        public string GetTexturePath(Gender gender)
        {
            return path + gender.GetPathRoute() + textureName;
        }

        public string GetTextureName()
        {
            return textureName;
        }

        public virtual void ReloadTextures(AssetManager assetManager)
        {
            this.assetManager = assetManager;

            ReloadBody();
            ReloadBodyTexture();
            ReloadEarsTexture();
            ReloadEyesTexture();
            ReloadNoseTexture();
        }

        public Eyes[] GetAvailableEyes()
        {
            return availableEyes;
        }

        public void SetEyes(Eyes eyes)
        {
            Eyes = eyes;
        }

        public Ears[] GetAvailableEars()
        {
            return availableEars;
        }

        public void SetEars(Ears ears)
        {
            Ears = ears;
        }

        public Nose[] GetAvailableNose()
        {
            return availableNoses;
        }

        public void SetNose(Nose nose)
        {
            Nose = nose;
        }

        public void ReloadBody()
        {
            if (availableEars.Count() > 0)
            {
                if (ears == null)
                    ears = availableEars[0];
            }
            else
                ears = null;

            if (availableEyes.Count() > 0)
            {
                if (eyes == null)
                    eyes = availableEyes[0];
            }
            else
                eyes = null;

            if (availableNoses.Count() > 0)
            {
                if (nose == null)
                    nose = availableNoses[0];
            }
            else
                nose = null;

        }


        private void ReloadNoseTexture()
        {
            if (!HasNose())
            {
                noseTexture = null;
                return;
            }
            noseTexture = assetManager.LoadTexture(nose.GetTexturePath(gender, body));
        }
        public bool HasNose()
        {
            return nose != null;
        }
        private void ReloadEyesTexture()
        {
            if (!HasEyes())
            {
                eyesTexture = null;
                return;
            }
            eyesTexture = assetManager.LoadTexture(eyes.GetTexturePath(gender, body));
        }

        public bool HasEyes()
        {
            return eyes != null;
        }

        private void ReloadEarsTexture()
        {
            if (!HasEars())
            {
                earsTexture = null;
                return;
            }
            earsTexture = assetManager.LoadTexture(ears.GetTexturePath(gender, body));
        }

        public bool HasEars()
        {
            return ears != null;
        }

        private void ReloadBodyTexture()
        {
            string name = body.GetTexturePath(gender);
            bodyTexture = assetManager.LoadTexture(name);
        }


        public Texture2D GetBodyTexture()
        {
            return bodyTexture;
        }


        public Texture2D GetEyesTexture()
        {
            return eyesTexture;
        }
        public Texture2D GetNoseTexture()
        {
            return noseTexture;
        }

        public Texture2D GetEarsTexture()
        {
            return earsTexture;
        }

        internal void Draw(SpriteBatch spriteBatch, Vector2 position, int drawHeight, int drawWidth, Rectangle source)
        {
        
            spriteBatch.DrawDefault(bodyTexture, new Rectangle((int)position.X, (int)position.Y, drawWidth, drawHeight), source, Color.White);
            if (earsTexture != null)
                spriteBatch.DrawDefaultAddition(earsTexture, new Rectangle((int)position.X, (int)position.Y, drawWidth, drawHeight), source, Color.White, 0.01f);
            if (eyesTexture != null)
                spriteBatch.DrawDefaultAddition(eyesTexture, new Rectangle((int)position.X, (int)position.Y, drawWidth, drawHeight), source, Color.White, 0.01f);
            if (noseTexture != null)
                spriteBatch.DrawDefaultAddition(noseTexture, new Rectangle((int)position.X, (int)position.Y, drawWidth, drawHeight), source, Color.White, 0.01f);
        }

        public static Body FromId(int id)
        {
            foreach (Body body in Values)
                if (body.GetId() == id)
                    return body;

            return Body.LIGHT;
        }
    }
}