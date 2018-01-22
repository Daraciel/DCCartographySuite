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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.nudSDSeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSDRoughness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSDDetail = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSDSize = new System.Windows.Forms.Label();
            this.btnSDGenerateRandomSeed = new System.Windows.Forms.Button();
            this.tcAlgorithms.SuspendLayout();
            this.tpSquaredDiamond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSDResult)).BeginInit();
            this.gbSDParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDRoughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAlgorithms
            // 
            this.tcAlgorithms.Controls.Add(this.tpSquaredDiamond);
            this.tcAlgorithms.Controls.Add(this.tabPage2);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(882, 567);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // lblSDSize
            // 
            this.lblSDSize.Location = new System.Drawing.Point(121, 46);
            this.lblSDSize.Name = "lblSDSize";
            this.lblSDSize.Size = new System.Drawing.Size(108, 23);
            this.lblSDSize.TabIndex = 8;
            this.lblSDSize.Text = "1x1";
            this.lblSDSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAlgorithms;
        private System.Windows.Forms.TabPage tpSquaredDiamond;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}

