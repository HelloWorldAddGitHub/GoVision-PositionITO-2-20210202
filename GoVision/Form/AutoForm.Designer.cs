namespace GoVision
{
    partial class AutoForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RoundButton_Login = new GoVisonUI.RoundButton();
            this.btnImageFile = new GoVisonUI.RoundButton();
            this.BtnRun = new GoVisonUI.RoundButton();
            this.btnSystemConfig = new GoVisonUI.RoundButton();
            this.btnSideCamera = new GoVisonUI.RoundButton();
            this.RoundButton_Communication = new GoVisonUI.RoundButton();
            this.btnMainCamera = new GoVisonUI.RoundButton();
            this.panel_main = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labConnectState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbVer = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btnMainCamera);
            this.panel1.Controls.Add(this.RoundButton_Login);
            this.panel1.Controls.Add(this.btnImageFile);
            this.panel1.Controls.Add(this.BtnRun);
            this.panel1.Controls.Add(this.btnSystemConfig);
            this.panel1.Controls.Add(this.btnSideCamera);
            this.panel1.Controls.Add(this.RoundButton_Communication);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 50);
            this.panel1.TabIndex = 0;
            // 
            // RoundButton_Login
            // 
            this.RoundButton_Login.BackColor = System.Drawing.Color.Transparent;
            this.RoundButton_Login.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.RoundButton_Login.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.RoundButton_Login.FlatAppearance.BorderSize = 0;
            this.RoundButton_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoundButton_Login.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoundButton_Login.ImageHeight = 80;
            this.RoundButton_Login.ImageWidth = 80;
            this.RoundButton_Login.Location = new System.Drawing.Point(882, 3);
            this.RoundButton_Login.Name = "RoundButton_Login";
            this.RoundButton_Login.Radius = 12;
            this.RoundButton_Login.Size = new System.Drawing.Size(120, 43);
            this.RoundButton_Login.SpliteButtonWidth = 18;
            this.RoundButton_Login.TabIndex = 0;
            this.RoundButton_Login.Text = "用户登录";
            this.RoundButton_Login.UseVisualStyleBackColor = false;
            this.RoundButton_Login.Click += new System.EventHandler(this.RoundButton_Login_Click);
            // 
            // btnImageFile
            // 
            this.btnImageFile.BackColor = System.Drawing.Color.Transparent;
            this.btnImageFile.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.btnImageFile.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.btnImageFile.FlatAppearance.BorderSize = 0;
            this.btnImageFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImageFile.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImageFile.ImageHeight = 80;
            this.btnImageFile.ImageWidth = 80;
            this.btnImageFile.Location = new System.Drawing.Point(736, 3);
            this.btnImageFile.Name = "btnImageFile";
            this.btnImageFile.Radius = 12;
            this.btnImageFile.Size = new System.Drawing.Size(120, 43);
            this.btnImageFile.SpliteButtonWidth = 18;
            this.btnImageFile.TabIndex = 0;
            this.btnImageFile.Text = "图像文件";
            this.btnImageFile.UseVisualStyleBackColor = false;
            // 
            // BtnRun
            // 
            this.BtnRun.BackColor = System.Drawing.Color.Transparent;
            this.BtnRun.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.BtnRun.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.BtnRun.FlatAppearance.BorderSize = 0;
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRun.ImageHeight = 80;
            this.BtnRun.ImageWidth = 80;
            this.BtnRun.Location = new System.Drawing.Point(590, 3);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Radius = 12;
            this.BtnRun.Size = new System.Drawing.Size(120, 43);
            this.BtnRun.SpliteButtonWidth = 18;
            this.BtnRun.TabIndex = 0;
            this.BtnRun.Text = "启动";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnSystemConfig.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.btnSystemConfig.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.btnSystemConfig.FlatAppearance.BorderSize = 0;
            this.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemConfig.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSystemConfig.ImageHeight = 80;
            this.btnSystemConfig.ImageWidth = 80;
            this.btnSystemConfig.Location = new System.Drawing.Point(298, 3);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Radius = 12;
            this.btnSystemConfig.Size = new System.Drawing.Size(120, 43);
            this.btnSystemConfig.SpliteButtonWidth = 18;
            this.btnSystemConfig.TabIndex = 0;
            this.btnSystemConfig.Text = "系统设置";
            this.btnSystemConfig.UseVisualStyleBackColor = false;
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // btnSideCamera
            // 
            this.btnSideCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnSideCamera.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.btnSideCamera.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.btnSideCamera.FlatAppearance.BorderSize = 0;
            this.btnSideCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideCamera.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSideCamera.ImageHeight = 80;
            this.btnSideCamera.ImageWidth = 80;
            this.btnSideCamera.Location = new System.Drawing.Point(152, 3);
            this.btnSideCamera.Name = "btnSideCamera";
            this.btnSideCamera.Radius = 12;
            this.btnSideCamera.Size = new System.Drawing.Size(120, 43);
            this.btnSideCamera.SpliteButtonWidth = 18;
            this.btnSideCamera.TabIndex = 0;
            this.btnSideCamera.Text = "侧相机";
            this.btnSideCamera.UseVisualStyleBackColor = false;
            this.btnSideCamera.Click += new System.EventHandler(this.RoundButton_Camera_Click);
            // 
            // RoundButton_Communication
            // 
            this.RoundButton_Communication.BackColor = System.Drawing.Color.Transparent;
            this.RoundButton_Communication.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.RoundButton_Communication.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.RoundButton_Communication.FlatAppearance.BorderSize = 0;
            this.RoundButton_Communication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoundButton_Communication.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoundButton_Communication.ImageHeight = 80;
            this.RoundButton_Communication.ImageWidth = 80;
            this.RoundButton_Communication.Location = new System.Drawing.Point(444, 3);
            this.RoundButton_Communication.Name = "RoundButton_Communication";
            this.RoundButton_Communication.Radius = 12;
            this.RoundButton_Communication.Size = new System.Drawing.Size(120, 43);
            this.RoundButton_Communication.SpliteButtonWidth = 18;
            this.RoundButton_Communication.TabIndex = 0;
            this.RoundButton_Communication.Text = "通讯设置";
            this.RoundButton_Communication.UseVisualStyleBackColor = false;
            this.RoundButton_Communication.Click += new System.EventHandler(this.RoundButton_Communication_Click);
            // 
            // btnMainCamera
            // 
            this.btnMainCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnMainCamera.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.btnMainCamera.BaseColorEnd = System.Drawing.Color.MediumAquamarine;
            this.btnMainCamera.FlatAppearance.BorderSize = 0;
            this.btnMainCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainCamera.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainCamera.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnMainCamera.ImageHeight = 80;
            this.btnMainCamera.ImageWidth = 80;
            this.btnMainCamera.Location = new System.Drawing.Point(3, 4);
            this.btnMainCamera.Name = "btnMainCamera";
            this.btnMainCamera.Radius = 12;
            this.btnMainCamera.Size = new System.Drawing.Size(120, 43);
            this.btnMainCamera.SpliteButtonWidth = 18;
            this.btnMainCamera.TabIndex = 0;
            this.btnMainCamera.Text = "主相机";
            this.btnMainCamera.UseVisualStyleBackColor = false;
            this.btnMainCamera.Click += new System.EventHandler(this.RoundButton_Main_Click);
            // 
            // panel_main
            // 
            this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_main.Location = new System.Drawing.Point(1, 58);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1007, 618);
            this.panel_main.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labConnectState,
            this.tlbVer});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labConnectState
            // 
            this.labConnectState.BackColor = System.Drawing.Color.Red;
            this.labConnectState.Name = "labConnectState";
            this.labConnectState.Size = new System.Drawing.Size(45, 17);
            this.labConnectState.Text = "0.0.0.0";
            // 
            // tlbVer
            // 
            this.tlbVer.Name = "tlbVer";
            this.tlbVer.Size = new System.Drawing.Size(68, 17);
            this.tlbVer.Text = "Ver:1.0.0.0";
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.MinimumSize = new System.Drawing.Size(1022, 673);
            this.Name = "AutoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GoVision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoForm_FormClosing);
            this.Load += new System.EventHandler(this.AutoForm_Load);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private GoVisonUI.RoundButton RoundButton_Login;
        private GoVisonUI.RoundButton btnImageFile;
        private GoVisonUI.RoundButton BtnRun;
        private GoVisonUI.RoundButton btnSystemConfig;
        private GoVisonUI.RoundButton btnSideCamera;
        private GoVisonUI.RoundButton RoundButton_Communication;
        private GoVisonUI.RoundButton btnMainCamera;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labConnectState;
        private System.Windows.Forms.ToolStripStatusLabel tlbVer;
    }
}

