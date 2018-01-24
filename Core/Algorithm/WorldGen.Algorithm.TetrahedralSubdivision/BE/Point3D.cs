namespace WorldGen.Algorithm.TetrahedralSubdivision.BE
{
    public class Point3D
    {
        #region PROPERTIES

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Point3D() { }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

    }
}
