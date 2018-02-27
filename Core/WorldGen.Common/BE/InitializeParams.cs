using System.Collections.Generic;
using WorldGen.Common.Enums;

namespace WorldGen.Common.BE
{
    public class InitializeParams
    {
        /// <summary>
        /// Default constructor for InitializeParams class
        /// </summary>
        public InitializeParams()
        {
            Parameters = new Dictionary<AlgorithmParameters, object>();
        }

        /// <summary>
        /// Parameter Collection
        /// </summary>
        public Dictionary<AlgorithmParameters, object> Parameters { get; set; }
        
        #region OVERRIDE METHODS

        public override string ToString()
        {
            string result = string.Empty;

            foreach(KeyValuePair<AlgorithmParameters, object> par in this.Parameters)
            {
                result += string.Format("Key: {0} | Value: {1} # ",
                                        par.Key.ToString(), par.Value.ToString());
            }

            return result;
        }

        #endregion
    }
}
