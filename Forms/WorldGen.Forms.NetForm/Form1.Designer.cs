namespace WorldGen.Forms.NetForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcAlgorithms = new TabControl();
            tpSquaredDiamond = new TabPage();
            pbSDResult = new PictureBox();
            gbSDParameters = new GroupBox();
            btnSDGenerateRandomSeed = new Button();
            lblSDSize = new Label();
            label4 = new Label();
            btnGenerate = new Button();
            nudSDSeed = new NumericUpDown();
            label3 = new Label();
            nudSDRoughness = new NumericUpDown();
            label2 = new Label();
            nudSDDetail = new NumericUpDown();
            label1 = new Label();
            tpTetraSubd = new TabPage();
            pbTSResult = new PictureBox();
            groupBox1 = new GroupBox();
            gbTSPrinting = new GroupBox();
            label13 = new Label();
            cmbTSColourSchema = new ComboBox();
            btnTSGenerate = new Button();
            nudTSInitialAltitude = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            cmbTSProjection = new ComboBox();
            nudTSLongitude = new NumericUpDown();
            label10 = new Label();
            nudTSLatitude = new NumericUpDown();
            label9 = new Label();
            nudTSScale = new NumericUpDown();
            label8 = new Label();
            nudTSHeight = new NumericUpDown();
            label6 = new Label();
            nudTSWidth = new NumericUpDown();
            label5 = new Label();
            btnTSGenerateRandomSeed = new Button();
            btnTSPrint = new Button();
            nudTSSeed = new NumericUpDown();
            label7 = new Label();
            tcAlgorithms.SuspendLayout();
            tpSquaredDiamond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSDResult).BeginInit();
            gbSDParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSDSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSDRoughness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSDDetail).BeginInit();
            tpTetraSubd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbTSResult).BeginInit();
            groupBox1.SuspendLayout();
            gbTSPrinting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTSInitialAltitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTSLongitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTSLatitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTSScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTSHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTSWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTSSeed).BeginInit();
            SuspendLayout();
            // 
            // tcAlgorithms
            // 
            tcAlgorithms.Controls.Add(tpSquaredDiamond);
            tcAlgorithms.Controls.Add(tpTetraSubd);
            tcAlgorithms.Dock = DockStyle.Fill;
            tcAlgorithms.Location = new Point(0, 0);
            tcAlgorithms.Name = "tcAlgorithms";
            tcAlgorithms.SelectedIndex = 0;
            tcAlgorithms.Size = new Size(1075, 593);
            tcAlgorithms.TabIndex = 0;
            // 
            // tpSquaredDiamond
            // 
            tpSquaredDiamond.Controls.Add(pbSDResult);
            tpSquaredDiamond.Controls.Add(gbSDParameters);
            tpSquaredDiamond.Location = new Point(4, 24);
            tpSquaredDiamond.Name = "tpSquaredDiamond";
            tpSquaredDiamond.Padding = new Padding(3);
            tpSquaredDiamond.Size = new Size(1067, 565);
            tpSquaredDiamond.TabIndex = 0;
            tpSquaredDiamond.Text = "Squared Diamond";
            tpSquaredDiamond.UseVisualStyleBackColor = true;
            // 
            // pbSDResult
            // 
            pbSDResult.Dock = DockStyle.Left;
            pbSDResult.Location = new Point(250, 3);
            pbSDResult.Name = "pbSDResult";
            pbSDResult.Size = new Size(810, 559);
            pbSDResult.TabIndex = 1;
            pbSDResult.TabStop = false;
            // 
            // gbSDParameters
            // 
            gbSDParameters.Controls.Add(btnSDGenerateRandomSeed);
            gbSDParameters.Controls.Add(lblSDSize);
            gbSDParameters.Controls.Add(label4);
            gbSDParameters.Controls.Add(btnGenerate);
            gbSDParameters.Controls.Add(nudSDSeed);
            gbSDParameters.Controls.Add(label3);
            gbSDParameters.Controls.Add(nudSDRoughness);
            gbSDParameters.Controls.Add(label2);
            gbSDParameters.Controls.Add(nudSDDetail);
            gbSDParameters.Controls.Add(label1);
            gbSDParameters.Dock = DockStyle.Left;
            gbSDParameters.Location = new Point(3, 3);
            gbSDParameters.Name = "gbSDParameters";
            gbSDParameters.Size = new Size(247, 559);
            gbSDParameters.TabIndex = 0;
            gbSDParameters.TabStop = false;
            gbSDParameters.Text = "Parameters";
            // 
            // btnSDGenerateRandomSeed
            // 
            btnSDGenerateRandomSeed.Location = new Point(121, 129);
            btnSDGenerateRandomSeed.Name = "btnSDGenerateRandomSeed";
            btnSDGenerateRandomSeed.Size = new Size(120, 23);
            btnSDGenerateRandomSeed.TabIndex = 9;
            btnSDGenerateRandomSeed.Text = "Random Seed";
            btnSDGenerateRandomSeed.UseVisualStyleBackColor = true;
            btnSDGenerateRandomSeed.Click += btnSDGenerateRandomSeed_Click;
            // 
            // lblSDSize
            // 
            lblSDSize.Location = new Point(121, 46);
            lblSDSize.Name = "lblSDSize";
            lblSDSize.Size = new Size(108, 23);
            lblSDSize.TabIndex = 8;
            lblSDSize.Text = "1x1";
            lblSDSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(6, 46);
            label4.Name = "label4";
            label4.Size = new Size(108, 23);
            label4.TabIndex = 7;
            label4.Text = "Resulting Size:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnGenerate
            // 
            btnGenerate.Dock = DockStyle.Bottom;
            btnGenerate.Location = new Point(3, 508);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(241, 48);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // nudSDSeed
            // 
            nudSDSeed.Location = new Point(121, 103);
            nudSDSeed.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudSDSeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSDSeed.Name = "nudSDSeed";
            nudSDSeed.Size = new Size(120, 23);
            nudSDSeed.TabIndex = 5;
            nudSDSeed.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.Location = new Point(7, 103);
            label3.Name = "label3";
            label3.Size = new Size(108, 23);
            label3.TabIndex = 4;
            label3.Text = "Seed";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudSDRoughness
            // 
            nudSDRoughness.DecimalPlaces = 2;
            nudSDRoughness.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudSDRoughness.Location = new Point(121, 77);
            nudSDRoughness.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSDRoughness.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudSDRoughness.Name = "nudSDRoughness";
            nudSDRoughness.Size = new Size(120, 23);
            nudSDRoughness.TabIndex = 3;
            nudSDRoughness.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            // 
            // label2
            // 
            label2.Location = new Point(7, 77);
            label2.Name = "label2";
            label2.Size = new Size(108, 23);
            label2.TabIndex = 2;
            label2.Text = "Roughness";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudSDDetail
            // 
            nudSDDetail.Location = new Point(121, 23);
            nudSDDetail.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudSDDetail.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudSDDetail.Name = "nudSDDetail";
            nudSDDetail.Size = new Size(120, 23);
            nudSDDetail.TabIndex = 1;
            nudSDDetail.Value = new decimal(new int[] { 2, 0, 0, 0 });
            nudSDDetail.ValueChanged += nudSDDetail_ValueChanged;
            // 
            // label1
            // 
            label1.Location = new Point(7, 20);
            label1.Name = "label1";
            label1.Size = new Size(108, 23);
            label1.TabIndex = 0;
            label1.Text = "Detail (Side)";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tpTetraSubd
            // 
            tpTetraSubd.Controls.Add(pbTSResult);
            tpTetraSubd.Controls.Add(groupBox1);
            tpTetraSubd.Location = new Point(4, 24);
            tpTetraSubd.Name = "tpTetraSubd";
            tpTetraSubd.Padding = new Padding(3);
            tpTetraSubd.Size = new Size(1067, 565);
            tpTetraSubd.TabIndex = 1;
            tpTetraSubd.Text = "Tetraherical subdivision";
            tpTetraSubd.UseVisualStyleBackColor = true;
            // 
            // pbTSResult
            // 
            pbTSResult.Dock = DockStyle.Left;
            pbTSResult.Location = new Point(250, 3);
            pbTSResult.Name = "pbTSResult";
            pbTSResult.Size = new Size(810, 559);
            pbTSResult.TabIndex = 3;
            pbTSResult.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gbTSPrinting);
            groupBox1.Controls.Add(btnTSGenerate);
            groupBox1.Controls.Add(nudTSInitialAltitude);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cmbTSProjection);
            groupBox1.Controls.Add(nudTSLongitude);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(nudTSLatitude);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(nudTSScale);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(nudTSHeight);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(nudTSWidth);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnTSGenerateRandomSeed);
            groupBox1.Controls.Add(btnTSPrint);
            groupBox1.Controls.Add(nudTSSeed);
            groupBox1.Controls.Add(label7);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(247, 559);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parameters";
            // 
            // gbTSPrinting
            // 
            gbTSPrinting.Controls.Add(label13);
            gbTSPrinting.Controls.Add(cmbTSColourSchema);
            gbTSPrinting.Location = new Point(3, 343);
            gbTSPrinting.Name = "gbTSPrinting";
            gbTSPrinting.Size = new Size(241, 113);
            gbTSPrinting.TabIndex = 25;
            gbTSPrinting.TabStop = false;
            gbTSPrinting.Text = "Printing";
            // 
            // label13
            // 
            label13.Location = new Point(4, 17);
            label13.Name = "label13";
            label13.Size = new Size(108, 23);
            label13.TabIndex = 23;
            label13.Text = "Colour Schema";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTSColourSchema
            // 
            cmbTSColourSchema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTSColourSchema.FormattingEnabled = true;
            cmbTSColourSchema.Location = new Point(118, 19);
            cmbTSColourSchema.Name = "cmbTSColourSchema";
            cmbTSColourSchema.Size = new Size(119, 23);
            cmbTSColourSchema.TabIndex = 22;
            // 
            // btnTSGenerate
            // 
            btnTSGenerate.Dock = DockStyle.Bottom;
            btnTSGenerate.Location = new Point(3, 460);
            btnTSGenerate.Name = "btnTSGenerate";
            btnTSGenerate.Size = new Size(241, 48);
            btnTSGenerate.TabIndex = 24;
            btnTSGenerate.Text = "Generate and Print";
            btnTSGenerate.UseVisualStyleBackColor = true;
            btnTSGenerate.Click += btnTSGenerate_Click;
            // 
            // nudTSInitialAltitude
            // 
            nudTSInitialAltitude.DecimalPlaces = 2;
            nudTSInitialAltitude.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudTSInitialAltitude.Location = new Point(121, 231);
            nudTSInitialAltitude.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudTSInitialAltitude.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nudTSInitialAltitude.Name = "nudTSInitialAltitude";
            nudTSInitialAltitude.Size = new Size(120, 23);
            nudTSInitialAltitude.TabIndex = 23;
            nudTSInitialAltitude.Value = new decimal(new int[] { 2, 0, 0, -2147352576 });
            // 
            // label12
            // 
            label12.Location = new Point(7, 231);
            label12.Name = "label12";
            label12.Size = new Size(108, 23);
            label12.TabIndex = 22;
            label12.Text = "Initial Altitude";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Location = new Point(7, 202);
            label11.Name = "label11";
            label11.Size = new Size(108, 23);
            label11.TabIndex = 21;
            label11.Text = "Projection";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTSProjection
            // 
            cmbTSProjection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTSProjection.FormattingEnabled = true;
            cmbTSProjection.Location = new Point(121, 204);
            cmbTSProjection.Name = "cmbTSProjection";
            cmbTSProjection.Size = new Size(119, 23);
            cmbTSProjection.TabIndex = 20;
            // 
            // nudTSLongitude
            // 
            nudTSLongitude.DecimalPlaces = 2;
            nudTSLongitude.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudTSLongitude.Location = new Point(121, 178);
            nudTSLongitude.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            nudTSLongitude.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            nudTSLongitude.Name = "nudTSLongitude";
            nudTSLongitude.Size = new Size(120, 23);
            nudTSLongitude.TabIndex = 19;
            // 
            // label10
            // 
            label10.Location = new Point(7, 178);
            label10.Name = "label10";
            label10.Size = new Size(108, 23);
            label10.TabIndex = 18;
            label10.Text = "Longitude";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudTSLatitude
            // 
            nudTSLatitude.DecimalPlaces = 2;
            nudTSLatitude.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudTSLatitude.Location = new Point(121, 152);
            nudTSLatitude.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            nudTSLatitude.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            nudTSLatitude.Name = "nudTSLatitude";
            nudTSLatitude.Size = new Size(120, 23);
            nudTSLatitude.TabIndex = 17;
            // 
            // label9
            // 
            label9.Location = new Point(7, 152);
            label9.Name = "label9";
            label9.Size = new Size(108, 23);
            label9.TabIndex = 16;
            label9.Text = "Latitude";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudTSScale
            // 
            nudTSScale.DecimalPlaces = 2;
            nudTSScale.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudTSScale.Location = new Point(120, 126);
            nudTSScale.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudTSScale.Name = "nudTSScale";
            nudTSScale.Size = new Size(120, 23);
            nudTSScale.TabIndex = 15;
            nudTSScale.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            // 
            // label8
            // 
            label8.Location = new Point(6, 126);
            label8.Name = "label8";
            label8.Size = new Size(108, 23);
            label8.TabIndex = 14;
            label8.Text = "Scale";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudTSHeight
            // 
            nudTSHeight.Location = new Point(121, 100);
            nudTSHeight.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudTSHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTSHeight.Name = "nudTSHeight";
            nudTSHeight.Size = new Size(120, 23);
            nudTSHeight.TabIndex = 13;
            nudTSHeight.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // label6
            // 
            label6.Location = new Point(7, 100);
            label6.Name = "label6";
            label6.Size = new Size(108, 23);
            label6.TabIndex = 12;
            label6.Text = "Height";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudTSWidth
            // 
            nudTSWidth.Location = new Point(120, 74);
            nudTSWidth.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudTSWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTSWidth.Name = "nudTSWidth";
            nudTSWidth.Size = new Size(120, 23);
            nudTSWidth.TabIndex = 11;
            nudTSWidth.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // label5
            // 
            label5.Location = new Point(6, 74);
            label5.Name = "label5";
            label5.Size = new Size(108, 23);
            label5.TabIndex = 10;
            label5.Text = "Width";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnTSGenerateRandomSeed
            // 
            btnTSGenerateRandomSeed.Location = new Point(120, 45);
            btnTSGenerateRandomSeed.Name = "btnTSGenerateRandomSeed";
            btnTSGenerateRandomSeed.Size = new Size(120, 23);
            btnTSGenerateRandomSeed.TabIndex = 9;
            btnTSGenerateRandomSeed.Text = "Random Seed";
            btnTSGenerateRandomSeed.UseVisualStyleBackColor = true;
            btnTSGenerateRandomSeed.Click += btnTSGenerateRandomSeed_Click;
            // 
            // btnTSPrint
            // 
            btnTSPrint.Dock = DockStyle.Bottom;
            btnTSPrint.Location = new Point(3, 508);
            btnTSPrint.Name = "btnTSPrint";
            btnTSPrint.Size = new Size(241, 48);
            btnTSPrint.TabIndex = 6;
            btnTSPrint.Text = "Print";
            btnTSPrint.UseVisualStyleBackColor = true;
            btnTSPrint.Click += btnTSPrint_Click;
            // 
            // nudTSSeed
            // 
            nudTSSeed.DecimalPlaces = 10;
            nudTSSeed.Location = new Point(121, 19);
            nudTSSeed.Maximum = new decimal(new int[] { 1410065407, 2, 0, 655360 });
            nudTSSeed.Minimum = new decimal(new int[] { 1, 0, 0, 655360 });
            nudTSSeed.Name = "nudTSSeed";
            nudTSSeed.Size = new Size(120, 23);
            nudTSSeed.TabIndex = 5;
            nudTSSeed.Value = new decimal(new int[] { 1111111111, 0, 0, 655360 });
            // 
            // label7
            // 
            label7.Location = new Point(7, 19);
            label7.Name = "label7";
            label7.Size = new Size(108, 23);
            label7.TabIndex = 4;
            label7.Text = "Seed";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 593);
            Controls.Add(tcAlgorithms);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tcAlgorithms.ResumeLayout(false);
            tpSquaredDiamond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbSDResult).EndInit();
            gbSDParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSDSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSDRoughness).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSDDetail).EndInit();
            tpTetraSubd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbTSResult).EndInit();
            groupBox1.ResumeLayout(false);
            gbTSPrinting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudTSInitialAltitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTSLongitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTSLatitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTSScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTSHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTSWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTSSeed).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.TabControl tcAlgorithms;
        private System.Windows.Forms.TabPage tpSquaredDiamond;
        private System.Windows.Forms.TabPage tpTetraSubd;
        private System.Windows.Forms.GroupBox gbSDParameters;
        private System.Windows.Forms.NumericUpDown nudSDDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSDRoughness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSDSeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbSDResult;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblSDSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSDGenerateRandomSeed;
        private System.Windows.Forms.PictureBox pbTSResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTSGenerateRandomSeed;
        private System.Windows.Forms.Button btnTSPrint;
        private System.Windows.Forms.NumericUpDown nudTSSeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudTSWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTSHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudTSLatitude;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudTSScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudTSLongitude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTSProjection;
        private System.Windows.Forms.NumericUpDown nudTSInitialAltitude;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnTSGenerate;
        private System.Windows.Forms.GroupBox gbTSPrinting;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTSColourSchema;
    }
}
