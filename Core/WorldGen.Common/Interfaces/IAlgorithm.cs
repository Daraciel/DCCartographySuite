﻿
using System;
using System.Collections.Generic;
using WorldGen.Common.Enums;

namespace WorldGen.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class IAlgorithm : ILoggable
    {
        #region FIELDS

        /// <summary>
        /// Flag to indicate if debug mode is set
        /// </summary>
        protected bool debugMode;

        /// <summary>
        /// Collection of map types that can be generated by this algorithm
        /// </summary>
        protected HashSet<MapTypes> outputMapList;

        #endregion

        #region PROPERTIES

        public bool DebugMode
        {
            get { return debugMode; }
            set { debugMode = value; }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Mass parameter initializer
        /// </summary>
        /// <param name="parameters">Array of parameters</param>
        public abstract void Initialize(BE.InitializeParams parameters);

        /// <summary>
        /// Sets a single parameter
        /// </summary>
        /// <param name="paramType"> Parameter type</param>
        /// <param name="value"> Parameter value</param>
        public abstract void SetParameter(AlgorithmParameters paramType, object value);

        /// <summary>
        /// Creates a map
        /// </summary>
        /// <returns>A map cretad by the algorithm</returns>
        public abstract IMap Create();

        #endregion

        #region ILOGGABLE


        protected override void WriteLogFunctionEnter(string fName, params object[] values)
        {
            string logString = String.Empty;
            string paramValues = String.Empty;
            if(this.DebugMode)
            {
                paramValues = this.GetArrayObjectsString(values);
                logString = string.Format(  this.functionEnterBaseString,
                                            DateTime.Now.ToString("HHmmSS"),
                                            this.GetType().Name,
                                            fName,
                                            paramValues);
            }
        }

        protected override void WriteLogFunctionExit(string fName, object result = null)
        {
            string logString = String.Empty;
            string resultString = String.Empty;
            if(this.DebugMode)
            {
                resultString = this.GetResultObjectString(result);
                logString = string.Format(  this.functionExitBaseString,
                                            DateTime.Now.ToString("HHmmSS"),
                                            this.GetType().Name,
                                            fName,
                                            resultString);
            }
        }

        protected override void WriteLogError(string fName, Exception ex)
        {
            string logString = String.Empty;
            logString = string.Format(  this.functionErrorBaseString,
                                        DateTime.Now.ToString("HHmmSS"),
                                        this.GetType().Name,
                                        fName,
                                        ex.Message);
        }

        protected override void WriteLogMessage(string fName, string message)
        {
            string logString = String.Empty;
            if(this.DebugMode)
            {
                logString = string.Format(  this.functionMessageBaseString,
                                            DateTime.Now.ToString("HHmmSS"),
                                            this.GetType().Name,
                                            fName,
                                            message);
            }
        }

        #endregion
    }
}
