using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Characters.Parts
{
    public class Gender
    {
        public static readonly Gender MALE = new Gender("Male", 0, "male/");
        public static readonly Gender FEMALE = new Gender("Female", 1, "female/");
        public static readonly Gender BOTH = new Gender("Unisex", 2, "unisex/");

        private readonly string description;
        private readonly int id;
        private readonly string pathRoute;

        public static IEnumerable<Gender> Values
        {
            get
            {
                yield return MALE;
                yield return FEMALE;
                yield return BOTH;
            }
        }
        public Gender(string description, int id, string pathRoute)
        {
            this.description = description;
            this.id = id;
            this.pathRoute = pathRoute;
        }

        public string GetDescription()
        {
            return description;
        }

        public int GetId()
        {
            return id;
        }

        public string GetPathRoute()
        {
            return pathRoute;
        }

        public static Gender FromId(int id)
        {
            foreach (Gender gender in Values)
                if (gender.GetId() == id)
                    return gender;

            return Gender.MALE;
        }
    }
}
