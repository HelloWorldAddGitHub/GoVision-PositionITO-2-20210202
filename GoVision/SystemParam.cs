namespace GoVision
{
    public class SystemParam
    {
        public string ProductName { get; set; }

        public string IP { get; set; }
        public int Port { get; set; }

        public string ManagerPassword { get; set; }
        public string OperatorPassword { get; set; }

        public bool IsSaveImageAll;
        public bool IsSaveImageNG;
        public bool IsSaveData;
        public bool IsSaveLog;
    }
}