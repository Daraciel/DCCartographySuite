namespace WorldGen.Forms.TestForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tcAlgorithms.SuspendLayout();
            this.tpSquaredDiamond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSDResult)).BeginInit();
            this.gbSDParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDRoughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDDetail)).BeginInit();
            this.tpTetraSubd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
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
            this.tcAlgorithms.Size = new System.Drawing.Size(890, 593);
            this.tcAlgorithms.TabIndex = 0;
            // 
            // tpSquaredDiamond
            // 
            this.tpSquaredDiamond.Controls.Add(this.pbSDResult);
            this.tpSquaredDiamond.Controls.Add(this.gbSDParameters);
            this.tpSquaredDiamond.Location = new System.Drawing.Point(4, 22);
            this.tpSquaredDiamond.Name = "tpSquaredDiamond";
            this.tpSquaredDiamond.Padding = new System.Windows.Forms.Padding(3);
            this.tpSquaredDiamond.Size = new System.Drawing.Size(882, 567);
            this.tpSquaredDiamond.TabIndex = 0;
            this.tpSquaredDiamond.Text = "Squared Diamond";
            this.tpSquaredDiamond.UseVisualStyleBackColor = true;
            // 
            // pbSDResult
            // 
            this.pbSDResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbSDResult.Location = new System.Drawing.Point(256, 3);
            this.pbSDResult.Name = "pbSDResult";
            this.pbSDResult.Size = new System.Drawing.Size(623, 561);
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
            this.tpTetraSubd.Controls.Add(this.pictureBox1);
            this.tpTetraSubd.Controls.Add(this.groupBox1);
            this.tpTetraSubd.Location = new System.Drawing.Point(4, 22);
            this.tpTetraSubd.Name = "tpTetraSubd";
            this.tpTetraSubd.Padding = new System.Windows.Forms.Padding(3);
            this.tpTetraSubd.Size = new System.Drawing.Size(882, 567);
            this.tpTetraSubd.TabIndex = 1;
            this.tpTetraSubd.Text = "Tetraherical subdivision";
            this.tpTetraSubd.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(256, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 561);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 561);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Random Seed";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(121, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "1x1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Resulting Size:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(3, 510);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 48);
            this.button2.TabIndex = 6;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(121, 103);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "Seed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(121, 77);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Roughness";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(121, 23);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 1;
            this.numericUpDown3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Detail (Side)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 593);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label9;
    }
}

