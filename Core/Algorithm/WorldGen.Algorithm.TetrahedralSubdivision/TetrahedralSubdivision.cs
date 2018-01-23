using System.Collections.Generic;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Interfaces;

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

        #endregion

        #region PROPERTIES

        public double DistanceFunctionPower { get => distanceFunctionPower; set => distanceFunctionPower = value; }
        public double DistanceWeight { get => distanceWeight; set => distanceWeight = value; }
        public double AltitudeDifferencePower { get => altitudeDifferencePower; set => altitudeDifferencePower = value; }
        public double AltitudeDifferenceWeight { get => altitudeDifferenceWeight; set => altitudeDifferenceWeight = value; }
        public double InitialAltitude { get => initialAltitude; set => initialAltitude = value; }

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
            }
        }

        #endregion
    }
}
