using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using HalconDotNet;

namespace GoVision
{
    internal class GoRun : SingletonTemplate<GoRun>
    {
        static public Dictionary<string, VisionBase> m_dicVision = new Dictionary<string, VisionBase>();
        public static MainCameraForm MF;

        public static DrawControl m_visioncontrol1;

        public bool ConfigAll()
        {
            try
            {
                AddVisionStep();
            }
            catch
            {
            }
            return true;
        }

        public static void AddVisionStep()
        {
            //加入一个相机采集类, 加入步骤前必须先添加相机采集
            VisionMgr.GetInstance().AddCamera(new CameraGige("test"));

            //加入视觉步骤类, 并将其绑定到指定的相机采集类上
            VisionMgr.GetInstance().AddVisionStep("test", new Process_Test("Process_Test"));
        }

        public static void InitSystem()
        {
            Action<object> action = (object obj) =>
            {
            };
            Task t1 = new Task(action, "");
            t1.Start();
        }

        public static void DeinitSystem()
        {
            //todo: tcp, com, vision
        }

        public bool Run()
        {
            TcpClientMgr.GetInstance().m_SocketClient.DelConnetEvent(new SocketClient.ConnetEvent(test1));
            TcpClientMgr.GetInstance().m_SocketClient.RegisterConnetEvent(new SocketClient.ConnetEvent(test1));

            TcpClientMgr.GetInstance().m_SocketClient.DelRecvEvent(new SocketClient.RecvEvent(sendMessage));
            TcpClientMgr.GetInstance().m_SocketClient.RegisterRecvEvent(new SocketClient.RecvEvent(sendMessage));
            TcpClientMgr.GetInstance().Connection();
            Action<object> action = (object obj) =>
            {
                Parallel.Invoke(() => sendMessage(""), () => cameraSnap(), () => processImage(), () => returnMessage());
            };
            Task t1 = new Task(action, "");
            t1.Start();

            return true;
        }

        private void test1(string code, bool flag)
        {
            string text = code + "\n\n";
            if (!flag)
                TcpClientMgr.GetInstance().Close();
        }

        private static Go<string> s = new Go<string>();
        private static Go<HObject> c = new Go<HObject>();
        private static Go<string> p = new Go<string>();
        private static Go<string> r = new Go<string>();

        public static void sendMessage(string mes)
        {
            if (mes == "s")
                s._go.Add("s");
        }

        public static void cameraSnap()
        {
            // CameraGige Camera = new CameraGige("test");
            string item;
            HObject img = null;
            while (!s._go.IsCompleted)
            {
                if (s._go.TryTake(out item))
                {
                    if (item == "s")
                    {
                        img = VisionMgr.GetInstance().CameraSnap("test");
                        if (img == null)
                            continue;
                        // m_visioncontrol1.DispImageFull(Camera.GetImage());
                        c._go.TryAdd(img, 5000);
                    }

                    // Console.WriteLine(item);
                }
                System.Threading.Thread.Sleep(10);
            }
            c._go.CompleteAdding();
        }

        public static void processImage()
        {
            //HObject item;

            //int i = 0;
            //while (!c._go.IsCompleted)
            //{
            //    if (c._go.TryTake(out item))
            //    {
            //        VisionMgr.GetInstance().ProcessImage("Process_Test", item, MF.DrawControl1);
            //        p._go.TryAdd(string.Format("处理：{0}", i++), 5000);

            //        //   Console.WriteLine(item);
            //    }
            //    System.Threading.Thread.Sleep(10);
            //}
            //p._go.CompleteAdding();
        }

        public static void returnMessage()
        {
            string item;
            int i = 0;
            while (!p._go.IsCompleted)
            {
                if (p._go.TryTake(out item))
                {
                    r._go.TryAdd(string.Format("处理：{0}", i++), 5000);
                    TcpClientMgr.GetInstance().Send("OK");
                    // Console.WriteLine(item);
                }
                System.Threading.Thread.Sleep(10);
            }
        }
    }

    public class Go<T>
    {
        public BlockingCollection<T> _go = new BlockingCollection<T>();
    }
}