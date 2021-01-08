using System.Collections.Generic;
using System.Threading;

namespace GoVision
{
    internal class TcpServerMgr
    {
        private static TcpServerMgr m_instance;
        private static object syslock = new object();

        private TcpServerMgr()
        {
        }

        public static TcpServerMgr GetInstance()
        {
            if (TcpServerMgr.m_instance == null)
            {
                object syslock = TcpServerMgr.syslock;
                lock (syslock)
                {
                    if (TcpServerMgr.m_instance == null)
                    {
                        TcpServerMgr.m_instance = new TcpServerMgr();
                    }
                }
            }
            return TcpServerMgr.m_instance;
        }

        public SocketServer m_SocketServer = new SocketServer(5000, null);

        //服务器对客户端请求指令集
        public List<string> m_strServerReqCmd = new List<string>
        {
        };

        //客户端对服务器请求指令集
        public List<string> m_strClientReqCmd = new List<string>
        {
        };

        //服务器对客户端请求指令缓存
        public Dictionary<string, string[]> m_dicServerReqCmdBuf = new Dictionary<string, string[]>();

        //客户端对服务器请求应答指令缓存
        public Dictionary<string, string[]> m_dicClientAnsCmdBuf = new Dictionary<string, string[]>();

        public Mutex m_mutexTcpWrite = new Mutex();

        /// <summary>
        /// 查询指定服务器是否创建成功
        /// </summary>
        /// <param name="strServerIp：为空时查询本地服务器"></param>
        /// <returns></returns>
        public bool IsCreatedSocketServer(string strServerIp = "")
        {
            if (strServerIp != "")
                return false;
            return (m_SocketServer != null);
        }

        /// <summary>
        /// 查询指定客户端是否连接
        /// </summary>
        /// <param name="nClientIndex"></param>
        /// <returns></returns>
        public bool IsClientConnected(int nClientIndex)
        {
            string strIp = "127.0.0.1";
            int nPort = 5000;
            if (-1 == nPort)
                return false;
            string strIport = strIp + ":" + nPort.ToString();

            m_mutexTcpWrite.WaitOne();
            bool bRtn = false;
            int nCmdIndex = m_strServerReqCmd.IndexOf("Disp_Connect_Status");
            if (-1 != nCmdIndex && m_dicServerReqCmdBuf.ContainsKey(strIport)
                && m_dicServerReqCmdBuf[strIport][nCmdIndex] == "OK")
            {
                bRtn = true;
            }
            m_mutexTcpWrite.ReleaseMutex();
            return bRtn;
        }

        /// <summary>
        /// 服务器端向指定客户端发送数据
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="iport"></param>
        /// <param name="strText"></param>
        public bool SendServerReqCmd(int nClientIndex, string strSendText, string strValue = null)
        {
            string strIp = "127.0.0.1";
            int nPort = 5000;

            if (-1 == nPort)
                return false;
            string strIport = strIp + ":" + nPort.ToString();

            m_mutexTcpWrite.WaitOne();
            int nCmdIndex = m_strServerReqCmd.IndexOf(strSendText);
            if (-1 != nCmdIndex)
            {
                if (m_dicServerReqCmdBuf.ContainsKey(strIport))
                {//更新服务端指令缓存
                    m_dicServerReqCmdBuf[strIport][nCmdIndex] = (null == strValue) ? "nil" : strValue;
                }
            }
            else
            {
                nCmdIndex = m_strClientReqCmd.IndexOf(strSendText);
                if (-1 == nCmdIndex)
                {
                    m_mutexTcpWrite.ReleaseMutex();
                    return false;
                }
                if (m_dicClientAnsCmdBuf.ContainsKey(strIport))
                {//更新客户端指令缓存
                    m_dicClientAnsCmdBuf[strIport][nCmdIndex] = strValue;
                }
            }

            m_mutexTcpWrite.ReleaseMutex();
            return true;
        }

        ///// <summary>
        ///// 服务器端向指定客户端接收数据
        ///// </summary>
        ///// <param name="ip"></param>
        ///// <param name="iport"></param>
        ///// <param name="strText"></param>
        //public bool ReadClientAnsCmd(int nClientIndex, string strCmdText, out string strAnsRst)
        //{
        //    strAnsRst = "nil";
        //    if (nClientIndex < 0 || nClientIndex >= (int)SysEthPortCfg.EndIndex)
        //        return false;
        //    string strIp = TcpMgr.GetInstance().GetTcpLink(nClientIndex).m_strIP;
        //    int nPort = m_SocketServer.GetPortByIP(strIp);
        //    if (-1 == nPort)
        //        return false;
        //    string strIport = strIp + ":" + nPort.ToString();

        //    m_mutexTcpWrite.WaitOne();
        //    bool bRtn = false;
        //    int nCmdIndex = m_strServerReqCmd.IndexOf(strCmdText);
        //    if (-1 != nCmdIndex)
        //    {
        //        if (m_dicServerReqCmdBuf.ContainsKey(strIport))
        //        {//读取服务端指令缓存
        //            strAnsRst = m_dicServerReqCmdBuf[strIport][nCmdIndex];
        //        }
        //    }
        //    else
        //    {
        //        nCmdIndex = m_strClientReqCmd.IndexOf(strCmdText);
        //        if (-1 == nCmdIndex)
        //        {
        //            m_mutexTcpWrite.ReleaseMutex();
        //            return false;
        //        }
        //        if (m_dicClientAnsCmdBuf.ContainsKey(strIport))
        //        {//读取客户端指令缓存
        //            strAnsRst = m_dicClientAnsCmdBuf[strIport][nCmdIndex];
        //        }
        //    }
        //    m_mutexTcpWrite.ReleaseMutex();
        //    bRtn = (strAnsRst != "nil") ? true : false;

        //    return bRtn;
        //}

        ///// <summary>
        ///// 获取服务器端从客户端接收的指令结果数据
        ///// </summary>
        ///// <param name="ip"></param>
        ///// <param name="iport"></param>
        ///// <param name="strText"></param>
        //public string GetClientAnsRstBuf(int nClientIndex, int nIndex)
        //{
        //    if (nClientIndex < 0 || nClientIndex >= (int)SysEthPortCfg.EndIndex)
        //        return null;
        //    string strIp = TcpMgr.GetInstance().GetTcpLink(nClientIndex).m_strIP;
        //    int nPort = m_SocketServer.GetPortByIP(strIp);
        //    if (-1 == nPort)
        //        return null;
        //    string strIport = strIp + ":" + nPort.ToString();

        //    m_mutexTcpWrite.WaitOne();
        //    if (nIndex < 0 || nIndex >= m_dicClientAnsCmdBuf[strIport].Length)
        //    {
        //        m_mutexTcpWrite.ReleaseMutex();
        //        return null;
        //    }
        //    string strAnsRst = "nil";
        //    if (m_dicClientAnsCmdBuf.ContainsKey(strIport))
        //    {
        //        strAnsRst = m_dicClientAnsCmdBuf[strIport][nIndex];
        //    }
        //    m_mutexTcpWrite.ReleaseMutex();

        //    return strAnsRst;
        //}
    }
}