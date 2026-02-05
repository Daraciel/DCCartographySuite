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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WorldGen.Console.TestConsole
{
    class Program
    {
        private static List<Tuple<string, int, int>> resolutions = new List<Tuple<string, int, int>>()
            {
                new Tuple<string, int, int>("CVGA 320×200", 320, 200),
                new Tuple<string, int, int>("QVGA 320×240", 320, 240),
                new Tuple<string, int, int>("VGA 640×480", 640, 480),
                new Tuple<string, int, int>("SVGA 800x600", 800, 600),
                new Tuple<string, int, int>("HD 1280x720", 1280, 720),
            };

        private static List<double> seeds = new List<double>()
            {
                0.2141870367,
                0.3463649213,
                0.4543181966,
                0.4638076137,
                0.4839993895,
                0.5029696404,
                0.5748610283,
                0.8880820194,
                0.9525475248,
                0.9930768225
            };
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0].Equals("efficiency", StringComparison.OrdinalIgnoreCase))
                {
                    string? outputPath = null;
                    string? improvement = null;

                    // Supported usage:
                    // - efficiency
                    // - efficiency <outputPath> <improvement>
                    // - efficiency --output <outputPath> --improvement <literal>
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i].Equals("--output", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        {
                            outputPath = args[++i];
                            continue;
                        }
                        if (args[i].Equals("--improvement", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        {
                            improvement = args[++i];
                            continue;
                        }
                    }

                    // Backward compatible positional args when no flags are provided.
                    if (outputPath is null && improvement is null)
                    {
                        outputPath = args.Length > 1 ? args[1] : null;
                        improvement = args.Length > 2 ? args[2] : null;
                    }
                    TestEficiency(outputPath, improvement);
                    return;
                }
            }

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
                System.Console.WriteLine("4 - TestScale (zoom)");
                System.Console.WriteLine("5 - EfficiencyTest (tiempos)");
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
                    case 5:
                        TestEficiency(null, null);
                        break;
                }
            } while (option != 0);

            System.Console.WriteLine(DateTime.Now.ToString("HHmmss") + " END");
        }

        private static void TestEficiency(string? markdownOutputPath, string? improvement)
        {
            Random rnd;
            TetrahedralSubdivision TSAlgorithm;
            HeightMap TSMaps;
            InitializeParams parameters;
            double seed;
            int width, height;
            Stopwatch sw = new Stopwatch();
            DateTime now = DateTime.Now;

            List<Tuple<string, double, TimeSpan>> results = new List<Tuple<string, double, TimeSpan>>();

            System.Console.WriteLine("Vamos a medir la velocidad de generacion del mapa");

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

            foreach (var res in resolutions)
            {
                width = res.Item2;
                height = res.Item3;
                parameters.Parameters[Common.Enums.AlgorithmParameters.WIDTH] = width;
                parameters.Parameters[Common.Enums.AlgorithmParameters.HEIGHT] = height;
                foreach (var s in seeds)
                {
                    parameters.Parameters[Common.Enums.AlgorithmParameters.SEED] = s;
                    System.Console.WriteLine($"Generando mapa de resolucion {res.Item1} ({width}x{height}) para la semilla {s}");
                    sw.Reset();
                    sw.Start();
                    TSAlgorithm.Initialize(parameters);
                    TSMaps = (HeightMap)TSAlgorithm.Create();
                    sw.Stop();
                    var duration = sw.Elapsed;
                    results.Add(new Tuple<string, double, TimeSpan>(res.Item1, s, duration));
                    if (duration.TotalMilliseconds < 1000)
                    {
                        System.Console.WriteLine($"Tiempo de generacion: {duration.TotalMilliseconds} ms");
                    }
                    else if (duration.TotalSeconds < 120)
                    {
                        System.Console.WriteLine($"Tiempo de generacion: {duration.TotalSeconds} s");
                    }
                    else
                    {
                        System.Console.WriteLine($"Tiempo de generacion: {duration.TotalMinutes} min");
                    }
                }
            }

            PrintResultsTable(results, improvement);

            if (!string.IsNullOrWhiteSpace(markdownOutputPath))
            {
                AppendResultsMarkdown(markdownOutputPath, results, now, improvement);
                System.Console.WriteLine($"Resultados exportados a: {markdownOutputPath}");
            }

        }

        private static void AppendResultsMarkdown(string markdownOutputPath, List<Tuple<string, double, TimeSpan>> results, DateTime now, string? improvement)
        {
            var dir = Path.GetDirectoryName(markdownOutputPath);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var headers = new List<string>(results.Count + 2) { "Date", "Improvement" };
            var values = new List<string>(results.Count + 2) { now.ToString("yyyy-MM-dd"), improvement ?? string.Empty };
            results.GroupBy(x => x.Item1)
                .ToList()
                .ForEach(g =>
                {
                    var avgDuration = new TimeSpan((long)g.Average(x => x.Item3.Ticks));
                    headers.Add(g.Key);
                    values.Add(FormatDuration(avgDuration));
                });

            static string PadWithTabsToHeader(string value, string header)
            {
                if (value is null) value = string.Empty;
                if (header is null) header = string.Empty;

                var result = value;
                while (result.Length < header.Length)
                {
                    result += "\t";
                }
                return result;
            }

            for (int i = 0; i < values.Count && i < headers.Count; i++)
            {
                values[i] = PadWithTabsToHeader(values[i], headers[i]);
            }

            var table = BuildMarkdownTable(headers, values);

            if (!File.Exists(markdownOutputPath))
            {
                File.WriteAllText(markdownOutputPath,
$"# Efficiency results\n\nTabla histórica generada por `WorldGen.Console.TestConsole` (modo `efficiency`).\n\n{table}\n");
                return;
            }

            var existing = File.ReadAllText(markdownOutputPath);
            if (existing.Contains("| Date\t\t\t|"))
            {
                var row = "| " + string.Join(" | ", values) + " |";
                if (!existing.Contains(row))
                {
                    File.AppendAllText(markdownOutputPath, row + Environment.NewLine);
                }
                return;
            }

            File.AppendAllText(markdownOutputPath, Environment.NewLine + table + Environment.NewLine);
        }

        private static string FormatDuration(TimeSpan duration)
        {
            if (duration.TotalMilliseconds < 1000)
            {
                return $"{duration.TotalMilliseconds:0.###} ms";
            }
            if (duration.TotalSeconds < 120)
            {
                return $"{duration.TotalSeconds:0.###} s";
            }
            return $"{duration.TotalMinutes:0.###} min";
        }

        private static string BuildMarkdownTable(IReadOnlyList<string> headers, IReadOnlyList<string> values)
        {
            var headerRow = "| " + string.Join(" | ", headers) + " |";
            var separatorRow = "| " + string.Join(" | ", headers.Select(_ => "---")) + " |";
            var valueRow = "| " + string.Join(" | ", values) + " |";
            return headerRow + Environment.NewLine + separatorRow + Environment.NewLine + valueRow + Environment.NewLine;
        }

        private static void PrintResultsTable(List<Tuple<string, double, TimeSpan>> results, string? improvement)
        {
            // Tabla con cabecera = Item1 y una única fila con tiempos (valores)
            // Se imprime en ms para mantener una unidad homogénea.
            var headers = new List<string>(results.Count);
            var values = new List<string>(results.Count);

            headers.Add("Date");
            values.Add(DateTime.Today.ToShortDateString());

            headers.Add("Improvement");
            values.Add(improvement ?? string.Empty);
            results.GroupBy(x => x.Item1)
                .ToList()
                .ForEach(g =>
                {
                    var avgDuration = new TimeSpan((long)g.Average(x => x.Item3.Ticks));
                    headers.Add(g.Key);
                    values.Add(FormatDuration(avgDuration));
                });

            int[] widths = new int[headers.Count];
            for (int i = 0; i < headers.Count; i++)
            {
                widths[i] = Math.Max(headers[i].Length, values[i].Length);
            }

            static string SepRow(int[] w)
            {
                var parts = new List<string>(w.Length);
                for (int i = 0; i < w.Length; i++) parts.Add(new string('-', w[i] + 2));
                return "+" + string.Join("+", parts) + "+";
            }

            static string DataRow(IReadOnlyList<string> cells, int[] w)
            {
                var parts = new List<string>(w.Length);
                for (int i = 0; i < w.Length; i++) parts.Add(" " + cells[i].PadRight(w[i]) + " ");
                return "|" + string.Join("|", parts) + "|";
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Resultados (tabla):");
            System.Console.WriteLine(SepRow(widths));
            System.Console.WriteLine(DataRow(headers, widths));
            System.Console.WriteLine(SepRow(widths));
            System.Console.WriteLine(DataRow(values, widths));
            System.Console.WriteLine(SepRow(widths));
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
            double seed;
            int width, height;
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
