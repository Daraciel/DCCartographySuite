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
            var dx = this.X - B.X;
            var dy = this.Y - B.Y;
            var dz = this.Z - B.Z;

            return (dx * dx) + (dy * dy) + (dz * dz);
        }

        #endregion

        #region OVERRIDE METHODS

        public override string ToString()
        {
            string result = string.Empty;

            result = string.Format("X: {0} | Y: {1} | Z: {2}",
                                    X, Y, Z);

            return result;
        }

        #endregion
    }
}
