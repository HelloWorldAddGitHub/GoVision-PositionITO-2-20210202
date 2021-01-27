using System;
using GoCommon;
using HalconDotNet;
using System.Threading.Tasks;

namespace GoVision
{
    /// <summary>
    /// 点碳定位流程
    /// </summary>
    public class ProcessMainPos : VisionBase
    {
        public ProcessMainPos(string strName) : base(strName)
        {
        }

        public override bool InitConfig()
        {
            LoadParam();
            return true;
        }

        public override bool ProcessImage(VisionControl ctl)
        {
            try
            {
                ctl.clearObj();
                ctl.DisplayResults();

                //保存图像
                //string imageName = $"{DateTime.Now:HHmmss}.tiff";

                //if (AutoForm._autoForm.Param.IsSaveImageAll)
                //{
                //    //保存原图
                //    string path = $@"{ProductMgr.GetInstance().ProductPath}Images\Platform\{DateTime.Now:yyMMdd}\Source\";
                //    if (!System.IO.Directory.Exists(path))
                //    {
                //        System.IO.Directory.CreateDirectory(path);
                //    }
                //    string fileName = $"{path}{imageName}";
                //    HDevelopExport.WriteImage(imgSrc, fileName);
                //}

                //图像预处理
                HObject image;

                if (ProductMgr.GetInstance().Param.PlatformRegion != null)
                {
                    HOperatorSet.ReduceDomain(imgSrc, ProductMgr.GetInstance().Param.PlatformRegion, out image);

                    //if (ProductMgr.GetInstance().Param.IsPerprocess)
                    //{
                    //    image = HDevelopExport.Preprocess(image, ProductMgr.GetInstance().Param.Emphasize, false);
                    //}
                }
                else
                {
                    image = imgSrc;
                }

                //查找模板
                HTuple row, column, angle, scale, score;
                bool result = HDevelopExport.FindScaleShapeModel(image, out row, out column, out angle, out scale, out score);

                //显示轮廓
                HDevelopExport.dev_display_shape_matching_results(ctl.GetHalconWindow(),
                    ProductMgr.GetInstance().Param.ModelID, "blue", row, column, angle, scale, scale, 0);

                //二次定位
                if (result && ProductMgr.GetInstance().Param.IsSecondPos)
                {
                    HTuple transRow, transColumn, transRadian;
                    result = HDevelopExport.FindPinCenter(imgSrc, row, column, angle, out transRow, out transColumn, out transRadian);

                    if (result)
                    {
                        row = transRow;
                        column = transColumn;
                        angle = transRadian;
                    }

                    //ctl.DisplayResults();
                }

                if (!result)
                {
                    Log.Show("查找模板失败");
                }
                else
                {
                    //弧度差
                    HTuple relRow, relColumn, relRadian, rowTrans, colTrans;
                    //relRadian = PlatformCalibData.MarkRadian - angle;
                    relRadian = 0 - angle;

                    //旋转特征点
                    //HTuple homMat2D;
                    //HOperatorSet.HomMat2dIdentity(out homMat2D);
                    //HOperatorSet.HomMat2dRotate(homMat2D, relRadian, PlatformCalibData.CenterRow, PlatformCalibData.CenterColumn, out homMat2D);
                    //HOperatorSet.AffineTransPixel(homMat2D, row, column, out rowTrans, out colTrans);

                    //以平台Mark点为基准
                    //relRow = PlatformCalibData.MarkRow - rowTrans;
                    //relColumn = PlatformCalibData.MarkColumn - colTrans;

                    //没有旋转，直接计算X和Y方向的差值，下面的角度只用于显示
                    //relRow = PlatformCalibData.MarkRow - row;
                    //relColumn = PlatformCalibData.MarkColumn - column;

                    //弧度转角度
                    HTuple degree;
                    HOperatorSet.TupleDeg(relRadian, out degree);

                    //赋值给需要发送的数据
                    //SendData.X = PlatformCalibData.PixelToMm(relColumn);
                    //SendData.Y = PlatformCalibData.PixelToMm(relRow);
                    //SendData.Angle = degree;


                    //用矩阵获得Mark点的世界坐标和模板的世界坐标，求差值
                    HTuple colMark, rowMark;
                    HOperatorSet.AffineTransPixel(PlatformCalibData.HomMat2D, PlatformCalibData.MarkColumn, PlatformCalibData.MarkRow, out colMark, out rowMark);
                    HOperatorSet.AffineTransPixel(PlatformCalibData.HomMat2D, column, row, out colTrans, out rowTrans);
                    SendData.X = colMark - colTrans;
                    SendData.Y = rowMark - rowTrans;



                    ctl.AddToStack(ProductMgr.GetInstance().Param.ModelContours);
                    ctl.AddToStack(ProductMgr.GetInstance().Param.ModelOriginContours);
                    ctl.AddToStack(ProductMgr.GetInstance().Param.MarkContours);

                    ctl.DisplayResults();

                    //显示数据到窗口
                    HTuple deg;
                    HOperatorSet.TupleDeg(angle, out deg);
                    Log.Show($"查找模板:row:{row.D:F2},column:{column.D:F2},degree:{deg.D:F2},分数：{score.D:F2}");

                    HDevelopExport.disp_message(ctl.GetHalconWindow(), $"位置：{row.D:F2},{column.D:F2},{degree.D:F2}", "window", 10, -1, "green", "false");
                    HDevelopExport.disp_message(ctl.GetHalconWindow(), $"分数：{score.D:F2}", "window", 30, -1, "green", "false");

                    HDevelopExport.disp_message(ctl.GetHalconWindow(), $"X:{SendData.X:F2},Y:{SendData.Y:F2},A:{SendData.Angle:F2}", "window", 150, -1, "green", "false");
                    Log.Show($"目标位置：X:{SendData.X:F2},Y:{SendData.Y:F2},A:{SendData.Angle:F2}");
                }

                //保存查找模板的窗口图片和原图
                if (AutoForm._autoForm.Param.IsSaveImageAll)
                {
                    SaveImage(ctl.GetHalconWindow(), result);
                }
                else
                {
                    if (AutoForm._autoForm.Param.IsSaveImageNG && !result)
                    {
                        SaveImage(ctl.GetHalconWindow(), result);
                    }
                }

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SaveImage(HTuple handle, bool result)
        {
            try
            {
                //Task.Run(() =>
                //{
                //string imageName = $"{DateTime.Now:HHmmss}.tiff";
                string imageName = $"{DateTime.Now:HHmmss}.jpg";

                string res = result ? "OK" : "NG";
                string pathSource = $@"{ProductMgr.GetInstance().ProductPath}Images\{DateTime.Now:yyyyMMdd}\Platform\{res}\Source\";
                string pathWindow = $@"{ProductMgr.GetInstance().ProductPath}Images\{DateTime.Now:yyyyMMdd}\Platform\{res}\Window\";

                if (!System.IO.Directory.Exists(pathSource))
                {
                    System.IO.Directory.CreateDirectory(pathSource);
                }

                if (!System.IO.Directory.Exists(pathWindow))
                {
                    System.IO.Directory.CreateDirectory(pathWindow);
                }

                string fileNameSource = $"{pathSource}{imageName}";
                string fileNameWindow = $"{pathWindow}{imageName}";

                HDevelopExport.WriteImage(imgSrc, fileNameSource);
                HDevelopExport.DumpWindow(handle, fileNameWindow);
                //});
            }
            catch (Exception)
            {

            }
        }

        public override void UpdateVisionControl(VisionControl ctl)
        {
            ctl.LockDisplay();
            try
            {
                if (imgSrc != null && imgSrc.IsInitialized() && imgSrc.Key != IntPtr.Zero)
                {
                    if (imgSrc != null)
                    {
                        HOperatorSet.DispObj(imgSrc, ctl.GetHalconWindow());
                    }

                    while (ctl.getStack().Count > 0)
                    {
                        HOperatorSet.DispObj(ctl.getStack().Pop(), ctl.GetHalconWindow());
                    }

                    //HTuple hv_Width, hv_Height;
                    //HOperatorSet.GetImageSize(m_image, out hv_Width, out hv_Height);
                    //HObject ht_CrossLineV, ht_CrossLineH;
                    //HOperatorSet.SetColor(ctl.GetHalconWindow(), "red");
                    //HOperatorSet.GenRegionLine(out ht_CrossLineV, 0, hv_Width / 2, hv_Height, hv_Width / 2);
                    //HOperatorSet.GenRegionLine(out ht_CrossLineH, hv_Height / 2, 0, hv_Height / 2, hv_Width);
                    //HOperatorSet.DispObj(ht_CrossLineV, ctl.GetHalconWindow());
                    //HOperatorSet.DispObj(ht_CrossLineH, ctl.GetHalconWindow());
                }
            }
            catch (HalconException HDevExpDefaultException1)
            {
                System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
            }
            catch (AccessViolationException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                ctl.UnlockDisplay();
            }
        }

        /// <summary>
        /// 设置曝光值
        /// </summary>
        /// <param name="nExp"></param>
        public override void SetExposureTime(int nExp)
        {
            try
            {
                //m_Camera.SetGrabParam("ExposureTimeAbs", nExp);
                m_Camera.SetGrabParam("ExposureTime", nExp);
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

        public override bool LoadParam()
        {
            string fileName = $@"{m_strDir}param.ini";

            if (!System.IO.Directory.Exists(m_strDir))
            {
                System.IO.Directory.CreateDirectory(m_strDir);
                SaveParam();
            }

            m_ExposureTime = IniTool.GetInt(fileName, "camera", "exposure", 1000);

            return true;
        }

        public override bool SaveParam()
        {
            string fileName = $@"{m_strDir}param.ini";

            if (!System.IO.Directory.Exists(m_strDir))
            {
                System.IO.Directory.CreateDirectory(m_strDir);
            }

            IniTool.Set(fileName, "camera", "exposure", m_ExposureTime);

            return true;
        }
    }
}