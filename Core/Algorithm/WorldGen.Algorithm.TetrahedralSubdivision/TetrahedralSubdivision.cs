﻿using System;
using System.Collections.Generic;
using WorldGen.Algorithm.TetrahedralSubdivision.BE;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Interfaces;
using WorldGen.Common.Maps;
using WorldGen.Utilities;

namespace WorldGen.Algorithm.TetrahedralSubdivision
{
    public class TetrahedralSubdivision : IAlgorithm
    {
        #region CONSTANTS

        private const string FUNC_NAME_CREATE = "Create";
        private const string FUNC_NAME_INITIALIZE = "Initialize";
        private const string FUNC_NAME_SETPARAMETER = "SetParameter";
        private const string FUNC_NAME_DOMERCATORPROJECTION = "DoMercatorProjection";
        private const string FUNC_NAME_GENERATEPOINT = "GeneratePoint";
        private const string FUNC_NAME_GETHEIGHTFORPOINT = "GetHeightForPoint";
        private const string FUNC_NAME_DOLATITUDEICECAPS = "DoLatitudeIcecaps";
        private const string FUNC_NAME_INITIALIZEDEFAULTTETRA = "InitializeDefaultTetra";
        private const string FUNC_NAME_SETDEPTH = "SetDepth";

        

        #endregion

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

        private bool isDoLatitudeIcecapsSet = false;

        private MapProjections projection = MapProjections.MERCATOR;



        private Tetrahedron savedTetra;

        private Tetrahedron defaultTetra;

        private double latitudeSin, latitudeCos, longitudeSin, longitudeCos;

        private double depth;

        private double randSeed1, randSeed2, randSeed3, randSeed4;

        private HeightMap resultMap;
        
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
                latitudeSin = Math.Sin(latitude);
                latitudeCos = Math.Cos(latitude);
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
                longitudeSin = Math.Sin(longitude);
                longitudeCos = Math.Cos(longitude);
            }
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public MapProjections Projection { get => projection; set => projection = value; }
        public bool IsDoLatitudeIcecapsSet { get => isDoLatitudeIcecapsSet; set => isDoLatitudeIcecapsSet = value; }

        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_CREATE);
                resultMap = new HeightMap(this.Height, this.Width, this.initialAltitude);
                randSeed1 = this.Seed;
                randSeed1 = random(randSeed1, randSeed1);
                randSeed2 = random(randSeed1, randSeed1);
                randSeed3 = random(randSeed1, randSeed2);
                randSeed4 = random(randSeed2, randSeed3);

                savedTetra = new Tetrahedron();
                InitilizeDefaultTetra();
                switch (this.Projection)
                {
                    case MapProjections.MERCATOR:
                    DoMercatorProjection();
                    break;
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_CREATE, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_CREATE);
            }
            
            return resultMap;
        }

        public override void Initialize(InitializeParams parameters)
        {
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_INITIALIZE, parameters);
                foreach(KeyValuePair<AlgorithmParameters, object> par in parameters.Parameters)
                {
                    this.SetParameter(par.Key, par.Value);
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_INITIALIZE, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_INITIALIZE);
            }

        }

        public override void SetParameter(AlgorithmParameters paramType, object value)
        {
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_SETPARAMETER, paramType, value);
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
                    case AlgorithmParameters.PROJECTION:
                        Projection = (MapProjections)value;
                        break;
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_SETPARAMETER, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_SETPARAMETER);
            }
        }

        #endregion

        #region PUBLIC METHODS

        public static HashSet<MapProjections> SupportedProjections()
        {
            return new HashSet<MapProjections>() { MapProjections.MERCATOR };
        }

        #endregion

        #region PROJECTIONS

        private void DoMercatorProjection()
        {
            double x, y, z, scale1, cos2, theta1;
            int i, j, k;
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_DOMERCATORPROJECTION);

                y = latitudeSin;
                y = (1.0 + y) / (1.0 - y);
                y = 0.5 * Math.Log10(y);
                k = (int)(0.5 * y * Width * scale / Constants.PI);
                for (j = 0; j < Height; j++)
                {
                    y = Constants.PI * (2.0 * (j - k) - Height) / Width / scale;
                    y = Math.Exp(2.0 * y);
                    y = (y - 1.0) / (y + 1.0);
                    scale1 = scale * Width / Height / Math.Sqrt(1.0 - y * y) / Constants.PI;
                    cos2 = Math.Sqrt(1.0 - y * y);
                    depth = 3 * (Math.Truncate(Math.Log(scale1 * Height, 2))) + 3;
                    for (i = 0; i < Width; i++)
                    {
                        theta1 = Longitude - 0.5 * Constants.PI + Constants.PI * (2.0 * i - Width) / Width / scale;
                        x = Math.Cos(theta1) * cos2;
                        z = -Math.Sin(theta1) * cos2;
                        generatePoint(x, y, z, i, j);
                    }
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_DOMERCATORPROJECTION, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_DOMERCATORPROJECTION);
            }
        }


        #endregion

        #region HEIGHT GENERATION

        private void generatePoint(double x, double y, double z, int i, int j)
        {
            double generatedHeight = 0;
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_GENERATEPOINT, x, y, z, i, j);

                generatedHeight = getHeightForPoint(new Point3D(x, y, z));

                this.resultMap.Heightmap[j*this.resultMap.Width + i] = generatedHeight;
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_GENERATEPOINT, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_GENERATEPOINT);
            }
        }

        private double getHeightForPoint(Point3D point)
        {
            double result = 0;
            bool isInsideTetrahedron = false;
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_GETHEIGHTFORPOINT, point);

                isInsideTetrahedron = savedTetra.IsInside(point);

                if(isInsideTetrahedron)
                {
                    result = getHeightForPoint(savedTetra.Copy(), point, 11);
                }
                else
                {
                    result = getHeightForPoint(defaultTetra.Copy(), 
                                            point, depth);
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_GETHEIGHTFORPOINT, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_GETHEIGHTFORPOINT, result);
            }

            return result;
        }

        private double getHeightForPoint(Tetrahedron tetra, Point3D point, double depth)
        {
            double result = 0;
            double es, es1, es2, es3;
            double longestSideValue;
            TetrahedronPoint E = new TetrahedronPoint();
            TetrahedronPoint A, B, Aux;
            Enum.TetrahedronEdges longestSide;
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_GETHEIGHTFORPOINT, tetra, point, depth);
                if (depth > 0)
                {
                    longestSide = tetra.LongestSide;
                    if (depth == 11)
                    {
                        savedTetra = tetra.Copy();
                    }
                    switch (longestSide)
                    {
                        case Enum.TetrahedronEdges.AB:
                        default:
                            A = tetra.A;
                            B = tetra.B;
                            longestSideValue = tetra.ABSideLength;
                            break;
                        case Enum.TetrahedronEdges.AC:
                            A = tetra.A;
                            B = tetra.C;
                            longestSideValue = tetra.ACSideLength;
                            break;
                        case Enum.TetrahedronEdges.AD:
                            A = tetra.A;
                            B = tetra.D;
                            longestSideValue = tetra.ADSideLength;
                            break;
                        case Enum.TetrahedronEdges.BC:
                            A = tetra.B;
                            B = tetra.C;
                            longestSideValue = tetra.BCSideLength;
                            break;
                        case Enum.TetrahedronEdges.BD:
                            A = tetra.B;
                            B = tetra.D;
                            longestSideValue = tetra.BDSideLength;
                            break;
                        case Enum.TetrahedronEdges.CD:
                            A = tetra.C;
                            B = tetra.D;
                            longestSideValue = tetra.CDSideLength;
                            break;
                    }

                    es = this.random(A.Seed, B.Seed);
                    es1 = this.random(es, es);
                    es2 = 0.5 + 0.1 * this.random(es1, es1);
                    es3 = 1.0 - es2;

                    E.Seed = es;

                    if (A.Seed < B.Seed )
                    {
                        E.X = (es2 * A.X + es3 * B.X);
                        E.Y = (es2 * A.Y + es3 * B.Y);
                        E.Z = (es2 * A.Z + es3 * B.Z);
                    }
                    else if (A.Seed > B.Seed)
                    {
                        E.X = (es3 * A.X + es2 * B.X);
                        E.Y = (es3 * A.Y + es2 * B.Y);
                        E.Z = (es3 * A.Z + es2 * B.Z);
                    }
                    else
                    {
                        E.X = (0.5 * A.X + 0.5 * B.X);
                        E.Y = (0.5 * A.Y + 0.5 * B.Y);
                        E.Z = (0.5 * A.Z + 0.5 * B.Z);
                    }

                    if (longestSideValue > 1.0) { longestSideValue = Math.Pow(longestSideValue, 0.5); }

                    E.Value = 0.5 * (A.Value + B.Value)
                                + es * this.AltitudeDifferenceWeight * Math.Pow(Math.Abs(A.Value - B.Value), this.AltitudeDifferencePower)
                                + es1 * this.DistanceWeight * Math.Pow(longestSideValue, this.DistanceFunctionPower);

                    switch (longestSide)
                    {
                        case Enum.TetrahedronEdges.AB:
                            tetra.B = E;
                            if(!tetra.IsBeside(Enum.TetrahedronSides.BCD, point))
                            {
                                tetra.A = E;
                                tetra.B = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.AC:
                            tetra.C = E;
                            if (!tetra.IsBeside(Enum.TetrahedronSides.BCD, point))
                            {
                                tetra.A = E;
                                tetra.C = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.AD:
                            tetra.D = E;
                            if (!tetra.IsBeside(Enum.TetrahedronSides.BCD, point))
                            {
                                tetra.A = E;
                                tetra.D = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.BC:
                            tetra.C = E;
                            if (!tetra.IsBeside(Enum.TetrahedronSides.ACD, point))
                            {
                                tetra.B = E;
                                tetra.C = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.BD:
                            tetra.D = E;
                            if (!tetra.IsBeside(Enum.TetrahedronSides.ACD, point))
                            {
                                tetra.B = E;
                                tetra.D = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.CD:
                            tetra.D = E;
                            if (!tetra.IsBeside(Enum.TetrahedronSides.ABD, point))
                            {
                                tetra.C = E;
                                tetra.D = B;
                            }
                            break;
                    }             
                    result = this.getHeightForPoint(tetra, point, depth - 1);
                }
                else
                {
                    result = (tetra.A.Value + tetra.B.Value + tetra.C.Value + tetra.D.Value) / 4;

                    result = doLatitudeIcecaps(result, point.Y);
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_GETHEIGHTFORPOINT, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_GETHEIGHTFORPOINT, result);
            }
            
            return result;
        }

        private double doLatitudeIcecaps(double alt, double y)
        {
            double result = 0;
            double yRaised;
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_DOLATITUDEICECAPS, alt, y);

                result = alt;
                if(IsDoLatitudeIcecapsSet)
                {
                    yRaised = y * y;
                    yRaised *= yRaised;
                    yRaised *= yRaised;
                    if(result <= 0 &&
                        yRaised + alt >= 1.0 - 0.02)
                    {
                        result = double.MaxValue;
                    }
                    else
                    {
                        result += 0.1 * yRaised;
                    }
                }

                if (result >= 0.1)
                {
                    result = double.MaxValue;
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_DOLATITUDEICECAPS, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_DOLATITUDEICECAPS, result);
            }

            return result;
        }

        #endregion

        #region PRIVATE METHODS

        private void InitilizeDefaultTetra()
        {
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_INITIALIZEDEFAULTTETRA);
            defaultTetra = new Tetrahedron( new double[] { -Constants.SQRT3 - 0.20, -Constants.SQRT3 - 0.22, -Constants.SQRT3 - 0.23, InitialAltitude, randSeed1 },
                                            new double[] { -Constants.SQRT3 - 0.19,  Constants.SQRT3 + 0.18,  Constants.SQRT3 + 0.17, InitialAltitude, randSeed2 },
                                            new double[] {  Constants.SQRT3 + 0.21, -Constants.SQRT3 - 0.24,  Constants.SQRT3 + 0.15, InitialAltitude, randSeed3 },
                                            new double[] {  Constants.SQRT3 + 0.24,  Constants.SQRT3 + 0.22, -Constants.SQRT3 - 0.25, InitialAltitude, randSeed4 });
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_INITIALIZEDEFAULTTETRA, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_INITIALIZEDEFAULTTETRA);
            }
        }

        private void setDepth()
        {
            int aux = 0;
            try
            {
                this.WriteLogFunctionEnter(FUNC_NAME_SETDEPTH);

                aux = Convert.ToInt32(Math.Log(Scale*Height, 2));
                aux *= 3;
                aux += 6;

                depth = aux;
            }
            catch(Exception ex)
            {
                this.WriteLogError(FUNC_NAME_SETDEPTH, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(FUNC_NAME_SETDEPTH);
            }
        }

        private double random(double a, double b)
        {
            double result = 0;

            result = (a + 3.14159265) * (b + 3.14159265);

            result -= Math.Truncate(result);
            result *= 2.0;
            result -= 1.0;
            return result;
            //return Math.Round(result, 6);

            //double r;
            //r = (a + 3.14159265) * (b + 3.14159265);
            //return (2.0 * (r - (int)r) - 1.0);

        }

        #endregion
    }
}
