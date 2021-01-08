namespace GoVision
{
    internal class global_object
    {
        public static UserMode m_runMode = UserMode.Operator;



        public delegate void UserChangedHandler();

        public static event UserChangedHandler UserChangedEvent;

        public static bool ChangeOpMode(string strPassword)
        {
            if (strPassword == "go9527")
            {
                m_runMode = UserMode.Operator;
                UserChangedEvent();
                return true;
            }
            return false;
        }

        public static bool ChangeManaMode(string strPassword)
        {
            if (strPassword == "go9527")
            {
                m_runMode = UserMode.Manager;
                UserChangedEvent();
                return true;
            }
            return false;
        }
    }
}