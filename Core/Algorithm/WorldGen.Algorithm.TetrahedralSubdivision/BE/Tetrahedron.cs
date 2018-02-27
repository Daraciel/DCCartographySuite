using System;
using WorldGen.Algorithm.TetrahedralSubdivision.Enum;
using WorldGen.Common.BE;

namespace WorldGen.Algorithm.TetrahedralSubdivision.BE
{
    public class Tetrahedron
    {
        #region FIELDS

        private TetrahedronPoint a;
        private TetrahedronPoint b;
        private TetrahedronPoint c;
        private TetrahedronPoint d;

        #endregion

        #region PROPERTIES

        public TetrahedronPoint A
        {
            get { return a; }
            set {  a = value; calculateSides(); }
        }

        public TetrahedronPoint B
        {
            get { return b; }
            set { b = value; calculateSides(); }
        }

        public TetrahedronPoint C
        {
            get { return c; }
            set { c = value; calculateSides(); }
        }

        public TetrahedronPoint D
        {
            get { return d; }
            set { d = value; calculateSides(); }
        }

        public double ABSideLength { get; private set; }
        public double ACSideLength { get; private set; }
        public double ADSideLength { get; private set; }
        public double BCSideLength { get; private set; }
        public double BDSideLength { get; private set; }
        public double CDSideLength { get; private set; }

        public TetrahedronEdges LongestSide { get; private set; }

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
                A = new TetrahedronPoint(v1.X, v1.Y, v1.Z, v1.Value, v1.Seed);
                B = new TetrahedronPoint(v2.X, v2.Y, v2.Z, v2.Value, v2.Seed);
                C = new TetrahedronPoint(v3.X, v3.Y, v3.Z, v3.Value, v3.Seed);
                D = new TetrahedronPoint(v4.X, v4.Y, v4.Z, v4.Value, v4.Seed);
            }
        }

        #endregion

        #region PUBLIC METHODS

        public void Reorder()
        {
            if(ABSideLength < ACSideLength)
            {
                this.SwitchSides(ref b, ref c);
                Reorder();
            }
            else if(ABSideLength < ADSideLength)
            {
                this.SwitchSides(ref b, ref c);
                this.SwitchSides(ref b, ref d);
                Reorder();
            }
            else if (ABSideLength < BCSideLength)
            {
                this.SwitchSides(ref a, ref b);
                this.SwitchSides(ref b, ref c);
                Reorder();
            }
            else if (ABSideLength < BDSideLength)
            {
                this.SwitchSides(ref b, ref c);
                this.SwitchSides(ref b, ref d);
                Reorder();
            }
        }

        private void SwitchSides(ref TetrahedronPoint b, ref TetrahedronPoint c)
        {
            throw new NotImplementedException();
        }

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
                if ((acx * aby * adz + acy * abz * adx + acz * abx * ady - acz * aby * adx - acy * abx * adz - acx * abz * ady) *
                (apx * aby * adz + apy * abz * adx + apz * abx * ady - apz * aby * adx - apy * abx * adz - apx * abz * ady) > 0.0)
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

        public bool IsBeside(TetrahedronSides side, Point3D point)
        {
            bool result = false;

            switch(side)
            {
                case TetrahedronSides.ABC:
                    result = checkIfPointIsBesideABCSide(point);
                    break;
                case TetrahedronSides.ABD:
                    result = checkIfPointIsBesideABDSide(point);
                    break;
                case TetrahedronSides.ACD:
                    result = checkIfPointIsBesideACDSide(point);
                    break;
                case TetrahedronSides.BCD:
                    result = checkIfPointIsBesideBCDSide(point);
                    break;
            }

            return result;
        }

        public Tetrahedron Copy()
        {
            //Tetrahedron result;

            //result = new Tetrahedron(A, B, C, D);

            //return result;

            return (Tetrahedron)this.MemberwiseClone();
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
                this.LongestSide = TetrahedronEdges.AB;
                longestSide = ABSideLength;
            }
            else
            {
                this.LongestSide = TetrahedronEdges.AC;
                longestSide = ACSideLength;
            }

            if (ADSideLength > longestSide)
            {
                this.LongestSide = TetrahedronEdges.AD;
                longestSide = ADSideLength;
            }

            if (BCSideLength > longestSide)
            {
                this.LongestSide = TetrahedronEdges.BC;
                longestSide = BCSideLength;
            }

            if (BDSideLength > longestSide)
            {
                this.LongestSide = TetrahedronEdges.BD;
                longestSide = BDSideLength;
            }

            if (CDSideLength > longestSide)
            {
                this.LongestSide = TetrahedronEdges.CD;
                longestSide = CDSideLength;
            }
        }

        private bool checkIfPointIsBesideBCDSide(Point3D p)
        {
            double  bax, bay, baz,
                    bpx, bpy, bpz,
                    bcx, bcy, bcz,
                    bdx, bdy, bdz;
            double vectorBCDA, vectorBCDP;
            bool result = false;

            bax = A.X - B.X; bay = A.Y - B.Y; baz = A.Z - B.Z;
            bpx = p.X - B.X; bpy = p.Y - B.Y; bpz = p.Z - B.Z;
            bcx = C.X - B.X; bcy = C.Y - B.Y; bcz = C.Z - B.Z;
            bdx = D.X - B.X; bdy = D.Y - B.Y; bdz = D.Z - B.Z;

            vectorBCDA = bax * bcy * bdz + bay * bcz * bdx + baz * bcx * bdy -
                         baz * bcy * bdx - bay * bcx * bdz - bax * bcz * bdy;

            vectorBCDP = bpx * bcy * bdz + bpy * bcz * bdx + bpz * bcx * bdy -
                         bpz * bcy * bdx - bpy * bcx * bdz - bpx * bcz * bdy;

            if (vectorBCDA * vectorBCDP > 0.0)
            //Math.Abs(vectorBCDA) < 0.000001)
            {
                result = true;
            }

            return result;
        }

        private bool checkIfPointIsBesideACDSide(Point3D p)
        {
            double abx, aby, abz,
                    apx, apy, apz,
                    acx, acy, acz,
                    adx, ady, adz;
            double vectorACDB, vectorACDP;
            bool result = false;

            abx = B.X - A.X; aby = B.Y - A.Y; abz = B.Z - A.Z;
            apx = p.X - A.X; apy = p.Y - A.Y; apz = p.Z - A.Z;
            acx = C.X - A.X; acy = C.Y - A.Y; acz = C.Z - A.Z;
            adx = D.X - A.X; ady = D.Y - A.Y; adz = D.Z - A.Z;

            vectorACDB = abx * acy * adz + aby * acz * adx + abz * acx * ady -
                         abz * acy * adx - aby * acx * adz - abx * acz * ady;

            vectorACDP = apx * acy * adz + apy * acz * adx + apz * acx * ady -
                         apz * acy * adx - apy * acx * adz - apx * acz * ady;

            if (vectorACDB * vectorACDP > 0.0)
                //Math.Abs(vectorACDB) < 0.000001)
            {
                result = true;
            }

            return result;
        }

        private bool checkIfPointIsBesideABDSide(Point3D p)
        {
            //checkIfPointIsBesideBCDSide
            double acx, acy, acz,
                    apx, apy, apz,
                    abx, aby, abz,
                    adx, ady, adz;
            double vectorABDC, vectorABDP;
            bool result = false;

            acx = C.X - A.X; acy = C.Y - A.Y; acz = C.Z - A.Z;
            apx = p.X - A.X; apy = p.Y - A.Y; apz = p.Z - A.Z;
            abx = C.X - A.X; aby = B.Y - A.Y; abz = B.Z - A.Z;
            adx = D.X - A.X; ady = D.Y - A.Y; adz = D.Z - A.Z;
            vectorABDC = acx * aby * adz + acy * abz * adx + acz * abx * ady -
                         acz * aby * adx - acy * abx * adz - acx * abz * ady;
            vectorABDP = apx * aby * adz + apy * abz * adx + apz * abx * ady -
                         apz * aby * adx - apy * abx * adz - apx * abz * ady;

            if (vectorABDC * vectorABDP >= 0.0)
            {
                result = true;
            }

            return result;
        }

        private bool checkIfPointIsBesideABCSide(Point3D p)
        {
            //checkIfPointIsBesideBCDSide
            double adx, ady, adz,
                    apx, apy, apz,
                    abx, aby, abz,
                    acx, acy, acz;
            double vectorABCD, vectorABCP;
            bool result = false;

            adx = D.X - A.X; ady = D.Y - A.Y; adz = D.Z - A.Z;
            apx = p.X - A.X; apy = p.Y - A.Y; apz = p.Z - A.Z;
            abx = A.X - B.X; aby = A.Y - B.Y; abz = A.Z - B.Z;
            acx = A.X - C.X; acy = A.Y - C.Y; acz = A.Z - C.Z;

            vectorABCD = adx * aby * acz + ady * abz * acx + adz * abx * acy -
                         adz * aby * acx - ady * abx * acz - adx * abz * acy;

            vectorABCP = apx * aby * acz + apy * abz * acx + apz * abx * acy - 
                         apz * aby * acx - apy * abx * acz - apx * abz * acy;

            if (vectorABCD * vectorABCP > 0.0)
                //Math.Abs(vectorABCD) < 0.000001)
            {
                result = true;
            }

            return result;
        }

        #endregion

        
        #region OVERRIDE METHODS

        public override string ToString()
        {
            string result = string.Empty;

            result = string.Format("A: {0} | B: {1} | C: {2} | D: {3}",
                                    A.ToString(), B.ToString(), C.ToString(), D.ToString());

            return result;
        }

        #endregion
    }
}
