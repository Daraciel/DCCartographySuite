using System;

namespace WorldGen.Common.BE
{
    public class Point3D
    {
        #region PROPERTIES

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region PUBLIC METHODS


        public double GetDistanceToPoint(Point3D B)
        {
            double result = 0;

            result = Math.Pow(this.X - B.X, 2);
            result += Math.Pow(this.Y - B.Y, 2);
            result += Math.Pow(this.Z - B.Z, 2);

            return result;
        }

        #endregion

    }
}
