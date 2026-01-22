using FluentAssertions;
using System.IO;
using System.Text.Json;
using WorldGen.Common.Maps;
using WorldGen.Common.Enums;

namespace WorldGen.Algorithm.TetrahedralSubdivision.Tests
{
    public class TetrahedralSubdivisionAdvancedTests
    {
        private const string TestDataPath = "TestData/BaseGeneration";
        private const double Tolerance = 1e-10; // Tolerance for double comparison

        public class TestScenario
        {
            public double DistanceFunctionPower { get; set; }
            public double DistanceWeight { get; set; }
            public double AltitudeDifferencePower { get; set; }
            public double AltitudeDifferenceWeight { get; set; }
            public double InitialAltitude { get; set; }
            public double Seed { get; set; }
            public double Scale { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Projection { get; set; }
            public bool IsDoLatitudeIcecapsSet { get; set; }
            public ResultMapData ResultMap { get; set; } = new ResultMapData();
        }

        public class ResultMapData
        {
            public double[] Heightmap { get; set; } = Array.Empty<double>();
        }

        public static IEnumerable<object[]> GetJsonTestFiles()
        {
            var testDirectory = Path.Combine(AppContext.BaseDirectory, TestDataPath);
            
            if (!Directory.Exists(testDirectory))
            {
                yield break;
            }

            var jsonFiles = Directory.GetFiles(testDirectory, "*.json");
            
            foreach (var jsonFile in jsonFiles)
            {
                yield return new object[] { jsonFile };
            }
        }

        [Theory]
        [MemberData(nameof(GetJsonTestFiles))]
        public void GenerateMap_WithJsonScenarios_DifferentSeeds(string jsonFilePath)
        {
            // Arrange
            var jsonContent = File.ReadAllText(jsonFilePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var scenario = JsonSerializer.Deserialize<TestScenario>(jsonContent, options);
            
            scenario.Should().NotBeNull($"JSON file {jsonFilePath} should be deserializable");

            var algorithm = new TetrahedralSubdivision
            {
                DistanceFunctionPower = scenario!.DistanceFunctionPower,
                DistanceWeight = scenario.DistanceWeight,
                AltitudeDifferencePower = scenario.AltitudeDifferencePower,
                AltitudeDifferenceWeight = scenario.AltitudeDifferenceWeight,
                InitialAltitude = scenario.InitialAltitude,
                Seed = scenario.Seed,
                Scale = scenario.Scale,
                Latitude = scenario.Latitude,
                Longitude = scenario.Longitude,
                Width = scenario.Width,
                Height = scenario.Height,
                Projection = (MapProjections)scenario.Projection,
                IsDoLatitudeIcecapsSet = scenario.IsDoLatitudeIcecapsSet
            };

            // Act
            var result = algorithm.Create();

            // Assert
            result.Should().NotBeNull("Generated map should not be null");
            result.Should().BeOfType<HeightMap>("Result should be a HeightMap");
            
            var heightMap = result as HeightMap;
            heightMap!.Width.Should().Be(scenario.Width, "Width should match the scenario");
            heightMap.Height.Should().Be(scenario.Height, "Height should match the scenario");
            heightMap.Heightmap.Should().NotBeNull("Heightmap array should not be null");
            heightMap.Heightmap.Length.Should().Be(scenario.ResultMap.Heightmap.Length, 
                "Heightmap length should match expected result");

            // Compare heightmap values with tolerance
            for (int i = 0; i < heightMap.Heightmap.Length; i++)
            {
                heightMap.Heightmap[i].Should().BeApproximately(
                    scenario.ResultMap.Heightmap[i], 
                    Tolerance,
                    $"Heightmap value at index {i} should match expected value");
            }
        }

    }
}
