using System;
using System.Threading;

namespace GoVision
{
    public class SingletonTemplate<T> where T : class, new()
    {
        protected bool m_bRunThread;
        private static T m_instance;
        private Thread m_thread;
        private static readonly object syslock;

        static SingletonTemplate()
        {
            SingletonTemplate<T>.syslock = new object();
        }

        public SingletonTemplate()
        {
            this.m_thread = null;
        }

        public static T GetInstance()
        {
            if (SingletonTemplate<T>.m_instance == null)
            {
                object syslock = SingletonTemplate<T>.syslock;
                lock (syslock)
                {
                    if (SingletonTemplate<T>.m_instance == null)
                    {
                        SingletonTemplate<T>.m_instance = Activator.CreateInstance<T>();
                    }
                }
            }
            return SingletonTemplate<T>.m_instance;
        }
    }
}