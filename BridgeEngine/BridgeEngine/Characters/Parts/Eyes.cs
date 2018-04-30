using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Characters.Parts
{
    public class Eyes
    {
        public static readonly Eyes BLUE = new Eyes("Blue", 0, "blue");
        public static readonly Eyes BROWN = new Eyes("Brown", 1, "brown");
        public static readonly Eyes GRAY = new Eyes("Gray", 2, "gray");
        public static readonly Eyes GREEN = new Eyes("Green", 3, "green");
        public static readonly Eyes ORANGE = new Eyes("Orange", 4, "orange");
        public static readonly Eyes PURPLE = new Eyes("Purple", 5, "purple");
        public static readonly Eyes RED = new Eyes("Red", 6, "red");
        public static readonly Eyes YELLOW = new Eyes("Yellow", 7, "yellow");
        public static readonly Eyes GLOWING = new Eyes("Glowing", 8, "casting_eyeglow_skeleton");


        public static IEnumerable<Eyes> Values
        {
            get
            {
                yield return BLUE;
                yield return BROWN;
                yield return GRAY;
                yield return GREEN;
                yield return ORANGE;
                yield return PURPLE;
                yield return RED;
                yield return YELLOW;
                yield return GLOWING;
            }
        }

        internal string GetTexturePath(Gender gender, Body body)
        {
            return Body.path + gender.GetPathRoute() + "eyes/" + textureName;
        }

        private readonly string description;
        private readonly int id;
        private readonly string textureName;

        public Eyes(string description, int id, string textureName)
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

        public static Eyes FromId(int id)
        {
            foreach (Eyes eyes in Values)
                if (eyes.GetId() == id)
                    return eyes;

            return Eyes.BLUE;
        }
    }
}
