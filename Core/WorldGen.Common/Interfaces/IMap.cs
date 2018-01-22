using ImageSharp;
using System;
using System.Threading.Tasks;

namespace WorldGen.Common.Interfaces
{
    public abstract class IMap
    {
        #region FIELDS

        protected Image<Rgba32> resultingMap;

        #endregion

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

        private void prepareSave()
        {
            if(resultingMap == null)
            {
                resultingMap = Print();
            }
        }

        public void Save(string path)
        {
            prepareSave();
            resultingMap.Save(path);
        }

        #endregion
    }
}
