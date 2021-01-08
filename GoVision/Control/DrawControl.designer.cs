namespace GoVision
{
    partial class DrawControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawControl));
            this.BtnDrawLine = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboOpera = new System.Windows.Forms.ComboBox();
            this.BtnSaveRoi = new System.Windows.Forms.Button();
            this.BtnClearRoi = new System.Windows.Forms.Button();
            this.BtnLoadRoi = new System.Windows.Forms.Button();
            this.BtnDrawRectangle2 = new System.Windows.Forms.Button();
            this.BtnDrawRectangle1 = new System.Windows.Forms.Button();
            this.BtnDrawCircle = new System.Windows.Forms.Button();
            this.ckbToolVis = new System.Windows.Forms.CheckBox();
            this.visionControl1 = new GoVision.VisionControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDrawLine
            // 
            this.BtnDrawLine.BackColor = System.Drawing.Color.White;
            this.BtnDrawLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDrawLine.Image = ((System.Drawing.Image)(resources.GetObject("BtnDrawLine.Image")));
            this.BtnDrawLine.Location = new System.Drawing.Point(4, 8);
            this.BtnDrawLine.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDrawLine.Name = "BtnDrawLine";
            this.BtnDrawLine.Size = new System.Drawing.Size(27, 25);
            this.BtnDrawLine.TabIndex = 1;
            this.BtnDrawLine.UseVisualStyleBackColor = false;
            this.BtnDrawLine.Click += new System.EventHandler(this.BtnDrawLine_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cboOpera);
            this.panel1.Controls.Add(this.BtnSaveRoi);
            this.panel1.Controls.Add(this.BtnClearRoi);
            this.panel1.Controls.Add(this.BtnLoadRoi);
            this.panel1.Controls.Add(this.BtnDrawRectangle2);
            this.panel1.Controls.Add(this.BtnDrawRectangle1);
            this.panel1.Controls.Add(this.BtnDrawCircle);
            this.panel1.Controls.Add(this.BtnDrawLine);
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 46);
            this.panel1.TabIndex = 2;
            // 
            // cboOpera
            // 
            this.cboOpera.FormattingEnabled = true;
            this.cboOpera.Items.AddRange(new object[] {
            "union",
            "intersection",
            "difference"});
            this.cboOpera.Location = new System.Drawing.Point(452, 8);
            this.cboOpera.Margin = new System.Windows.Forms.Padding(4);
            this.cboOpera.Name = "cboOpera";
            this.cboOpera.Size = new System.Drawing.Size(160, 23);
            this.cboOpera.TabIndex = 2;
            // 
            // BtnSaveRoi
            // 
            this.BtnSaveRoi.BackColor = System.Drawing.Color.White;
            this.BtnSaveRoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveRoi.Location = new System.Drawing.Point(363, 8);
            this.BtnSaveRoi.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSaveRoi.Name = "BtnSaveRoi";
            this.BtnSaveRoi.Size = new System.Drawing.Size(81, 30);
            this.BtnSaveRoi.TabIndex = 1;
            this.BtnSaveRoi.Text = "保存";
            this.BtnSaveRoi.UseVisualStyleBackColor = false;
            this.BtnSaveRoi.Click += new System.EventHandler(this.BtnSaveRoi_Click);
            // 
            // BtnClearRoi
            // 
            this.BtnClearRoi.BackColor = System.Drawing.Color.White;
            this.BtnClearRoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearRoi.Location = new System.Drawing.Point(184, 9);
            this.BtnClearRoi.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClearRoi.Name = "BtnClearRoi";
            this.BtnClearRoi.Size = new System.Drawing.Size(81, 29);
            this.BtnClearRoi.TabIndex = 1;
            this.BtnClearRoi.Text = "清除";
            this.BtnClearRoi.UseVisualStyleBackColor = false;
            this.BtnClearRoi.Click += new System.EventHandler(this.BtnClearRoi_Click);
            // 
            // BtnLoadRoi
            // 
            this.BtnLoadRoi.BackColor = System.Drawing.Color.White;
            this.BtnLoadRoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadRoi.Location = new System.Drawing.Point(273, 9);
            this.BtnLoadRoi.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLoadRoi.Name = "BtnLoadRoi";
            this.BtnLoadRoi.Size = new System.Drawing.Size(81, 29);
            this.BtnLoadRoi.TabIndex = 1;
            this.BtnLoadRoi.Text = "加载";
            this.BtnLoadRoi.UseVisualStyleBackColor = false;
            this.BtnLoadRoi.Click += new System.EventHandler(this.BtnLoadRoi_Click);
            // 
            // BtnDrawRectangle2
            // 
            this.BtnDrawRectangle2.BackColor = System.Drawing.Color.White;
            this.BtnDrawRectangle2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDrawRectangle2.Image = ((System.Drawing.Image)(resources.GetObject("BtnDrawRectangle2.Image")));
            this.BtnDrawRectangle2.Location = new System.Drawing.Point(108, 8);
            this.BtnDrawRectangle2.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDrawRectangle2.Name = "BtnDrawRectangle2";
            this.BtnDrawRectangle2.Size = new System.Drawing.Size(27, 25);
            this.BtnDrawRectangle2.TabIndex = 1;
            this.BtnDrawRectangle2.UseVisualStyleBackColor = false;
            this.BtnDrawRectangle2.Click += new System.EventHandler(this.BtnDrawRectangle2_Click);
            // 
            // BtnDrawRectangle1
            // 
            this.BtnDrawRectangle1.BackColor = System.Drawing.Color.White;
            this.BtnDrawRectangle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDrawRectangle1.Image = ((System.Drawing.Image)(resources.GetObject("BtnDrawRectangle1.Image")));
            this.BtnDrawRectangle1.Location = new System.Drawing.Point(73, 8);
            this.BtnDrawRectangle1.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDrawRectangle1.Name = "BtnDrawRectangle1";
            this.BtnDrawRectangle1.Size = new System.Drawing.Size(27, 25);
            this.BtnDrawRectangle1.TabIndex = 1;
            this.BtnDrawRectangle1.UseVisualStyleBackColor = false;
            this.BtnDrawRectangle1.Click += new System.EventHandler(this.BtnDrawRectangle1_Click);
            // 
            // BtnDrawCircle
            // 
            this.BtnDrawCircle.BackColor = System.Drawing.Color.White;
            this.BtnDrawCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDrawCircle.Image = ((System.Drawing.Image)(resources.GetObject("BtnDrawCircle.Image")));
            this.BtnDrawCircle.Location = new System.Drawing.Point(39, 8);
            this.BtnDrawCircle.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDrawCircle.Name = "BtnDrawCircle";
            this.BtnDrawCircle.Size = new System.Drawing.Size(27, 25);
            this.BtnDrawCircle.TabIndex = 1;
            this.BtnDrawCircle.UseVisualStyleBackColor = false;
            this.BtnDrawCircle.Click += new System.EventHandler(this.BtnDrawCircle_Click);
            // 
            // ckbToolVis
            // 
            this.ckbToolVis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbToolVis.AutoSize = true;
            this.ckbToolVis.Checked = true;
            this.ckbToolVis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbToolVis.Location = new System.Drawing.Point(635, 461);
            this.ckbToolVis.Margin = new System.Windows.Forms.Padding(4);
            this.ckbToolVis.Name = "ckbToolVis";
            this.ckbToolVis.Size = new System.Drawing.Size(18, 17);
            this.ckbToolVis.TabIndex = 3;
            this.ckbToolVis.UseVisualStyleBackColor = true;
            this.ckbToolVis.CheckedChanged += new System.EventHandler(this.ckbToolVis_CheckedChanged);
            // 
            // visionControl1
            // 
            this.visionControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visionControl1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.visionControl1.Location = new System.Drawing.Point(0, 0);
            this.visionControl1.Margin = new System.Windows.Forms.Padding(4);
            this.visionControl1.Name = "visionControl1";
            this.visionControl1.Size = new System.Drawing.Size(653, 478);
            this.visionControl1.TabIndex = 0;
            this.visionControl1.TabStop = false;
            // 
            // DrawControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbToolVis);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.visionControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DrawControl";
            this.Size = new System.Drawing.Size(653, 532);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visionControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnDrawLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboOpera;
        private System.Windows.Forms.Button BtnSaveRoi;
        private System.Windows.Forms.Button BtnLoadRoi;
        private System.Windows.Forms.Button BtnDrawCircle;
        private System.Windows.Forms.CheckBox ckbToolVis;
        private System.Windows.Forms.Button BtnDrawRectangle1;
        private System.Windows.Forms.Button BtnDrawRectangle2;
        private System.Windows.Forms.Button BtnClearRoi;
        public VisionControl visionControl1;
    }
}
