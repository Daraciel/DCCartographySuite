using System;
using WorldGen.Algorithm.TetrahedralSubdivision;
using WorldGen.Algorithm.TetrahedralSubdivision.BE;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Maps;
using WorldGen.Utilities.Logger;
using WorldGen.Utilities.Enum;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace WorldGen.Console.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity;
            string line;
            StaticLogger.SetLoggerType(LoggerTypes.TEXT);
            System.Console.WriteLine("cuantos mapas quiere crear?");
            line = System.Console.ReadLine();
            quantity = int.Parse(line);
            System.Console.WriteLine(DateTime.Now.ToString("HHmmss") + " START");

            //TestTetrahedronReorder();
            //TestManyMaps(quantity);
            //TestMaps();
            TestLatitudeRotation(quantity);

            System.Console.WriteLine(DateTime.Now.ToString("HHmmss") + " END");
        }

        private static void TestLatitudeRotation(int quantity)
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed;
            int width, height, totalsnapshots, degreeRotation;
            rnd = new Random();
            seed = rnd.NextDouble();
            width = 400;
            height = 300;
            TSAlgorithm = new TetrahedralSubdivision();
            parameters = new InitializeParams();
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.DEBUG, false);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.WIDTH, width);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.HEIGHT, height);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SEED, seed);

            //StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);


            degreeRotation = 90 / quantity;

            for (int i = 0; i < quantity; i++)
            {
                System.Console.WriteLine($"Generando mapa {i + 1} de {quantity} (Grados = {i * degreeRotation})");
                if (parameters.Parameters.ContainsKey(AlgorithmParameters.LATITUDE))
                {
                    parameters.Parameters[Common.Enums.AlgorithmParameters.LATITUDE] = i * degreeRotation;
                }
                else
                {
                    parameters.Parameters.Add(Common.Enums.AlgorithmParameters.LATITUDE, i * degreeRotation);
                }
                TSAlgorithm.Initialize(parameters);
                TSMaps = (HeightMap)TSAlgorithm.Create();
                TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");

                if (!Directory.Exists("Results"))
                {
                    Directory.CreateDirectory("Results");
                }
                TSMaps.Save(@$"Results/{i * degreeRotation}.jpg");

                File.WriteAllText(@$"Results/{i * degreeRotation}.json", JsonConvert.SerializeObject(TSAlgorithm));
            }
        }

        private static void TestMaps()
        {
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed;
            int width, height;
            seed = 0.3;
            width = 200;
            height = 150;
            TSAlgorithm = new TetrahedralSubdivision();
            parameters = new InitializeParams();
            //parameters.Parameters.Add(Common.Enums.AlgorithmParameters.DEBUG, true);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SEED, seed);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.WIDTH, width);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.HEIGHT, height);

            //StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);
            TSAlgorithm.Initialize(parameters);
            TSMaps = (HeightMap)TSAlgorithm.Create();

            TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");
            TSMaps.Save(@"Results/sampleTSimage.jpg");
        }

        private static void TestTetrahedronReorder()
        {
            TetrahedronPoint A;
            TetrahedronPoint B;
            TetrahedronPoint C;
            TetrahedronPoint D;
            Tetrahedron T;

            A = new TetrahedronPoint(0, 0, 0, 0, 0);
            B = new TetrahedronPoint(0, 2, 0, 0, 0);
            C = new TetrahedronPoint(0, 2, 4, 0, 0);
            D = new TetrahedronPoint(0, 0, 3, 0, 0);

            T = new Tetrahedron(A, B, C, D);
            T.Reorder();

        }


        private static void TestManyMaps(int quantity)
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed;
            int width, height;
            rnd = new Random();
            seed = 0.3;
            width = 400;
            height = 300;
            TSAlgorithm = new TetrahedralSubdivision();
            parameters = new InitializeParams();
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.DEBUG, false);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.WIDTH, width);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.HEIGHT, height);

            //StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);


            for (int i =0; i<quantity; i++)
            {
                seed = rnd.NextDouble();
                System.Console.WriteLine("Generando mapa " + (i+1) + " de " + quantity + " (Semilla = " + seed + ")");
                if (parameters.Parameters.ContainsKey(AlgorithmParameters.SEED))
                {
                    parameters.Parameters[Common.Enums.AlgorithmParameters.SEED] = seed;
                }
                else
                {
                    parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SEED, seed);
                }
                TSAlgorithm.Initialize(parameters);
                TSMaps = (HeightMap)TSAlgorithm.Create();
                TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");

                if(!Directory.Exists("Results"))
                {
                    Directory.CreateDirectory("Results");
                }
                TSMaps.Save(@"Results/" + seed + ".jpg");

                File.WriteAllText(@"Results/" + seed + ".json", JsonConvert.SerializeObject(TSAlgorithm));
            }


        }
    }
}
