//#define JAI

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using GoCommon;
using GoVisonUI;

namespace GoVision
{
    public partial class AutoForm : Form
    {
        private Dictionary<RoundButton, Form> m_dicForm = new Dictionary<RoundButton, Form>();
        private Form m_currentForm = null;
        private RoundButton m_currentButton = null;
        public RoundButton m_lastButton = null;
        static public AutoForm _autoForm;
        public static LoginForm LF;

        static public int Runmode;

        /// <summary>
        /// 显示日志
        /// </summary>
        //public static Action<string> ShowLog;

        /// <summary>
        /// 系统参数，永久保存
        /// </summary>
        public SystemParam Param { get; private set; }

        public AutoForm()
        {
            InitializeComponent();
        }

        public void LoadParam()
        {
            string path = $@"{Environment.CurrentDirectory}\Product\SystemParam.xml";
            if (System.IO.File.Exists(path))
            {
                //反序列化文件到对象
                XmlSerializer xs = new XmlSerializer(typeof(SystemParam));
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);

                Param = (SystemParam)xs.Deserialize(fs);
                fs.Close();
            }
            else
            {
                Param = new SystemParam();
                Param.ProductName = "Demo";
                Param.IP = "127.0.0.1";
                Param.Port = 5000;
                Param.ManagerPassword = "123";
                Param.OperatorPassword = "1";
            }
        }

        public void SaveParam()
        {
            Param.ProductName = ProductMgr.GetInstance().ProductName;

            //序列化SystemParam类实例到文件
            XmlSerializer xs = new XmlSerializer(typeof(SystemParam));

            string path = $@"{Environment.CurrentDirectory}\Product\SystemParam.xml";
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);

            xs.Serialize(fs, Param);
            fs.Close();
        }

        public void SetServer(string ip, int port)
        {
            if (ip != Param.IP || port != Param.Port)
            {
                Param.IP = ip;
                Param.Port = port;
                TcpClientMgr.GetInstance().Close();
                ConnectServer();
            }
        }

        public void ConnectServer()
        {
            //连接到服务器
            labConnectState.Text = $@"{Param.IP}:{Param.Port}";
            Log.Show($@"连接服务器{Param.IP}:{Param.Port}");

            TcpClientMgr.GetInstance().m_SocketClient = new SocketClient(Param.IP, Param.Port);
            TcpClientMgr.GetInstance().m_SocketClient.RegisterConnetEvent(ConnectServer);
            TcpClientMgr.GetInstance().m_SocketClient.RegisterRecvEvent(ReceiveData);
            TcpClientMgr.GetInstance().Connection();
        }

        public void ConnectServer(string text, bool succeed)
        {
            if (succeed)
            {
                //连接成功，显示绿色
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Log.Show($@"连接成功");
                    labConnectState.BackColor = Color.Green;
                });
            }
            else
            {
                this?.BeginInvoke((MethodInvoker)delegate
                {
                    //断开连接，重新实例化Socket，再连接至服务器
                    if (labConnectState.BackColor == Color.Green)
                    {
                        Log.Show($@"连接断开");
                        ConnectServer();
                    }

                    //连接失败，显示红色
                    labConnectState.BackColor = Color.Red;
                });
            }
        }

        public void ReceiveData(string data)
        {
            //TODO 解析指令
            //string command = string.Empty;

            Receive.Parse(data);

            //string step = string.Empty;

            //VisionMgr.GetInstance().GetVisionBase(step).Process();

            //TODO 根据指令运行对应流程
            //switch (command)
            //{
            //    case "T1":
            //        VisionMgr.GetInstance().GetVisionBase(VisionStepName.ClickCarbon).Process();
            //        break;
            //    case "C1":
            //        VisionMgr.GetInstance().GetVisionBase(VisionStepName.ClickCarbonCalib).Process();
            //        break;
            //    case "T2":
            //        VisionMgr.GetInstance().GetVisionBase(VisionStepName.PickScreen).Process();
            //        break;
            //    case "C2":
            //        VisionMgr.GetInstance().GetVisionBase(VisionStepName.PickScreenCalib).Process();
            //        break;
            //    default:
            //        break;
            //}
        }

        public void SwitchWnd(RoundButton btn)
        {
            if (m_currentButton != btn)
            {
                if (null == m_currentButton)
                {
                    m_currentButton = RoundButton_Login;
                    m_currentButton.BaseColor = m_currentButton.BaseColorEnd = Color.FromArgb(160, 72, 160);
                }

                m_lastButton = m_currentButton;

                if (m_currentButton != null)
                {
                    m_currentButton.BaseColor = m_currentButton.BaseColorEnd = Color.MediumAquamarine;
                }

                m_currentButton = btn;

                m_currentButton.BaseColor = m_currentButton.BaseColorEnd = Color.FromArgb(160, 72, 160);

                if (m_currentForm != null)
                {
                    m_currentForm.Hide();
                }

                if (m_currentForm != m_dicForm[btn])
                {
                    m_currentForm = m_dicForm[btn];
                    m_currentForm.Show();
                }
            }
        }

        public void ChangeProduct(string name, string path)
        {
            //先切换产品管理类产品
            //ProductMgr.GetInstance().ChangeProduct(name);

            //后切换流程管理类产品
            VisionMgr.GetInstance().m_strConfigDir = path;
            VisionMgr.GetInstance().OnProductChanged();

            Text = $"RUIFEI VISION    {name}";

            Form fainForm;
            m_dicForm.TryGetValue(btnMainCamera, out fainForm);
            ((MainCameraForm)fainForm)?.ChangeProduct(name, path);
        }

        public bool ChangeUser(UserMode user, string password)
        {
            if (user == UserMode.Manager && password == Param.ManagerPassword)
            {
                m_dicForm[btnMainCamera].Enabled = true;
                m_dicForm[btnSideCamera].Enabled = true;
                m_dicForm[RoundButton_Communication].Enabled = true;
                m_dicForm[btnSystemConfig].Enabled = true;

                return true;
            }

            if (user == UserMode.Operator && password == Param.OperatorPassword)
            {
                m_dicForm[btnMainCamera].Enabled = false;
                m_dicForm[btnSideCamera].Enabled = false;
                m_dicForm[RoundButton_Communication].Enabled = false;
                m_dicForm[btnSystemConfig].Enabled = false;

                return true;
            }

            return false;
        }

        #region 事件

        private void AutoForm_Load(object sender, EventArgs e)
        {
            //btnSystemConfig.Enabled = false;
            btnSideCamera.Enabled = false;
            RoundButton_Communication.Enabled = false;
            btnImageFile.Enabled = false;
            BtnRun.Enabled = false;
            RoundButton_Login.Enabled = false;
            //BtnRun.BaseColorEnd = BtnRun.BaseColor = Color.FromArgb(230, 216, 216);

            //btnSystemConfig.BaseColor = Color.DarkGray;
            RoundButton_Communication.BaseColor = Color.DarkGray;
            btnImageFile.BaseColor = Color.DarkGray;
            BtnRun.BaseColor = Color.DarkGray;
            RoundButton_Login.BaseColor = Color.DarkGray;

            tlbVer.Alignment = ToolStripItemAlignment.Right;
            tlbVer.Text = $"V2.1：{System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location)}";

            _autoForm = this;

            //获取相机名称
            string fileName = $@"{System.Environment.CurrentDirectory}\Product\CameraName.ini";
            CameraName.MainCamera = IniTool.GetString(fileName, "CameraName", "MainCamera", "MainCam");
            CameraName.SideCamera = IniTool.GetString(fileName, "CameraName", "SideCamera", "HE012A1GM");

#if JAI
            //添加相机并绑定到窗口
            foreach (var cam in CameraJai.FindCamera())
            {
                if (cam.ModelName == CameraName.MainCamera || cam.ModelName == CameraName.SideCamera)
                {
                    VisionMgr.GetInstance().AddCamera(new CameraJai(cam.ModelName, cam));
                }
            }
#else
            //添加相机并绑定到窗口
            //VisionMgr.GetInstance().AddCamera(new CameraGige(CameraName.MainCamera));
            //VisionMgr.GetInstance().AddCamera(new CameraGige(CameraName.SideCamera));
            VisionMgr.GetInstance().AddCamera(new CameraMVision(CameraName.MainCamera));
            VisionMgr.GetInstance().AddCamera(new CameraMVision(CameraName.SideCamera));
#endif

            //添加视觉步骤
            VisionMgr.GetInstance().AddVisionStep(CameraName.MainCamera, new ProcessMainPos(VisionStepName.MainPos));
            VisionMgr.GetInstance().AddVisionStep(CameraName.MainCamera, new ProcessMainMea(VisionStepName.MainMea));
            VisionMgr.GetInstance().AddVisionStep(CameraName.SideCamera, new ProcessSideMea(VisionStepName.SideMea));

            //加载系统参数
            LoadParam();

            //切换产品
            ProductMgr.GetInstance().ProductChangedMethod += ChangeProduct;
            ProductMgr.GetInstance().ChangeProduct(Param.ProductName);

            //关联页面和按钮
            m_dicForm.Add(btnMainCamera, new MainCameraForm());
            //m_dicForm.Add(RoundButton_Login, new LoginForm());
            m_dicForm.Add(RoundButton_Communication, new CommunicationForm());
            m_dicForm.Add(btnSideCamera, new SideCameraForm());
            m_dicForm.Add(btnSystemConfig, new SystemConfigForm());

            //初始化页面属性
            foreach (KeyValuePair<RoundButton, Form> kp in m_dicForm)
            {
                kp.Value.TopLevel = false;
                kp.Value.Parent = this.panel_main;
                kp.Value.Dock = DockStyle.Fill;
            }

            btnMainCamera.PerformClick();

            //切换用户
            //((LoginForm)m_dicForm[RoundButton_Login]).UserChangingMethod = ChangeUser;
            //ChangeUser(UserMode.Operator, Param.OperatorPassword);

            //设置日志显示
            Log.Show = ((MainCameraForm)m_dicForm[btnMainCamera]).ShowLog;
            Data.Show = ((MainCameraForm)m_dicForm[btnMainCamera]).ShowData;

            //连接服务器
            ((SystemConfigForm)m_dicForm[btnSystemConfig]).SetServerMethod = SetServer;
            ConnectServer();
        }

        private void AutoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveParam();

            //获取相机名称
            string fileName = $@"{System.Environment.CurrentDirectory}\Product\CameraName.ini";
            IniTool.Set(fileName, "CameraName", "MainCamera", CameraName.MainCamera);
            IniTool.Set(fileName, "CameraName", "SideCamera", CameraName.SideCamera);

            foreach (var cam in VisionMgr.GetInstance().m_dicCamera.Values)
            {
                cam.Close();
            }
        }

        private void RoundButton_Main_Click(object sender, EventArgs e)
        {
            SwitchWnd(btnMainCamera);
        }

        private void RoundButton_Login_Click(object sender, EventArgs e)
        {
            SwitchWnd(RoundButton_Login);
        }

        private void RoundButton_Communication_Click(object sender, EventArgs e)
        {
            SwitchWnd(RoundButton_Communication);
        }

        //主入口
        private void BtnRun_Click(object sender, EventArgs e)
        {
            //GoRun.GetInstance().Run();
        }

        private void RoundButton_Camera_Click(object sender, EventArgs e)
        {
            SwitchWnd(btnSideCamera);
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            SwitchWnd(btnSystemConfig);
        }

        #endregion 事件
    }
}