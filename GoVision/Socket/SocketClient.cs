using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GoVision
{
    /// <summary>
    /// 网络客户端类
    /// </summary>
    public class SocketClient
    {
        public delegate void ConnetEvent(string str, bool flag);

        public delegate void RecvEvent(string str);

        private IPEndPoint _ipSever;
        private Socket _conmunicationSocket;
        public TcpClient _clientSocket;
        private int _clientPort;
        private string _ip;
        private int _iport;
        private Thread _connectThread;
        private Thread _recvThread;

        public string IP { get { return _ip; } }
        public int Port { get { return _iport; } }

        private event ConnetEvent _ConnetEvent = null;

        private event RecvEvent _RecvEvent = null;

        private bool m_bRun = false; //接收线程的状态

        public SocketClient(string ip, int iport)
        {
            /*string strip1 = ip.Substring(0, ip.IndexOf("."));
            string stripl1 = ip.Substring(ip.IndexOf(".") + 1);

            string strip2 = stripl1.Substring(0, stripl1.IndexOf("."));
            string stripl2 = stripl1.Substring(stripl1.IndexOf(".") + 1);

            string strip3 = stripl2.Substring(0, stripl2.IndexOf("."));
            string stripl3 = stripl2.Substring(stripl2.IndexOf(".") + 1);

            string strip4 = stripl3;
            byte[] ipbyte = { Convert.ToByte(strip1), Convert.ToByte(strip2), Convert.ToByte(strip3), Convert.ToByte(strip4) };
            IPAddress SeverIP = new IPAddress(ipbyte);*/
            _ip = ip;
            _iport = iport;
            //_ipSever = new IPEndPoint(SeverIP, iport);
            //_conmunicationSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            /*_clientPort = 25700;
            _ipSever = new IPEndPoint(IPAddress.Parse(_ip), _clientPort);
            if (_clientSocket == null)
                _clientSocket = new TcpClient(_ipSever);*/

            _clientSocket = new TcpClient();
            _ipSever = new IPEndPoint(IPAddress.Parse(_ip), _iport);
        }

        public SocketClient(string ip, int Sport, int Cport)
        {
            _ip = ip;
            _iport = Sport;
            _clientPort = Cport;
            _ipSever = new IPEndPoint(IPAddress.Parse(_ip), _clientPort);
            if (_clientSocket == null)
                _clientSocket = new TcpClient(_ipSever);
        }

        public void RegisterRecvEvent(RecvEvent e)
        {
            _RecvEvent += e;
        }

        public void DelRecvEvent(RecvEvent e)
        {
            _RecvEvent -= e;
        }

        public void RegisterConnetEvent(ConnetEvent e)
        {
            _ConnetEvent += e;
        }

        public void DelConnetEvent(ConnetEvent e)
        {
            _ConnetEvent -= e;
        }

        private void SocketConnectThread()
        {
            //if (!_conmunicationSocket.Connected)
            //    _conmunicationSocket.Connect(_ipSever);

            while (!IsOnline())
            {
                try
                {
                    _clientSocket.Connect(_ip, _iport);
                }
                catch
                {
                    //_ConnetEvent("连接失败", true);//连接失败应该是false
                    _ConnetEvent?.Invoke("连接失败", false);
                    Thread.Sleep(2000);
                }
            }

            if (_recvThread == null)
            {
                _recvThread = new Thread(SocketRecvThread);
                _recvThread.IsBackground = true;
                m_bRun = true;
                _recvThread.Start();
            }

            _ConnetEvent("连接成功", true);
        }

        private void SocketRecvThread()
        {
            int n = 0;
            while (true)
            {
                try
                {
                    //if (_conmunicationSocket.Connected)
                    if (_clientSocket.Connected && m_bRun == true)
                    {
                        byte[] recvbyte = RecvData(ref n);
                        if (n <= 0)
                        {
                            //服务器掉线
                            if (m_bRun == true)
                            {
                                _ConnetEvent("服务器已掉线", false);
                                return;
                            }
                        }
                        string str = Encoding.Default.GetString(recvbyte, 0, n);
                        //string str = Encoding.UTF8.GetString(recvbyte, 0, n);
                        //if (_RecvEvent != null && _conmunicationSocket.Connected)
                        if (_RecvEvent != null && _clientSocket.Connected)
                        {
                            _RecvEvent(str);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch
                {
                }
            }
        }

        public void Connection()
        {
            if (_connectThread == null)
            {
                _connectThread = new Thread(SocketConnectThread);
                _connectThread.IsBackground = true;
            }

            if (!_connectThread.IsAlive)
            {
                _connectThread.Start();
            }
        }

        public byte[] RecvData(ref int r)
        {
            try
            {
                byte[] recvDataByte = new byte[1024 * 1024 * 5];
                //if (_conmunicationSocket.Connected)
                if (IsOnline())
                {
                    //int r = _conmunicationSocket.Receive(recvDataByte);
                    r = _clientSocket.Client.Receive(recvDataByte);
                    //if (r == 0)
                    if (r <= 0)
                    {
                        // recvDataByte.SetValue(0, 0);
                        return recvDataByte;
                    }
                    else
                        return recvDataByte;
                }
                else
                {
                    //recvDataByte.SetValue(1, 0);
                    return recvDataByte;
                }
            }
            catch
            {
                byte[] recvDataByte = new byte[1024 * 1024 * 5];
                //recvDataByte.SetValue(2, 0);
                return recvDataByte;
            }
        }

        public void SendData(string str)
        {
            try
            {
                //if (_conmunicationSocket.Connected)
                if (IsOnline())
                {
                    //str = str + "\r\n";
                    byte[] sendbyte = System.Text.Encoding.Default.GetBytes(str);
                    //_conmunicationSocket.Send(sendbyte);
                    _clientSocket.Client.Send(sendbyte);
                }
            }
            catch
            { }
        }

        public void Close()
        {
            //关闭接收线程
            m_bRun = false;

            _connectThread?.Abort();

            if (_recvThread != null)
            {
                if (_recvThread.Join(2000) == false)
                {
                    _clientSocket.Close();
                    _clientSocket = null;
                    _recvThread.Abort();
                }

                _recvThread = null;
            }
        }

        public bool IsOnline()
        {
            return !((_clientSocket.Client.Poll(1000, SelectMode.SelectRead) && (_clientSocket.Client.Available == 0)) || !_clientSocket.Client.Connected);
        }
    }
}