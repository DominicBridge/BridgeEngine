using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Helpers
{
    public static class IntHelper
    {
        public static int IncrementByArray(this int i, object[] array)
        {
            i++;
            if (i >= array.Length)
                            i = 0;
            return i;
        }
        public static int DecrementByArray(this int i, object[] array)
        {
            i--;
            if (i < 0)
                i = array.Length - 1;

            return i;
        }


        public static int IncrementByArray(this int i, List<object> array)
        {
            i++;
            if (i >= array.Count)
                i = 0;

            return i;
        }
        public static int DecrementByArray(this int i, List<object> array)
        {
            i--;
            if (i < 0)
                i = array.Count - 1;

            return i;
        }

        public static int IncrementByArray(this int i, IEnumerable<object> array)
        {
            i++;
            if (i >= array.Count())
                i = 0;

            return i;
        }
        public static int DecrementByArray(this int i, IEnumerable<object> array)
        {
            i--;
            if (i < 0)
                i = array.Count() - 1;

            return i;
        }

        public static int Random(this int i, int max)
        {
            Random random = new Random(new Random().Next());
            return random.Next(max);
        }
    }
}
