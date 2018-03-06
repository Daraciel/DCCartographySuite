using System;
using System.Collections.Generic;
using System.Reflection;
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
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method);
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
                    case MapProjections.PETERS:
                        DoPeterProjection();
                        break;
                    case MapProjections.SQUARE:
                        DoSquareProjection();
                        break;
                    case MapProjections.MOLLWEIDE:
                        DoMollweideProjection();
                        break;
                    case MapProjections.SINUSOID:
                        DoSinusoidProjection();
                        break;
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
            
            return resultMap;
        }

        public override void Initialize(InitializeParams parameters)
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, parameters);
                foreach(KeyValuePair<AlgorithmParameters, object> par in parameters.Parameters)
                {
                    this.SetParameter(par.Key, par.Value);
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }

        }

        public override void SetParameter(AlgorithmParameters paramType, object value)
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, paramType, value);
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
                this.WriteLogError(method, ex);
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
        }

        #endregion

        #region PUBLIC METHODS

        public static HashSet<MapProjections> SupportedProjections()
        {
            return new HashSet<MapProjections>() {  MapProjections.MERCATOR, MapProjections.PETERS, MapProjections.SQUARE,
                                                    MapProjections.MOLLWEIDE, MapProjections.SINUSOID};
        }

        #endregion

        #region PROJECTIONS

        private void DoMercatorProjection()
        {
            double x, y, z, scale1, cos2, theta1;
            int i, j, k;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method);

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
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
        }

        private void DoPeterProjection()
        {
            double x, y, z, cos2, theta1, scale1;
            int k, i, j;//, water, land;

            y = 2.0*latitudeSin;
            k = (int)(0.5*y*Width*Scale/Constants.PI+0.5);
            //water = land = 0;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method);
                for (j = 0; j < Height; j++) 
                {
                    y = 0.5*Constants.PI*(2.0*(j-k)-Height)/Width/Scale;
                    if (Math.Abs(y)>1.0)
                    {
                        for (i = 0; i < Width ; i++) 
                        {
                            setFixedPointValue(i, j, Constants.COLOURS_BLACK);
                        }
                    }		
                    else 
                    {
                        cos2 = Math.Sqrt(1.0 - y*y);
                        if (cos2>0.0) 
                        {
                            scale1 = Scale*Width/Height/cos2/Constants.PI;
                            depth = 3*((int)(Math.Log(scale1*Height, 2)))+3;
                            for (i = 0; i < Width ; i++) 
                            {
                                theta1 = Longitude-0.5*Constants.PI + Constants.PI*(2.0*i-Width)/Width/Scale;
                                x = Math.Cos(theta1)*cos2;
                                z = -Math.Sin(theta1)*cos2;
                                generatePoint(x, y, z, i, j);
                                //if (col[i][j] < LAND) water++; else land++;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
        }

        private void DoSquareProjection()
        {
            double x, y, z, scale1, theta1, cos2;
            int k, i, j;

            k = (int)(0.5 * Latitude * Width * Scale / Constants.PI + 0.5);
            for (j = 0; j < Height; j++)
            {
                y = (2.0 * (j - k) - Height) / Width / Scale * Constants.PI;
                if (Math.Abs(y + y) > Constants.PI)
                {
                    for (i = 0; i < Width; i++)
                    {
                        setFixedPointValue(i, j, Constants.COLOURS_BLACK);
                    }
                }
                else
                {
                    cos2 = Math.Cos(y);
                    y = Math.Sin(y);
                    if (cos2 > 0.0)
                    {
                        scale1 = scale * Width / Height / cos2 / Constants.PI;
                        depth = 3 * ((int)(Math.Log(scale1 * Height, 2))) + 3;
                        for (i = 0; i < Width; i++)
                        {
                            theta1 = Longitude - 0.5 * Constants.PI + Constants.PI * (2.0 * i - Width) / Width / scale;
                            x = Math.Cos(theta1) * cos2;
                            z = -Math.Sin(theta1) * cos2;
                            generatePoint(x, y, z, i, j);
                        }
                    }
                }
            }
        }

        private void DoMollweideProjection()
        {
            double x, y, z, y1, zz, scale1, cos2, theta1;
            int i, j, k;

            for (j = 0; j < Height; j++)
            {
                y1 = 2 * (2.0 * j - Height) / Width / Scale;
                if (Math.Abs(y1) >= 1.0)
                {
                    for (i = 0; i < Width; i++)
                    {
                        setFixedPointValue(i, j, Constants.COLOURS_BLACK);
                    }
                }
                else
                {
                    zz = Math.Sqrt(1.0 - y1 * y1);
                    y = 2.0 / Constants.PI * (y1 * zz + Math.Asin(y1));
                    cos2 = Math.Sqrt(1.0 - y * y);
                    if (cos2 > 0.0)
                    {
                        scale1 = Scale * Width / Height / cos2 / Constants.PI;
                        depth = 3 * ((int)(Math.Log(scale1 * Height, 2))) + 3;
                        for (i = 0; i < Width; i++)
                        {
                            theta1 = Constants.PI / zz * (2.0 * i - Width) / Width / Scale;
                            if (Math.Abs(theta1) > Constants.PI)
                            {
                                setFixedPointValue(i, j, Constants.COLOURS_BLACK);
                            }
                            else
                            {
                                double x2, y2, z2, x3, y3, z3;
                                theta1 += -0.5 * Constants.PI;
                                x2 = Math.Cos(theta1) * cos2;
                                y2 = y;
                                z2 = -Math.Sin(theta1) * cos2;
                                x3 = longitudeCos * x2 + longitudeSin * latitudeSin * y2 + longitudeSin * latitudeCos * z2;
                                y3 = latitudeCos * y2 - latitudeSin * z2;
                                z3 = -longitudeSin * x2 + longitudeCos * latitudeSin * y2 + longitudeCos * latitudeCos * z2;

                                generatePoint(x3, y3, z3, i, j);
                            }
                        }
                    }
                }
            }
        }

        private void DoSinusoidProjection()
        {
            double x, y, z, theta1, theta2, cos2, l1, i1, scale1;
            int k, i, j, l, c;

            k = (int)(Latitude * Width * Scale / Constants.PI + 0.5);
            for (j = 0; j < Height; j++)
            {
                y = (2.0 * (j - k) - Height) / Width / Scale * Constants.PI;
                if (Math.Abs(y + y) > Constants.PI)
                {
                    for (i = 0; i < Width; i++)
                    {
                        setFixedPointValue(i, j, Constants.COLOURS_BLACK);
                    }
                }
                else
                {
                    cos2 = Math.Cos(y);
                    if (cos2 > 0.0)
                    {
                        y = Math.Sin(y);
                        scale1 = Scale * Width / Height / cos2 / Constants.PI;
                        depth = 3 * ((int)(Math.Log(scale1 * Height, 2))) + 3;
                        for (i = 0; i < Width; i++)
                        {
                            l = i * 12 / Width / (int)Scale;
                            l1 = l * Width * Scale / 12.0;
                            i1 = i - l1;
                            theta2 = Longitude - 0.5 * Constants.PI + Constants.PI * (2.0 * l1 - Width) / Width / Scale;
                            theta1 = (Constants.PI * (2.0 * i1 - Width * Scale / 12.0) / Width / Scale) / cos2;
                            if (Math.Abs(theta1) > Constants.PI / 12.0)
                            {
                                setFixedPointValue(i, j, Constants.COLOURS_BLACK);
                            }
                            else
                            {
                                x = Math.Cos(theta1 + theta2) * cos2;
                                z = -Math.Sin(theta1 + theta2) * cos2;
                                generatePoint(x, y, z, i, j);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region HEIGHT GENERATION

        private void setFixedPointValue(int i, int j, double value)
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, i, j, value);
                
                this.resultMap.Heightmap[j*this.resultMap.Width + i] = value;
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
        }

        private void generatePoint(double x, double y, double z, int i, int j)
        {
            double generatedHeight = 0;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, x, y, z, i, j);

                generatedHeight = getHeightForPoint(new Point3D(x, y, z));

                this.resultMap.Heightmap[j*this.resultMap.Width + i] = generatedHeight;
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
        }

        private double getHeightForPoint(Point3D point)
        {
            double result = 0;
            bool isInsideTetrahedron = false;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, point);

                isInsideTetrahedron = savedTetra.IsInside(point);

                if(isInsideTetrahedron)
                {
                    result = getHeightForPoint(savedTetra, point, 11);
                }
                else
                {
                    result = getHeightForPoint(defaultTetra.Copy(), 
                                            point, depth);
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method, result);
            }

            return result;
        }

        private double getHeightForPoint(Tetrahedron tetra, Point3D point, double depth)
        {
            double result = 0;
            double es, es1, es2, es3;
            double longestSideValue;
            TetrahedronPoint E;
            TetrahedronPoint A, B;
            Enum.TetrahedronEdges longestSide;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, tetra, point, depth);
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
                            A = tetra.A.Copy();
                            B = tetra.B.Copy();
                            longestSideValue = tetra.ABSideLength;
                            break;
                        case Enum.TetrahedronEdges.AC:
                            A = tetra.A.Copy();
                            B = tetra.C.Copy();
                            longestSideValue = tetra.ACSideLength;
                            break;
                        case Enum.TetrahedronEdges.AD:
                            A = tetra.A.Copy();
                            B = tetra.D.Copy();
                            longestSideValue = tetra.ADSideLength;
                            break;
                        case Enum.TetrahedronEdges.BC:
                            A = tetra.B.Copy();
                            B = tetra.C.Copy();
                            longestSideValue = tetra.BCSideLength;
                            break;
                        case Enum.TetrahedronEdges.BD:
                            A = tetra.B.Copy();
                            B = tetra.D.Copy();
                            longestSideValue = tetra.BDSideLength;
                            break;
                        case Enum.TetrahedronEdges.CD:
                            A = tetra.C.Copy();
                            B = tetra.D.Copy();
                            longestSideValue = tetra.CDSideLength;
                            break;
                    }

                    es = this.random(A.Seed, B.Seed);
                    es1 = this.random(es, es);
                    es2 = 0.5 + 0.1 * this.random(es1, es1);
                    es3 = 1.0 - es2;

                    E = new TetrahedronPoint();
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
                            if(!tetra.IsInside(point))
                            {
                                tetra.A = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.AC:
                            tetra.C = E;
                            if(!tetra.IsInside(point))
                            {
                                tetra.A = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.AD:
                            tetra.D = E;
                            if(!tetra.IsInside(point))
                            {
                                tetra.A = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.BC:
                            tetra.C = E;
                            if(!tetra.IsInside(point))
                            {
                                tetra.B = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.BD:
                            tetra.D = E;
                            if(!tetra.IsInside(point))
                            {
                                tetra.B = B;
                            }
                            break;
                        case Enum.TetrahedronEdges.CD:
                            tetra.D = E;
                            if(!tetra.IsInside(point))
                            {
                                tetra.C = B;
                            }
                            break;
                    }             
                    result = this.getHeightForPointOld(tetra, point, depth - 1);
                }
                else
                {
                    result = (tetra.A.Value + tetra.B.Value + tetra.C.Value + tetra.D.Value) / 4;

                    result = doLatitudeIcecaps(result, point.Y);
                }
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method, result);
            }
            
            return result;
        }

        private double getHeightForPointOld(Tetrahedron tetra, Point3D point, double depth)
        {
            double result = 0;
            double es, es1, es2, es3;
            double longestSideValue;
            TetrahedronPoint E;
            TetrahedronPoint B;
            Enum.TetrahedronEdges longestSide;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, tetra, point, depth);
                if (depth > 0)
                {
                    tetra.Reorder();
                    longestSide = tetra.LongestSide;
                    if (depth == 11)
                    {
                        savedTetra = tetra.Copy();
                    }
                    B = tetra.B.Copy();
                    longestSideValue = tetra.ABSideLength;

                    es = this.random(tetra.A.Seed, tetra.B.Seed);
                    es1 = this.random(es, es);
                    es2 = 0.5 + 0.1 * this.random(es1, es1);
                    es3 = 1.0 - es2;
                    E = new TetrahedronPoint();
                    E.Seed = es;

                    if (tetra.A.Seed < tetra.B.Seed )
                    {
                        E.X = (es2 * tetra.A.X + es3 * tetra.B.X);
                        E.Y = (es2 * tetra.A.Y + es3 * tetra.B.Y);
                        E.Z = (es2 * tetra.A.Z + es3 * tetra.B.Z);
                    }
                    else if (tetra.A.Seed > tetra.B.Seed)
                    {
                        E.X = (es3 * tetra.A.X + es2 * tetra.B.X);
                        E.Y = (es3 * tetra.A.Y + es2 * tetra.B.Y);
                        E.Z = (es3 * tetra.A.Z + es2 * tetra.B.Z);
                    }
                    else
                    {
                        E.X = (0.5 * tetra.A.X + 0.5 * tetra.B.X);
                        E.Y = (0.5 * tetra.A.Y + 0.5 * tetra.B.Y);
                        E.Z = (0.5 * tetra.A.Z + 0.5 * tetra.B.Z);
                    }

                    if (tetra.ABSideLength > 1.0) { longestSideValue = Math.Pow(longestSideValue, 0.5); }

                    E.Value = 0.5 * (tetra.A.Value + tetra.B.Value)
                                + es * this.AltitudeDifferenceWeight * Math.Pow(Math.Abs(tetra.A.Value - tetra.B.Value), this.AltitudeDifferencePower)
                                + es1 * this.DistanceWeight * Math.Pow(longestSideValue, this.DistanceFunctionPower);

                    tetra.B = E; 
                    if(!tetra.IsBeside(Enum.TetrahedronSides.BCD, point))
                    {
                        tetra.A = B;
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
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method, result);
            }
            
            return result;
        }

        private double doLatitudeIcecaps(double alt, double y)
        {
            double result = 0;
            double yRaised;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method, alt, y);

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
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogMessage(method, "result test = " + result);
                this.WriteLogFunctionExit(method, result);
            }

            return result;
        }

        #endregion

        #region PRIVATE METHODS

        private void InitilizeDefaultTetra()
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method);
            defaultTetra = new Tetrahedron( new double[] { -Constants.SQRT3 - 0.20, -Constants.SQRT3 - 0.22, -Constants.SQRT3 - 0.23, InitialAltitude, randSeed1 },
                                            new double[] { -Constants.SQRT3 - 0.19,  Constants.SQRT3 + 0.18,  Constants.SQRT3 + 0.17, InitialAltitude, randSeed2 },
                                            new double[] {  Constants.SQRT3 + 0.21, -Constants.SQRT3 - 0.24,  Constants.SQRT3 + 0.15, InitialAltitude, randSeed3 },
                                            new double[] {  Constants.SQRT3 + 0.24,  Constants.SQRT3 + 0.22, -Constants.SQRT3 - 0.25, InitialAltitude, randSeed4 });
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
            }
        }

        private void setDepth()
        {
            int aux = 0;
            MethodBase method = MethodBase.GetCurrentMethod();
            try
            {
                this.WriteLogFunctionEnter(method);

                aux = Convert.ToInt32(Math.Log(Scale*Height, 2));
                aux *= 3;
                aux += 6;

                depth = aux;
            }
            catch(Exception ex)
            {
                this.WriteLogError(method, ex);
                throw ex;
            }
            finally
            {
                this.WriteLogFunctionExit(method);
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
