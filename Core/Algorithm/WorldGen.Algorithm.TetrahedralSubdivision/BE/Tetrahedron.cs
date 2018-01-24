namespace WorldGen.Algorithm.TetrahedralSubdivision.BE
{
    public class Tetrahedron
    {
        #region PROPERTIES

        public Point3D V1;
        public Point3D V2;
        public Point3D V3;
        public Point3D V4;

        #endregion

        #region CONSTRUCTORS

        public Tetrahedron() { }

        public Tetrahedron(double[] v1, double[] v2, double[] v3, double[] v4)
        {
            if( v1 == null || v1.Length != 3 ||
                v2 == null || v2.Length != 3 ||
                v3 == null || v3.Length != 3 ||
                v4 == null || v4.Length != 3)
            {
                throw new System.Exception("Some parameters are empty");
            }
            else
            {
                V1 = new Point3D(v1[0], v1[1], v1[2]);
                V2 = new Point3D(v2[0], v2[1], v2[2]);
                V3 = new Point3D(v3[0], v3[1], v3[2]);
                V4 = new Point3D(v4[0], v4[1], v4[2]);
            }
        }

        public Tetrahedron(Point3D v1, Point3D v2, Point3D v3, Point3D v4)
        {
            if (v1 == null ||
                v2 == null ||
                v3 == null ||
                v4 == null)
            {
                throw new System.Exception("Some parameters are empty");
            }
            else
            {
                V1 = v1;
                V2 = v2;
                V3 = v3;
                V4 = v4;
            }
        }

        #endregion
    }
}
