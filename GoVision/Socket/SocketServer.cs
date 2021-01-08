using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoVision
{
    /// <summary>
    /// 网络服务器类
    /// </summary>
    internal class SocketServer
    {
        public delegate void ConnetEvnt(string paran);

        public delegate void RevStrShow(string strShow);

        private Socket _SocketWatch;
        private IPAddress _Ip;
        private int _Iport;
        private IPEndPoint _PortIp;
        private Thread _Thrad = null;
        private Thread _ThreadRev = null;
        private Dictionary<string, Socket> _dicSocet = new Dictionary<string, Socket>();

        public event ConnetEvnt _ConnetEvent = null;

        public event RevStrShow _RevStrShowEvent = null;

        public Mutex _mutexDicSocet = new Mutex();

        /// <summary>
        /// 获取服务器IP和端口
        /// </summary>
        /// <returns></returns>
        public void GetServerIPort(out string Ip, out int Iport)
        {
            Ip = _Ip.ToString();
            Iport = _Iport;
        }

        /// <summary>
        /// 获取已连接客户端列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetConnetList()
        {
            List<string> ConnetList = new List<string>();
            _mutexDicSocet.WaitOne();
            foreach (var item in _dicSocet)
            {
                ConnetList.Add(item.Key);
            }
            _mutexDicSocet.ReleaseMutex();

            return ConnetList;
        }

        /// <summary>
        /// 通过指定客户端IP从已连接的客户端列表中取出对应的端口,返回-1表示没找到
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int GetPortByIP(string ip)
        {
            string strIport, strPort = null;
            int nPos = -1;
            _mutexDicSocet.WaitOne();
            foreach (var item in _dicSocet)
            {
                strIport = item.Key;
                nPos = strIport.IndexOf(":");
                if (nPos != -1 && ip == strIport.Substring(0, nPos))
                {
                    strPort = strIport.Substring(nPos + 1);
                    break;
                }
            }
            _mutexDicSocet.ReleaseMutex();

            int nPort = (strPort != null) ? Convert.ToInt32(strPort) : -1;
            return nPort;
        }

        /// <summary>
        /// 服务器端构造函数，创建本地的一个用来监控端口的Socket
        /// </summary>
        /// <param name="iport"></param>
        /// <param name="sender"></param>
        public SocketServer(int iport, object sender)
        {
            try
            {
                //服务器端，创建一个用来监控端口socket
                _SocketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _Ip = IPAddress.Any;//服务器的IP地址
                _Iport = iport;//服务器的端口
                _PortIp = new IPEndPoint(_Ip, _Iport);//创建IP-端口对象。
                BindSeverSocket();
                ListenSeverSocket(sender);
            }
            catch (Exception ep)
            {
                System.Diagnostics.Debug.WriteLine(ep.ToString());
                System.Windows.Forms.MessageBox.Show(ep.ToString());
            }
        }

        /// <summary>
        /// 绑定服务器监控端口socket
        /// </summary>
        public bool CreateSever(object sender, SocketServer server = null)
        {
            try
            {
                if (null == server)
                {
                    if (null == TcpServerMgr.GetInstance().m_SocketServer)
                    {
                        TcpServerMgr.GetInstance().m_SocketServer = new SocketServer(5000, sender);
                    }
                }
                else
                {
                    server = new SocketServer(5000, sender);
                }

                return true;
            }
            catch (Exception ep)
            {
                System.Diagnostics.Debug.WriteLine(ep.ToString());
                System.Windows.Forms.MessageBox.Show(ep.ToString());
                return false;
            }
        }

        /// <summary>
        /// 绑定服务器监控端口socket
        /// </summary>
        public void BindSeverSocket()
        {
            try
            {
                _SocketWatch.Bind(_PortIp);
            }
            catch (Exception ep)
            {
                System.Diagnostics.Debug.WriteLine(ep.ToString());
                System.Windows.Forms.MessageBox.Show(ep.ToString());
            }
        }

        /// <summary>
        /// 创建客户端连接监听线程
        /// </summary>
        /// <param name="sender"></param>
        public void ListenSeverSocket(object sender)
        {
            try
            {
                _SocketWatch.Listen(20);//这个socket 开始监听 最大10 对访问对象
                _Thrad = new Thread(AccpetThread);
                _Thrad.IsBackground = true;//线程是分前台线程 后台线程，程序关闭后台线程自动关闭，前台程序关闭程序才推出。
                _Thrad.Start(sender);
            }
            catch (Exception ep)
            {
                System.Diagnostics.Debug.WriteLine(ep.ToString());
                System.Windows.Forms.MessageBox.Show(ep.ToString());
            }
        }

        /// <summary>
        /// 服务器端向指定客户端发送数据
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="iport"></param>
        /// <param name="strText"></param>
        public void Send(string strClientIp, int nClientIport, string strText)
        {
            try
            {
                Socket socketsend;
                string ipport = strClientIp + ":" + nClientIport.ToString();
                _mutexDicSocet.WaitOne();
                socketsend = _dicSocet[ipport];
                if (socketsend != null)
                {
                    byte[] sendbuffer = Encoding.Default.GetBytes(strText);
                    socketsend.Send(sendbuffer);
                }
                _mutexDicSocet.ReleaseMutex();
            }
            catch (Exception ep)
            {
                System.Diagnostics.Debug.WriteLine(ep.ToString());
                System.Windows.Forms.MessageBox.Show(ep.ToString());
            }
        }

        /// <summary>
        /// 服务器端监听客户端发送数据的线程函数
        /// </summary>
        /// <param name="sender"></param>
        public void ReciveFromClint(Socket _SocketCominnication)
        {
            // Form1 a = sender as Form1;
            byte[] bufferRecv = new byte[1024];
            byte[] bufferSend = new byte[1024];
            int rNum = 0;
            string strRev;
            while (true)
            {
                try
                {
                    rNum = 0;
                    while (true)
                    {
                        int nRtn = _SocketCominnication.Receive(bufferRecv, rNum, 1, 0);
                        if (0 == nRtn)
                        {//断连后抛出异常，并从客户列表删除该客户端
                            throw new Exception("链接断开");
                        }
                        if ('\r' == bufferRecv[rNum] || '\n' == bufferRecv[rNum])
                        {
                            if (0 == rNum)
                            {
                                continue;
                            }
                            bufferRecv[rNum] = 0;
                            break;
                        }
                        rNum++;
                    }

                    strRev = Encoding.Default.GetString(bufferRecv, 0, rNum);
                    _RevStrShowEvent.Invoke(strRev);
                    //System.Diagnostics.Debug.WriteLine(strRev);

                    string strIport = _SocketCominnication.RemoteEndPoint.ToString();
                    int nPos = strIport.IndexOf(":");
                    if (-1 == nPos)
                    {
                        break;
                    }
                    string strIp = Convert.ToString(strIport.Substring(0, nPos));
                    int nPort = Convert.ToInt32(strIport.Substring(nPos + 1));
                    string strOptCmd = null;
                    string strRevCmd = null;
                    string strRevRst = null;
                    nPos = strRev.IndexOf(",");
                    if (-1 != nPos)
                    {
                        strOptCmd = strRev.Substring(0, nPos);
                        strRev = strRev.Substring(nPos + 1);
                        nPos = strRev.IndexOf(",");
                        if (-1 != nPos)
                        {
                            strRevCmd = strRev.Substring(0, nPos);
                            strRev = strRev.Substring(nPos + 1);
                            nPos = strRev.IndexOf(",");
                            //if (-1 != nPos)
                            //{
                            //    strRevRst = strRev.Substring(nPos + 1);
                            //}
                            //else
                            {
                                strRevRst = strRev;
                            }
                        }
                        else
                        {
                            strRevCmd = strRev;
                        }

                        if ("R" == strOptCmd)
                        {
                            TcpServerMgr.GetInstance().m_mutexTcpWrite.WaitOne();
                            bool bEnableSend = false;
                            int nIndex = TcpServerMgr.GetInstance().m_strServerReqCmd.IndexOf(strRevCmd);
                            if (nIndex != -1)
                            {
                                string strRst = TcpServerMgr.GetInstance().m_dicServerReqCmdBuf[strIport][nIndex];
                                bufferSend = Encoding.Default.GetBytes(strRst + "\n");
                                bEnableSend = true;
                            }
                            else
                            {
                                nIndex = TcpServerMgr.GetInstance().m_strClientReqCmd.IndexOf(strRevCmd);
                                if (nIndex != -1)
                                {
                                    string strRst = TcpServerMgr.GetInstance().m_dicClientAnsCmdBuf[strIport][nIndex];
                                    bufferSend = Encoding.Default.GetBytes(strRst + "\n");
                                    bEnableSend = true;
                                }
                            }
                            TcpServerMgr.GetInstance().m_mutexTcpWrite.ReleaseMutex();

                            if (bEnableSend)
                            {
                                _SocketCominnication.Send(bufferSend);
                            }
                        }
                        else if ("W" == strOptCmd)
                        {
                            TcpServerMgr.GetInstance().m_mutexTcpWrite.WaitOne();
                            int nIndex = TcpServerMgr.GetInstance().m_strServerReqCmd.IndexOf(strRevCmd);
                            if (nIndex != -1)
                            {
                                TcpServerMgr.GetInstance().m_dicServerReqCmdBuf[strIport][nIndex] = strRevRst;
                            }
                            else
                            {
                                nIndex = TcpServerMgr.GetInstance().m_strClientReqCmd.IndexOf(strRevCmd);
                                if (nIndex != -1)
                                {
                                    TcpServerMgr.GetInstance().m_dicClientAnsCmdBuf[strIport][nIndex] = strRevRst;
                                }
                            }

                            try
                            {
                                string strPath = string.Format("D:/exe/Data/{0}", DateTime.Now.ToString("yyyyMMdd"));
                                if (!Directory.Exists(strPath))
                                    Directory.CreateDirectory(strPath);
                                File.AppendAllLines(string.Format("{0}/StageCummunicate.csv", strPath), new string[] { strIport + "," + strOptCmd + "," + strRevCmd + "," + strRev });
                            }
                            catch (System.Exception)
                            {
                                MessageBox.Show("写入文件失败，\n请确保“StageCummunicate.csv”文件未被打开！");
                            }

                            TcpServerMgr.GetInstance().m_mutexTcpWrite.ReleaseMutex();
                        }
                    }
                }
                catch (Exception ep)
                {
                    System.Diagnostics.Debug.WriteLine(ep.ToString());
                    //System.Windows.Forms.MessageBox.Show(ep.ToString());

                    string strIport = _SocketCominnication.RemoteEndPoint.ToString();
                    TcpServerMgr.GetInstance().m_mutexTcpWrite.WaitOne();
                    TcpServerMgr.GetInstance().m_dicServerReqCmdBuf.Remove(strIport);
                    TcpServerMgr.GetInstance().m_dicClientAnsCmdBuf.Remove(strIport);
                    TcpServerMgr.GetInstance().m_mutexTcpWrite.ReleaseMutex();

                    //_mutexDicSocet.WaitOne();
                    //_dicSocet.Remove(strIport);
                    //_mutexDicSocet.ReleaseMutex();
                    //_SocketCominnication.Close();

                    return;
                }
            }
        }

        /// <summary>
        /// 服务器端监听客户端连接的线程函数
        /// </summary>
        /// <param name="sender"></param>
        private void AccpetThread(object sender)
        {
            byte[] buffer = new byte[1024];
            //socket服务器 a = Sender as socket服务器;
            while (true)
            {
                //  a.ShowMsg("hello");
                //等待一个客户端的链接，并且返回一个用于通信的socket
                //有一个客户端和服务器链接就一个socket 有10个客户端就有10个socket用来跟客户端通信。
                Socket _SocketCominnication = _SocketWatch.Accept();
                _SocketCominnication.NoDelay = true;
                _ConnetEvent.Invoke(_SocketCominnication.RemoteEndPoint.ToString() + " 链接成功---");
                string strClientIport = _SocketCominnication.RemoteEndPoint.ToString();
                int nPos = strClientIport.IndexOf(":");
                _mutexDicSocet.WaitOne();
                if (nPos != -1)
                {
                    string strIp = strClientIport.Substring(0, nPos);
                    foreach (var item in _dicSocet)
                    {
                        string strIport = item.Key;
                        nPos = strIport.IndexOf(strIp);
                        if (nPos != -1)
                        {
                            _dicSocet.Remove(strIport);
                            TcpServerMgr.GetInstance().m_mutexTcpWrite.WaitOne();
                            TcpServerMgr.GetInstance().m_dicClientAnsCmdBuf.Remove(strIport);
                            TcpServerMgr.GetInstance().m_mutexTcpWrite.ReleaseMutex();
                            break;
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("无效IP：{0}", strClientIport));
                    continue;
                }

                _dicSocet.Add(_SocketCominnication.RemoteEndPoint.ToString(), _SocketCominnication);
                _mutexDicSocet.ReleaseMutex();

                TcpServerMgr.GetInstance().m_mutexTcpWrite.WaitOne();
                int nCmdCount = TcpServerMgr.GetInstance().m_strServerReqCmd.Count;
                string[] strServerReqCmdBuf = new string[nCmdCount];
                for (int i = 0; i < nCmdCount; i++)
                {
                    strServerReqCmdBuf[i] = "nil";
                }
                nCmdCount = TcpServerMgr.GetInstance().m_strClientReqCmd.Count;
                string[] strClientAnsCmdBuf = new string[nCmdCount];
                for (int i = 0; i < nCmdCount; i++)
                {
                    strClientAnsCmdBuf[i] = "nil";
                }
                TcpServerMgr.GetInstance().m_dicServerReqCmdBuf.Add(strClientIport, strServerReqCmdBuf);
                TcpServerMgr.GetInstance().m_dicClientAnsCmdBuf.Add(strClientIport, strClientAnsCmdBuf);

                int nCmdIndex = TcpServerMgr.GetInstance().m_strServerReqCmd.IndexOf("Disp_Connect_Status");
                if (-1 != nCmdIndex)
                {
                    if (TcpServerMgr.GetInstance().m_dicServerReqCmdBuf.ContainsKey(strClientIport))
                    {//更新服务端指令缓存
                        TcpServerMgr.GetInstance().m_dicServerReqCmdBuf[strClientIport][nCmdIndex] = "OK";
                    }
                }

                TcpServerMgr.GetInstance().m_mutexTcpWrite.ReleaseMutex();

                //string str = "Hello telnet " + _SocketCominnication.RemoteEndPoint.ToString();
                //str = "Request_Connect,OK";
                //buffer = Encoding.Default.GetBytes(str);
                //_SocketCominnication.Send(buffer);
                _ThreadRev = new Thread(() => ReciveFromClint(_SocketCominnication));
                _ThreadRev.IsBackground = true;
                _ThreadRev.Start();
            }
        }
    }
}