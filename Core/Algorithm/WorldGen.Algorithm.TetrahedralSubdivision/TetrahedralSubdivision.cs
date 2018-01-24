using System.Collections.Generic;
using WorldGen.Algorithm.TetrahedralSubdivision.BE;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Interfaces;
using WorldGen.Utilities;

namespace WorldGen.Algorithm.TetrahedralSubdivision
{
    public class TetrahedralSubdivision : IAlgorithm
    {

        #region FIELDS

        /// <summary>
        /// Default altitude for the map
        /// </summary>
        private double initialAltitude = -0.02;

        /// <summary>
        /// 
        /// </summary>
        private double altitudeDifferenceWeight = 0.45;

        /// <summary>
        /// 
        /// </summary>
        private double altitudeDifferencePower = 1.0;

        /// <summary>
        /// 
        /// </summary>
        private double distanceWeight = 0.035;

        /// <summary>
        /// 
        /// </summary>
        private double distanceFunctionPower = 0.47;

        /// <summary>
        /// 
        /// </summary>
        private double seed = 0.1111111;

        /// <summary>
        /// 
        /// </summary>
        private double latitude = 0.0;

        /// <summary>
        /// 
        /// </summary>
        private double longitude = 0.0;

        /// <summary>
        /// 
        /// </summary>
        private double scale = 1.0;

        /// <summary>
        /// 
        /// </summary>
        private int width = 800;

        /// <summary>
        /// 
        /// </summary>
        private int height = 600;




        private Tetrahedron workingTetra = new Tetrahedron( new double[] {  -Constants.SQRT3 - 0.20, -Constants.SQRT3 - 0.22, -Constants.SQRT3 - 0.23 },
                                                            new double[] {  -Constants.SQRT3 - 0.19,  Constants.SQRT3 + 0.18,  Constants.SQRT3 + 0.17 },
                                                            new double[] {   Constants.SQRT3 + 0.21, -Constants.SQRT3 - 0.24,  Constants.SQRT3 + 0.15 },
                                                            new double[] {   Constants.SQRT3 + 0.24,  Constants.SQRT3 + 0.22, -Constants.SQRT3 - 0.25 });

        private double latitudeSin, latitudeCos, longitudeSin, longitudeCos;

        
        #endregion

        #region PROPERTIES

        public double DistanceFunctionPower { get => distanceFunctionPower; set => distanceFunctionPower = value; }
        public double DistanceWeight { get => distanceWeight; set => distanceWeight = value; }
        public double AltitudeDifferencePower { get => altitudeDifferencePower; set => altitudeDifferencePower = value; }
        public double AltitudeDifferenceWeight { get => altitudeDifferenceWeight; set => altitudeDifferenceWeight = value; }
        public double InitialAltitude { get => initialAltitude; set => initialAltitude = value; }
        public double Seed { get => seed; set => seed = value; }

        public double Scale
        {
            get => scale;
            set
            {
                scale = value;
                if (value < 1) scale = 1;
            }
        }

        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                if (value < -90) latitude = -90;
                if (value > 90) latitude = 90;
                latitude *= Constants.DEG2RAD;
            }
        }

        public double Longitude
        {
            get => longitude;
            set
            {
                longitude = value;
                while (longitude < -180) longitude += 360;
                while (longitude > 180) longitude -= 360;
                longitude *= Constants.DEG2RAD;
            }
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        #endregion



        #region PROPERTIES

        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize(InitializeParams parameters)
        {
            foreach(KeyValuePair<AlgorithmParameters, object> par in parameters.Parameters)
            {
                this.SetParameter(par.Key, par.Value);
            }
        }

        public override void SetParameter(AlgorithmParameters paramType, object value)
        {
            switch(paramType)
            {
                case AlgorithmParameters.DEBUG:
                    DebugMode = (bool)value;
                    break;
                case AlgorithmParameters.DISTANCEWEIGHT:
                    DistanceWeight = (double)value;
                    break;
                case AlgorithmParameters.ALTITUDE_DIFFERENCE_WEIGHT:
                    AltitudeDifferenceWeight = (double)value;
                    break;
                case AlgorithmParameters.SEED:
                    Seed = (double)value;
                    break;
                case AlgorithmParameters.WIDTH:
                    Width = (int)value;
                    break;
                case AlgorithmParameters.HEIGHT:
                    Height = (int)value;
                    break;
                case AlgorithmParameters.SCALE:
                    Scale = (double)value;
                    break;
                case AlgorithmParameters.LONGITUDE:
                    Longitude = (double)value;
                    break;
                case AlgorithmParameters.LATITUDE:
                    Latitude = (double)value; 
                    break;
                case AlgorithmParameters.INITIAL_ALTITUDE:
                    InitialAltitude = (double)value;
                    break;
            }
        }

        #endregion
    }
}
