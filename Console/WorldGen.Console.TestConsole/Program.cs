using System;
using WorldGen.Algorithm.TetrahedralSubdivision;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Maps;
using WorldGen.Utilities.Logger;
using WorldGen.Utilities.Enum;

namespace WorldGen.Console.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed, width, height;
            seed = 0.3;
            width = 200;
            height = 150;
            TSAlgorithm = new TetrahedralSubdivision();
            parameters = new InitializeParams();
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SEED, seed);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.WIDTH, width);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.HEIGHT, height);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.DEBUG, true);

            StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);
            TSAlgorithm.Initialize(parameters);
            TSMaps = (HeightMap)TSAlgorithm.Create();

            TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");
            //TSMaps.Save(@"C:/sample/sampleTSimage.jpg");
        }
    }
}
