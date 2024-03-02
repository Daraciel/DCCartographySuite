using SixLabors.ImageSharp.PixelFormats;
using System.Text.RegularExpressions;

namespace WorldGen.Common.BE
{
    public class ColorSchema
    {
        #region CONSTANTS

        private const int COLORCOUNT = 65535;

        #endregion

        #region FIELDS

        private Rgba32[] colors;

        private int highest;
        private int lowest = 6;
        private int sea;
        private int land;

        #endregion

        #region PROPERTIES

        public Rgba32[] Colors { get => colors; set => colors = value; }
        public int Highest { get => highest; set => highest = value; }
        public int Sea { get => sea; set => sea = value; }
        public int Land { get => land; set => land = value; }
        public int Lowest { get => lowest; private set => lowest = value; }

        #endregion

        #region CONSTRUCTORS

        public ColorSchema()
        {
            Colors = new Rgba32[COLORCOUNT];
        }

        public ColorSchema(string path)
        {
            Colors = new Rgba32[COLORCOUNT];
            FromFile(path);
        }

        #endregion

        #region PUBLIC METHODS

        public void FromFile(string path)
        {
            StreamReader file;
            int currentIndex, lastIndex;
            string line;
            string[] values;
            string pattern = @"(\d+) (\d+) (\d+) (\d+)";
            try
            {
                currentIndex = 0;
                file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    if(Regex.IsMatch(line, pattern))
                    {
                        line = line.TrimStart(' ');
                        values = line.Split(' ');
                        if( !string.IsNullOrEmpty(values[0]) &&
                            !string.IsNullOrEmpty(values[1]) &&
                            !string.IsNullOrEmpty(values[2]) &&
                            !string.IsNullOrEmpty(values[3]))
                        {
                            lastIndex = currentIndex;
                            currentIndex = int.Parse(values[0]);
                            Colors[currentIndex] = new Rgba32(  byte.Parse(values[1]),
                                                                byte.Parse(values[2]),
                                                                byte.Parse(values[3]));
                            FillColorsBetweenIndexes(lastIndex, currentIndex);
                        }
                    }
                }

                file.Close();

                if(currentIndex < 9)
                {
                    for(int i = currentIndex + 1; i < 10; i++)
                    {
                        /* fill up rest of colour table with last read colour */
                        Colors[i] = Colors[currentIndex];
                    }
                }

                Highest = currentIndex;
                Sea = (Highest + Lowest)/ 2;
                Land = Sea + 1;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void FillColorsBetweenIndexes(int lastIndex, int currentIndex)
        {
            Rgba32 auxColor;
            Rgba32 lastColor;
            Rgba32 currentColor;
            try
            {
                lastColor = Colors[lastIndex];
                currentColor = Colors[currentIndex];
                //Parallel.For(lastIndex + 1, currentIndex + lastIndex + 1,
                //   index => {
                //       auxColor
                //        = new Rgba32(   (byte)((lastColor.R * (currentIndex - index) + currentColor.R * (index - lastIndex)) / (currentIndex - lastIndex + 1)),
                //                        (byte)((lastColor.G * (currentIndex - index) + currentColor.G * (index - lastIndex)) / (currentIndex - lastIndex + 1)),
                //                        (byte)((lastColor.B * (currentIndex - index) + currentColor.B * (index - lastIndex)) / (currentIndex - lastIndex + 1)));
                //       Colors[index] = auxColor;
                //   });
                for (int i = lastIndex + 1; i < currentIndex; i++)
                {
                    auxColor = new Rgba32(  (byte)((lastColor.R * (currentIndex - i) + currentColor.R * (i - lastIndex)) / (currentIndex - lastIndex + 1)),
                                            (byte)((lastColor.G * (currentIndex - i) + currentColor.G * (i - lastIndex)) / (currentIndex - lastIndex + 1)),
                                            (byte)((lastColor.B * (currentIndex - i) + currentColor.B * (i - lastIndex)) / (currentIndex - lastIndex + 1)));
                    Colors[i] = auxColor;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
