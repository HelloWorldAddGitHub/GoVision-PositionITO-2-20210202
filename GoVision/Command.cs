using System;

namespace GoVision
{
    public struct CommandType
    {
        public const string T1 = "03,01,01,0,11;";//平台定位
        public const string T2 = "03,01,02,0,12;";//机械手定位
    }

    public class Receive
    {
        /// <summary>
        /// 解析指令
        /// </summary>
        /// <param name="data"></param>
        public static void Parse(string data)
        {
            DateTime t1 = DateTime.Now;
            Log.Show($"接收：{data}");

            bool result = false;

            //清理数据
            SendData.Clear();

            //平台定位
            if (data == CommandType.T1)
            {
                result = VisionMgr.GetInstance().GetVisionBase(VisionStepName.MainPos).Process();
                string temp;

                if (result)
                {
                    /* 12345678-数值必须用8位表示
                     * 12-前2位表示数值的符号，00-正，11-负
                     * 3456-中间4位表示数值的整数部分
                     * 78-后2位表示数值的小数部分
                     */
                    string x = $"{SendData.X:000000.00}".Replace(".", "").Replace("-00", "11");
                    string y = $"{SendData.Y:000000.00}".Replace(".", "").Replace("-00", "11");
                    string u = $"{SendData.Angle:000000.00}".Replace(".", "").Replace("-00", "11");

                    temp = $"01,,01,,01,,{x},,{y},,{u}";
                }
                else
                {
                    temp = $"01,,01,,00,,00000000,,00000000,,00000000";
                }

                TcpClientMgr.GetInstance().Send(temp);
                Log.Show($"发送：{temp}");
            }

            //机械手定位
            if (data == CommandType.T2)
            {
                result = VisionMgr.GetInstance().GetVisionBase(VisionStepName.MainMea).Process();
                string temp;

                if (result)
                {
                    string x = $"{SendData.X:000000.00}".Replace(".", "").Replace("-00", "11");
                    string y = $"{SendData.Y:000000.00}".Replace(".", "").Replace("-00", "11");
                    string areaNgCount = $"{SendData.CountAreaNG:0000}";
                    string posNgCount = $"{SendData.CountPosNG:0000}";

                    //面积NG数量 位置NG数量
                    temp = $"01,,02,,01,,{x},,{y},,{areaNgCount}{posNgCount}";
                }
                else
                {
                    temp = $"01,,02,,00,,00000000,,00000000,,00000000";
                }

                TcpClientMgr.GetInstance().Send(temp);
                Log.Show($"发送：{temp}");
            }

            TimeSpan time = DateTime.Now - t1;
            Log.Show($"用时：{time.TotalMilliseconds}");
        }
    }

    public class SendData
    {
        public static double X;
        public static double Y;
        public static double Angle;
        public static int CountAreaNG;//面积NG数量
        public static int CountPosNG;//位置NG数量

        public static void Clear()
        {
            X = 0;
            Y = 0;
            Angle = 0;
            CountAreaNG = 0;
            CountPosNG = 0;
        }
    }
}