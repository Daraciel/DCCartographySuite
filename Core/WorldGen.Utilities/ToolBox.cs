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
    }
}
