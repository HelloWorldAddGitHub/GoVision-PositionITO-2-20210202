using HalconDotNet;

namespace GoVision
{
    public abstract class CameraBase
    {
        public HObject m_image = new HObject();
        private string m_strCamName;

        public CameraBase(string strName)
        {
            m_strCamName = strName;

            HOperatorSet.GenEmptyObj(out m_image);
        }

        public string Name
        {
            get { return m_strCamName; }
            set { m_strCamName = value; }
        }

        public HObject GetImage()
        {
            return m_image;
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns></returns>
        public abstract bool Open();

        /// <summary>
        /// 判断相机是否打开
        /// </summary>
        /// <returns></returns>
        public abstract bool isOpen();

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public abstract bool Close();

        /// <summary>
        /// 软件触发一次同步采集
        /// </summary>
        /// <returns></returns>
        public abstract int Snap();

        /// <summary>
        /// 设置采集参数
        /// </summary>
        /// <param name="strParam"></param>
        /// <param name="nValue"></param>
        public abstract void SetGrabParam(string strParam, int nValue);

        /// <summary>
        /// 触发一次异步采集
        /// </summary>
        /// <returns></returns>
        public abstract int Grab();

        /// <summary>
        /// 停止异步采集
        /// </summary>
        /// <returns></returns>
        public abstract bool StopGrab();
    }
}