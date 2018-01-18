using ImageSharp;
using System;
using System.Threading.Tasks;
using WorldGen.Common.Interfaces;

namespace WorldGen.Common.Maps
{
    public class HeightMap : IMap
    {

        #region CONSTANTS

        #endregion

        #region CONSTRUCTORS

        public HeightMap(uint height, uint width)
        {
            this.height = height;
            this.width = width;
            InitializeMap();
        }

        #endregion

        #region FIELDS

        private float[] heightmap;
        private uint height;
        private uint width;

        #endregion

        #region PROPERTIES

        public float[] Heightmap
        {
            get
            {
                return heightmap;
            }

            set
            {
                heightmap = value;
            }
        }

        public uint Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public uint Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        #endregion

        #region IMAP

        public override Image<Rgba32> Print()
        {
            Image<Rgba32> result;
            Rgba32 color;
            byte pointValue;
            long position;
            float maxHeight;

            maxHeight = Utilities.ToolBox.GetMaxValue(this.heightmap);
            color.A = byte.MaxValue;

            result = new Image<Rgba32>((int)this.width, (int)this.height);

            if(result == null || result.Width > 0 || result.Height > 0)
            {
                return null;
            }

            result.Fill(Rgba32.Red);

            for(int x= 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    position = x + this.width * y;
                    if (this.heightmap.Length > position)
                    {
                        pointValue = (byte)((this.Heightmap[position] / maxHeight) * 255);
                        color.R = pointValue;
                        color.G = pointValue;
                        color.B = pointValue;
                        result[x,y] = color;
                    }
                }
            }

            //using (result = new Image<Rgba32>((int)this.width, (int)this.height))
            //{
            //    result.Fill(Rgba32.Red);

            //    image.Mutate(x => x
            //         .Resize(image.Width / 2, image.Height / 2)
            //         .Grayscale());
            //    image.Save("bar.jpg"); // automatic encoder selected based on extension.
            //}

            return result;
        }

        //public override Image Show()
        //{
        //    float maxHeight = this.Heightmap.Max();

        //    //float minHeight = this.Heightmap.Min();
        //    int bnColor;
        //    long position = 0;
        //    Bitmap result = new Bitmap((int)this.width, (int)this.height);
        //    //Image temp = null;
        //    Color c;
        //    using (var graphics = Graphics.FromImage(result))
        //    {
        //        graphics.FillRectangle(Brushes.Red, 0, 0, result.Width, result.Height);
        //        for (int x = 0; x < this.width; x++)
        //        {
        //            for (int y = 0; y < this.height; y++)
        //            {
        //                position = x + this.width * y;
        //                if (this.heightmap.Length > position)
        //                {
        //                    bnColor = (int)((this.Heightmap[position] / maxHeight) * 255);
        //                    c = Color.FromArgb(bnColor, bnColor, bnColor);
        //                    result.SetPixel(x, y, c);
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        private void InitializeMap()
        {
            this.heightmap = new float[this.width * this.height];

            Parallel.ForEach(this.heightmap, (point) =>
            {
                point = 0.0f;
            });
        }

        #endregion
    }
}
