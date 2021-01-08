using System;
using GoCommon;
using HalconDotNet;

namespace GoVision
{
    /// <summary>
    /// 侧相机测量
    /// </summary>
    internal class ProcessSideMea : VisionBase
    {
        //HDevelopExport hde = new HDevelopExport();

        //private HTuple ModelId;
        //private HTuple ModelData;

        public HTuple HandleScreen;
        public HTuple HandleNeedle;

        //public HObject MeasureRect;
        public HObject Lines;

        public HTuple IntraDistance;

        public HTuple Sigma = 1;
        public HTuple Threshold = 30;

        public void CloseScreen()
        {
            try
            {
                if (HandleScreen != null)
                {
                    HOperatorSet.CloseMeasure(HandleScreen);
                    HandleScreen = null;
                }
            }
            catch (Exception)
            {
            }
        }

        public void CloseNeedle()
        {
            try
            {
                if (HandleNeedle != null)
                {
                    HOperatorSet.CloseMeasure(HandleNeedle);
                    HandleNeedle = null;
                }
            }
            catch (Exception)
            {
            }
        }

        public void Clear()
        {
            if (HandleScreen != null)
            {
                HOperatorSet.CloseMeasure(HandleScreen);
                HandleScreen = null;
            }

            if (HandleNeedle != null)
            {
                HOperatorSet.CloseMeasure(HandleNeedle);
                HandleNeedle = null;
            }

            //MeasureRect?.Dispose();
            Lines?.Dispose();
            IntraDistance = null;
        }

        public void Measuer()
        {
            if (imgSrc == null)
            {
                return;
            }

            Lines?.Dispose();
            HOperatorSet.GenEmptyObj(out Lines);
            IntraDistance = null;

            HTuple rowEdgeFirst1 = null, columnEdgeFirst1 = null, amplitudeFirst1;
            HTuple rowEdgeSecond1 = null, columnEdgeSecond1 = null, amplitudeSecond1;
            HTuple intraDistance1 = null, interDistance1;

            HTuple rowEdgeFirst2 = null, columnEdgeFirst2 = null, amplitudeFirst2;
            HTuple rowEdgeSecond2 = null, columnEdgeSecond2 = null, amplitudeSecond2;
            HTuple intraDistance2 = null, interDistance2;

            if (HandleScreen != null)
            {
                for (int i = 0; i <= 5; i++)
                {
                    HTuple threshold = Threshold - i * 2;
                    HOperatorSet.MeasurePairs(imgSrc, HandleScreen, Sigma, threshold, "positive", "first",
                        out rowEdgeFirst1, out columnEdgeFirst1, out amplitudeFirst1,
                        out rowEdgeSecond1, out columnEdgeSecond1, out amplitudeSecond1,
                        out intraDistance1, out interDistance1);

                    if (intraDistance1.Length > 0)
                    {
                        HObject line;
                        HOperatorSet.GenContourPolygonXld(out line,
                            new HTuple(rowEdgeFirst1, rowEdgeSecond1), new HTuple(columnEdgeFirst1, columnEdgeSecond1));
                        HOperatorSet.ConcatObj(Lines, line, out Lines);
                        break;
                    }
                }
            }

            if (HandleNeedle != null)
            {
                for (int i = 0; i <= 5; i++)
                {
                    HTuple threshold = Threshold - i * 2;
                    HOperatorSet.MeasurePairs(imgSrc, HandleNeedle, Sigma, threshold, "negative", "first",
                    out rowEdgeFirst2, out columnEdgeFirst2, out amplitudeFirst2,
                    out rowEdgeSecond2, out columnEdgeSecond2, out amplitudeSecond2,
                    out intraDistance2, out interDistance2);

                    if (intraDistance2.Length > 0)
                    {
                        HObject line;
                        HOperatorSet.GenContourPolygonXld(out line,
                            new HTuple(rowEdgeFirst2, rowEdgeSecond2), new HTuple(columnEdgeFirst2, columnEdgeSecond2));
                        HOperatorSet.ConcatObj(Lines, line, out Lines);
                        break;
                    }
                }
            }

            if (intraDistance1 != null && intraDistance1.Length > 0
                && intraDistance2 != null && intraDistance2.Length > 0)
            {
                HTuple rowMean1, rowMean2, colMean1, colMean2;
                HOperatorSet.TupleMean(new HTuple(rowEdgeFirst1, rowEdgeSecond1), out rowMean1);
                HOperatorSet.TupleMean(new HTuple(rowEdgeFirst2, rowEdgeSecond2), out rowMean2);
                HOperatorSet.TupleMean(new HTuple(columnEdgeFirst1, columnEdgeSecond1), out colMean1);
                HOperatorSet.TupleMean(new HTuple(columnEdgeFirst2, columnEdgeSecond2), out colMean2);

                HObject line1, line2;
                HOperatorSet.GenContourPolygonXld(out line1,
                    new HTuple(rowMean1, rowMean1), new HTuple(colMean1, colMean2));
                HOperatorSet.GenContourPolygonXld(out line2,
                    new HTuple(rowMean2, rowMean2), new HTuple(colMean1, colMean2));

                HOperatorSet.ConcatObj(Lines, line1, out Lines);
                HOperatorSet.ConcatObj(Lines, line2, out Lines);

                HOperatorSet.DistancePp(rowMean1, 0, rowMean2, 0, out IntraDistance);
            }
        }

        /// <summary>
        /// 构造函数,输入处理程序名称，和相机名称
        /// </summary>
        /// <param name="strName"></param>
        public ProcessSideMea(string strName) : base(strName)
        {
        }

        /// <summary>
        /// 初始化配置(模板数据)
        /// </summary>
        /// <returns></returns>
        public override bool InitConfig()
        {
            // hde.InitTemplete(m_strDir, out ModelId, out ModelData);
            LoadParam();
            return true;
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        /// <returns></returns>
        public override bool LoadParam()
        {
            string fileName = $@"{m_strDir}param.ini";

            if (!System.IO.Directory.Exists(m_strDir))
            {
                System.IO.Directory.CreateDirectory(m_strDir);
                SaveParam();
            }

            m_ExposureTime = IniTool.GetInt(fileName, "camera", "exposure", 0);

            //if (System.IO.File.Exists($"{m_strDir}MeasureHandle.mea"))
            //{
            //    HOperatorSet.ReadMeasure($"{m_strDir}MeasureHandle.mea", out MeasureHandle);
            //}

            //if (System.IO.File.Exists($"{m_strDir}MeasureRect.hobj"))
            //{
            //    HOperatorSet.ReadObject(out MeasureRect, $"{m_strDir}MeasureRect.hobj");
            //}

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override bool SaveParam()
        {
            string fileName = $@"{m_strDir}param.ini";

            if (!System.IO.Directory.Exists(m_strDir))
            {
                System.IO.Directory.CreateDirectory(m_strDir);
            }

            //if (MeasureHandle != null)
            //{
            //    HOperatorSet.WriteMeasure(MeasureHandle, $"{m_strDir}MeasureHandle.mea");
            //    HOperatorSet.WriteObject(MeasureRect, $"{MeasureRect}MeasureRect.hobj");
            //}

            IniTool.Set(fileName, "camera", "exposure", m_ExposureTime);

            return true;
        }

        /// <summary>
        /// 更新显示控件
        /// </summary>
        /// <param name="ctl"></param>
        public override void UpdateVisionControl(VisionControl ctl)
        {
            ctl.LockDisplay();
            try
            {
                if (imgSrc != null && imgSrc.IsInitialized() && imgSrc.Key != IntPtr.Zero)
                {
                    HTuple num = 0;
                    HOperatorSet.CountObj(imgSrc, out num);
                    if (num > 0)//&& m_image.IsInitialized() && m_image.Key != IntPtr.Zero)
                    {
                        HOperatorSet.DispObj(imgSrc, ctl.GetHalconWindow());
                    }
                    //    HOperatorSet.DispObj(ModelContour, ctl.GetHalconWindow());

                    //if (MeasureRect != null && MeasureRect.IsInitialized())
                    //{
                    //    HOperatorSet.SetColor(m_visionControl.GetHalconWindow(), "red");
                    //    HOperatorSet.DispObj(MeasureRect, ctl.GetHalconWindow());
                    //}

                    if (Lines != null && Lines.IsInitialized())
                    {
                        HOperatorSet.SetColor(m_visionControl.GetHalconWindow(), "blue");
                        HOperatorSet.DispObj(Lines, ctl.GetHalconWindow());
                    }

                    if (IntraDistance != null && IntraDistance.Length > 0)
                    {
                        if (IntraDistance.Type == HTupleType.STRING)
                        {
                            HDevelopExport.disp_message(m_visionControl.GetHalconWindow(),
                                IntraDistance, "window", 20, -1, "green", "false");
                        }
                        else
                        {
                            var value = SideCameraCalibData.PixelToMm(IntraDistance);
                            HDevelopExport.disp_message(m_visionControl.GetHalconWindow(),
                                $"{value:F2}", "window", 20, -1, "green", "false");
                        }
                    }
                }
            }
            catch (HalconException HDevExpDefaultException1)
            {
                System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.WriteLine(exp.ToString());
            }
            finally
            {
                ctl.UnlockDisplay();
            }
        }

        /// <summary>
        /// 设定曝光值
        /// </summary>
        /// <param name="nExp"></param>
        public override void SetExposureTime(int nExp)
        {
            try
            {
                m_Camera.SetGrabParam("ExposureTimeAbs", nExp);
                m_ExposureTime = nExp;

                if (!System.IO.Directory.Exists(m_strDir))
                {
                    System.IO.Directory.CreateDirectory(m_strDir);
                }

                IniTool.Set($@"{m_strDir}param.ini", "camera", "exposure", m_ExposureTime);
            }
            catch (Exception)
            {
            }
        }

        public override bool Process()
        {
            if (m_Camera != null)
            {
                if (m_visionControl != null)
                    m_visionControl.RegisterUpdateInterface(this);
                //  if (SystemMgr.GetInstance().IsAutoCalibMode())
                {
                    m_ExposureTime = 30000;
                }
                //第一次拍照要求暗,
                m_Camera.SetGrabParam("ExposureTimeAbs", m_ExposureTime);
                if (Snap())
                {
                    return ProcessImage(m_visionControl);
                }
                else
                {
                    //VisionMgr.GetInstance().ShowLog(Name + " process snap1 fail ! ");
                    return false;
                }
            }
            return false;
        }

        private void CalcDetlaData(double x2, double y2, double angle2)
        {
        }

        /// <summary>
        /// 处理当前图像并显示在指定控件上
        /// </summary>
        /// <param name="vc"></param>
        /// <returns></returns>
        public override bool ProcessImage(VisionControl vc)
        {
            Measuer();
            return true;
        }
    }
}