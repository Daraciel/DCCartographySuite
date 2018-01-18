using System;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Interfaces;
using WorldGen.Common.Maps;

namespace WorldGen.Algorithm.SquaredDiamond
{
    public class SquaredDiamond : IAlgorithm
    {

        #region FIELDS

        private uint Detail;
        private int? Seed;
        private float Roughness;
        private Random rnd;

        private HeightMap resultMap;

        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize(InitializeParams parameters)
        {
            throw new System.NotImplementedException();
        }

        public override void SetParameter(AlgorithmParameters paramType, object value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
