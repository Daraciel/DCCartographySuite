using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldGen.Algorithm.SquaredDiamond;
using WorldGen.Common.BE;

namespace WorldGen.Forms.TestForm
{
    public partial class Form1 : Form
    {
        private InitializeParams parameters;
        private SquaredDiamond SDAlgorithm;
        private Random rnd;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.nudSDDetail.Value = 8;
            this.nudSDSeed.Value = rnd.Next(99999999);
        }

        private void btnSDGenerateRandomSeed_Click(object sender, EventArgs e)
        {
            this.nudSDSeed.Value = rnd.Next(99999999);
        }


    }
}
