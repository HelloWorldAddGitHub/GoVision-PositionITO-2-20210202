namespace GoVision
{
    partial class LoginForm
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
            this.BtnLogin = new GoVisonUI.RoundButton();
            this.CobUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TebPassword = new System.Windows.Forms.TextBox();
            this.BtnReturn = new GoVisonUI.RoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOperaMode = new GoVisonUI.RoundButton();
            this.BtnManaMode = new GoVisonUI.RoundButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnLogin.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLogin.ImageHeight = 80;
            this.BtnLogin.ImageWidth = 80;
            this.BtnLogin.Location = new System.Drawing.Point(50, 176);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Radius = 24;
            this.BtnLogin.Size = new System.Drawing.Size(119, 43);
            this.BtnLogin.SpliteButtonWidth = 18;
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // CobUser
            // 
            this.CobUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CobUser.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CobUser.FormattingEnabled = true;
            this.CobUser.Location = new System.Drawing.Point(111, 37);
            this.CobUser.Margin = new System.Windows.Forms.Padding(4);
            this.CobUser.Name = "CobUser";
            this.CobUser.Size = new System.Drawing.Size(239, 39);
            this.CobUser.TabIndex = 1;
            this.CobUser.SelectedIndexChanged += new System.EventHandler(this.CobUser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户：";
            // 
            // TebPassword
            // 
            this.TebPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TebPassword.Location = new System.Drawing.Point(111, 102);
            this.TebPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TebPassword.Name = "TebPassword";
            this.TebPassword.PasswordChar = '*';
            this.TebPassword.Size = new System.Drawing.Size(239, 39);
            this.TebPassword.TabIndex = 3;
            // 
            // BtnReturn
            // 
            this.BtnReturn.BackColor = System.Drawing.Color.Transparent;
            this.BtnReturn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnReturn.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnReturn.FlatAppearance.BorderSize = 0;
            this.BtnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReturn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReturn.ImageHeight = 80;
            this.BtnReturn.ImageWidth = 80;
            this.BtnReturn.Location = new System.Drawing.Point(231, 176);
            this.BtnReturn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Radius = 24;
            this.BtnReturn.Size = new System.Drawing.Size(119, 43);
            this.BtnReturn.SpliteButtonWidth = 18;
            this.BtnReturn.TabIndex = 0;
            this.BtnReturn.Text = "返回";
            this.BtnReturn.UseVisualStyleBackColor = false;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(47, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // BtnOperaMode
            // 
            this.BtnOperaMode.BackColor = System.Drawing.Color.Transparent;
            this.BtnOperaMode.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(86)))), ((int)(((byte)(240)))));
            this.BtnOperaMode.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(86)))), ((int)(((byte)(240)))));
            this.BtnOperaMode.Enabled = false;
            this.BtnOperaMode.FlatAppearance.BorderSize = 0;
            this.BtnOperaMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOperaMode.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOperaMode.ImageHeight = 80;
            this.BtnOperaMode.ImageWidth = 80;
            this.BtnOperaMode.Location = new System.Drawing.Point(50, 253);
            this.BtnOperaMode.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOperaMode.Name = "BtnOperaMode";
            this.BtnOperaMode.Radius = 12;
            this.BtnOperaMode.Size = new System.Drawing.Size(300, 100);
            this.BtnOperaMode.SpliteButtonWidth = 18;
            this.BtnOperaMode.TabIndex = 4;
            this.BtnOperaMode.Text = "Operator Mode";
            this.BtnOperaMode.UseVisualStyleBackColor = false;
            // 
            // BtnManaMode
            // 
            this.BtnManaMode.BackColor = System.Drawing.Color.Transparent;
            this.BtnManaMode.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.BtnManaMode.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.BtnManaMode.Enabled = false;
            this.BtnManaMode.FlatAppearance.BorderSize = 0;
            this.BtnManaMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnManaMode.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManaMode.ImageHeight = 80;
            this.BtnManaMode.ImageWidth = 80;
            this.BtnManaMode.Location = new System.Drawing.Point(50, 367);
            this.BtnManaMode.Margin = new System.Windows.Forms.Padding(4);
            this.BtnManaMode.Name = "BtnManaMode";
            this.BtnManaMode.Radius = 12;
            this.BtnManaMode.Size = new System.Drawing.Size(300, 100);
            this.BtnManaMode.SpliteButtonWidth = 18;
            this.BtnManaMode.TabIndex = 4;
            this.BtnManaMode.Text = "Manager Mode";
            this.BtnManaMode.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.CobUser);
            this.groupBox1.Controls.Add(this.BtnManaMode);
            this.groupBox1.Controls.Add(this.BtnLogin);
            this.groupBox1.Controls.Add(this.BtnOperaMode);
            this.groupBox1.Controls.Add(this.BtnReturn);
            this.groupBox1.Controls.Add(this.TebPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(595, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 500);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnReturn;
            this.ClientSize = new System.Drawing.Size(1007, 618);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.VisibleChanged += new System.EventHandler(this.LoginForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GoVisonUI.RoundButton BtnLogin;
        private System.Windows.Forms.ComboBox CobUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TebPassword;
        private GoVisonUI.RoundButton BtnReturn;
        private System.Windows.Forms.Label label2;
        private GoVisonUI.RoundButton BtnOperaMode;
        private GoVisonUI.RoundButton BtnManaMode;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}