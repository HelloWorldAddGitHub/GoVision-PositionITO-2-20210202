using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoVision
{
    public partial class LoginForm : Form
    {
        public Func<UserMode, string, bool> UserChangingMethod;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //AutoForm.LF = this;
            // BtnOperaMode.BackColor = Color.FromArgb(14, 86, 240);

            CobUser.Items.Add(UserMode.Operator);
            CobUser.Items.Add(UserMode.Manager);
            CobUser.SelectedIndex = 1;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //获取用户名和密码
            UserMode user = (UserMode)Enum.Parse(typeof(UserMode), CobUser.Text);
            string password = TebPassword.Text;

            TebPassword.Clear();

            if (UserChangingMethod != null)
            {
                //切换用户，返回切换后的用户
                bool result = UserChangingMethod(user, password);
                if (result)
                {
                    if (user == UserMode.Manager)
                    {
                        BtnManaMode.BaseColor = BtnManaMode.BaseColorEnd = Color.FromArgb(4, 86, 240);
                        BtnOperaMode.BaseColor = BtnManaMode.BaseColorEnd = Color.Transparent;
                    }
                    else
                    {
                        BtnManaMode.BaseColor = BtnManaMode.BaseColorEnd = Color.Transparent;
                        BtnOperaMode.BaseColor = BtnManaMode.BaseColorEnd = Color.FromArgb(4, 86, 240);
                    }
                }
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            AutoForm._autoForm.SwitchWnd(AutoForm._autoForm.m_lastButton);
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                TebPassword.Focus();
            }
        }

        private void CobUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            TebPassword.Focus();
        }
    }
}