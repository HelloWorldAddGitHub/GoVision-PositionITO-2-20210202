namespace GoVision
{
    partial class CommunicationForm
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
            this.SelectBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.StopBits_comboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Parity_comboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DataBits_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BaudRate_comboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.com_comboBox = new System.Windows.Forms.ComboBox();
            this.BtnOpen = new GoVisonUI.RoundButton();
            this.BtnClose = new GoVisonUI.RoundButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RecvTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new GoVisonUI.RoundButton();
            this.roundButton4 = new GoVisonUI.RoundButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SelectBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectBox
            // 
            this.SelectBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectBox.Controls.Add(this.radioButton2);
            this.SelectBox.Controls.Add(this.radioButton1);
            this.SelectBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectBox.Location = new System.Drawing.Point(12, 12);
            this.SelectBox.Name = "SelectBox";
            this.SelectBox.Size = new System.Drawing.Size(121, 85);
            this.SelectBox.TabIndex = 0;
            this.SelectBox.TabStop = false;
            this.SelectBox.Text = "通讯选择";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "串口通讯";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "网口通讯";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 363);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "网口配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(-4, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 204);
            this.panel1.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(83, 87);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(106, 23);
            this.textBox4.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(83, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(106, 23);
            this.textBox3.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "客户端",
            "服务端"});
            this.comboBox1.Location = new System.Drawing.Point(83, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 25);
            this.comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "终端选择：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.StopBits_comboBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.Parity_comboBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.DataBits_comboBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.BaudRate_comboBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.com_comboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 333);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "串口配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(-4, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 140);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "串口号：";
            // 
            // StopBits_comboBox
            // 
            this.StopBits_comboBox.FormattingEnabled = true;
            this.StopBits_comboBox.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.StopBits_comboBox.Location = new System.Drawing.Point(77, 157);
            this.StopBits_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.StopBits_comboBox.Name = "StopBits_comboBox";
            this.StopBits_comboBox.Size = new System.Drawing.Size(92, 25);
            this.StopBits_comboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "波特率：";
            // 
            // Parity_comboBox
            // 
            this.Parity_comboBox.FormattingEnabled = true;
            this.Parity_comboBox.Items.AddRange(new object[] {
            "none",
            "奇校验",
            "偶校验"});
            this.Parity_comboBox.Location = new System.Drawing.Point(77, 118);
            this.Parity_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.Parity_comboBox.Name = "Parity_comboBox";
            this.Parity_comboBox.Size = new System.Drawing.Size(92, 25);
            this.Parity_comboBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "数据位：";
            // 
            // DataBits_comboBox
            // 
            this.DataBits_comboBox.FormattingEnabled = true;
            this.DataBits_comboBox.Items.AddRange(new object[] {
            "8",
            "7"});
            this.DataBits_comboBox.Location = new System.Drawing.Point(77, 80);
            this.DataBits_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.DataBits_comboBox.Name = "DataBits_comboBox";
            this.DataBits_comboBox.Size = new System.Drawing.Size(92, 25);
            this.DataBits_comboBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "校验位：";
            // 
            // BaudRate_comboBox
            // 
            this.BaudRate_comboBox.FormattingEnabled = true;
            this.BaudRate_comboBox.Items.AddRange(new object[] {
            "2400",
            "9600"});
            this.BaudRate_comboBox.Location = new System.Drawing.Point(77, 46);
            this.BaudRate_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BaudRate_comboBox.Name = "BaudRate_comboBox";
            this.BaudRate_comboBox.Size = new System.Drawing.Size(92, 25);
            this.BaudRate_comboBox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 157);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "停止位：";
            // 
            // com_comboBox
            // 
            this.com_comboBox.FormattingEnabled = true;
            this.com_comboBox.Location = new System.Drawing.Point(77, 12);
            this.com_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.com_comboBox.Name = "com_comboBox";
            this.com_comboBox.Size = new System.Drawing.Size(92, 25);
            this.com_comboBox.TabIndex = 11;
            // 
            // BtnOpen
            // 
            this.BtnOpen.BackColor = System.Drawing.Color.Transparent;
            this.BtnOpen.BaseColor = System.Drawing.SystemColors.Info;
            this.BtnOpen.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.BtnOpen.FlatAppearance.BorderSize = 0;
            this.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOpen.ImageHeight = 80;
            this.BtnOpen.ImageWidth = 80;
            this.BtnOpen.Location = new System.Drawing.Point(137, 12);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Radius = 8;
            this.BtnOpen.Size = new System.Drawing.Size(75, 32);
            this.BtnOpen.SpliteButtonWidth = 18;
            this.BtnOpen.TabIndex = 2;
            this.BtnOpen.Text = "打开";
            this.BtnOpen.UseVisualStyleBackColor = false;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.BaseColor = System.Drawing.SystemColors.Info;
            this.BtnClose.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnClose.ImageHeight = 80;
            this.BtnClose.ImageWidth = 80;
            this.BtnClose.Location = new System.Drawing.Point(137, 57);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Radius = 8;
            this.BtnClose.Size = new System.Drawing.Size(75, 32);
            this.BtnClose.SpliteButtonWidth = 18;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RecvTextBox);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(251, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 272);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息接收";
            // 
            // RecvTextBox
            // 
            this.RecvTextBox.Location = new System.Drawing.Point(6, 22);
            this.RecvTextBox.Multiline = true;
            this.RecvTextBox.Name = "RecvTextBox";
            this.RecvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecvTextBox.Size = new System.Drawing.Size(553, 244);
            this.RecvTextBox.TabIndex = 0;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.Transparent;
            this.SendButton.BaseColor = System.Drawing.Color.LightYellow;
            this.SendButton.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.SendButton.FlatAppearance.BorderSize = 0;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendButton.ImageHeight = 80;
            this.SendButton.ImageWidth = 80;
            this.SendButton.Location = new System.Drawing.Point(735, 472);
            this.SendButton.Name = "SendButton";
            this.SendButton.Radius = 8;
            this.SendButton.Size = new System.Drawing.Size(75, 33);
            this.SendButton.SpliteButtonWidth = 18;
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "发送";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // roundButton4
            // 
            this.roundButton4.BackColor = System.Drawing.Color.Transparent;
            this.roundButton4.BaseColor = System.Drawing.Color.LightYellow;
            this.roundButton4.BaseColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.roundButton4.FlatAppearance.BorderSize = 0;
            this.roundButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundButton4.ImageHeight = 80;
            this.roundButton4.ImageWidth = 80;
            this.roundButton4.Location = new System.Drawing.Point(735, 300);
            this.roundButton4.Name = "roundButton4";
            this.roundButton4.Radius = 8;
            this.roundButton4.Size = new System.Drawing.Size(75, 33);
            this.roundButton4.SpliteButtonWidth = 18;
            this.roundButton4.TabIndex = 4;
            this.roundButton4.Text = "清空";
            this.roundButton4.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(676, 317);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(41, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hex";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(602, 317);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Byte";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(251, 339);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 127);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "信息发送";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 22);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(553, 99);
            this.textBox2.TabIndex = 0;
            // 
            // CommunicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.roundButton4);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SelectBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommunicationForm";
            this.Text = "CommunicationForm";
            this.Load += new System.EventHandler(this.CommunicationForm_Load);
            this.SelectBox.ResumeLayout(false);
            this.SelectBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SelectBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GoVisonUI.RoundButton BtnOpen;
        private GoVisonUI.RoundButton BtnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RecvTextBox;
        private GoVisonUI.RoundButton SendButton;
        private GoVisonUI.RoundButton roundButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox StopBits_comboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Parity_comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox DataBits_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox BaudRate_comboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox com_comboBox;
    }
}