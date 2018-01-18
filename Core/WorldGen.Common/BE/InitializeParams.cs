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
    }
}
