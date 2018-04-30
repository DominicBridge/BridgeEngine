using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Characters.Parts
{
    public class Ears
    {
        public static readonly Ears BIG=  new Ears("Big", 0, "bigears");
        public static readonly Ears ELVEN = new Ears("Elven", 1, "elvenears");

        public static IEnumerable<Ears> Values
        {
            get
            {
                yield return BIG;
                yield return ELVEN;
            }
        }

        private readonly string description;
        private readonly int id;
        private readonly string textureName;

        public Ears(string description, int id, string textureName)
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

        public string GetTexturePath(Gender gender, Body body)
        {
            return Body.path + gender.GetPathRoute() + "ears/" + textureName + "_" + body.GetTextureName();
        }

        public string GetTextureName()
        {
            return textureName;
        }


        public static Ears FromId(int id)
        {
            foreach (Ears ears in Values)
                if (ears.GetId() == id)
                    return ears;

            return Ears.BIG;
        }
    }
}
