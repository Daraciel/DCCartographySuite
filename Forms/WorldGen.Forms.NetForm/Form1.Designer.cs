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
            this.tcAlgorithms = new System.Windows.Forms.TabControl();
            this.tpSquaredDiamond = new System.Windows.Forms.TabPage();
            this.pbSDResult = new System.Windows.Forms.PictureBox();
            this.gbSDParameters = new System.Windows.Forms.GroupBox();
            this.btnSDGenerateRandomSeed = new System.Windows.Forms.Button();
            this.lblSDSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.nudSDSeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSDRoughness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSDDetail = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tpTetraSubd = new System.Windows.Forms.TabPage();
            this.pbTSResult = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTSGenerate = new System.Windows.Forms.Button();
            this.nudTSInitialAltitude = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTSProjection = new System.Windows.Forms.ComboBox();
            this.nudTSLongitude = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudTSLatitude = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudTSScale = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudTSHeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudTSWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTSGenerateRandomSeed = new System.Windows.Forms.Button();
            this.btnTSPrint = new System.Windows.Forms.Button();
            this.nudTSSeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.gbTSPrinting = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTSColourSchema = new System.Windows.Forms.ComboBox();
            this.tcAlgorithms.SuspendLayout();
            this.tpSquaredDiamond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSDResult)).BeginInit();
            this.gbSDParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDRoughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDDetail)).BeginInit();
            this.tpTetraSubd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTSResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSInitialAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSLongitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSLatitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSSeed)).BeginInit();
            this.gbTSPrinting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAlgorithms
            // 
            this.tcAlgorithms.Controls.Add(this.tpSquaredDiamond);
            this.tcAlgorithms.Controls.Add(this.tpTetraSubd);
            this.tcAlgorithms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlgorithms.Location = new System.Drawing.Point(0, 0);
            this.tcAlgorithms.Name = "tcAlgorithms";
            this.tcAlgorithms.SelectedIndex = 0;
            this.tcAlgorithms.Size = new System.Drawing.Size(1075, 593);
            this.tcAlgorithms.TabIndex = 0;
            // 
            // tpSquaredDiamond
            // 
            this.tpSquaredDiamond.Controls.Add(this.pbSDResult);
            this.tpSquaredDiamond.Controls.Add(this.gbSDParameters);
            this.tpSquaredDiamond.Location = new System.Drawing.Point(4, 22);
            this.tpSquaredDiamond.Name = "tpSquaredDiamond";
            this.tpSquaredDiamond.Padding = new System.Windows.Forms.Padding(3);
            this.tpSquaredDiamond.Size = new System.Drawing.Size(1067, 567);
            this.tpSquaredDiamond.TabIndex = 0;
            this.tpSquaredDiamond.Text = "Squared Diamond";
            this.tpSquaredDiamond.UseVisualStyleBackColor = true;
            // 
            // pbSDResult
            // 
            this.pbSDResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbSDResult.Location = new System.Drawing.Point(250, 3);
            this.pbSDResult.Name = "pbSDResult";
            this.pbSDResult.Size = new System.Drawing.Size(810, 561);
            this.pbSDResult.TabIndex = 1;
            this.pbSDResult.TabStop = false;
            // 
            // gbSDParameters
            // 
            this.gbSDParameters.Controls.Add(this.btnSDGenerateRandomSeed);
            this.gbSDParameters.Controls.Add(this.lblSDSize);
            this.gbSDParameters.Controls.Add(this.label4);
            this.gbSDParameters.Controls.Add(this.btnGenerate);
            this.gbSDParameters.Controls.Add(this.nudSDSeed);
            this.gbSDParameters.Controls.Add(this.label3);
            this.gbSDParameters.Controls.Add(this.nudSDRoughness);
            this.gbSDParameters.Controls.Add(this.label2);
            this.gbSDParameters.Controls.Add(this.nudSDDetail);
            this.gbSDParameters.Controls.Add(this.label1);
            this.gbSDParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbSDParameters.Location = new System.Drawing.Point(3, 3);
            this.gbSDParameters.Name = "gbSDParameters";
            this.gbSDParameters.Size = new System.Drawing.Size(247, 561);
            this.gbSDParameters.TabIndex = 0;
            this.gbSDParameters.TabStop = false;
            this.gbSDParameters.Text = "Parameters";
            // 
            // btnSDGenerateRandomSeed
            // 
            this.btnSDGenerateRandomSeed.Location = new System.Drawing.Point(121, 129);
            this.btnSDGenerateRandomSeed.Name = "btnSDGenerateRandomSeed";
            this.btnSDGenerateRandomSeed.Size = new System.Drawing.Size(120, 23);
            this.btnSDGenerateRandomSeed.TabIndex = 9;
            this.btnSDGenerateRandomSeed.Text = "Random Seed";
            this.btnSDGenerateRandomSeed.UseVisualStyleBackColor = true;
            this.btnSDGenerateRandomSeed.Click += new System.EventHandler(this.btnSDGenerateRandomSeed_Click);
            // 
            // lblSDSize
            // 
            this.lblSDSize.Location = new System.Drawing.Point(121, 46);
            this.lblSDSize.Name = "lblSDSize";
            this.lblSDSize.Size = new System.Drawing.Size(108, 23);
            this.lblSDSize.TabIndex = 8;
            this.lblSDSize.Text = "1x1";
            this.lblSDSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Resulting Size:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Location = new System.Drawing.Point(3, 510);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(241, 48);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // nudSDSeed
            // 
            this.nudSDSeed.Location = new System.Drawing.Point(121, 103);
            this.nudSDSeed.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSDSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSDSeed.Name = "nudSDSeed";
            this.nudSDSeed.Size = new System.Drawing.Size(120, 20);
            this.nudSDSeed.TabIndex = 5;
            this.nudSDSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSDRoughness
            // 
            this.nudSDRoughness.DecimalPlaces = 2;
            this.nudSDRoughness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudSDRoughness.Location = new System.Drawing.Point(121, 77);
            this.nudSDRoughness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSDRoughness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudSDRoughness.Name = "nudSDRoughness";
            this.nudSDRoughness.Size = new System.Drawing.Size(120, 20);
            this.nudSDRoughness.TabIndex = 3;
            this.nudSDRoughness.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Roughness";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSDDetail
            // 
            this.nudSDDetail.Location = new System.Drawing.Point(121, 23);
            this.nudSDDetail.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudSDDetail.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSDDetail.Name = "nudSDDetail";
            this.nudSDDetail.Size = new System.Drawing.Size(120, 20);
            this.nudSDDetail.TabIndex = 1;
            this.nudSDDetail.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSDDetail.ValueChanged += new System.EventHandler(this.nudSDDetail_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detail (Side)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpTetraSubd
            // 
            this.tpTetraSubd.Controls.Add(this.pbTSResult);
            this.tpTetraSubd.Controls.Add(this.groupBox1);
            this.tpTetraSubd.Location = new System.Drawing.Point(4, 22);
            this.tpTetraSubd.Name = "tpTetraSubd";
            this.tpTetraSubd.Padding = new System.Windows.Forms.Padding(3);
            this.tpTetraSubd.Size = new System.Drawing.Size(1067, 567);
            this.tpTetraSubd.TabIndex = 1;
            this.tpTetraSubd.Text = "Tetraherical subdivision";
            this.tpTetraSubd.UseVisualStyleBackColor = true;
            // 
            // pbTSResult
            // 
            this.pbTSResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbTSResult.Location = new System.Drawing.Point(250, 3);
            this.pbTSResult.Name = "pbTSResult";
            this.pbTSResult.Size = new System.Drawing.Size(810, 561);
            this.pbTSResult.TabIndex = 3;
            this.pbTSResult.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbTSPrinting);
            this.groupBox1.Controls.Add(this.btnTSGenerate);
            this.groupBox1.Controls.Add(this.nudTSInitialAltitude);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbTSProjection);
            this.groupBox1.Controls.Add(this.nudTSLongitude);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nudTSLatitude);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.nudTSScale);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nudTSHeight);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudTSWidth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnTSGenerateRandomSeed);
            this.groupBox1.Controls.Add(this.btnTSPrint);
            this.groupBox1.Controls.Add(this.nudTSSeed);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 561);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // btnTSGenerate
            // 
            this.btnTSGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTSGenerate.Location = new System.Drawing.Point(3, 462);
            this.btnTSGenerate.Name = "btnTSGenerate";
            this.btnTSGenerate.Size = new System.Drawing.Size(241, 48);
            this.btnTSGenerate.TabIndex = 24;
            this.btnTSGenerate.Text = "Generate and Print";
            this.btnTSGenerate.UseVisualStyleBackColor = true;
            this.btnTSGenerate.Click += new System.EventHandler(this.btnTSGenerate_Click);
            // 
            // nudTSInitialAltitude
            // 
            this.nudTSInitialAltitude.DecimalPlaces = 2;
            this.nudTSInitialAltitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTSInitialAltitude.Location = new System.Drawing.Point(121, 231);
            this.nudTSInitialAltitude.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTSInitialAltitude.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudTSInitialAltitude.Name = "nudTSInitialAltitude";
            this.nudTSInitialAltitude.Size = new System.Drawing.Size(120, 20);
            this.nudTSInitialAltitude.TabIndex = 23;
            this.nudTSInitialAltitude.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147352576});
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "Initial Altitude";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Projection";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTSProjection
            // 
            this.cmbTSProjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTSProjection.FormattingEnabled = true;
            this.cmbTSProjection.Location = new System.Drawing.Point(121, 204);
            this.cmbTSProjection.Name = "cmbTSProjection";
            this.cmbTSProjection.Size = new System.Drawing.Size(119, 21);
            this.cmbTSProjection.TabIndex = 20;
            // 
            // nudTSLongitude
            // 
            this.nudTSLongitude.DecimalPlaces = 2;
            this.nudTSLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTSLongitude.Location = new System.Drawing.Point(121, 178);
            this.nudTSLongitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudTSLongitude.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudTSLongitude.Name = "nudTSLongitude";
            this.nudTSLongitude.Size = new System.Drawing.Size(120, 20);
            this.nudTSLongitude.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(7, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Longitude";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTSLatitude
            // 
            this.nudTSLatitude.DecimalPlaces = 2;
            this.nudTSLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTSLatitude.Location = new System.Drawing.Point(121, 152);
            this.nudTSLatitude.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudTSLatitude.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudTSLatitude.Name = "nudTSLatitude";
            this.nudTSLatitude.Size = new System.Drawing.Size(120, 20);
            this.nudTSLatitude.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Latitude";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTSScale
            // 
            this.nudTSScale.DecimalPlaces = 2;
            this.nudTSScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTSScale.Location = new System.Drawing.Point(120, 126);
            this.nudTSScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTSScale.Name = "nudTSScale";
            this.nudTSScale.Size = new System.Drawing.Size(120, 20);
            this.nudTSScale.TabIndex = 15;
            this.nudTSScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Scale";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTSHeight
            // 
            this.nudTSHeight.Location = new System.Drawing.Point(121, 100);
            this.nudTSHeight.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTSHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTSHeight.Name = "nudTSHeight";
            this.nudTSHeight.Size = new System.Drawing.Size(120, 20);
            this.nudTSHeight.TabIndex = 13;
            this.nudTSHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Height";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTSWidth
            // 
            this.nudTSWidth.Location = new System.Drawing.Point(120, 74);
            this.nudTSWidth.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTSWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTSWidth.Name = "nudTSWidth";
            this.nudTSWidth.Size = new System.Drawing.Size(120, 20);
            this.nudTSWidth.TabIndex = 11;
            this.nudTSWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Width";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTSGenerateRandomSeed
            // 
            this.btnTSGenerateRandomSeed.Location = new System.Drawing.Point(120, 45);
            this.btnTSGenerateRandomSeed.Name = "btnTSGenerateRandomSeed";
            this.btnTSGenerateRandomSeed.Size = new System.Drawing.Size(120, 23);
            this.btnTSGenerateRandomSeed.TabIndex = 9;
            this.btnTSGenerateRandomSeed.Text = "Random Seed";
            this.btnTSGenerateRandomSeed.UseVisualStyleBackColor = true;
            this.btnTSGenerateRandomSeed.Click += new System.EventHandler(this.btnTSGenerateRandomSeed_Click);
            // 
            // btnTSPrint
            // 
            this.btnTSPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTSPrint.Location = new System.Drawing.Point(3, 510);
            this.btnTSPrint.Name = "btnTSPrint";
            this.btnTSPrint.Size = new System.Drawing.Size(241, 48);
            this.btnTSPrint.TabIndex = 6;
            this.btnTSPrint.Text = "Print";
            this.btnTSPrint.UseVisualStyleBackColor = true;
            this.btnTSPrint.Click += new System.EventHandler(this.btnTSPrint_Click);
            // 
            // nudTSSeed
            // 
            this.nudTSSeed.DecimalPlaces = 10;
            this.nudTSSeed.Location = new System.Drawing.Point(121, 19);
            this.nudTSSeed.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            655360});
            this.nudTSSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.nudTSSeed.Name = "nudTSSeed";
            this.nudTSSeed.Size = new System.Drawing.Size(120, 20);
            this.nudTSSeed.TabIndex = 5;
            this.nudTSSeed.Value = new decimal(new int[] {
            1111111111,
            0,
            0,
            655360});
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "Seed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbTSPrinting
            // 
            this.gbTSPrinting.Controls.Add(this.label13);
            this.gbTSPrinting.Controls.Add(this.cmbTSColourSchema);
            this.gbTSPrinting.Location = new System.Drawing.Point(3, 343);
            this.gbTSPrinting.Name = "gbTSPrinting";
            this.gbTSPrinting.Size = new System.Drawing.Size(241, 113);
            this.gbTSPrinting.TabIndex = 25;
            this.gbTSPrinting.TabStop = false;
            this.gbTSPrinting.Text = "Printing";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(4, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 23);
            this.label13.TabIndex = 23;
            this.label13.Text = "Colour Schema";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTSColourSchema
            // 
            this.cmbTSColourSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTSColourSchema.FormattingEnabled = true;
            this.cmbTSColourSchema.Location = new System.Drawing.Point(118, 19);
            this.cmbTSColourSchema.Name = "cmbTSColourSchema";
            this.cmbTSColourSchema.Size = new System.Drawing.Size(119, 21);
            this.cmbTSColourSchema.TabIndex = 22;

            SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 593);
            this.Controls.Add(this.tcAlgorithms);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcAlgorithms.ResumeLayout(false);
            this.tpSquaredDiamond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSDResult)).EndInit();
            this.gbSDParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSDSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDRoughness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDDetail)).EndInit();
            this.tpTetraSubd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTSResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTSInitialAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSLongitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSLatitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTSSeed)).EndInit();
            this.gbTSPrinting.ResumeLayout(false);
            this.ResumeLayout(false);
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
