using FluentAssertions;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Maps;

namespace WorldGen.Algorithm.TetrahedralSubdivision.Tests;

public class TetrahedralSubdivisionBasicTests
{
    #region PROPERTY TESTS

    [Fact]
    public void DistanceFunctionPower_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 0.75;

        // Act
        algorithm.DistanceFunctionPower = expectedValue;

        // Assert
        algorithm.DistanceFunctionPower.Should().Be(expectedValue);
    }

    [Fact]
    public void DistanceWeight_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 0.05;

        // Act
        algorithm.DistanceWeight = expectedValue;

        // Assert
        algorithm.DistanceWeight.Should().Be(expectedValue);
    }

    [Fact]
    public void AltitudeDifferencePower_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 1.5;

        // Act
        algorithm.AltitudeDifferencePower = expectedValue;

        // Assert
        algorithm.AltitudeDifferencePower.Should().Be(expectedValue);
    }

    [Fact]
    public void AltitudeDifferenceWeight_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 0.6;

        // Act
        algorithm.AltitudeDifferenceWeight = expectedValue;

        // Assert
        algorithm.AltitudeDifferenceWeight.Should().Be(expectedValue);
    }

    [Fact]
    public void InitialAltitude_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = -0.05;

        // Act
        algorithm.InitialAltitude = expectedValue;

        // Assert
        algorithm.InitialAltitude.Should().Be(expectedValue);
    }

    [Fact]
    public void Seed_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 0.5555;

        // Act
        algorithm.Seed = expectedValue;

        // Assert
        algorithm.Seed.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(2.0, 2.0)]
    [InlineData(1.0, 1.0)]
    [InlineData(0.5, 1.0)] // Values less than 1 should be set to 1
    [InlineData(10.0, 10.0)]
    public void Scale_SetWithDifferentValues_ReturnsExpectedValue(double input, double expected)
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();

        // Act
        algorithm.Scale = input;

        // Assert
        algorithm.Scale.Should().Be(expected);
    }

    [Theory]
    [InlineData(0.0, 0.0)]
    [InlineData(45.0, 45.0)]
    [InlineData(-45.0, -45.0)]
    [InlineData(90.0, 90.0)]
    [InlineData(-90.0, -90.0)]
    [InlineData(100.0, 90.0)] // Should clamp to 90
    [InlineData(-100.0, -90.0)] // Should clamp to -90
    public void Latitude_SetWithDifferentValues_ClampsCorrectly(double input, double expected)
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();

        // Act
        algorithm.Latitude = input;

        // Assert
        // Convert back to degrees for comparison (property converts to radians)
        var actualDegrees = algorithm.Latitude * 180.0 / Math.PI;
        actualDegrees.Should().BeApproximately(expected, 0.001);
    }

    [Theory]
    [InlineData(0.0, 0.0)]
    [InlineData(90.0, 90.0)]
    [InlineData(-90.0, -90.0)]
    [InlineData(180.0, 180.0)]
    [InlineData(-180.0, -180.0)]
    [InlineData(270.0, -90.0)] // Should wrap around
    [InlineData(-270.0, 90.0)] // Should wrap around
    public void Longitude_SetWithDifferentValues_WrapsCorrectly(double input, double expected)
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();

        // Act
        algorithm.Longitude = input;

        // Assert
        var actualDegrees = algorithm.Longitude * 180.0 / Math.PI;
        actualDegrees.Should().BeApproximately(expected, 0.001);
    }

    [Fact]
    public void Width_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 1024;

        // Act
        algorithm.Width = expectedValue;

        // Assert
        algorithm.Width.Should().Be(expectedValue);
    }

    [Fact]
    public void Height_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 768;

        // Act
        algorithm.Height = expectedValue;

        // Assert
        algorithm.Height.Should().Be(expectedValue);
    }

    [Fact]
    public void Projection_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = MapProjections.PETERS;

        // Act
        algorithm.Projection = expectedValue;

        // Assert
        algorithm.Projection.Should().Be(expectedValue);
    }

    [Fact]
    public void IsDoLatitudeIcecapsSet_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();

        // Act
        algorithm.IsDoLatitudeIcecapsSet = true;

        // Assert
        algorithm.IsDoLatitudeIcecapsSet.Should().BeTrue();
    }

    #endregion

    #region INITIALIZATION TESTS

    [Fact]
    public void Initialize_WithValidParameters_SetsPropertiesCorrectly()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var parameters = new InitializeParams
        {
            Parameters = new Dictionary<AlgorithmParameters, object>
            {
                { AlgorithmParameters.SEED, 0.2222 },
                { AlgorithmParameters.WIDTH, 1024 },
                { AlgorithmParameters.HEIGHT, 768 },
                { AlgorithmParameters.SCALE, 2.0 },
                { AlgorithmParameters.LATITUDE, 45.0 },
                { AlgorithmParameters.LONGITUDE, 90.0 },
                { AlgorithmParameters.INITIAL_ALTITUDE, -0.03 },
                { AlgorithmParameters.PROJECTION, MapProjections.SQUARE }
            }
        };

        // Act
        algorithm.Initialize(parameters);

        // Assert
        algorithm.Seed.Should().Be(0.2222);
        algorithm.Width.Should().Be(1024);
        algorithm.Height.Should().Be(768);
        algorithm.Scale.Should().Be(2.0);
        algorithm.InitialAltitude.Should().Be(-0.03);
        algorithm.Projection.Should().Be(MapProjections.SQUARE);
    }

    [Fact]
    public void SetParameter_WithDebug_SetsDebugMode()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();

        // Act
        algorithm.SetParameter(AlgorithmParameters.DEBUG, true);

        // Assert
        algorithm.DebugMode.Should().BeTrue();
    }

    [Fact]
    public void SetParameter_WithDistanceWeight_SetsProperty()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 0.08;

        // Act
        algorithm.SetParameter(AlgorithmParameters.DISTANCEWEIGHT, expectedValue);

        // Assert
        algorithm.DistanceWeight.Should().Be(expectedValue);
    }

    [Fact]
    public void SetParameter_WithAltitudeDifferenceWeight_SetsProperty()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var expectedValue = 0.55;

        // Act
        algorithm.SetParameter(AlgorithmParameters.ALTITUDE_DIFFERENCE_WEIGHT, expectedValue);

        // Assert
        algorithm.AltitudeDifferenceWeight.Should().Be(expectedValue);
    }

    #endregion

    #region SUPPORTED PROJECTIONS TESTS

    [Fact]
    public void SupportedProjections_ReturnsExpectedProjections()
    {
        // Act
        var supportedProjections = TetrahedralSubdivision.SupportedProjections();

        // Assert
        supportedProjections.Should().NotBeNull();
        supportedProjections.Should().Contain(MapProjections.MERCATOR);
        supportedProjections.Should().Contain(MapProjections.PETERS);
        supportedProjections.Should().Contain(MapProjections.SQUARE);
        supportedProjections.Should().Contain(MapProjections.MOLLWEIDE);
        supportedProjections.Should().Contain(MapProjections.SINUSOID);
        supportedProjections.Should().Contain(MapProjections.STEREOGRAPHIC);
        supportedProjections.Should().Contain(MapProjections.ORTOGRAPHIC);
        supportedProjections.Should().Contain(MapProjections.ICOSAHEDRAL);
        supportedProjections.Should().Contain(MapProjections.GNOMONIC);
        supportedProjections.Should().Contain(MapProjections.AZIMUTH);
        supportedProjections.Should().Contain(MapProjections.CONICAL);
        supportedProjections.Count.Should().Be(11);
    }

    #endregion

    #region MAP CREATION TESTS

    [Theory]
    [InlineData(MapProjections.MERCATOR)]
    [InlineData(MapProjections.PETERS)]
    [InlineData(MapProjections.SQUARE)]
    [InlineData(MapProjections.MOLLWEIDE)]
    [InlineData(MapProjections.SINUSOID)]
    [InlineData(MapProjections.STEREOGRAPHIC)]
    [InlineData(MapProjections.ORTOGRAPHIC)]
    [InlineData(MapProjections.ICOSAHEDRAL)]
    [InlineData(MapProjections.GNOMONIC)]
    [InlineData(MapProjections.AZIMUTH)]
    [InlineData(MapProjections.CONICAL)]
    public void Create_WithDifferentProjections_ReturnsValidHeightMap(MapProjections projection)
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();
        var parameters = new InitializeParams
        {
            Parameters = new Dictionary<AlgorithmParameters, object>
            {
                { AlgorithmParameters.WIDTH, 100 },
                { AlgorithmParameters.HEIGHT, 100 },
                { AlgorithmParameters.PROJECTION, projection },
                { AlgorithmParameters.SEED, 0.123 }
            }
        };
        algorithm.Initialize(parameters);

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<HeightMap>();
        var heightMap = result as HeightMap;
        heightMap!.Width.Should().Be(100);
        heightMap.Height.Should().Be(100);
        heightMap.Heightmap.Should().NotBeNull();
        heightMap.Heightmap.Length.Should().Be(100 * 100);
    }

    [Fact]
    public void Create_WithDefaultSettings_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision();

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<HeightMap>();
        var heightMap = result as HeightMap;
        heightMap!.Width.Should().Be(800); // Default width
        heightMap.Height.Should().Be(600); // Default height
        heightMap.Heightmap.Should().NotBeNull();
    }

    [Fact]
    public void Create_WithSmallDimensions_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 10,
            Height = 10,
            Seed = 0.5
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        var heightMap = result as HeightMap;
        heightMap!.Heightmap.Should().NotBeNull();
        heightMap.Heightmap.Length.Should().Be(100);
    }

    [Fact]
    public void Create_WithConicalProjectionPositiveLatitude_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 100,
            Height = 100,
            Projection = MapProjections.CONICAL,
            Latitude = 45.0,
            Seed = 0.123
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        var heightMap = result as HeightMap;
        heightMap!.Heightmap.Should().NotBeNull();
    }

    [Fact]
    public void Create_WithConicalProjectionNegativeLatitude_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 100,
            Height = 100,
            Projection = MapProjections.CONICAL,
            Latitude = -45.0,
            Seed = 0.123
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        var heightMap = result as HeightMap;
        heightMap!.Heightmap.Should().NotBeNull();
    }

    [Fact]
    public void Create_WithIcecaps_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 100,
            Height = 100,
            IsDoLatitudeIcecapsSet = true,
            Seed = 0.123
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        var heightMap = result as HeightMap;
        heightMap!.Heightmap.Should().NotBeNull();
    }

    [Fact]
    public void Create_MultipleTimes_WithSameSeed_ProducesSameResults()
    {
        // Arrange
        var algorithm1 = new TetrahedralSubdivision
        {
            Width = 50,
            Height = 50,
            Seed = 0.12345,
            Projection = MapProjections.MERCATOR
        };

        var algorithm2 = new TetrahedralSubdivision
        {
            Width = 50,
            Height = 50,
            Seed = 0.12345,
            Projection = MapProjections.MERCATOR
        };

        // Act
        var result1 = algorithm1.Create() as HeightMap;
        var result2 = algorithm2.Create() as HeightMap;

        // Assert
        result1.Should().NotBeNull();
        result2.Should().NotBeNull();
        result1!.Heightmap.Should().BeEquivalentTo(result2!.Heightmap);
    }

    [Fact]
    public void Create_WithDifferentSeeds_ProducesDifferentResults()
    {
        // Arrange
        var algorithm1 = new TetrahedralSubdivision
        {
            Width = 50,
            Height = 50,
            Seed = 0.11111,
            Projection = MapProjections.MERCATOR
        };

        var algorithm2 = new TetrahedralSubdivision
        {
            Width = 50,
            Height = 50,
            Seed = 0.99999,
            Projection = MapProjections.MERCATOR
        };

        // Act
        var result1 = algorithm1.Create() as HeightMap;
        var result2 = algorithm2.Create() as HeightMap;

        // Assert
        result1.Should().NotBeNull();
        result2.Should().NotBeNull();
        result1!.Heightmap.Should().NotBeEquivalentTo(result2!.Heightmap);
    }

    #endregion

    #region EDGE CASE TESTS

    [Fact]
    public void Create_WithLargeScale_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 100,
            Height = 100,
            Scale = 10.0,
            Seed = 0.5
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
        var heightMap = result as HeightMap;
        heightMap!.Heightmap.Should().NotBeNull();
    }

    [Fact]
    public void Create_WithExtremeLatitudes_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 100,
            Height = 100,
            Latitude = 90.0,
            Seed = 0.5
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Create_WithExtremeLongitudes_ReturnsValidHeightMap()
    {
        // Arrange
        var algorithm = new TetrahedralSubdivision
        {
            Width = 100,
            Height = 100,
            Longitude = 180.0,
            Seed = 0.5
        };

        // Act
        var result = algorithm.Create();

        // Assert
        result.Should().NotBeNull();
    }

    #endregion
}
