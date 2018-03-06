using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldGen.Algorithm.SquaredDiamond;
using WorldGen.Algorithm.TetrahedralSubdivision;
using WorldGen.Common.BE;
using WorldGen.Common.Enums;
using WorldGen.Common.Maps;

namespace WorldGen.Forms.TestForm
{
    public partial class Form1 : Form
    {
        private InitializeParams parameters;
        private SquaredDiamond SDAlgorithm;
        private TetrahedralSubdivision TSAlgorithm;
        private Random rnd;

        private HeightMap TSMaps;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.setSquaredDiamondValues();
            this.setTetrahedricalSubdivisionValues();
        }

        #region SQUARED-DIAMOND METHODS

        private void setSquaredDiamondValues()
        {
            this.nudSDDetail.Value = 8;
            this.nudSDSeed.Value = rnd.Next(99999999);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int detail;
            float roughness;
            int seed;
            parameters = new InitializeParams();

            detail = int.Parse(nudSDDetail.Value.ToString());
            roughness = float.Parse(nudSDRoughness.Value.ToString());
            seed = int.Parse(nudSDSeed.Value.ToString());

            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.DETAIL, detail);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.ROUGHNESS, roughness);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SEED, seed);

            SDAlgorithm = new SquaredDiamond();
            SDAlgorithm.Initialize(parameters);
            SDAlgorithm.Create().Save(@"C:/sample/sampleimage.jpg");
            pbSDResult.ImageLocation = @"C:/sample/sampleimage.jpg";




        }

        private void nudSDDetail_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)Math.Pow(2, (int)nudSDDetail.Value);
            this.lblSDSize.Text = size + "x" + size;
        }

        private void btnSDGenerateRandomSeed_Click(object sender, EventArgs e)
        {
            this.nudSDSeed.Value = rnd.Next(99999999);
        }

        #endregion

        #region TETRAHEDRICAL SUBDIVISION METHODS

        private void setTetrahedricalSubdivisionValues()
        {
            this.populateCmbTSProjection();
            this.populateCmbTSColourSchema();
        }

        private void populateCmbTSColourSchema()
        {
            this.cmbTSColourSchema.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(@"ColorSchemas/");
            FileInfo[] Files = d.GetFiles("*.col");

            this.cmbTSColourSchema.DataSource = new BindingSource(Files.ToDictionary(t => t.Name, t => t.FullName), null);
            this.cmbTSColourSchema.DisplayMember = "Key";
            this.cmbTSColourSchema.ValueMember = "Value";

        }

        private void populateCmbTSProjection()
        {
            this.cmbTSProjection.Items.Clear();
            HashSet<MapProjections> projs;

            projs = TetrahedralSubdivision.SupportedProjections();

            this.cmbTSProjection.DataSource = new BindingSource(projs.ToDictionary(t => (int)t, t => t.ToString()), null);
            this.cmbTSProjection.DisplayMember = "Value";
            this.cmbTSProjection.ValueMember = "Key";

        }

        private void btnTSGenerate_Click(object sender, EventArgs e)
        {
            int width, height;
            double seed, scale, latitude, longitude, initialAltitude;
            MapProjections projection;
            parameters = new InitializeParams();

            seed = (double)nudTSSeed.Value;
            width = (int)nudTSWidth.Value;
            height = (int)nudTSHeight.Value;
            scale = (double)nudTSScale.Value;
            longitude = (double)nudTSLongitude.Value;
            latitude = (double)nudTSLatitude.Value;
            initialAltitude = (double)nudTSInitialAltitude.Value;
            projection = (MapProjections)cmbTSProjection.SelectedValue;

            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SEED, seed);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.WIDTH, width);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.HEIGHT, height);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.SCALE, scale);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.LONGITUDE, longitude);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.LATITUDE, latitude);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.INITIAL_ALTITUDE, initialAltitude);
            parameters.Parameters.Add(Common.Enums.AlgorithmParameters.PROJECTION, projection);

            TSAlgorithm = new TetrahedralSubdivision();
            TSAlgorithm.Initialize(parameters);
            TSMaps = (HeightMap)TSAlgorithm.Create();
            TSPrint();
        }

        private void btnTSPrint_Click(object sender, EventArgs e)
        {
            TSPrint();
        }

        private void TSPrint()
        {
            TSMaps.SetColorSchema(this.cmbTSColourSchema.SelectedValue.ToString());
            TSMaps.Save(@"C:/sample/sampleTSimage.jpg");
            pbTSResult.ImageLocation = @"C:/sample/sampleTSimage.jpg";
        }

        private void btnTSGenerateRandomSeed_Click(object sender, EventArgs e)
        {
            this.nudTSSeed.Value = (decimal)rnd.NextDouble();
        }

        #endregion
    }
}
