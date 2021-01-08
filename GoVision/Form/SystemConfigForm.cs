using System;
using System.Windows.Forms;

namespace GoVision
{
    public partial class SystemConfigForm : Form
    {
        public Action<string, int> SetServerMethod;

        public SystemConfigForm()
        {
            InitializeComponent();
        }

        private void SystemConfig_Load(object sender, EventArgs e)
        {
            ShowProductAll();

            txtAddr.Text = TcpClientMgr.GetInstance().m_SocketClient.IP;
            txtPort.Text = TcpClientMgr.GetInstance().m_SocketClient.Port.ToString();

            ckbSaveImageAll.Checked = AutoForm._autoForm.Param.IsSaveImageAll;
            ckbSaveImageNG.Checked = AutoForm._autoForm.Param.IsSaveImageNG;
            ckbSaveData.Checked = AutoForm._autoForm.Param.IsSaveData;
            ckbSaveLog.Checked = AutoForm._autoForm.Param.IsSaveLog;
        }

        private void ShowProductAll()
        {
            string[] productCollection = ProductMgr.GetInstance().GetProductList();
            lstProduct.Items.Clear();
            lstProduct.Items.AddRange(productCollection);
            lstProduct.SelectedIndex = 0;

            grpProductManage.Text = $@"当前产品-{ProductMgr.GetInstance().ProductName}";

            

           
         

        }

        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            bool result = ProductMgr.GetInstance().ChangeProduct(txtProduct.Text);
            if (!result)
            {
                MessageBox.Show($"没有{txtProduct.Text}产品");
            }
            else
            {
                grpProductManage.Text = $@"当前产品-{ProductMgr.GetInstance().ProductName}";
               
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool result = ProductMgr.GetInstance().Add(txtProduct.Text);
            if (!result)
            {
                MessageBox.Show($"产品{txtProduct.Text}已存在");
            }
            else
            {
                ShowProductAll();
            }
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            if (lstProduct.Items.Count <= 1)
            {
                MessageBox.Show($"至少需要保留一个产品");
                return;
            }

            if (txtProduct.Text == ProductMgr.GetInstance().ProductName)
            {
                MessageBox.Show($"{txtProduct.Text}是当前产品，不能删除");
                return;
            }

            DialogResult result = MessageBox.Show($"确认删除{txtProduct.Text}产品？", "删除产品", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                ProductMgr.GetInstance().Delete(txtProduct.Text);
                ShowProductAll();
            }
        }

        private void lstProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            txtProduct.Text = lstProduct.SelectedItem.ToString();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtAddr.Text.Trim();
            int port = int.Parse(txtPort.Text.Trim());
            SetServerMethod?.Invoke(ip, port);
        }

        private void ckbSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            AutoForm._autoForm.Param.IsSaveImageAll = ckbSaveImageAll.Checked;
        }

        private void ckbSaveImageNG_CheckedChanged(object sender, EventArgs e)
        {
            AutoForm._autoForm.Param.IsSaveImageNG = ckbSaveImageNG.Checked;
        }

        private void ckbSaveData_CheckedChanged(object sender, EventArgs e)
        {
            AutoForm._autoForm.Param.IsSaveData = ckbSaveData.Checked;
        }

        private void ckbSaveLog_CheckedChanged(object sender, EventArgs e)
        {
            AutoForm._autoForm.Param.IsSaveLog = ckbSaveLog.Checked;
        }


    }
}