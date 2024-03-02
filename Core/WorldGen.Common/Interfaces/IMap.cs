using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using WorldGen.Common.BE;

namespace WorldGen.Common.Interfaces
{
    public abstract class IMap
    {
        #region FIELDS

        protected ColorSchema colorPalette;

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

        public abstract Image<Rgba32> PrintBW();

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

        public void SetColorSchema(string path)
        {
            if(File.Exists(path))
            {
                this.colorPalette = new ColorSchema(path);
                this.resultingMap = null;
            }
        }

        #endregion
    }
}
