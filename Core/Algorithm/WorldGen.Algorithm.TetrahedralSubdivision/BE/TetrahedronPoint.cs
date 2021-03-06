﻿using WorldGen.Common.BE;

namespace WorldGen.Algorithm.TetrahedralSubdivision.BE
{
    public class TetrahedronPoint : Point3D
    {
        #region PROPERTIES

        public double Value { get; set; }
        public double Seed { get; set; }

        #endregion

        #region CONSTRUCTORS

        public TetrahedronPoint() : base()
        {
            Value = 0;
            Seed = 0;
        }

        public TetrahedronPoint(double x, double y, double z, double v, double s) : base(x,y,z)
        {
            Value = v;
            Seed = s;
        }

        public TetrahedronPoint Copy()
        {
            //TetrahedronPoint result;

            //result = new TetrahedronPoint(X, Y, Z, Value, Seed);

            //return result;
            return (TetrahedronPoint)this.MemberwiseClone();
        }

        #endregion


        #region OVERRIDE METHODS

        public override string ToString()
        {
            string result = string.Empty;

            result = string.Format("X: {0} | Y: {1} | Z: {2} | Value: {3} | Seed: {4}",
                                    X, Y, Z, Value, Seed);

            return result;
        }

        #endregion
    }
}
