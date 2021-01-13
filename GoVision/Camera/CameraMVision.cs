using HalconDotNet;

namespace GoVision
{
    public class CameraMVision : CameraBase
    {
        /// <summary>
        /// 相机采集句柄
        /// </summary>
        private HTuple m_hAcqHandle = null;

        /// <summary>
        /// 当前是否处在异步模式
        /// </summary>
        private bool m_bIsGrab = false;

        /// <summary>
        /// 以相机名称进行构造
        /// </summary>
        /// <param name="strName"></param>
        public CameraMVision(string strName) : base(strName)
        {
        }

        public bool Open(int index)
        {
            if (m_hAcqHandle == null)
            {
                try
                {
                    //HOperatorSet.OpenFramegrabber("GigEVision", 1, 1, 0, 0, 0, 0, "default", -1,
                    //    "default", -1, "default", "default", index, -1, -1, out m_hAcqHandle);

                    HOperatorSet.OpenFramegrabber("MVision", 0, 0, 0, 0, 0, 0, "default", 8,
                        "default", -1, "false", "auto", index, 0, -1, out m_hAcqHandle);

                    if (m_hAcqHandle == null || m_hAcqHandle.Length == 0)
                    {
                        m_hAcqHandle = null;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (HalconException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    m_hAcqHandle = null;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns></returns>
        public override bool Open()
        {
            if (m_hAcqHandle == null)
            {
                try
                {
                    //HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default",
                    //    -1, "default", -1, "false", "default", this.Name, 0, -1, out m_hAcqHandle);
                    //HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb",
                    //    -1, "false", "default", "[0] Integrated Camera", 0, -1, out m_hAcqHandle);

                    HOperatorSet.OpenFramegrabber("MVision", 0, 0, 0, 0, 0, 0, "default", 8,
                        "default", -1, "false", "auto", this.Name, 0, -1, out m_hAcqHandle);

                    if (m_hAcqHandle == null || m_hAcqHandle.Length == 0)
                    {
                        m_hAcqHandle = null;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (HalconException HDevExpDefaultException1)
                {
                    System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
                    m_hAcqHandle = null;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断相机是否打开
        /// </summary>
        /// <returns></returns>
        public override bool isOpen()
        {
            return m_hAcqHandle != null;
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public override bool Close()
        {
            if (m_hAcqHandle != null)
            {
                try
                {
                    HOperatorSet.CloseFramegrabber(m_hAcqHandle);
                }
                catch (HalconException HDevExpDefaultException1)
                {
                    System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
                    return false;
                }
                m_hAcqHandle = null;
            }

            m_image = null;
            return true;
        }

        /// <summary>
        /// 软件触发一次同步采集
        /// </summary>
        /// <returns></returns>
        public override int Snap()
        {
            if (m_hAcqHandle == null)
                Open();
            if (m_hAcqHandle != null)
            {
                try
                {
                    m_image?.Dispose();
                    HOperatorSet.GrabImage(out m_image, m_hAcqHandle);
                }
                catch (HalconException HDevExpDefaultException1)
                {
                    System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
                    return 0;
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 设置采集参数
        /// </summary>
        /// <param name="strParam"></param>
        /// <param name="nValue"></param>
        public override void SetGrabParam(string strParam, int nValue)
        {
            try
            {
                if (m_hAcqHandle == null)
                    Open();
                if (m_hAcqHandle != null)
                    HOperatorSet.SetFramegrabberParam(m_hAcqHandle, strParam, nValue);
            }
            catch (HalconException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 触发一次异步采集
        /// </summary>
        /// <returns></returns>
        public override int Grab()
        {
            if (m_hAcqHandle == null)
                Open();
            if (m_hAcqHandle != null)
            {
                try
                {
                    if (m_bIsGrab == false)
                    {
                        m_bIsGrab = true;
                        HOperatorSet.GrabImageStart(m_hAcqHandle, -1);
                    }
                    m_image?.Dispose();
                    HOperatorSet.GrabImageAsync(out m_image, m_hAcqHandle, -1);
                }
                catch (HalconException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    return 0;
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 停止异步采集
        /// </summary>
        /// <returns></returns>
        public override bool StopGrab()
        {
            if (m_hAcqHandle != null)
            {
                try
                {
                    HOperatorSet.SetFramegrabberParam(m_hAcqHandle, "do_abort_grab", 1);
                }
                catch (HalconException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}