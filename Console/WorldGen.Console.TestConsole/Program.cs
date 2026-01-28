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
            int option;
            string line;
            StaticLogger.SetLoggerType(LoggerTypes.TEXT);
            System.Console.WriteLine(DateTime.Now.ToString("HHmmss") + " START");
            do
            {
                System.Console.WriteLine("¿Que tipo de test quieres hacer?");
                System.Console.WriteLine("1 - TestManyMaps");
                System.Console.WriteLine("2 - TestLatitudeRotation (rotacion vertical)");
                System.Console.WriteLine("3 - TestLongitudeRotation (rotacion horizontal)");
                System.Console.WriteLine("4 - TestScale (rotacion horizontal)");
                System.Console.WriteLine("0 - Salir");
                line = System.Console.ReadLine();
                option = int.Parse(line);
                switch(option)
                {
                    case 1:
                        TestManyMaps();
                        break;
                    case 2:
                        TestLatitudeRotation();
                        break;
                    case 3:
                        TestLongitudeRotation();
                        break;
                    case 4:
                        TestScale();
                        break;
                }
            } while (option != 0);

            System.Console.WriteLine(DateTime.Now.ToString("HHmmss") + " END");
        }

        private static void TestLongitudeRotation()
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed, longitude;
            int width, height, degreeRotation;
            string line, path;
            int quantity;
            DateTime now = DateTime.Now;

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
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SCALE, 1.0);

            //StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);

            System.Console.WriteLine("cuantas particiones quieres hacer?");
            line = System.Console.ReadLine();
            quantity = int.Parse(line);
            System.Console.WriteLine(now.ToString("HHmmss") + " START");
            path = @$"Results/{now.ToString("dd-MM-yyyy-HHmmss")}";
            degreeRotation = 360 / quantity;

            for (int i = 0; i < quantity; i++)
            {
                longitude = (i * degreeRotation) - 180;
                System.Console.WriteLine($"Generando mapa {i + 1} de {quantity} (Grados = {longitude})");
                if (parameters.Parameters.ContainsKey(AlgorithmParameters.LONGITUDE))
                {
                    parameters.Parameters[Common.Enums.AlgorithmParameters.LONGITUDE] = longitude;
                }
                else
                {
                    parameters.Parameters.Add(Common.Enums.AlgorithmParameters.LONGITUDE, longitude);
                }
                TSAlgorithm.Initialize(parameters);
                TSMaps = (HeightMap)TSAlgorithm.Create();
                TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");

                /*
                if (!Directory.Exists("Results"))
                {
                    Directory.CreateDirectory("Results");
                }
                */

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                TSMaps.Save(@$"{path}/{longitude}.jpg");

                File.WriteAllText(@$"{path}/{longitude}.json", JsonConvert.SerializeObject(TSAlgorithm));
            }
        }

        private static void TestLatitudeRotation()
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed, latitude;
            int width, height, totalsnapshots, degreeRotation;
            string line, path;
            int quantity;
            DateTime now = DateTime.Now;

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
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SCALE, 2.0);

            //StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);

            System.Console.WriteLine("cuantas particiones quieres hacer?");
            line = System.Console.ReadLine();
            quantity = int.Parse(line);
            System.Console.WriteLine(now.ToString("HHmmss") + " START");
            path = @$"Results/{now.ToString("dd-MM-yyyy-HHmmss")}";
            degreeRotation = 180 / quantity;

            for (int i = 0; i < quantity; i++)
            {
                latitude = (i * degreeRotation) - 90;
                System.Console.WriteLine($"Generando mapa {i + 1} de {quantity} (Grados = {latitude})");
                if (parameters.Parameters.ContainsKey(AlgorithmParameters.LATITUDE))
                {
                    parameters.Parameters[Common.Enums.AlgorithmParameters.LATITUDE] = latitude;
                }
                else
                {
                    parameters.Parameters.Add(Common.Enums.AlgorithmParameters.LATITUDE, latitude);
                }
                TSAlgorithm.Initialize(parameters);
                TSMaps = (HeightMap)TSAlgorithm.Create();
                TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");

                /*
                if (!Directory.Exists("Results"))
                {
                    Directory.CreateDirectory("Results");
                }
                */

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                TSMaps.Save(@$"{path}/{latitude}.jpg");

                File.WriteAllText(@$"{path}/{latitude}.json", JsonConvert.SerializeObject(TSAlgorithm));
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

        private static void TestScale()
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed, longitude;
            int width, height, degreeRotation;
            string line, path;
            int quantity;
            DateTime now = DateTime.Now;

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
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SCALE, 1.0);

            //StaticLogger.SetLoggerType(LoggerTypes.CONSOLE);

            System.Console.WriteLine("cuantos zooms quieres hacer?");
            line = System.Console.ReadLine();
            quantity = int.Parse(line);
            System.Console.WriteLine(now.ToString("HHmmss") + " START");
            path = @$"Results/{now.ToString("dd-MM-yyyy-HHmmss")}";

            for (int i = 1; i <= quantity; i++)
            {
                System.Console.WriteLine($"Generando mapa {i} de {quantity} (Zoom = {i})");
                if (parameters.Parameters.ContainsKey(AlgorithmParameters.SCALE))
                {
                    parameters.Parameters[Common.Enums.AlgorithmParameters.SCALE] = i;
                }
                else
                {
                    parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SCALE, i);
                }
                TSAlgorithm.Initialize(parameters);
                TSMaps = (HeightMap)TSAlgorithm.Create();
                TSMaps.SetColorSchema(@"ColorSchemas/Olsson.col");

                /*
                if (!Directory.Exists("Results"))
                {
                    Directory.CreateDirectory("Results");
                }
                */

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                TSMaps.Save(@$"{path}/{i}.jpg");

                File.WriteAllText(@$"{path}/{i}.json", JsonConvert.SerializeObject(TSAlgorithm));
            }
        }


        private static void TestManyMaps()
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed;
            int width, height, quantity;
            string line;
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

            System.Console.WriteLine("¿Cuantos mapas quieres generar?");
            line = System.Console.ReadLine();
            quantity = int.Parse(line);

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
