using ImageSharp;
using System;
using System.Threading.Tasks;

namespace WorldGen.Common.Interfaces
{
    public abstract class IMap
    {
        #region CONSTRUCTORS

        public IMap()
        {
        }

        #endregion

        #region PROPERTIES

        public Tuple<int, int> Size { get; set; }

        #endregion

        #region METHODS

        public abstract Image<Rgba32> Print();

        #endregion
    }
}
