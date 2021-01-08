using System;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;

namespace GoVision
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool CreatedSuccessfully;
            Mutex mutexApp = new Mutex(true, Application.ProductName, out CreatedSuccessfully);

            if (!CreatedSuccessfully)
            {
                MessageBox.Show($"{Application.ProductName}正在运行");
                return;
            }

            //HALCON系统的初始化。
            HOperatorSet.ResetObjDb(5472, 3648, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutoForm());
        }
    }
}