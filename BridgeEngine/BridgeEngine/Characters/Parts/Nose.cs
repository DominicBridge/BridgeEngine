using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Characters.Parts
{
    public class Nose
    {
        public static readonly Nose BIG = new Nose("Big Nose", 0, "bignose");
        public static readonly Nose BUTTON = new Nose("Big Nose", 0, "buttonnose");
        public static readonly Nose STRAIGHT = new Nose("Big Nose", 0, "straightnose");


        public static IEnumerable<Nose> Values
        {
            get
            {
                yield return BIG;
                yield return BUTTON;
                yield return STRAIGHT;
            }
        }

        private readonly string description;
        private readonly int id;
        private readonly string textureName;

        public Nose(string description, int id, string textureName)
        {
            this.description = description;
            this.id = id;
            this.textureName = textureName;
        }

        public string GetDescription()
        {
            return description;
        }

        public int GetId()
        {
            return id;
        }

        public string GetTextureName()
        {
            return textureName;
        }

        internal string GetTexturePath(Gender gender, Body body)
        {
            return Body.path + gender.GetPathRoute() + "nose/" + textureName + "_" + body.GetTextureName();
        }

        public static Nose FromId(int id)
        {
            foreach (Nose nose in Values)
                if (nose.GetId() == id)
                    return nose;

            return Nose.BIG;
        }
    }
}
