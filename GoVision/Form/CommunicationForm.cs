using System;
using System.Windows.Forms;

namespace GoVision
{
    public partial class CommunicationForm : Form
    {
        public CommunicationForm()
        {
            InitializeComponent();
        }

        private void CommunicationForm_Load(object sender, EventArgs e)
        {
        }

        private void test(string code)
        {
            string text = code + "\n\n";
            string a = RecvTextBox.Text;
            if (RecvTextBox.InvokeRequired)
            {//c#中禁止跨线程直接访问控件，InvokeRequired是为了解决这个问题而产生的,用一个异步执行委托
                RecvTextBox.BeginInvoke(new MethodInvoker(delegate
                {
                    RecvTextBox.AppendText(text);
                }));
            }
            else
                RecvTextBox.AppendText(text);
        }

        private void test1(string code, bool flag)
        {
            string text = code + "\n\n";
            string a = RecvTextBox.Text;
            if (RecvTextBox.InvokeRequired)
            {//c#中禁止跨线程直接访问控件，InvokeRequired是为了解决这个问题而产生的,用一个异步执行委托
                RecvTextBox.BeginInvoke(new MethodInvoker(delegate
                {
                    RecvTextBox.AppendText(text);
                }));
            }
            else
                RecvTextBox.AppendText(text);
            if (!flag)
                TcpClientMgr.GetInstance().Close();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            TcpClientMgr.GetInstance().m_SocketClient.DelRecvEvent(new SocketClient.RecvEvent(test));
            TcpClientMgr.GetInstance().m_SocketClient.RegisterRecvEvent(new SocketClient.RecvEvent(test));

            TcpClientMgr.GetInstance().m_SocketClient.DelConnetEvent(new SocketClient.ConnetEvent(test1));
            TcpClientMgr.GetInstance().m_SocketClient.RegisterConnetEvent(new SocketClient.ConnetEvent(test1));
            TcpClientMgr.GetInstance().Connection();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            TcpClientMgr.GetInstance().Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
        }
    }
}