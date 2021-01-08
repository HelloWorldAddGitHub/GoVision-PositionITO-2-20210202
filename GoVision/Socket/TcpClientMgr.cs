namespace GoVision
{
    internal class TcpClientMgr
    {
        private static TcpClientMgr m_instance;
        private static object syslock = new object();

        //private string _ip;
        //private int _port;
        //private int _Cport;
        public SocketClient m_SocketClient = null;

        public static TcpClientMgr GetInstance()
        {
            if (TcpClientMgr.m_instance == null)
            {
                object syslock = TcpClientMgr.syslock;
                lock (syslock)
                {
                    if (TcpClientMgr.m_instance == null)
                    {
                        TcpClientMgr.m_instance = new TcpClientMgr();
                    }
                }
            }
            return TcpClientMgr.m_instance;
        }

        private TcpClientMgr()
        {
            //_ip = "127.0.0.1";
            //_port = 5000;
            //_Cport = 4000;
            //if (m_SocketClient == null)
            //    m_SocketClient = new SocketClient("127.0.0.1", 5000, 4000);
        }

        ~TcpClientMgr()
        {
            //m_SocketClient.Close();
            //if (m_instance != null)
            //    m_instance = null;
        }

        public void Close()
        {
            if (m_instance != null)
                m_instance = null;
            m_SocketClient?.Close();
        }

        public void Connection()
        {
            m_SocketClient.Connection();
        }

        public void Send(string data)
        {
            m_SocketClient.SendData(data);
        }
    }
}