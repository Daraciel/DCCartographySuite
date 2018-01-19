using System;
using System.Collections.Generic;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Interfaces;
using WorldGen.Common.Maps;

namespace WorldGen.Algorithm.SquaredDiamond
{
    public class SquaredDiamond : IAlgorithm
    {
        #region CONSTANTS

        private const int MAX_RANDOM_VALUE = Int32.MaxValue / 2;

        #endregion

        #region FIELDS

        private uint Detail;
        private int? Seed;
        private float Roughness;
        private Random rnd;

        private HeightMap resultMap;

        private int maxIterations;

        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            this.resultMap = new HeightMap(this.Detail, this.Detail);

            InitializeHeightMap();

            Divide(this.maxIterations, this.Roughness);

            NormalizeMap();

            return this.resultMap;
        }

        public override void Initialize(InitializeParams Params)
        {
            LoadDefaultValues();
            foreach (KeyValuePair<AlgorithmParameters, object> kvp in Params.Parameters)
            {
                switch (kvp.Key)
                {
                    case AlgorithmParameters.DETAIL:
                        Detail = (uint)kvp.Value;
                        break;
                    case AlgorithmParameters.ROUGHNESS:
                        Roughness = (float)kvp.Value;
                        break;
                    case AlgorithmParameters.SEED:
                        Seed = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.DEBUG:
                        debugMode = (bool)kvp.Value;
                        break;
                }

            }

            if (this.Seed.HasValue)
            {
                rnd = new Random(this.Seed.Value);
            }
            else
            {
                rnd = new Random();
            }
        }

        public override void SetParameter(AlgorithmParameters paramType, object value)
        {
            switch (paramType)
            {
                case AlgorithmParameters.DETAIL:
                    Detail = (uint)value;
                    break;
                case AlgorithmParameters.ROUGHNESS:
                    Roughness = (float)value;
                    break;
                case AlgorithmParameters.SEED:
                    Seed = (int)value;

                    if (this.Seed.HasValue)
                    {
                        rnd = new Random(this.Seed.Value);
                    }
                    else
                    {
                        rnd = new Random();
                    }
                    break;
                case AlgorithmParameters.DEBUG:
                    debugMode = (bool)value;
                    break;
            }
        }

        #endregion

        #region PRIVATE METHODS


        private void LoadDefaultValues()
        {
            Detail = 9;
            Roughness = 0.7f;
            Seed = null;
            debugMode = false;

        }

        private void Divide(int size, float slope)
        {
            int x, y, half;
            float offset;
            half = size / 2;
            float scale = this.Roughness * this.resultMap.Height;
            if (half >= 1)
            {
                for (y = half; y < this.maxIterations; y += size)
                {
                    for (x = half; x < this.maxIterations; x += size)
                    {
                        offset = getOffset(slope);
                        Square(x, y, half, offset);
                    }
                }


                for (y = 0; y <= this.maxIterations; y += half)
                {
                    for (x = (y + half) % size; x <= this.maxIterations; x += size)
                    {
                        //offset = getRandomInt(MAX_RANDOM_VALUE) * scale * 2 - scale;

                        offset = getOffset(slope);
                        Diamond(x, y, half, offset);
                    }
                }

                slope *= this.Roughness;
                Divide(half, slope);
            }
        }

        private void Square(int x, int y, int size, float offset)
        {
            float newValue;
            float[] values = new float[] {
                                            this.getValue(x - size, y - size),
                                            this.getValue(x + size, y - size),
                                            this.getValue(x + size, y + size),
                                            this.getValue(x - size, y + size)
                };
            newValue = WorldGen.Utilities.ToolBox.Average(values) + offset;

            this.setValue(x, y, newValue);
        }
    
        private void Diamond(int x, int y, int size, float offset)
        {
            float newValue;
            float[] values = new float[] {
                                                this.getValue(x, y - size),
                                                this.getValue(x + size, y),
                                                this.getValue(x, y + size),
                                                this.getValue(x - size, y)
                    };
            newValue = WorldGen.Utilities.ToolBox.Average(values) + offset;

            this.setValue(x, y, newValue);
        }

        private void InitializeHeightMap()
        {
            this.setValue(0, 0, 0);
            this.setValue(this.maxIterations, 0, 0);
            this.setValue(this.maxIterations, this.maxIterations, 0);
            this.setValue(0, this.maxIterations, 0);
        }

        private void NormalizeMap()
        {
            float lowest = WorldGen.Utilities.ToolBox.GetMinValue(this.resultMap.Heightmap);
            float highest = WorldGen.Utilities.ToolBox.GetMaxValue(this.resultMap.Heightmap);
            for (int i = 0; i < this.resultMap.Heightmap.Length; i++)
            {
                this.resultMap.Heightmap[i] = (this.resultMap.Heightmap[i] - lowest) / (highest - lowest);
            }
        }

        private float getOffset(float slope)
        {
            return getRandomInt(MAX_RANDOM_VALUE) * slope;
        }

        private int getRandomInt(int limit)
        {
            int result = 0;

            result = rnd.Next(-limit, limit);

            return result;
        }

        private void setValue(int x, int y, float value)
        {
            this.resultMap.Heightmap[x + this.resultMap.Height * y] = value;
        }

        private float getValue(int x, int y)
        {
            float result = -1;
            if (x >= 0 &&
                x <= this.maxIterations &&
                y >= 0 &&
                y <= this.maxIterations)
            {
                result = this.resultMap.Heightmap[x + this.resultMap.Height * y];
            }

            return result;
        }

        #endregion
    }
}
