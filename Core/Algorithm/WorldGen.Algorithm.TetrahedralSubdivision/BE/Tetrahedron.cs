using System;
using WorldGen.Algorithm.TetrahedralSubdivision.Enum;
using WorldGen.Common.BE;

namespace WorldGen.Algorithm.TetrahedralSubdivision.BE
{
    public class Tetrahedron
    {
        #region PROPERTIES

        public TetrahedronPoint A
        {
            get { return A; }
            set {  A = value; calculateSides(); }
        }

        public TetrahedronPoint B
        {
            get { return B; }
            set { B = value; calculateSides(); }
        }

        public TetrahedronPoint C
        {
            get { return C; }
            set { C = value; calculateSides(); }
        }

        public TetrahedronPoint D
        {
            get { return D; }
            set { D = value; calculateSides(); }
        }

        public double ABSideLength { get; private set; }
        public double ACSideLength { get; private set; }
        public double ADSideLength { get; private set; }
        public double BCSideLength { get; private set; }
        public double BDSideLength { get; private set; }
        public double CDSideLength { get; private set; }

        public TetrahedronSides LongestSide { get; private set; }

        #endregion

        #region CONSTRUCTORS

        public Tetrahedron()
        {
            A = new TetrahedronPoint();
            B = new TetrahedronPoint();
            C = new TetrahedronPoint();
            D = new TetrahedronPoint();
        }

        public Tetrahedron(double[] v1, double[] v2, double[] v3, double[] v4)
        {
            if( v1 == null || v1.Length != 5 ||
                v2 == null || v2.Length != 5 ||
                v3 == null || v3.Length != 5 ||
                v4 == null || v4.Length != 5)
            {
                throw new System.Exception("Some parameters are empty");
            }
            else
            {
                A = new TetrahedronPoint(v1[0], v1[1], v1[2], v1[3], v1[4]);
                B = new TetrahedronPoint(v2[0], v2[1], v2[2], v2[3], v2[4]);
                C = new TetrahedronPoint(v3[0], v3[1], v3[2], v3[3], v3[4]);
                D = new TetrahedronPoint(v4[0], v4[1], v4[2], v4[3], v4[4]);
            }
        }

        public Tetrahedron(TetrahedronPoint v1, TetrahedronPoint v2, TetrahedronPoint v3, TetrahedronPoint v4)
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
                A = v1;
                B = v2;
                C = v3;
                D = v4;
            }
        }

        #endregion

        #region PUBLIC METHODS
        
        public bool IsInside(Point3D point)
        {
            bool result;
            double abx, aby, abz, acx, acy, acz, adx, ady, adz, apx, apy, apz;
            double bax, bay, baz, bcx, bcy, bcz, bdx, bdy, bdz, bpx, bpy, bpz;
            result = false;
            abx = this.B.X - this.A.X;
            aby = this.B.Y - this.A.Y;
            abz = this.B.Z - this.A.Z;
            acx = this.C.X - this.A.X;
            acy = this.C.Y - this.A.Y;
            acz = this.C.Z - this.A.Z;
            adx = this.D.X - this.A.X;
            ady = this.D.Y - this.A.Y;
            adz = this.D.Z - this.A.Y;
            apx = point.X - this.A.X;
            apy = point.Y - this.A.Y;
            apz = point.Z - this.A.Z;
            if ((adx * aby * acz + ady * abz * acx + adz * abx * acy
                 - adz * aby * acx - ady * abx * acz - adx * abz * acy) *
                (apx * aby * acz + apy * abz * acx + apz * abx * acy
                 - apz * aby * acx - apy * abx * acz - apx * abz * acy) > 0.0)
            {
                /* p is on same side of abc as d */
                if ((acx * aby * adz + acy * abz * adx + acz * abx * ady
                 - acz * aby * adx - acy * abx * adz - acx * abz * ady) *
                (apx * aby * adz + apy * abz * adx + apz * abx * ady
                 - apz * aby * adx - apy * abx * adz - apx * abz * ady) > 0.0)
                {
                    /* p is on same side of abd as c */
                    if ((abx * ady * acz + aby * adz * acx + abz * adx * acy
                     - abz * ady * acx - aby * adx * acz - abx * adz * acy) *
                    (apx * ady * acz + apy * adz * acx + apz * adx * acy
                     - apz * ady * acx - apy * adx * acz - apx * adz * acy) > 0.0)
                    {
                        /* p is on same side of acd as b */
                        bax = -abx;
                        bay = -aby;
                        baz = -abz;
                        bcx = this.C.X - this.B.X;
                        bcy = this.C.Y - this.B.Y;
                        bcz = this.C.Z - this.B.Z;
                        bdx = this.D.X - this.B.X;
                        bdy = this.D.Y - this.B.Y;
                        bdz = this.D.Z - this.B.Z;
                        bpx = point.X - this.B.X;
                        bpy = point.Y - this.B.Y;
                        bpz = point.Z - this.B.Z;
                        if ((bax * bcy * bdz + bay * bcz * bdx + baz * bcx * bdy
                             - baz * bcy * bdx - bay * bcx * bdz - bax * bcz * bdy) *
                            (bpx * bcy * bdz + bpy * bcz * bdx + bpz * bcx * bdy
                             - bpz * bcy * bdx - bpy * bcx * bdz - bpx * bcz * bdy) > 0.0)
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region PRIVATE METHODS

        private void calculateSides()
        {
            if( A != null &&
                B != null &&
                C != null &&
                D != null)
            {

                ABSideLength = this.A.GetDistanceToPoint(this.B);
                ACSideLength = this.A.GetDistanceToPoint(this.C);
                ADSideLength = this.A.GetDistanceToPoint(this.D);
                BCSideLength = this.B.GetDistanceToPoint(this.C);
                BDSideLength = this.B.GetDistanceToPoint(this.D);
                CDSideLength = this.C.GetDistanceToPoint(this.D);

                setLongestSide();

            }
        }

        private void setLongestSide()
        {
            double longestSide;
            if (ABSideLength > ACSideLength)
            {
                this.LongestSide = TetrahedronSides.AB;
                longestSide = ABSideLength;
            }
            else
            {
                this.LongestSide = TetrahedronSides.AC;
                longestSide = ACSideLength;
            }

            if (ADSideLength > longestSide)
            {
                this.LongestSide = TetrahedronSides.AD;
                longestSide = ADSideLength;
            }

            if (BCSideLength > longestSide)
            {
                this.LongestSide = TetrahedronSides.BC;
                longestSide = BCSideLength;
            }

            if (BDSideLength > longestSide)
            {
                this.LongestSide = TetrahedronSides.BD;
                longestSide = BDSideLength;
            }

            if (CDSideLength > longestSide)
            {
                this.LongestSide = TetrahedronSides.CD;
                longestSide = CDSideLength;
            }
        }

        #endregion
    }
}
