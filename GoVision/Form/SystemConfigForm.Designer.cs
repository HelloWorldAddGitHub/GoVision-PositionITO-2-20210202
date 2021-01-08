namespace GoVision
{
    partial class SystemConfigForm
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
            this.grpProductManage = new System.Windows.Forms.GroupBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.btnSelectProduct = new System.Windows.Forms.Button();
            this.btnDelProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lstProduct = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbSaveLog = new System.Windows.Forms.CheckBox();
            this.ckbSaveData = new System.Windows.Forms.CheckBox();
            this.ckbSaveImageAll = new System.Windows.Forms.CheckBox();
            this.ckbSaveImageNG = new System.Windows.Forms.CheckBox();
            this.grpProductManage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProductManage
            // 
            this.grpProductManage.BackColor = System.Drawing.SystemColors.Window;
            this.grpProductManage.Controls.Add(this.txtProduct);
            this.grpProductManage.Controls.Add(this.btnSelectProduct);
            this.grpProductManage.Controls.Add(this.btnDelProduct);
            this.grpProductManage.Controls.Add(this.btnAddProduct);
            this.grpProductManage.Controls.Add(this.lstProduct);
            this.grpProductManage.Location = new System.Drawing.Point(16, 16);
            this.grpProductManage.Margin = new System.Windows.Forms.Padding(4);
            this.grpProductManage.Name = "grpProductManage";
            this.grpProductManage.Padding = new System.Windows.Forms.Padding(4);
            this.grpProductManage.Size = new System.Drawing.Size(310, 327);
            this.grpProductManage.TabIndex = 0;
            this.grpProductManage.TabStop = false;
            this.grpProductManage.Text = "产品管理";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(8, 230);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(294, 26);
            this.txtProduct.TabIndex = 1;
            // 
            // btnSelectProduct
            // 
            this.btnSelectProduct.Location = new System.Drawing.Point(8, 266);
            this.btnSelectProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectProduct.Name = "btnSelectProduct";
            this.btnSelectProduct.Size = new System.Drawing.Size(90, 30);
            this.btnSelectProduct.TabIndex = 1;
            this.btnSelectProduct.Text = "选择";
            this.btnSelectProduct.UseVisualStyleBackColor = true;
            this.btnSelectProduct.Click += new System.EventHandler(this.btnSelectProduct_Click);
            // 
            // btnDelProduct
            // 
            this.btnDelProduct.Location = new System.Drawing.Point(208, 266);
            this.btnDelProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelProduct.Name = "btnDelProduct";
            this.btnDelProduct.Size = new System.Drawing.Size(90, 30);
            this.btnDelProduct.TabIndex = 1;
            this.btnDelProduct.Text = "删除";
            this.btnDelProduct.UseVisualStyleBackColor = true;
            this.btnDelProduct.Click += new System.EventHandler(this.btnDelProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(108, 266);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(90, 30);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "增加";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lstProduct
            // 
            this.lstProduct.FormattingEnabled = true;
            this.lstProduct.ItemHeight = 16;
            this.lstProduct.Location = new System.Drawing.Point(8, 26);
            this.lstProduct.Margin = new System.Windows.Forms.Padding(4);
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(294, 196);
            this.lstProduct.TabIndex = 1;
            this.lstProduct.SelectedValueChanged += new System.EventHandler(this.lstProduct_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtAddr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 184);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(24, 129);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(274, 30);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(86, 81);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(212, 26);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "5000";
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(88, 42);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(210, 26);
            this.txtAddr.TabIndex = 2;
            this.txtAddr.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.ckbSaveLog);
            this.groupBox2.Controls.Add(this.ckbSaveData);
            this.groupBox2.Controls.Add(this.ckbSaveImageNG);
            this.groupBox2.Controls.Add(this.ckbSaveImageAll);
            this.groupBox2.Location = new System.Drawing.Point(354, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 278);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存设置";
            // 
            // ckbSaveLog
            // 
            this.ckbSaveLog.AutoSize = true;
            this.ckbSaveLog.Location = new System.Drawing.Point(36, 114);
            this.ckbSaveLog.Name = "ckbSaveLog";
            this.ckbSaveLog.Size = new System.Drawing.Size(91, 20);
            this.ckbSaveLog.TabIndex = 0;
            this.ckbSaveLog.Text = "保存日志";
            this.ckbSaveLog.UseVisualStyleBackColor = true;
            this.ckbSaveLog.CheckedChanged += new System.EventHandler(this.ckbSaveLog_CheckedChanged);
            // 
            // ckbSaveData
            // 
            this.ckbSaveData.AutoSize = true;
            this.ckbSaveData.Location = new System.Drawing.Point(36, 88);
            this.ckbSaveData.Name = "ckbSaveData";
            this.ckbSaveData.Size = new System.Drawing.Size(91, 20);
            this.ckbSaveData.TabIndex = 0;
            this.ckbSaveData.Text = "保存数据";
            this.ckbSaveData.UseVisualStyleBackColor = true;
            this.ckbSaveData.CheckedChanged += new System.EventHandler(this.ckbSaveData_CheckedChanged);
            // 
            // ckbSaveImageAll
            // 
            this.ckbSaveImageAll.AutoSize = true;
            this.ckbSaveImageAll.Location = new System.Drawing.Point(36, 36);
            this.ckbSaveImageAll.Name = "ckbSaveImageAll";
            this.ckbSaveImageAll.Size = new System.Drawing.Size(123, 20);
            this.ckbSaveImageAll.TabIndex = 0;
            this.ckbSaveImageAll.Text = "保存所有图像";
            this.ckbSaveImageAll.UseVisualStyleBackColor = true;
            this.ckbSaveImageAll.CheckedChanged += new System.EventHandler(this.ckbSaveImage_CheckedChanged);
            // 
            // ckbSaveImageNG
            // 
            this.ckbSaveImageNG.AutoSize = true;
            this.ckbSaveImageNG.Location = new System.Drawing.Point(36, 62);
            this.ckbSaveImageNG.Name = "ckbSaveImageNG";
            this.ckbSaveImageNG.Size = new System.Drawing.Size(107, 20);
            this.ckbSaveImageNG.TabIndex = 0;
            this.ckbSaveImageNG.Text = "保存NG图像";
            this.ckbSaveImageNG.UseVisualStyleBackColor = true;
            this.ckbSaveImageNG.CheckedChanged += new System.EventHandler(this.ckbSaveImageNG_CheckedChanged);
            // 
            // SystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 618);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpProductManage);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SystemConfigForm";
            this.Text = "SystemConfig";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SystemConfig_Load);
            this.grpProductManage.ResumeLayout(false);
            this.grpProductManage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProductManage;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Button btnSelectProduct;
        private System.Windows.Forms.Button btnDelProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ListBox lstProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbSaveLog;
        private System.Windows.Forms.CheckBox ckbSaveData;
        private System.Windows.Forms.CheckBox ckbSaveImageAll;
        private System.Windows.Forms.CheckBox ckbSaveImageNG;
    }
}