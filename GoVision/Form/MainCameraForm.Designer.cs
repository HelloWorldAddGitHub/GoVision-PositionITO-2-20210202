namespace GoVision
{
    partial class MainCameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCameraForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStopGrab = new System.Windows.Forms.Button();
            this.btnContinuGrab = new System.Windows.Forms.Button();
            this.btnGrabOne = new System.Windows.Forms.Button();
            this.cmbProcess = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnProcessImage = new System.Windows.Forms.Button();
            this.btnReadImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.nudExposure = new System.Windows.Forms.NumericUpDown();
            this.tbpCalib = new System.Windows.Forms.TabPage();
            this.label48 = new System.Windows.Forms.Label();
            this.nudOffsetDia = new System.Windows.Forms.NumericUpDown();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnSaveMark = new System.Windows.Forms.Button();
            this.btnGetMark = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.nudMarkColumn = new System.Windows.Forms.NumericUpDown();
            this.label47 = new System.Windows.Forms.Label();
            this.nudMarkRow = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dgvCalib = new System.Windows.Forms.DataGridView();
            this.txtCalibX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCalibY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCalibCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCalibRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalibFindModel = new System.Windows.Forms.Button();
            this.btnCalibData = new System.Windows.Forms.Button();
            this.tbpMeasure = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.nudMaginTopMax = new System.Windows.Forms.NumericUpDown();
            this.nudMaginTop = new System.Windows.Forms.NumericUpDown();
            this.nudMaginLeft = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.nudPinCount = new System.Windows.Forms.NumericUpDown();
            this.nudDiameterMax = new System.Windows.Forms.NumericUpDown();
            this.nudMaginRight = new System.Windows.Forms.NumericUpDown();
            this.nudPinDistance = new System.Windows.Forms.NumericUpDown();
            this.nudDiameterMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudSigma = new System.Windows.Forms.NumericUpDown();
            this.tcbThreshold = new System.Windows.Forms.TrackBar();
            this.ckbPairs = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.tcbSigma = new System.Windows.Forms.TrackBar();
            this.cmbTransition = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnMeasureTest = new System.Windows.Forms.Button();
            this.btnSaveMeasure = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.nudMeasureRoiColumn = new System.Windows.Forms.NumericUpDown();
            this.nudDisEdge = new System.Windows.Forms.NumericUpDown();
            this.nudMeasureRoiHeight = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.nudMeasureRoiRow = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.nudMeasureRoiPhi = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.nudMeasureRoiWidth = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbInterpolation = new System.Windows.Forms.ComboBox();
            this.btnDelMeasure = new System.Windows.Forms.Button();
            this.btnDrawMeasure = new System.Windows.Forms.Button();
            this.lstMeasureList = new System.Windows.Forms.ListBox();
            this.tbpFindModel = new System.Windows.Forms.TabPage();
            this.ckbSecondPos = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnImagePer = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.nudEmphasize = new System.Windows.Forms.NumericUpDown();
            this.ckbAdjustImage = new System.Windows.Forms.CheckBox();
            this.ckbPerprocess = new System.Windows.Forms.CheckBox();
            this.btnPlatformRegion = new System.Windows.Forms.Button();
            this.btnSaveFindConfig = new System.Windows.Forms.Button();
            this.btnFindModel = new System.Windows.Forms.Button();
            this.tcbFindLevels = new System.Windows.Forms.TrackBar();
            this.nudFindLeves = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbSubPixel = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tcbMaxOverlap = new System.Windows.Forms.TrackBar();
            this.nudMaxOverlap = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.tcbGreediness = new System.Windows.Forms.TrackBar();
            this.nudGreediness = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.tcbNumMatches = new System.Windows.Forms.TrackBar();
            this.nudNumMatches = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tcbMinScore = new System.Windows.Forms.TrackBar();
            this.nudMinScore = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.tbpCreateModel = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.nudColumn = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.nudRow = new System.Windows.Forms.NumericUpDown();
            this.btnSetOrigin = new System.Windows.Forms.Button();
            this.btnGetPos = new System.Windows.Forms.Button();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.groupBoxCreateModel = new System.Windows.Forms.GroupBox();
            this.DispPyramidTrackBar = new System.Windows.Forms.TrackBar();
            this.DispPyramidUpDown = new System.Windows.Forms.NumericUpDown();
            this.cmbMetric = new System.Windows.Forms.ComboBox();
            this.tcbScaleMax = new System.Windows.Forms.TrackBar();
            this.tcbScaleMin = new System.Windows.Forms.TrackBar();
            this.tcbAngleExtent = new System.Windows.Forms.TrackBar();
            this.tcbAngleStart = new System.Windows.Forms.TrackBar();
            this.tcbNumLevels = new System.Windows.Forms.TrackBar();
            this.tcbMinContrast = new System.Windows.Forms.TrackBar();
            this.MinContrastAutoButton = new System.Windows.Forms.Button();
            this.nudMinContrast = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbOptimization = new System.Windows.Forms.ComboBox();
            this.OptimizationAutoButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudScaleMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar_Min_Size = new System.Windows.Forms.TrackBar();
            this.PyramidLevelAutoButton = new System.Windows.Forms.Button();
            this.nudScaleMax = new System.Windows.Forms.NumericUpDown();
            this.UpDown_MinSize = new System.Windows.Forms.NumericUpDown();
            this.nudNumLevels = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudAngleExtent = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudAngleStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button_MinSizeAuto = new System.Windows.Forms.Button();
            this.ContrastAutoButton = new System.Windows.Forms.Button();
            this.nudContrastHigh = new System.Windows.Forms.NumericUpDown();
            this.nudContrastLow = new System.Windows.Forms.NumericUpDown();
            this.tcbContrastHigh = new System.Windows.Forms.TrackBar();
            this.tcbContrastLow = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpRoi = new System.Windows.Forms.GroupBox();
            this.rdbUnion = new System.Windows.Forms.RadioButton();
            this.rdbDifference = new System.Windows.Forms.RadioButton();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.rdbIntersection = new System.Windows.Forms.RadioButton();
            this.btnDrawCircle = new System.Windows.Forms.Button();
            this.btnDrawRectangle1 = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDrawRectangle2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.visionControl1 = new GoVision.VisionControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.grpLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExposure)).BeginInit();
            this.tbpCalib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetDia)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarkColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarkRow)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalib)).BeginInit();
            this.tbpMeasure.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginTopMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiameterMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiameterMin)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbSigma)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiWidth)).BeginInit();
            this.tbpFindModel.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmphasize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbFindLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFindLeves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbMaxOverlap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxOverlap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbGreediness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreediness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbNumMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbMinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinScore)).BeginInit();
            this.tbpCreateModel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).BeginInit();
            this.groupBoxCreateModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DispPyramidTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispPyramidUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbScaleMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbScaleMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbAngleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbNumLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbMinContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Min_Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_MinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbContrastHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbContrastLow)).BeginInit();
            this.grpRoi.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 406);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpLog);
            this.splitContainer1.Size = new System.Drawing.Size(705, 208);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 3;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvData);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(326, 208);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            this.grpData.Text = "数据";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 16);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(320, 189);
            this.dgvData.TabIndex = 0;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(0, 0);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(375, 208);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(369, 189);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnStopGrab
            // 
            this.btnStopGrab.Location = new System.Drawing.Point(6, 153);
            this.btnStopGrab.Name = "btnStopGrab";
            this.btnStopGrab.Size = new System.Drawing.Size(73, 43);
            this.btnStopGrab.TabIndex = 3;
            this.btnStopGrab.Text = "停止采集";
            this.btnStopGrab.UseVisualStyleBackColor = true;
            this.btnStopGrab.Click += new System.EventHandler(this.btnStopGrab_Click);
            // 
            // btnContinuGrab
            // 
            this.btnContinuGrab.Location = new System.Drawing.Point(6, 103);
            this.btnContinuGrab.Name = "btnContinuGrab";
            this.btnContinuGrab.Size = new System.Drawing.Size(73, 43);
            this.btnContinuGrab.TabIndex = 3;
            this.btnContinuGrab.Text = "连续采集";
            this.btnContinuGrab.UseVisualStyleBackColor = true;
            this.btnContinuGrab.Click += new System.EventHandler(this.btnContinuGrab_Click);
            // 
            // btnGrabOne
            // 
            this.btnGrabOne.Location = new System.Drawing.Point(6, 53);
            this.btnGrabOne.Name = "btnGrabOne";
            this.btnGrabOne.Size = new System.Drawing.Size(73, 43);
            this.btnGrabOne.TabIndex = 3;
            this.btnGrabOne.Text = "单帧采集";
            this.btnGrabOne.UseVisualStyleBackColor = true;
            this.btnGrabOne.Click += new System.EventHandler(this.btnGrabOne_Click);
            // 
            // cmbProcess
            // 
            this.cmbProcess.FormattingEnabled = true;
            this.cmbProcess.Location = new System.Drawing.Point(52, 21);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Size = new System.Drawing.Size(106, 22);
            this.cmbProcess.TabIndex = 2;
            this.cmbProcess.SelectedIndexChanged += new System.EventHandler(this.cmbProcess_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "流程";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(85, 153);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(73, 43);
            this.btnSaveImage.TabIndex = 0;
            this.btnSaveImage.Text = "保存图像";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnProcessImage
            // 
            this.btnProcessImage.Location = new System.Drawing.Point(85, 53);
            this.btnProcessImage.Name = "btnProcessImage";
            this.btnProcessImage.Size = new System.Drawing.Size(73, 43);
            this.btnProcessImage.TabIndex = 0;
            this.btnProcessImage.Text = "处理图像";
            this.btnProcessImage.UseVisualStyleBackColor = true;
            this.btnProcessImage.Click += new System.EventHandler(this.btnProcessImage_Click);
            // 
            // btnReadImage
            // 
            this.btnReadImage.Location = new System.Drawing.Point(85, 103);
            this.btnReadImage.Name = "btnReadImage";
            this.btnReadImage.Size = new System.Drawing.Size(73, 43);
            this.btnReadImage.TabIndex = 0;
            this.btnReadImage.Text = "读取图像";
            this.btnReadImage.UseVisualStyleBackColor = true;
            this.btnReadImage.Click += new System.EventHandler(this.btnReadImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.nudExposure);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbProcess);
            this.groupBox1.Controls.Add(this.btnSaveImage);
            this.groupBox1.Controls.Add(this.btnStopGrab);
            this.groupBox1.Controls.Add(this.btnReadImage);
            this.groupBox1.Controls.Add(this.btnProcessImage);
            this.groupBox1.Controls.Add(this.btnGrabOne);
            this.groupBox1.Controls.Add(this.btnContinuGrab);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(539, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 400);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(14, 326);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 14);
            this.label41.TabIndex = 15;
            this.label41.Text = "label41";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(27, 312);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 14);
            this.label34.TabIndex = 14;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 208);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(63, 14);
            this.label44.TabIndex = 12;
            this.label44.Text = "曝光时间";
            // 
            // nudExposure
            // 
            this.nudExposure.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudExposure.Location = new System.Drawing.Point(75, 206);
            this.nudExposure.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudExposure.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudExposure.Name = "nudExposure";
            this.nudExposure.Size = new System.Drawing.Size(83, 23);
            this.nudExposure.TabIndex = 11;
            this.nudExposure.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudExposure.ValueChanged += new System.EventHandler(this.nudExposure_ValueChanged);
            // 
            // tbpCalib
            // 
            this.tbpCalib.Controls.Add(this.label48);
            this.tbpCalib.Controls.Add(this.nudOffsetDia);
            this.tbpCalib.Controls.Add(this.groupBox11);
            this.tbpCalib.Controls.Add(this.groupBox9);
            this.tbpCalib.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbpCalib.Location = new System.Drawing.Point(4, 26);
            this.tbpCalib.Name = "tbpCalib";
            this.tbpCalib.Size = new System.Drawing.Size(287, 581);
            this.tbpCalib.TabIndex = 5;
            this.tbpCalib.Text = "标定";
            this.tbpCalib.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 345);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(63, 14);
            this.label48.TabIndex = 93;
            this.label48.Text = "直径补偿";
            // 
            // nudOffsetDia
            // 
            this.nudOffsetDia.DecimalPlaces = 2;
            this.nudOffsetDia.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudOffsetDia.Location = new System.Drawing.Point(82, 342);
            this.nudOffsetDia.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudOffsetDia.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudOffsetDia.Name = "nudOffsetDia";
            this.nudOffsetDia.Size = new System.Drawing.Size(73, 23);
            this.nudOffsetDia.TabIndex = 92;
            this.nudOffsetDia.ValueChanged += new System.EventHandler(this.nudOffsetDia_ValueChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnSaveMark);
            this.groupBox11.Controls.Add(this.btnGetMark);
            this.groupBox11.Controls.Add(this.label46);
            this.groupBox11.Controls.Add(this.nudMarkColumn);
            this.groupBox11.Controls.Add(this.label47);
            this.groupBox11.Controls.Add(this.nudMarkRow);
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(282, 86);
            this.groupBox11.TabIndex = 91;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "平台Mark点";
            // 
            // btnSaveMark
            // 
            this.btnSaveMark.Location = new System.Drawing.Point(93, 53);
            this.btnSaveMark.Name = "btnSaveMark";
            this.btnSaveMark.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMark.TabIndex = 14;
            this.btnSaveMark.Text = "保存位置";
            this.btnSaveMark.UseVisualStyleBackColor = true;
            this.btnSaveMark.Click += new System.EventHandler(this.btnSaveMark_Click);
            // 
            // btnGetMark
            // 
            this.btnGetMark.Location = new System.Drawing.Point(13, 53);
            this.btnGetMark.Name = "btnGetMark";
            this.btnGetMark.Size = new System.Drawing.Size(75, 23);
            this.btnGetMark.TabIndex = 14;
            this.btnGetMark.Text = "获取坐标";
            this.btnGetMark.UseVisualStyleBackColor = true;
            this.btnGetMark.Click += new System.EventHandler(this.btnGetMark_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(141, 20);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(49, 14);
            this.label46.TabIndex = 13;
            this.label46.Text = "Column";
            // 
            // nudMarkColumn
            // 
            this.nudMarkColumn.DecimalPlaces = 2;
            this.nudMarkColumn.Location = new System.Drawing.Point(192, 20);
            this.nudMarkColumn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMarkColumn.Name = "nudMarkColumn";
            this.nudMarkColumn.Size = new System.Drawing.Size(73, 23);
            this.nudMarkColumn.TabIndex = 12;
            this.nudMarkColumn.ValueChanged += new System.EventHandler(this.nudMarkColumn_ValueChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(11, 20);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(28, 14);
            this.label47.TabIndex = 11;
            this.label47.Text = "Row";
            // 
            // nudMarkRow
            // 
            this.nudMarkRow.DecimalPlaces = 2;
            this.nudMarkRow.Location = new System.Drawing.Point(62, 17);
            this.nudMarkRow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMarkRow.Name = "nudMarkRow";
            this.nudMarkRow.Size = new System.Drawing.Size(73, 23);
            this.nudMarkRow.TabIndex = 10;
            this.nudMarkRow.ValueChanged += new System.EventHandler(this.nudMarkRow_ValueChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dgvCalib);
            this.groupBox9.Controls.Add(this.btnCalibFindModel);
            this.groupBox9.Controls.Add(this.btnCalibData);
            this.groupBox9.Location = new System.Drawing.Point(3, 95);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(284, 235);
            this.groupBox9.TabIndex = 89;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "标定";
            // 
            // dgvCalib
            // 
            this.dgvCalib.AllowUserToAddRows = false;
            this.dgvCalib.AllowUserToDeleteRows = false;
            this.dgvCalib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalib.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCalibX,
            this.txtCalibY,
            this.txtCalibCol,
            this.txtCalibRow});
            this.dgvCalib.Location = new System.Drawing.Point(6, 22);
            this.dgvCalib.Name = "dgvCalib";
            this.dgvCalib.RowHeadersVisible = false;
            this.dgvCalib.Size = new System.Drawing.Size(277, 176);
            this.dgvCalib.TabIndex = 9;
            // 
            // txtCalibX
            // 
            this.txtCalibX.HeaderText = "X";
            this.txtCalibX.Name = "txtCalibX";
            this.txtCalibX.Width = 60;
            // 
            // txtCalibY
            // 
            this.txtCalibY.HeaderText = "Y";
            this.txtCalibY.Name = "txtCalibY";
            this.txtCalibY.Width = 60;
            // 
            // txtCalibCol
            // 
            this.txtCalibCol.HeaderText = "Column";
            this.txtCalibCol.Name = "txtCalibCol";
            this.txtCalibCol.Width = 60;
            // 
            // txtCalibRow
            // 
            this.txtCalibRow.HeaderText = "Row";
            this.txtCalibRow.Name = "txtCalibRow";
            this.txtCalibRow.Width = 60;
            // 
            // btnCalibFindModel
            // 
            this.btnCalibFindModel.Location = new System.Drawing.Point(6, 202);
            this.btnCalibFindModel.Name = "btnCalibFindModel";
            this.btnCalibFindModel.Size = new System.Drawing.Size(75, 23);
            this.btnCalibFindModel.TabIndex = 10;
            this.btnCalibFindModel.Text = "查找模板";
            this.btnCalibFindModel.UseVisualStyleBackColor = true;
            this.btnCalibFindModel.Click += new System.EventHandler(this.btnCalibFindModel_Click);
            // 
            // btnCalibData
            // 
            this.btnCalibData.Location = new System.Drawing.Point(87, 200);
            this.btnCalibData.Name = "btnCalibData";
            this.btnCalibData.Size = new System.Drawing.Size(74, 25);
            this.btnCalibData.TabIndex = 13;
            this.btnCalibData.Text = "标定";
            this.btnCalibData.UseVisualStyleBackColor = true;
            this.btnCalibData.Click += new System.EventHandler(this.btnCalibData_Click);
            // 
            // tbpMeasure
            // 
            this.tbpMeasure.Controls.Add(this.groupBox6);
            this.tbpMeasure.Controls.Add(this.groupBox4);
            this.tbpMeasure.Controls.Add(this.btnMeasureTest);
            this.tbpMeasure.Controls.Add(this.btnSaveMeasure);
            this.tbpMeasure.Controls.Add(this.groupBox3);
            this.tbpMeasure.Controls.Add(this.btnDelMeasure);
            this.tbpMeasure.Controls.Add(this.btnDrawMeasure);
            this.tbpMeasure.Controls.Add(this.lstMeasureList);
            this.tbpMeasure.Location = new System.Drawing.Point(4, 26);
            this.tbpMeasure.Name = "tbpMeasure";
            this.tbpMeasure.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMeasure.Size = new System.Drawing.Size(287, 581);
            this.tbpMeasure.TabIndex = 2;
            this.tbpMeasure.Text = "测量";
            this.tbpMeasure.UseVisualStyleBackColor = true;
            this.tbpMeasure.Click += new System.EventHandler(this.tbpPickScreen_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.nudMaginTopMax);
            this.groupBox6.Controls.Add(this.nudMaginTop);
            this.groupBox6.Controls.Add(this.nudMaginLeft);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.nudPinCount);
            this.groupBox6.Controls.Add(this.nudDiameterMax);
            this.groupBox6.Controls.Add(this.nudMaginRight);
            this.groupBox6.Controls.Add(this.nudPinDistance);
            this.groupBox6.Controls.Add(this.nudDiameterMin);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(6, 294);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(271, 124);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "测量界限 mm";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(120, 98);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(65, 12);
            this.label32.TabIndex = 1;
            this.label32.Text = "最大下边距";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 98);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 12);
            this.label39.TabIndex = 1;
            this.label39.Text = "最小下边距";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 72);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(41, 12);
            this.label38.TabIndex = 1;
            this.label38.Text = "左边距";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(137, 72);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 12);
            this.label36.TabIndex = 1;
            this.label36.Text = "右边距";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 22);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 12);
            this.label40.TabIndex = 1;
            this.label40.Text = "引脚数量";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 46);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(53, 12);
            this.label37.TabIndex = 1;
            this.label37.Text = "最大直径";
            // 
            // nudMaginTopMax
            // 
            this.nudMaginTopMax.DecimalPlaces = 2;
            this.nudMaginTopMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaginTopMax.Location = new System.Drawing.Point(190, 95);
            this.nudMaginTopMax.Name = "nudMaginTopMax";
            this.nudMaginTopMax.Size = new System.Drawing.Size(45, 21);
            this.nudMaginTopMax.TabIndex = 0;
            this.nudMaginTopMax.Value = new decimal(new int[] {
            16,
            0,
            0,
            65536});
            this.nudMaginTopMax.ValueChanged += new System.EventHandler(this.nudMaginTopMax_ValueChanged);
            // 
            // nudMaginTop
            // 
            this.nudMaginTop.DecimalPlaces = 2;
            this.nudMaginTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaginTop.Location = new System.Drawing.Point(72, 95);
            this.nudMaginTop.Name = "nudMaginTop";
            this.nudMaginTop.Size = new System.Drawing.Size(45, 21);
            this.nudMaginTop.TabIndex = 0;
            this.nudMaginTop.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudMaginTop.ValueChanged += new System.EventHandler(this.nudMaginTop_ValueChanged);
            // 
            // nudMaginLeft
            // 
            this.nudMaginLeft.DecimalPlaces = 2;
            this.nudMaginLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaginLeft.Location = new System.Drawing.Point(60, 69);
            this.nudMaginLeft.Name = "nudMaginLeft";
            this.nudMaginLeft.Size = new System.Drawing.Size(45, 21);
            this.nudMaginLeft.TabIndex = 0;
            this.nudMaginLeft.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudMaginLeft.ValueChanged += new System.EventHandler(this.nudMaginLeft_ValueChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(136, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 12);
            this.label33.TabIndex = 1;
            this.label33.Text = "引脚距离";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(136, 48);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.TabIndex = 1;
            this.label35.Text = "最小直径";
            // 
            // nudPinCount
            // 
            this.nudPinCount.Location = new System.Drawing.Point(60, 20);
            this.nudPinCount.Name = "nudPinCount";
            this.nudPinCount.Size = new System.Drawing.Size(45, 21);
            this.nudPinCount.TabIndex = 0;
            this.nudPinCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPinCount.ValueChanged += new System.EventHandler(this.nudPinCount_ValueChanged);
            // 
            // nudDiameterMax
            // 
            this.nudDiameterMax.DecimalPlaces = 2;
            this.nudDiameterMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudDiameterMax.Location = new System.Drawing.Point(60, 43);
            this.nudDiameterMax.Name = "nudDiameterMax";
            this.nudDiameterMax.Size = new System.Drawing.Size(45, 21);
            this.nudDiameterMax.TabIndex = 0;
            this.nudDiameterMax.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.nudDiameterMax.ValueChanged += new System.EventHandler(this.nudDiameterMax_ValueChanged);
            // 
            // nudMaginRight
            // 
            this.nudMaginRight.DecimalPlaces = 2;
            this.nudMaginRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaginRight.Location = new System.Drawing.Point(190, 69);
            this.nudMaginRight.Name = "nudMaginRight";
            this.nudMaginRight.Size = new System.Drawing.Size(45, 21);
            this.nudMaginRight.TabIndex = 0;
            this.nudMaginRight.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudMaginRight.ValueChanged += new System.EventHandler(this.nudMaginRight_ValueChanged);
            // 
            // nudPinDistance
            // 
            this.nudPinDistance.DecimalPlaces = 3;
            this.nudPinDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudPinDistance.Location = new System.Drawing.Point(190, 20);
            this.nudPinDistance.Name = "nudPinDistance";
            this.nudPinDistance.Size = new System.Drawing.Size(60, 21);
            this.nudPinDistance.TabIndex = 0;
            this.nudPinDistance.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPinDistance.ValueChanged += new System.EventHandler(this.nudPinDistance_ValueChanged);
            // 
            // nudDiameterMin
            // 
            this.nudDiameterMin.DecimalPlaces = 2;
            this.nudDiameterMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudDiameterMin.Location = new System.Drawing.Point(190, 43);
            this.nudDiameterMin.Name = "nudDiameterMin";
            this.nudDiameterMin.Size = new System.Drawing.Size(45, 21);
            this.nudDiameterMin.TabIndex = 0;
            this.nudDiameterMin.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nudDiameterMin.ValueChanged += new System.EventHandler(this.nudDiameterMin_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.nudThreshold);
            this.groupBox4.Controls.Add(this.nudSigma);
            this.groupBox4.Controls.Add(this.tcbThreshold);
            this.groupBox4.Controls.Add(this.ckbPairs);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.cmbSelect);
            this.groupBox4.Controls.Add(this.tcbSigma);
            this.groupBox4.Controls.Add(this.cmbTransition);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(6, 213);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(271, 75);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "测量参数";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(2, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 14);
            this.label22.TabIndex = 3;
            this.label22.Text = "最小边缘幅度";
            // 
            // nudThreshold
            // 
            this.nudThreshold.Location = new System.Drawing.Point(95, 22);
            this.nudThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(64, 21);
            this.nudThreshold.TabIndex = 2;
            this.nudThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudThreshold.ValueChanged += new System.EventHandler(this.nudThreshold_ValueChanged);
            // 
            // nudSigma
            // 
            this.nudSigma.DecimalPlaces = 2;
            this.nudSigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudSigma.Location = new System.Drawing.Point(95, 48);
            this.nudSigma.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nudSigma.Name = "nudSigma";
            this.nudSigma.Size = new System.Drawing.Size(64, 21);
            this.nudSigma.TabIndex = 2;
            this.nudSigma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSigma.ValueChanged += new System.EventHandler(this.nudSigma_ValueChanged);
            // 
            // tcbThreshold
            // 
            this.tcbThreshold.AutoSize = false;
            this.tcbThreshold.Location = new System.Drawing.Point(162, 22);
            this.tcbThreshold.Maximum = 255;
            this.tcbThreshold.Minimum = 1;
            this.tcbThreshold.Name = "tcbThreshold";
            this.tcbThreshold.Size = new System.Drawing.Size(104, 22);
            this.tcbThreshold.TabIndex = 4;
            this.tcbThreshold.Value = 30;
            this.tcbThreshold.Scroll += new System.EventHandler(this.tcbThreshold_Scroll);
            // 
            // ckbPairs
            // 
            this.ckbPairs.AutoSize = true;
            this.ckbPairs.Enabled = false;
            this.ckbPairs.Location = new System.Drawing.Point(9, 109);
            this.ckbPairs.Name = "ckbPairs";
            this.ckbPairs.Size = new System.Drawing.Size(120, 16);
            this.ckbPairs.TabIndex = 6;
            this.ckbPairs.Text = "将边缘组成边缘对";
            this.ckbPairs.UseVisualStyleBackColor = true;
            this.ckbPairs.Visible = false;
            this.ckbPairs.CheckedChanged += new System.EventHandler(this.ckbPairs_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(6, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 3;
            this.label23.Text = "平滑";
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect.Enabled = false;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "all",
            "first",
            "last"});
            this.cmbSelect.Location = new System.Drawing.Point(154, 81);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(65, 20);
            this.cmbSelect.TabIndex = 5;
            this.cmbSelect.Visible = false;
            this.cmbSelect.SelectedIndexChanged += new System.EventHandler(this.cmbSelect_SelectedIndexChanged);
            // 
            // tcbSigma
            // 
            this.tcbSigma.AutoSize = false;
            this.tcbSigma.Location = new System.Drawing.Point(162, 48);
            this.tcbSigma.Maximum = 1000;
            this.tcbSigma.Minimum = 4;
            this.tcbSigma.Name = "tcbSigma";
            this.tcbSigma.Size = new System.Drawing.Size(104, 22);
            this.tcbSigma.TabIndex = 4;
            this.tcbSigma.Value = 10;
            this.tcbSigma.Scroll += new System.EventHandler(this.tcbSigma_Scroll);
            // 
            // cmbTransition
            // 
            this.cmbTransition.AutoCompleteCustomSource.AddRange(new string[] {
            "all",
            "first",
            "last"});
            this.cmbTransition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransition.Enabled = false;
            this.cmbTransition.FormattingEnabled = true;
            this.cmbTransition.Items.AddRange(new object[] {
            "all",
            "negative",
            "positive"});
            this.cmbTransition.Location = new System.Drawing.Point(41, 81);
            this.cmbTransition.Name = "cmbTransition";
            this.cmbTransition.Size = new System.Drawing.Size(65, 20);
            this.cmbTransition.TabIndex = 5;
            this.cmbTransition.Visible = false;
            this.cmbTransition.SelectedIndexChanged += new System.EventHandler(this.cmbTransition_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(6, 81);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 14);
            this.label26.TabIndex = 3;
            this.label26.Text = "变换";
            this.label26.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(117, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 14);
            this.label27.TabIndex = 3;
            this.label27.Text = "位置";
            this.label27.Visible = false;
            // 
            // btnMeasureTest
            // 
            this.btnMeasureTest.Location = new System.Drawing.Point(5, 424);
            this.btnMeasureTest.Name = "btnMeasureTest";
            this.btnMeasureTest.Size = new System.Drawing.Size(56, 26);
            this.btnMeasureTest.TabIndex = 8;
            this.btnMeasureTest.Text = "测量";
            this.btnMeasureTest.UseVisualStyleBackColor = true;
            this.btnMeasureTest.Click += new System.EventHandler(this.btnMeasureTest_Click);
            // 
            // btnSaveMeasure
            // 
            this.btnSaveMeasure.Location = new System.Drawing.Point(65, 424);
            this.btnSaveMeasure.Name = "btnSaveMeasure";
            this.btnSaveMeasure.Size = new System.Drawing.Size(122, 26);
            this.btnSaveMeasure.TabIndex = 8;
            this.btnSaveMeasure.Text = "保存所有测量";
            this.btnSaveMeasure.UseVisualStyleBackColor = true;
            this.btnSaveMeasure.Click += new System.EventHandler(this.btnSaveMeasure_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.nudMeasureRoiColumn);
            this.groupBox3.Controls.Add(this.nudDisEdge);
            this.groupBox3.Controls.Add(this.nudMeasureRoiHeight);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.nudMeasureRoiRow);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.nudMeasureRoiPhi);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.nudMeasureRoiWidth);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.cmbInterpolation);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(6, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 134);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测量矩形 pixel";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(141, 22);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 14);
            this.label30.TabIndex = 3;
            this.label30.Text = "列坐标";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(9, 99);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(133, 14);
            this.label50.TabIndex = 3;
            this.label50.Text = "中心到下边缘的距离";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(142, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 14);
            this.label28.TabIndex = 3;
            this.label28.Text = "高度";
            // 
            // nudMeasureRoiColumn
            // 
            this.nudMeasureRoiColumn.DecimalPlaces = 2;
            this.nudMeasureRoiColumn.Location = new System.Drawing.Point(196, 17);
            this.nudMeasureRoiColumn.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudMeasureRoiColumn.Name = "nudMeasureRoiColumn";
            this.nudMeasureRoiColumn.Size = new System.Drawing.Size(64, 21);
            this.nudMeasureRoiColumn.TabIndex = 2;
            this.nudMeasureRoiColumn.ValueChanged += new System.EventHandler(this.nudMeasureRoiColumn_ValueChanged);
            // 
            // nudDisEdge
            // 
            this.nudDisEdge.Location = new System.Drawing.Point(148, 96);
            this.nudDisEdge.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudDisEdge.Name = "nudDisEdge";
            this.nudDisEdge.Size = new System.Drawing.Size(64, 21);
            this.nudDisEdge.TabIndex = 2;
            this.nudDisEdge.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudDisEdge.ValueChanged += new System.EventHandler(this.nudDisEdge_ValueChanged);
            // 
            // nudMeasureRoiHeight
            // 
            this.nudMeasureRoiHeight.Location = new System.Drawing.Point(196, 43);
            this.nudMeasureRoiHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMeasureRoiHeight.Name = "nudMeasureRoiHeight";
            this.nudMeasureRoiHeight.Size = new System.Drawing.Size(64, 21);
            this.nudMeasureRoiHeight.TabIndex = 2;
            this.nudMeasureRoiHeight.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudMeasureRoiHeight.ValueChanged += new System.EventHandler(this.nudMeasureRoHeight_ValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(9, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 14);
            this.label29.TabIndex = 3;
            this.label29.Text = "行坐标";
            // 
            // nudMeasureRoiRow
            // 
            this.nudMeasureRoiRow.DecimalPlaces = 2;
            this.nudMeasureRoiRow.Location = new System.Drawing.Point(66, 17);
            this.nudMeasureRoiRow.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudMeasureRoiRow.Name = "nudMeasureRoiRow";
            this.nudMeasureRoiRow.Size = new System.Drawing.Size(64, 21);
            this.nudMeasureRoiRow.TabIndex = 2;
            this.nudMeasureRoiRow.ValueChanged += new System.EventHandler(this.nudMeasureRoiRow_ValueChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(13, 69);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 14);
            this.label31.TabIndex = 3;
            this.label31.Text = "角度";
            // 
            // nudMeasureRoiPhi
            // 
            this.nudMeasureRoiPhi.DecimalPlaces = 2;
            this.nudMeasureRoiPhi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMeasureRoiPhi.Location = new System.Drawing.Point(66, 69);
            this.nudMeasureRoiPhi.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudMeasureRoiPhi.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudMeasureRoiPhi.Name = "nudMeasureRoiPhi";
            this.nudMeasureRoiPhi.Size = new System.Drawing.Size(64, 21);
            this.nudMeasureRoiPhi.TabIndex = 2;
            this.nudMeasureRoiPhi.ValueChanged += new System.EventHandler(this.nudMeasureRoiPhi_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(14, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 14);
            this.label24.TabIndex = 3;
            this.label24.Text = "宽度";
            // 
            // nudMeasureRoiWidth
            // 
            this.nudMeasureRoiWidth.Location = new System.Drawing.Point(66, 43);
            this.nudMeasureRoiWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudMeasureRoiWidth.Name = "nudMeasureRoiWidth";
            this.nudMeasureRoiWidth.Size = new System.Drawing.Size(64, 21);
            this.nudMeasureRoiWidth.TabIndex = 2;
            this.nudMeasureRoiWidth.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudMeasureRoiWidth.ValueChanged += new System.EventHandler(this.nudMeasureRoiWidth_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(113, 159);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 14);
            this.label25.TabIndex = 3;
            this.label25.Text = "插值";
            // 
            // cmbInterpolation
            // 
            this.cmbInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterpolation.FormattingEnabled = true;
            this.cmbInterpolation.Items.AddRange(new object[] {
            "nearest_neighbor",
            "bicubic",
            "bilinear"});
            this.cmbInterpolation.Location = new System.Drawing.Point(168, 159);
            this.cmbInterpolation.Name = "cmbInterpolation";
            this.cmbInterpolation.Size = new System.Drawing.Size(102, 20);
            this.cmbInterpolation.TabIndex = 5;
            this.cmbInterpolation.SelectedIndexChanged += new System.EventHandler(this.cmbInterpolation_SelectedIndexChanged);
            // 
            // btnDelMeasure
            // 
            this.btnDelMeasure.Location = new System.Drawing.Point(163, 36);
            this.btnDelMeasure.Name = "btnDelMeasure";
            this.btnDelMeasure.Size = new System.Drawing.Size(114, 27);
            this.btnDelMeasure.TabIndex = 1;
            this.btnDelMeasure.Text = "删除测量";
            this.btnDelMeasure.UseVisualStyleBackColor = true;
            this.btnDelMeasure.Click += new System.EventHandler(this.btnDelMeasure_Click);
            // 
            // btnDrawMeasure
            // 
            this.btnDrawMeasure.Location = new System.Drawing.Point(163, 7);
            this.btnDrawMeasure.Name = "btnDrawMeasure";
            this.btnDrawMeasure.Size = new System.Drawing.Size(114, 27);
            this.btnDrawMeasure.TabIndex = 1;
            this.btnDrawMeasure.Text = "绘制测量区域";
            this.btnDrawMeasure.UseVisualStyleBackColor = true;
            this.btnDrawMeasure.Click += new System.EventHandler(this.btnDrawMeasure_Click);
            // 
            // lstMeasureList
            // 
            this.lstMeasureList.FormattingEnabled = true;
            this.lstMeasureList.ItemHeight = 16;
            this.lstMeasureList.Location = new System.Drawing.Point(6, 7);
            this.lstMeasureList.Name = "lstMeasureList";
            this.lstMeasureList.Size = new System.Drawing.Size(151, 52);
            this.lstMeasureList.TabIndex = 0;
            this.lstMeasureList.SelectedIndexChanged += new System.EventHandler(this.lstMeasureList_SelectedIndexChanged);
            // 
            // tbpFindModel
            // 
            this.tbpFindModel.Controls.Add(this.ckbSecondPos);
            this.tbpFindModel.Controls.Add(this.groupBox12);
            this.tbpFindModel.Controls.Add(this.btnPlatformRegion);
            this.tbpFindModel.Controls.Add(this.btnSaveFindConfig);
            this.tbpFindModel.Controls.Add(this.btnFindModel);
            this.tbpFindModel.Controls.Add(this.tcbFindLevels);
            this.tbpFindModel.Controls.Add(this.nudFindLeves);
            this.tbpFindModel.Controls.Add(this.label18);
            this.tbpFindModel.Controls.Add(this.cmbSubPixel);
            this.tbpFindModel.Controls.Add(this.label17);
            this.tbpFindModel.Controls.Add(this.tcbMaxOverlap);
            this.tbpFindModel.Controls.Add(this.nudMaxOverlap);
            this.tbpFindModel.Controls.Add(this.label15);
            this.tbpFindModel.Controls.Add(this.tcbGreediness);
            this.tbpFindModel.Controls.Add(this.nudGreediness);
            this.tbpFindModel.Controls.Add(this.label16);
            this.tbpFindModel.Controls.Add(this.tcbNumMatches);
            this.tbpFindModel.Controls.Add(this.nudNumMatches);
            this.tbpFindModel.Controls.Add(this.label14);
            this.tbpFindModel.Controls.Add(this.tcbMinScore);
            this.tbpFindModel.Controls.Add(this.nudMinScore);
            this.tbpFindModel.Controls.Add(this.label19);
            this.tbpFindModel.Location = new System.Drawing.Point(4, 26);
            this.tbpFindModel.Name = "tbpFindModel";
            this.tbpFindModel.Size = new System.Drawing.Size(287, 581);
            this.tbpFindModel.TabIndex = 4;
            this.tbpFindModel.Text = "查找模板";
            this.tbpFindModel.UseVisualStyleBackColor = true;
            // 
            // ckbSecondPos
            // 
            this.ckbSecondPos.AutoSize = true;
            this.ckbSecondPos.Location = new System.Drawing.Point(21, 329);
            this.ckbSecondPos.Name = "ckbSecondPos";
            this.ckbSecondPos.Size = new System.Drawing.Size(123, 20);
            this.ckbSecondPos.TabIndex = 88;
            this.ckbSecondPos.Text = "启用二次定位";
            this.ckbSecondPos.UseVisualStyleBackColor = true;
            this.ckbSecondPos.CheckedChanged += new System.EventHandler(this.ckbSecondPos_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnImagePer);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Controls.Add(this.nudEmphasize);
            this.groupBox12.Controls.Add(this.ckbAdjustImage);
            this.groupBox12.Controls.Add(this.ckbPerprocess);
            this.groupBox12.Location = new System.Drawing.Point(2, 459);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox12.Size = new System.Drawing.Size(279, 124);
            this.groupBox12.TabIndex = 87;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "预处理";
            this.groupBox12.Visible = false;
            // 
            // btnImagePer
            // 
            this.btnImagePer.Location = new System.Drawing.Point(7, 87);
            this.btnImagePer.Name = "btnImagePer";
            this.btnImagePer.Size = new System.Drawing.Size(83, 28);
            this.btnImagePer.TabIndex = 11;
            this.btnImagePer.Text = "图像优化";
            this.btnImagePer.UseVisualStyleBackColor = true;
            this.btnImagePer.Click += new System.EventHandler(this.btnImagePer_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(4, 56);
            this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(88, 16);
            this.label49.TabIndex = 10;
            this.label49.Text = "增强对比度";
            // 
            // nudEmphasize
            // 
            this.nudEmphasize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudEmphasize.Location = new System.Drawing.Point(95, 51);
            this.nudEmphasize.Margin = new System.Windows.Forms.Padding(2);
            this.nudEmphasize.Maximum = new decimal(new int[] {
            201,
            0,
            0,
            0});
            this.nudEmphasize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudEmphasize.Name = "nudEmphasize";
            this.nudEmphasize.Size = new System.Drawing.Size(80, 26);
            this.nudEmphasize.TabIndex = 9;
            this.nudEmphasize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudEmphasize.ValueChanged += new System.EventHandler(this.nudEmphasize_ValueChanged);
            // 
            // ckbAdjustImage
            // 
            this.ckbAdjustImage.AutoSize = true;
            this.ckbAdjustImage.Location = new System.Drawing.Point(146, 25);
            this.ckbAdjustImage.Name = "ckbAdjustImage";
            this.ckbAdjustImage.Size = new System.Drawing.Size(91, 20);
            this.ckbAdjustImage.TabIndex = 8;
            this.ckbAdjustImage.Text = "矫正图像";
            this.ckbAdjustImage.UseVisualStyleBackColor = true;
            // 
            // ckbPerprocess
            // 
            this.ckbPerprocess.AutoSize = true;
            this.ckbPerprocess.Location = new System.Drawing.Point(5, 25);
            this.ckbPerprocess.Name = "ckbPerprocess";
            this.ckbPerprocess.Size = new System.Drawing.Size(139, 20);
            this.ckbPerprocess.TabIndex = 8;
            this.ckbPerprocess.Text = "启用图像预处理";
            this.ckbPerprocess.UseVisualStyleBackColor = true;
            this.ckbPerprocess.CheckedChanged += new System.EventHandler(this.ckbPreprocess_CheckedChanged);
            // 
            // btnPlatformRegion
            // 
            this.btnPlatformRegion.Location = new System.Drawing.Point(19, 274);
            this.btnPlatformRegion.Name = "btnPlatformRegion";
            this.btnPlatformRegion.Size = new System.Drawing.Size(179, 46);
            this.btnPlatformRegion.TabIndex = 86;
            this.btnPlatformRegion.Text = "绘制定位检测区域";
            this.btnPlatformRegion.UseVisualStyleBackColor = true;
            this.btnPlatformRegion.Click += new System.EventHandler(this.btnPlatformRegion_Click);
            // 
            // btnSaveFindConfig
            // 
            this.btnSaveFindConfig.Location = new System.Drawing.Point(116, 228);
            this.btnSaveFindConfig.Name = "btnSaveFindConfig";
            this.btnSaveFindConfig.Size = new System.Drawing.Size(82, 42);
            this.btnSaveFindConfig.TabIndex = 82;
            this.btnSaveFindConfig.Text = "保存设置";
            this.btnSaveFindConfig.UseVisualStyleBackColor = true;
            this.btnSaveFindConfig.Click += new System.EventHandler(this.btnSaveFindConfig_Click);
            // 
            // btnFindModel
            // 
            this.btnFindModel.Location = new System.Drawing.Point(19, 228);
            this.btnFindModel.Name = "btnFindModel";
            this.btnFindModel.Size = new System.Drawing.Size(82, 42);
            this.btnFindModel.TabIndex = 82;
            this.btnFindModel.Text = "查找模板";
            this.btnFindModel.UseVisualStyleBackColor = true;
            this.btnFindModel.Click += new System.EventHandler(this.btnFindModel_Click);
            // 
            // tcbFindLevels
            // 
            this.tcbFindLevels.AutoSize = false;
            this.tcbFindLevels.Location = new System.Drawing.Point(181, 191);
            this.tcbFindLevels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbFindLevels.Maximum = 5;
            this.tcbFindLevels.Name = "tcbFindLevels";
            this.tcbFindLevels.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbFindLevels.Size = new System.Drawing.Size(76, 29);
            this.tcbFindLevels.TabIndex = 79;
            this.tcbFindLevels.TickFrequency = 20;
            this.tcbFindLevels.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbFindLevels.Scroll += new System.EventHandler(this.tcbFindLevels_Scroll);
            // 
            // nudFindLeves
            // 
            this.nudFindLeves.Location = new System.Drawing.Point(122, 186);
            this.nudFindLeves.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudFindLeves.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFindLeves.Name = "nudFindLeves";
            this.nudFindLeves.Size = new System.Drawing.Size(57, 26);
            this.nudFindLeves.TabIndex = 78;
            this.nudFindLeves.ValueChanged += new System.EventHandler(this.nudFindLeves_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 191);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 16);
            this.label18.TabIndex = 77;
            this.label18.Text = "最大金字塔级别";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSubPixel
            // 
            this.cmbSubPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubPixel.ItemHeight = 16;
            this.cmbSubPixel.Items.AddRange(new object[] {
            "none",
            "interpolation",
            "least_squares",
            "least_squares_high",
            "least_squares_very_high"});
            this.cmbSubPixel.Location = new System.Drawing.Point(122, 151);
            this.cmbSubPixel.MaxDropDownItems = 5;
            this.cmbSubPixel.Name = "cmbSubPixel";
            this.cmbSubPixel.Size = new System.Drawing.Size(125, 24);
            this.cmbSubPixel.TabIndex = 76;
            this.cmbSubPixel.SelectedIndexChanged += new System.EventHandler(this.cmbSubPixel_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 157);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 75;
            this.label17.Text = "亚像素";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcbMaxOverlap
            // 
            this.tcbMaxOverlap.AutoSize = false;
            this.tcbMaxOverlap.LargeChange = 1;
            this.tcbMaxOverlap.Location = new System.Drawing.Point(181, 116);
            this.tcbMaxOverlap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbMaxOverlap.Name = "tcbMaxOverlap";
            this.tcbMaxOverlap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbMaxOverlap.Size = new System.Drawing.Size(76, 29);
            this.tcbMaxOverlap.TabIndex = 74;
            this.tcbMaxOverlap.TickFrequency = 10;
            this.tcbMaxOverlap.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbMaxOverlap.Value = 5;
            this.tcbMaxOverlap.Scroll += new System.EventHandler(this.tcbMaxOverlap_Scroll);
            // 
            // nudMaxOverlap
            // 
            this.nudMaxOverlap.DecimalPlaces = 1;
            this.nudMaxOverlap.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMaxOverlap.Location = new System.Drawing.Point(122, 116);
            this.nudMaxOverlap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudMaxOverlap.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxOverlap.Name = "nudMaxOverlap";
            this.nudMaxOverlap.Size = new System.Drawing.Size(57, 26);
            this.nudMaxOverlap.TabIndex = 73;
            this.nudMaxOverlap.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMaxOverlap.ValueChanged += new System.EventHandler(this.nudMaxOverlap_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 72;
            this.label15.Text = "最大重叠";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcbGreediness
            // 
            this.tcbGreediness.AutoSize = false;
            this.tcbGreediness.LargeChange = 1;
            this.tcbGreediness.Location = new System.Drawing.Point(181, 81);
            this.tcbGreediness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbGreediness.Name = "tcbGreediness";
            this.tcbGreediness.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbGreediness.Size = new System.Drawing.Size(76, 29);
            this.tcbGreediness.TabIndex = 71;
            this.tcbGreediness.TickFrequency = 10;
            this.tcbGreediness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbGreediness.Value = 9;
            this.tcbGreediness.Scroll += new System.EventHandler(this.tcbGreediness_Scroll);
            // 
            // nudGreediness
            // 
            this.nudGreediness.DecimalPlaces = 1;
            this.nudGreediness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudGreediness.Location = new System.Drawing.Point(122, 81);
            this.nudGreediness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudGreediness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGreediness.Name = "nudGreediness";
            this.nudGreediness.Size = new System.Drawing.Size(57, 26);
            this.nudGreediness.TabIndex = 70;
            this.nudGreediness.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.nudGreediness.ValueChanged += new System.EventHandler(this.nudGreediness_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 69;
            this.label16.Text = "贪心值";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcbNumMatches
            // 
            this.tcbNumMatches.AutoSize = false;
            this.tcbNumMatches.LargeChange = 10;
            this.tcbNumMatches.Location = new System.Drawing.Point(181, 47);
            this.tcbNumMatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbNumMatches.Maximum = 100;
            this.tcbNumMatches.Name = "tcbNumMatches";
            this.tcbNumMatches.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbNumMatches.Size = new System.Drawing.Size(76, 29);
            this.tcbNumMatches.TabIndex = 68;
            this.tcbNumMatches.TickFrequency = 20;
            this.tcbNumMatches.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbNumMatches.Value = 1;
            this.tcbNumMatches.Scroll += new System.EventHandler(this.tcbNumMatches_Scroll);
            // 
            // nudNumMatches
            // 
            this.nudNumMatches.Location = new System.Drawing.Point(122, 47);
            this.nudNumMatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudNumMatches.Name = "nudNumMatches";
            this.nudNumMatches.Size = new System.Drawing.Size(57, 26);
            this.nudNumMatches.TabIndex = 67;
            this.nudNumMatches.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumMatches.ValueChanged += new System.EventHandler(this.nudNumMatches_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 66;
            this.label14.Text = "匹配个数";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcbMinScore
            // 
            this.tcbMinScore.AutoSize = false;
            this.tcbMinScore.LargeChange = 10;
            this.tcbMinScore.Location = new System.Drawing.Point(181, 12);
            this.tcbMinScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbMinScore.Minimum = 1;
            this.tcbMinScore.Name = "tcbMinScore";
            this.tcbMinScore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbMinScore.Size = new System.Drawing.Size(76, 29);
            this.tcbMinScore.TabIndex = 65;
            this.tcbMinScore.TickFrequency = 10;
            this.tcbMinScore.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbMinScore.Value = 9;
            this.tcbMinScore.Scroll += new System.EventHandler(this.tcbMinScore_Scroll);
            // 
            // nudMinScore
            // 
            this.nudMinScore.DecimalPlaces = 1;
            this.nudMinScore.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinScore.Location = new System.Drawing.Point(122, 12);
            this.nudMinScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudMinScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinScore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinScore.Name = "nudMinScore";
            this.nudMinScore.Size = new System.Drawing.Size(57, 26);
            this.nudMinScore.TabIndex = 64;
            this.nudMinScore.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMinScore.ValueChanged += new System.EventHandler(this.nudMinScore_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 16);
            this.label19.TabIndex = 63;
            this.label19.Text = "最小得分";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCreateModel
            // 
            this.tbpCreateModel.AutoScroll = true;
            this.tbpCreateModel.Controls.Add(this.groupBox2);
            this.tbpCreateModel.Controls.Add(this.btnCreateModel);
            this.tbpCreateModel.Controls.Add(this.btnSaveModel);
            this.tbpCreateModel.Controls.Add(this.groupBoxCreateModel);
            this.tbpCreateModel.Controls.Add(this.grpRoi);
            this.tbpCreateModel.Location = new System.Drawing.Point(4, 26);
            this.tbpCreateModel.Name = "tbpCreateModel";
            this.tbpCreateModel.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCreateModel.Size = new System.Drawing.Size(287, 581);
            this.tbpCreateModel.TabIndex = 3;
            this.tbpCreateModel.Text = "创建模板";
            this.tbpCreateModel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.nudColumn);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.nudRow);
            this.groupBox2.Controls.Add(this.btnSetOrigin);
            this.groupBox2.Controls.Add(this.btnGetPos);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(7, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 72);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模板原点";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 14);
            this.label20.TabIndex = 81;
            this.label20.Text = "Row";
            // 
            // nudColumn
            // 
            this.nudColumn.DecimalPlaces = 2;
            this.nudColumn.Location = new System.Drawing.Point(68, 44);
            this.nudColumn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudColumn.Name = "nudColumn";
            this.nudColumn.Size = new System.Drawing.Size(100, 23);
            this.nudColumn.TabIndex = 83;
            this.nudColumn.ValueChanged += new System.EventHandler(this.nudColumn_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 14);
            this.label21.TabIndex = 81;
            this.label21.Text = "Column";
            // 
            // nudRow
            // 
            this.nudRow.DecimalPlaces = 2;
            this.nudRow.Location = new System.Drawing.Point(68, 16);
            this.nudRow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRow.Name = "nudRow";
            this.nudRow.Size = new System.Drawing.Size(100, 23);
            this.nudRow.TabIndex = 83;
            this.nudRow.ValueChanged += new System.EventHandler(this.nudRow_ValueChanged);
            // 
            // btnSetOrigin
            // 
            this.btnSetOrigin.Location = new System.Drawing.Point(176, 40);
            this.btnSetOrigin.Name = "btnSetOrigin";
            this.btnSetOrigin.Size = new System.Drawing.Size(83, 28);
            this.btnSetOrigin.TabIndex = 82;
            this.btnSetOrigin.Text = "设置原点";
            this.btnSetOrigin.UseVisualStyleBackColor = true;
            this.btnSetOrigin.Click += new System.EventHandler(this.btnSetOrigin_Click);
            // 
            // btnGetPos
            // 
            this.btnGetPos.Location = new System.Drawing.Point(176, 12);
            this.btnGetPos.Name = "btnGetPos";
            this.btnGetPos.Size = new System.Drawing.Size(83, 28);
            this.btnGetPos.TabIndex = 82;
            this.btnGetPos.Text = "获取坐标";
            this.btnGetPos.UseVisualStyleBackColor = true;
            this.btnGetPos.Click += new System.EventHandler(this.btnGetPos_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(6, 430);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(83, 28);
            this.btnCreateModel.TabIndex = 0;
            this.btnCreateModel.Text = "创建模板";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Location = new System.Drawing.Point(6, 535);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(83, 28);
            this.btnSaveModel.TabIndex = 0;
            this.btnSaveModel.Text = "保存模板";
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // groupBoxCreateModel
            // 
            this.groupBoxCreateModel.Controls.Add(this.DispPyramidTrackBar);
            this.groupBoxCreateModel.Controls.Add(this.DispPyramidUpDown);
            this.groupBoxCreateModel.Controls.Add(this.cmbMetric);
            this.groupBoxCreateModel.Controls.Add(this.tcbScaleMax);
            this.groupBoxCreateModel.Controls.Add(this.tcbScaleMin);
            this.groupBoxCreateModel.Controls.Add(this.tcbAngleExtent);
            this.groupBoxCreateModel.Controls.Add(this.tcbAngleStart);
            this.groupBoxCreateModel.Controls.Add(this.tcbNumLevels);
            this.groupBoxCreateModel.Controls.Add(this.tcbMinContrast);
            this.groupBoxCreateModel.Controls.Add(this.MinContrastAutoButton);
            this.groupBoxCreateModel.Controls.Add(this.nudMinContrast);
            this.groupBoxCreateModel.Controls.Add(this.label12);
            this.groupBoxCreateModel.Controls.Add(this.cmbOptimization);
            this.groupBoxCreateModel.Controls.Add(this.OptimizationAutoButton);
            this.groupBoxCreateModel.Controls.Add(this.label10);
            this.groupBoxCreateModel.Controls.Add(this.label3);
            this.groupBoxCreateModel.Controls.Add(this.label9);
            this.groupBoxCreateModel.Controls.Add(this.nudScaleMin);
            this.groupBoxCreateModel.Controls.Add(this.label4);
            this.groupBoxCreateModel.Controls.Add(this.trackBar_Min_Size);
            this.groupBoxCreateModel.Controls.Add(this.PyramidLevelAutoButton);
            this.groupBoxCreateModel.Controls.Add(this.nudScaleMax);
            this.groupBoxCreateModel.Controls.Add(this.UpDown_MinSize);
            this.groupBoxCreateModel.Controls.Add(this.nudNumLevels);
            this.groupBoxCreateModel.Controls.Add(this.label8);
            this.groupBoxCreateModel.Controls.Add(this.nudAngleExtent);
            this.groupBoxCreateModel.Controls.Add(this.label6);
            this.groupBoxCreateModel.Controls.Add(this.nudAngleStart);
            this.groupBoxCreateModel.Controls.Add(this.label5);
            this.groupBoxCreateModel.Controls.Add(this.button_MinSizeAuto);
            this.groupBoxCreateModel.Controls.Add(this.ContrastAutoButton);
            this.groupBoxCreateModel.Controls.Add(this.nudContrastHigh);
            this.groupBoxCreateModel.Controls.Add(this.nudContrastLow);
            this.groupBoxCreateModel.Controls.Add(this.tcbContrastHigh);
            this.groupBoxCreateModel.Controls.Add(this.tcbContrastLow);
            this.groupBoxCreateModel.Controls.Add(this.label11);
            this.groupBoxCreateModel.Controls.Add(this.label7);
            this.groupBoxCreateModel.Controls.Add(this.label2);
            this.groupBoxCreateModel.Controls.Add(this.label13);
            this.groupBoxCreateModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxCreateModel.Location = new System.Drawing.Point(6, 62);
            this.groupBoxCreateModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxCreateModel.Name = "groupBoxCreateModel";
            this.groupBoxCreateModel.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxCreateModel.Size = new System.Drawing.Size(266, 366);
            this.groupBoxCreateModel.TabIndex = 56;
            this.groupBoxCreateModel.TabStop = false;
            this.groupBoxCreateModel.Text = "模板参数设置";
            // 
            // DispPyramidTrackBar
            // 
            this.DispPyramidTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DispPyramidTrackBar.AutoSize = false;
            this.DispPyramidTrackBar.Enabled = false;
            this.DispPyramidTrackBar.LargeChange = 1;
            this.DispPyramidTrackBar.Location = new System.Drawing.Point(162, 336);
            this.DispPyramidTrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DispPyramidTrackBar.Maximum = 6;
            this.DispPyramidTrackBar.Minimum = 1;
            this.DispPyramidTrackBar.Name = "DispPyramidTrackBar";
            this.DispPyramidTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DispPyramidTrackBar.Size = new System.Drawing.Size(65, 28);
            this.DispPyramidTrackBar.TabIndex = 29;
            this.DispPyramidTrackBar.Value = 1;
            // 
            // DispPyramidUpDown
            // 
            this.DispPyramidUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DispPyramidUpDown.Location = new System.Drawing.Point(111, 336);
            this.DispPyramidUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DispPyramidUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.DispPyramidUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DispPyramidUpDown.Name = "DispPyramidUpDown";
            this.DispPyramidUpDown.Size = new System.Drawing.Size(50, 26);
            this.DispPyramidUpDown.TabIndex = 30;
            this.DispPyramidUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbMetric
            // 
            this.cmbMetric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetric.Items.AddRange(new object[] {
            "use_polarity",
            "ignore_global_polarity",
            "ignore_local_polarity",
            "ignore_color_polarity"});
            this.cmbMetric.Location = new System.Drawing.Point(81, 255);
            this.cmbMetric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMetric.Name = "cmbMetric";
            this.cmbMetric.Size = new System.Drawing.Size(146, 20);
            this.cmbMetric.TabIndex = 73;
            this.cmbMetric.SelectedIndexChanged += new System.EventHandler(this.cmbMetric_SelectedIndexChanged);
            // 
            // tcbScaleMax
            // 
            this.tcbScaleMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbScaleMax.AutoSize = false;
            this.tcbScaleMax.Location = new System.Drawing.Point(131, 222);
            this.tcbScaleMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbScaleMax.Maximum = 15;
            this.tcbScaleMax.Minimum = 10;
            this.tcbScaleMax.Name = "tcbScaleMax";
            this.tcbScaleMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbScaleMax.Size = new System.Drawing.Size(96, 28);
            this.tcbScaleMax.TabIndex = 45;
            this.tcbScaleMax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbScaleMax.Value = 11;
            this.tcbScaleMax.Scroll += new System.EventHandler(this.tcbScaleMax_Scroll);
            // 
            // tcbScaleMin
            // 
            this.tcbScaleMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbScaleMin.AutoSize = false;
            this.tcbScaleMin.LargeChange = 1;
            this.tcbScaleMin.Location = new System.Drawing.Point(131, 193);
            this.tcbScaleMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbScaleMin.Minimum = 5;
            this.tcbScaleMin.Name = "tcbScaleMin";
            this.tcbScaleMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbScaleMin.Size = new System.Drawing.Size(96, 28);
            this.tcbScaleMin.TabIndex = 42;
            this.tcbScaleMin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbScaleMin.Value = 9;
            this.tcbScaleMin.Scroll += new System.EventHandler(this.tcbScaleMin_Scroll);
            // 
            // tcbAngleExtent
            // 
            this.tcbAngleExtent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbAngleExtent.AutoSize = false;
            this.tcbAngleExtent.Location = new System.Drawing.Point(131, 164);
            this.tcbAngleExtent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbAngleExtent.Maximum = 360;
            this.tcbAngleExtent.Name = "tcbAngleExtent";
            this.tcbAngleExtent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbAngleExtent.Size = new System.Drawing.Size(96, 28);
            this.tcbAngleExtent.TabIndex = 63;
            this.tcbAngleExtent.TickFrequency = 20;
            this.tcbAngleExtent.Value = 360;
            this.tcbAngleExtent.Scroll += new System.EventHandler(this.tcbAngleExtent_Scroll);
            // 
            // tcbAngleStart
            // 
            this.tcbAngleStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbAngleStart.AutoSize = false;
            this.tcbAngleStart.Location = new System.Drawing.Point(131, 134);
            this.tcbAngleStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbAngleStart.Maximum = 360;
            this.tcbAngleStart.Minimum = -360;
            this.tcbAngleStart.Name = "tcbAngleStart";
            this.tcbAngleStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbAngleStart.Size = new System.Drawing.Size(96, 28);
            this.tcbAngleStart.TabIndex = 60;
            this.tcbAngleStart.TickFrequency = 20;
            this.tcbAngleStart.Value = -180;
            this.tcbAngleStart.Scroll += new System.EventHandler(this.tcbAngleStart_Scroll);
            // 
            // tcbNumLevels
            // 
            this.tcbNumLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbNumLevels.AutoSize = false;
            this.tcbNumLevels.Location = new System.Drawing.Point(131, 105);
            this.tcbNumLevels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbNumLevels.Name = "tcbNumLevels";
            this.tcbNumLevels.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbNumLevels.Size = new System.Drawing.Size(96, 28);
            this.tcbNumLevels.TabIndex = 71;
            this.tcbNumLevels.Scroll += new System.EventHandler(this.tcbNumLevels_Scroll);
            // 
            // tcbMinContrast
            // 
            this.tcbMinContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbMinContrast.AutoSize = false;
            this.tcbMinContrast.Location = new System.Drawing.Point(162, 307);
            this.tcbMinContrast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbMinContrast.Maximum = 40;
            this.tcbMinContrast.Name = "tcbMinContrast";
            this.tcbMinContrast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbMinContrast.Size = new System.Drawing.Size(65, 28);
            this.tcbMinContrast.TabIndex = 80;
            this.tcbMinContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbMinContrast.Scroll += new System.EventHandler(this.tcbMinContrast_Scroll);
            // 
            // MinContrastAutoButton
            // 
            this.MinContrastAutoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinContrastAutoButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinContrastAutoButton.Location = new System.Drawing.Point(227, 307);
            this.MinContrastAutoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinContrastAutoButton.Name = "MinContrastAutoButton";
            this.MinContrastAutoButton.Size = new System.Drawing.Size(39, 28);
            this.MinContrastAutoButton.TabIndex = 79;
            this.MinContrastAutoButton.Text = "自动";
            // 
            // nudMinContrast
            // 
            this.nudMinContrast.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudMinContrast.Location = new System.Drawing.Point(111, 307);
            this.nudMinContrast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudMinContrast.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudMinContrast.Name = "nudMinContrast";
            this.nudMinContrast.Size = new System.Drawing.Size(50, 26);
            this.nudMinContrast.TabIndex = 78;
            this.nudMinContrast.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMinContrast.ValueChanged += new System.EventHandler(this.nudMinContrast_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(3, 309);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 77;
            this.label12.Text = "最小对比度";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOptimization
            // 
            this.cmbOptimization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOptimization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptimization.Items.AddRange(new object[] {
            "none",
            "point_reduction_low",
            "point_reduction_medium",
            "point_reduction_high"});
            this.cmbOptimization.Location = new System.Drawing.Point(81, 281);
            this.cmbOptimization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbOptimization.Name = "cmbOptimization";
            this.cmbOptimization.Size = new System.Drawing.Size(146, 20);
            this.cmbOptimization.TabIndex = 76;
            this.cmbOptimization.SelectedIndexChanged += new System.EventHandler(this.cmbOptimization_SelectedIndexChanged);
            // 
            // OptimizationAutoButton
            // 
            this.OptimizationAutoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OptimizationAutoButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptimizationAutoButton.Location = new System.Drawing.Point(226, 281);
            this.OptimizationAutoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OptimizationAutoButton.Name = "OptimizationAutoButton";
            this.OptimizationAutoButton.Size = new System.Drawing.Size(39, 22);
            this.OptimizationAutoButton.TabIndex = 75;
            this.OptimizationAutoButton.Text = "自动";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(3, 281);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 74;
            this.label10.Text = "最优化";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "最小缩放";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 255);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 72;
            this.label9.Text = "极性选择";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudScaleMin
            // 
            this.nudScaleMin.DecimalPlaces = 2;
            this.nudScaleMin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudScaleMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScaleMin.Location = new System.Drawing.Point(81, 193);
            this.nudScaleMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudScaleMin.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudScaleMin.Name = "nudScaleMin";
            this.nudScaleMin.Size = new System.Drawing.Size(50, 26);
            this.nudScaleMin.TabIndex = 43;
            this.nudScaleMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleMin.ValueChanged += new System.EventHandler(this.nudScaleMin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "最大缩放";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackBar_Min_Size
            // 
            this.trackBar_Min_Size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_Min_Size.AutoSize = false;
            this.trackBar_Min_Size.Location = new System.Drawing.Point(131, 76);
            this.trackBar_Min_Size.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBar_Min_Size.Maximum = 500;
            this.trackBar_Min_Size.Minimum = 1;
            this.trackBar_Min_Size.Name = "trackBar_Min_Size";
            this.trackBar_Min_Size.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Min_Size.Size = new System.Drawing.Size(96, 28);
            this.trackBar_Min_Size.TabIndex = 71;
            this.trackBar_Min_Size.TickFrequency = 10;
            this.trackBar_Min_Size.Value = 5;
            // 
            // PyramidLevelAutoButton
            // 
            this.PyramidLevelAutoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PyramidLevelAutoButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PyramidLevelAutoButton.Location = new System.Drawing.Point(226, 105);
            this.PyramidLevelAutoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PyramidLevelAutoButton.Name = "PyramidLevelAutoButton";
            this.PyramidLevelAutoButton.Size = new System.Drawing.Size(39, 28);
            this.PyramidLevelAutoButton.TabIndex = 70;
            this.PyramidLevelAutoButton.Text = "自动";
            // 
            // nudScaleMax
            // 
            this.nudScaleMax.DecimalPlaces = 2;
            this.nudScaleMax.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudScaleMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScaleMax.Location = new System.Drawing.Point(81, 222);
            this.nudScaleMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudScaleMax.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudScaleMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleMax.Name = "nudScaleMax";
            this.nudScaleMax.Size = new System.Drawing.Size(50, 26);
            this.nudScaleMax.TabIndex = 46;
            this.nudScaleMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleMax.ValueChanged += new System.EventHandler(this.nudScaleMax_ValueChanged);
            // 
            // UpDown_MinSize
            // 
            this.UpDown_MinSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpDown_MinSize.Location = new System.Drawing.Point(81, 76);
            this.UpDown_MinSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpDown_MinSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.UpDown_MinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDown_MinSize.Name = "UpDown_MinSize";
            this.UpDown_MinSize.Size = new System.Drawing.Size(50, 26);
            this.UpDown_MinSize.TabIndex = 69;
            this.UpDown_MinSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudNumLevels
            // 
            this.nudNumLevels.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudNumLevels.Location = new System.Drawing.Point(81, 105);
            this.nudNumLevels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudNumLevels.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumLevels.Name = "nudNumLevels";
            this.nudNumLevels.Size = new System.Drawing.Size(50, 26);
            this.nudNumLevels.TabIndex = 69;
            this.nudNumLevels.ValueChanged += new System.EventHandler(this.nudNumLevels_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "金字塔等级";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudAngleExtent
            // 
            this.nudAngleExtent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudAngleExtent.Location = new System.Drawing.Point(81, 164);
            this.nudAngleExtent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudAngleExtent.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngleExtent.Name = "nudAngleExtent";
            this.nudAngleExtent.Size = new System.Drawing.Size(50, 26);
            this.nudAngleExtent.TabIndex = 62;
            this.nudAngleExtent.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudAngleExtent.ValueChanged += new System.EventHandler(this.nudAngleExtent_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 61;
            this.label6.Text = "角度范围";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudAngleStart
            // 
            this.nudAngleStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudAngleStart.Location = new System.Drawing.Point(81, 134);
            this.nudAngleStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudAngleStart.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngleStart.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudAngleStart.Name = "nudAngleStart";
            this.nudAngleStart.Size = new System.Drawing.Size(50, 26);
            this.nudAngleStart.TabIndex = 59;
            this.nudAngleStart.Value = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.nudAngleStart.ValueChanged += new System.EventHandler(this.nudAngleStart_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 58;
            this.label5.Text = "开始角度";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_MinSizeAuto
            // 
            this.button_MinSizeAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_MinSizeAuto.BackColor = System.Drawing.SystemColors.Control;
            this.button_MinSizeAuto.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_MinSizeAuto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_MinSizeAuto.Location = new System.Drawing.Point(226, 76);
            this.button_MinSizeAuto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_MinSizeAuto.Name = "button_MinSizeAuto";
            this.button_MinSizeAuto.Size = new System.Drawing.Size(39, 28);
            this.button_MinSizeAuto.TabIndex = 40;
            this.button_MinSizeAuto.Text = "自动";
            this.button_MinSizeAuto.UseVisualStyleBackColor = false;
            // 
            // ContrastAutoButton
            // 
            this.ContrastAutoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ContrastAutoButton.BackColor = System.Drawing.SystemColors.Control;
            this.ContrastAutoButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContrastAutoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ContrastAutoButton.Location = new System.Drawing.Point(226, 17);
            this.ContrastAutoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ContrastAutoButton.Name = "ContrastAutoButton";
            this.ContrastAutoButton.Size = new System.Drawing.Size(39, 57);
            this.ContrastAutoButton.TabIndex = 40;
            this.ContrastAutoButton.Text = "自动";
            this.ContrastAutoButton.UseVisualStyleBackColor = false;
            // 
            // nudContrastHigh
            // 
            this.nudContrastHigh.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudContrastHigh.Location = new System.Drawing.Point(81, 47);
            this.nudContrastHigh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudContrastHigh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudContrastHigh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContrastHigh.Name = "nudContrastHigh";
            this.nudContrastHigh.Size = new System.Drawing.Size(50, 26);
            this.nudContrastHigh.TabIndex = 39;
            this.nudContrastHigh.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudContrastHigh.ValueChanged += new System.EventHandler(this.nudContrastHigh_ValueChanged);
            // 
            // nudContrastLow
            // 
            this.nudContrastLow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudContrastLow.Location = new System.Drawing.Point(81, 17);
            this.nudContrastLow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudContrastLow.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudContrastLow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContrastLow.Name = "nudContrastLow";
            this.nudContrastLow.Size = new System.Drawing.Size(50, 26);
            this.nudContrastLow.TabIndex = 39;
            this.nudContrastLow.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudContrastLow.ValueChanged += new System.EventHandler(this.nudContrastLow_ValueChanged);
            // 
            // tcbContrastHigh
            // 
            this.tcbContrastHigh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbContrastHigh.AutoSize = false;
            this.tcbContrastHigh.Location = new System.Drawing.Point(131, 47);
            this.tcbContrastHigh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbContrastHigh.Maximum = 255;
            this.tcbContrastHigh.Minimum = 1;
            this.tcbContrastHigh.Name = "tcbContrastHigh";
            this.tcbContrastHigh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbContrastHigh.Size = new System.Drawing.Size(96, 28);
            this.tcbContrastHigh.TabIndex = 38;
            this.tcbContrastHigh.TickFrequency = 15;
            this.tcbContrastHigh.Value = 40;
            this.tcbContrastHigh.Scroll += new System.EventHandler(this.tcbContrastHigh_Scroll);
            // 
            // tcbContrastLow
            // 
            this.tcbContrastLow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcbContrastLow.AutoSize = false;
            this.tcbContrastLow.Location = new System.Drawing.Point(131, 17);
            this.tcbContrastLow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcbContrastLow.Maximum = 255;
            this.tcbContrastLow.Minimum = 1;
            this.tcbContrastLow.Name = "tcbContrastLow";
            this.tcbContrastLow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcbContrastLow.Size = new System.Drawing.Size(96, 28);
            this.tcbContrastLow.TabIndex = 38;
            this.tcbContrastLow.TickFrequency = 15;
            this.tcbContrastLow.Value = 30;
            this.tcbContrastLow.Scroll += new System.EventHandler(this.tcbContrastLow_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "有效尺寸";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "对比度(高)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "对比度(低)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(3, 338);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "显示金字塔图像";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpRoi
            // 
            this.grpRoi.Controls.Add(this.rdbUnion);
            this.grpRoi.Controls.Add(this.rdbDifference);
            this.grpRoi.Controls.Add(this.btnDrawLine);
            this.grpRoi.Controls.Add(this.rdbIntersection);
            this.grpRoi.Controls.Add(this.btnDrawCircle);
            this.grpRoi.Controls.Add(this.btnDrawRectangle1);
            this.grpRoi.Controls.Add(this.btnDel);
            this.grpRoi.Controls.Add(this.btnDrawRectangle2);
            this.grpRoi.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpRoi.Location = new System.Drawing.Point(6, 4);
            this.grpRoi.Name = "grpRoi";
            this.grpRoi.Size = new System.Drawing.Size(266, 55);
            this.grpRoi.TabIndex = 7;
            this.grpRoi.TabStop = false;
            this.grpRoi.Text = "ROI";
            // 
            // rdbUnion
            // 
            this.rdbUnion.AutoSize = true;
            this.rdbUnion.Checked = true;
            this.rdbUnion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbUnion.Location = new System.Drawing.Point(6, 22);
            this.rdbUnion.Name = "rdbUnion";
            this.rdbUnion.Size = new System.Drawing.Size(35, 16);
            this.rdbUnion.TabIndex = 6;
            this.rdbUnion.TabStop = true;
            this.rdbUnion.Text = "∪";
            this.rdbUnion.UseVisualStyleBackColor = true;
            // 
            // rdbDifference
            // 
            this.rdbDifference.AutoSize = true;
            this.rdbDifference.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbDifference.Location = new System.Drawing.Point(87, 22);
            this.rdbDifference.Name = "rdbDifference";
            this.rdbDifference.Size = new System.Drawing.Size(29, 16);
            this.rdbDifference.TabIndex = 6;
            this.rdbDifference.Text = "-";
            this.rdbDifference.UseVisualStyleBackColor = true;
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.BackColor = System.Drawing.Color.White;
            this.btnDrawLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawLine.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawLine.Image")));
            this.btnDrawLine.Location = new System.Drawing.Point(122, 17);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(20, 22);
            this.btnDrawLine.TabIndex = 5;
            this.btnDrawLine.UseVisualStyleBackColor = false;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // rdbIntersection
            // 
            this.rdbIntersection.AutoSize = true;
            this.rdbIntersection.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbIntersection.Location = new System.Drawing.Point(46, 22);
            this.rdbIntersection.Name = "rdbIntersection";
            this.rdbIntersection.Size = new System.Drawing.Size(35, 16);
            this.rdbIntersection.TabIndex = 6;
            this.rdbIntersection.Text = "∩";
            this.rdbIntersection.UseVisualStyleBackColor = true;
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.BackColor = System.Drawing.Color.White;
            this.btnDrawCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawCircle.Image")));
            this.btnDrawCircle.Location = new System.Drawing.Point(148, 17);
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.Size = new System.Drawing.Size(20, 22);
            this.btnDrawCircle.TabIndex = 4;
            this.btnDrawCircle.UseVisualStyleBackColor = false;
            this.btnDrawCircle.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // btnDrawRectangle1
            // 
            this.btnDrawRectangle1.BackColor = System.Drawing.Color.White;
            this.btnDrawRectangle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawRectangle1.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawRectangle1.Image")));
            this.btnDrawRectangle1.Location = new System.Drawing.Point(174, 17);
            this.btnDrawRectangle1.Name = "btnDrawRectangle1";
            this.btnDrawRectangle1.Size = new System.Drawing.Size(20, 22);
            this.btnDrawRectangle1.TabIndex = 3;
            this.btnDrawRectangle1.UseVisualStyleBackColor = false;
            this.btnDrawRectangle1.Click += new System.EventHandler(this.btnDrawRectangle1_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.White;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(226, 17);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(20, 22);
            this.btnDel.TabIndex = 2;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnDrawRectangle2
            // 
            this.btnDrawRectangle2.BackColor = System.Drawing.Color.White;
            this.btnDrawRectangle2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawRectangle2.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawRectangle2.Image")));
            this.btnDrawRectangle2.Location = new System.Drawing.Point(200, 17);
            this.btnDrawRectangle2.Name = "btnDrawRectangle2";
            this.btnDrawRectangle2.Size = new System.Drawing.Size(20, 22);
            this.btnDrawRectangle2.TabIndex = 2;
            this.btnDrawRectangle2.UseVisualStyleBackColor = false;
            this.btnDrawRectangle2.Click += new System.EventHandler(this.btnDrawRectangle2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpCreateModel);
            this.tabControl1.Controls.Add(this.tbpFindModel);
            this.tabControl1.Controls.Add(this.tbpMeasure);
            this.tabControl1.Controls.Add(this.tbpCalib);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(711, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(295, 611);
            this.tabControl1.TabIndex = 4;
            // 
            // visionControl1
            // 
            this.visionControl1.BackColor = System.Drawing.SystemColors.Highlight;
            this.visionControl1.Location = new System.Drawing.Point(0, 0);
            this.visionControl1.MouseMode = GoVision.VisionControl.WindowMouseMode.Move;
            this.visionControl1.Name = "visionControl1";
            this.visionControl1.Size = new System.Drawing.Size(533, 400);
            this.visionControl1.TabIndex = 5;
            this.visionControl1.TabStop = false;
            this.visionControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.visionControl1_MouseMove);
            this.visionControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.visionControl1_MouseUp);
            this.visionControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.visionControl1_MouseWheel);
            // 
            // MainCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1007, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.visionControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainCameraForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainCameraForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExposure)).EndInit();
            this.tbpCalib.ResumeLayout(false);
            this.tbpCalib.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetDia)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarkColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarkRow)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalib)).EndInit();
            this.tbpMeasure.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginTopMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiameterMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiameterMin)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbSigma)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasureRoiWidth)).EndInit();
            this.tbpFindModel.ResumeLayout(false);
            this.tbpFindModel.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmphasize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbFindLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFindLeves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbMaxOverlap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxOverlap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbGreediness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreediness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbNumMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbMinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinScore)).EndInit();
            this.tbpCreateModel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).EndInit();
            this.groupBoxCreateModel.ResumeLayout(false);
            this.groupBoxCreateModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DispPyramidTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispPyramidUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbScaleMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbScaleMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbAngleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbNumLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbMinContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Min_Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_MinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbContrastHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbContrastLow)).EndInit();
            this.grpRoi.ResumeLayout(false);
            this.grpRoi.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visionControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnReadImage;
        private System.Windows.Forms.Button btnStopGrab;
        private System.Windows.Forms.Button btnContinuGrab;
        private System.Windows.Forms.Button btnGrabOne;
        private System.Windows.Forms.ComboBox cmbProcess;
        private System.Windows.Forms.Label label1;
        private VisionControl visionControl1;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnProcessImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.NumericUpDown nudExposure;
        private System.Windows.Forms.TabPage tbpCalib;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnSaveMark;
        private System.Windows.Forms.Button btnGetMark;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.NumericUpDown nudMarkColumn;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.NumericUpDown nudMarkRow;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dgvCalib;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCalibX;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCalibY;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCalibCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCalibRow;
        private System.Windows.Forms.Button btnCalibFindModel;
        private System.Windows.Forms.Button btnCalibData;
        private System.Windows.Forms.TabPage tbpMeasure;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown nudMaginTop;
        private System.Windows.Forms.NumericUpDown nudMaginLeft;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown nudPinCount;
        private System.Windows.Forms.NumericUpDown nudDiameterMax;
        private System.Windows.Forms.NumericUpDown nudMaginRight;
        private System.Windows.Forms.NumericUpDown nudPinDistance;
        private System.Windows.Forms.NumericUpDown nudDiameterMin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.NumericUpDown nudSigma;
        private System.Windows.Forms.TrackBar tcbThreshold;
        private System.Windows.Forms.CheckBox ckbPairs;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.TrackBar tcbSigma;
        private System.Windows.Forms.ComboBox cmbTransition;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnMeasureTest;
        private System.Windows.Forms.Button btnSaveMeasure;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown nudMeasureRoiColumn;
        private System.Windows.Forms.NumericUpDown nudDisEdge;
        private System.Windows.Forms.NumericUpDown nudMeasureRoiHeight;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown nudMeasureRoiRow;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown nudMeasureRoiPhi;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown nudMeasureRoiWidth;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbInterpolation;
        private System.Windows.Forms.Button btnDelMeasure;
        private System.Windows.Forms.Button btnDrawMeasure;
        private System.Windows.Forms.ListBox lstMeasureList;
        private System.Windows.Forms.TabPage tbpFindModel;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnImagePer;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.NumericUpDown nudEmphasize;
        private System.Windows.Forms.CheckBox ckbAdjustImage;
        private System.Windows.Forms.CheckBox ckbPerprocess;
        private System.Windows.Forms.Button btnPlatformRegion;
        private System.Windows.Forms.Button btnSaveFindConfig;
        private System.Windows.Forms.Button btnFindModel;
        private System.Windows.Forms.TrackBar tcbFindLevels;
        private System.Windows.Forms.NumericUpDown nudFindLeves;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbSubPixel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar tcbMaxOverlap;
        private System.Windows.Forms.NumericUpDown nudMaxOverlap;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar tcbGreediness;
        private System.Windows.Forms.NumericUpDown nudGreediness;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar tcbNumMatches;
        private System.Windows.Forms.NumericUpDown nudNumMatches;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar tcbMinScore;
        private System.Windows.Forms.NumericUpDown nudMinScore;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tbpCreateModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudColumn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nudRow;
        private System.Windows.Forms.Button btnSetOrigin;
        private System.Windows.Forms.Button btnGetPos;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.GroupBox groupBoxCreateModel;
        private System.Windows.Forms.TrackBar DispPyramidTrackBar;
        private System.Windows.Forms.NumericUpDown DispPyramidUpDown;
        private System.Windows.Forms.ComboBox cmbMetric;
        private System.Windows.Forms.TrackBar tcbScaleMax;
        private System.Windows.Forms.TrackBar tcbScaleMin;
        private System.Windows.Forms.TrackBar tcbAngleExtent;
        private System.Windows.Forms.TrackBar tcbAngleStart;
        private System.Windows.Forms.TrackBar tcbNumLevels;
        private System.Windows.Forms.TrackBar tcbMinContrast;
        private System.Windows.Forms.Button MinContrastAutoButton;
        private System.Windows.Forms.NumericUpDown nudMinContrast;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbOptimization;
        private System.Windows.Forms.Button OptimizationAutoButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudScaleMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar_Min_Size;
        private System.Windows.Forms.Button PyramidLevelAutoButton;
        private System.Windows.Forms.NumericUpDown nudScaleMax;
        private System.Windows.Forms.NumericUpDown UpDown_MinSize;
        private System.Windows.Forms.NumericUpDown nudNumLevels;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudAngleExtent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAngleStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_MinSizeAuto;
        private System.Windows.Forms.Button ContrastAutoButton;
        private System.Windows.Forms.NumericUpDown nudContrastHigh;
        private System.Windows.Forms.NumericUpDown nudContrastLow;
        private System.Windows.Forms.TrackBar tcbContrastHigh;
        private System.Windows.Forms.TrackBar tcbContrastLow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpRoi;
        private System.Windows.Forms.RadioButton rdbUnion;
        private System.Windows.Forms.RadioButton rdbDifference;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.RadioButton rdbIntersection;
        private System.Windows.Forms.Button btnDrawCircle;
        private System.Windows.Forms.Button btnDrawRectangle1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDrawRectangle2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox ckbSecondPos;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.NumericUpDown nudOffsetDia;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown nudMaginTopMax;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label41;
    }
}