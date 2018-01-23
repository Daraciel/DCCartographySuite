using System.Linq;
using System.Threading.Tasks;

namespace WorldGen.Utilities
{
    public static class ToolBox
    {
        public static float GetMaxValue(float[] array)
        {
            float result = float.MinValue;

            Parallel.ForEach(array, (point) =>
            {
                if (point > result)
                {
                    result = point;
                }
            });

            return result;
        }

        public static int GetMaxValue(int x, int y)
        {
            return (x < y ? y : x);
        }

        public static float GetMaxValue(float x, float y)
        {
            return (x < y ? y : x);
        }

        public static float GetMinValue(float[] array)
        {
            float result = float.MaxValue;

            Parallel.ForEach(array, (point) =>
            {
                if (point < result)
                {
                    result = point;
                }
            });

            return result;
        }
        
        public static int GetMinValue(int x, int y)
        {
            return (x < y ? x : y);
        }

        public static float GetMinValue(float x, float y)
        {
            return (x < y ? x : y);
        }

        public static float Average(float[] values)
        {
            float result = 0;
            values = values.Where(p => p != -1).ToArray();
            result = values.Sum();
            result /= values.Length;

            return result;
        }
    }
}
