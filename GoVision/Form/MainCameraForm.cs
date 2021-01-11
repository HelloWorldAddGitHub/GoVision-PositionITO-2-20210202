using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoCommon;
using HalconDotNet;

namespace GoVision
{
    public partial class MainCameraForm : Form
    {
        private VisionBase vision;  //图像处理对象
        private bool continuGrab;   //连续采集

        public object textBox1 { get; private set; }

        public MainCameraForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示日志
        /// </summary>
        /// <param name="value"></param>
        public void ShowLog(string value)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke((MethodInvoker)delegate ()
                {
                    txtLog.AppendText($"{value}\r\n");
                });
            }
            else
            {
                txtLog.AppendText($"{value}\r\n");
            }

            if (AutoForm._autoForm.Param.IsSaveLog)
            {
                ProductMgr.GetInstance().Log.WritrLine(value);
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="value"></param>
        public void ShowData(int index, double[] diameter, double[] disLeft, double[] disRight, double[] disTop)
        {
            string text = string.Empty;

            if (dgvData.InvokeRequired)
            {
                dgvData.Invoke((MethodInvoker)delegate ()
                {
                    if (index <= 0)
                    {
                        dgvData.Rows.Clear();
                    }

                    var mea = MeasureMgr.GetInstance().MeasureList[index];

                    for (int i = 0; i < diameter.Length; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Cells.AddRange(new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(),
                            new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell());
                        row.Cells[0].Value = $"{index}-{i}";
                        row.Cells[1].Value = diameter[i].ToString("F2");
                        row.Cells[2].Value = disLeft[i].ToString("F2");
                        row.Cells[3].Value = disRight[i].ToString("F2");
                        row.Cells[4].Value = disTop[i].ToString("F2");

                        //判断是否NG
                        double LimiteMax = PlatformCalibData.PixelToMm(mea.PinDistance);
                        if (diameter[i] > mea.LimiteDiameterMax || diameter[i] < mea.LimiteDiameterMin)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (disLeft[i] < mea.LimiteLeft || disLeft[i] > LimiteMax
                        || disRight[i] < mea.LimiteRight || disRight[i] > LimiteMax
                        || disTop[i] < mea.LimiteTopMin || disTop[i] > mea.LimiteTopMax)
                        {
                            row.DefaultCellStyle.BackColor = Color.Magenta;
                        }

                        //添加到列表
                        dgvData.Rows.Add(row);

                        text += $"{DateTime.Now:HH:mm:ss},{index}-{i:00},{diameter[i]:00.00},{disLeft[i]:00.00},{disRight[i]:00.00},{disTop[i]:00.00}\r\n";
                    }
                });
            }
            else
            {
                if (index <= 0)
                {
                    dgvData.Rows.Clear();
                }

                var mea = MeasureMgr.GetInstance().MeasureList[index];

                for (int i = 0; i < diameter.Length; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.AddRange(new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(),
                        new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell());
                    row.Cells[0].Value = $"{index}-{i}";
                    row.Cells[1].Value = diameter[i].ToString("F2");
                    row.Cells[2].Value = disLeft[i].ToString("F2");
                    row.Cells[3].Value = disRight[i].ToString("F2");
                    row.Cells[4].Value = disTop[i].ToString("F2");

                    //判断是否NG
                    double LimiteMax = PlatformCalibData.PixelToMm(mea.PinDistance);
                    if (diameter[i] > mea.LimiteDiameterMax || diameter[i] < mea.LimiteDiameterMin)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (disLeft[i] < mea.LimiteLeft || disLeft[i] > LimiteMax
                    || disRight[i] < mea.LimiteRight || disRight[i] > LimiteMax
                    || disTop[i] < mea.LimiteTopMin || disTop[i] > mea.LimiteTopMax)
                    {
                        row.DefaultCellStyle.BackColor = Color.Magenta;
                    }

                    //添加到列表
                    dgvData.Rows.Add(row);

                    text += $"{DateTime.Now:HH:mm:ss},{index}-{i:00},{diameter[i]:00.00},{disLeft[i]:00.00},{disRight[i]:00.00},{disTop[i]:00.00}\r\n";
                }
            }

            if (AutoForm._autoForm.Param.IsSaveData)
            {
                ProductMgr.GetInstance().Data.WriteLine(text);
            }
        }

        public void HObjectDispose()
        {
            //vision.imgSrc?.Dispose();
            ProductMgr.GetInstance().Param.Roi?.Dispose();
            ProductMgr.GetInstance().Param.ModelContours?.Dispose();
            ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();

            ProductMgr.GetInstance().Param.Roi = null;
            ProductMgr.GetInstance().Param.ModelContours = null;
            ProductMgr.GetInstance().Param.ModelOriginContours = null;

            foreach (var mea in MeasureMgr.GetInstance().MeasureList)
            {
                mea.ClearResult();
            }
        }

        private void LoadParam()
        {
            //标定的数据保存到Product文件夹下
            string fileName = $@"{System.Environment.CurrentDirectory}\Product\Calib.ini";

            //读取矩阵
            if (System.IO.File.Exists($@"{System.Environment.CurrentDirectory}\Product\HomMat2D.hm"))
            {
                string path = $@"{System.Environment.CurrentDirectory}\Product\HomMat2D.hm".Replace("\\", "/");
                HOperatorSet.ReadTuple(path, out PlatformCalibData.HomMat2D);
            }

            //读取旋转中心和像素每毫米
            PlatformCalibData.CenterRow = IniTool.GetDouble(fileName, "calib", "CenterRow", 0);
            PlatformCalibData.CenterColumn = IniTool.GetDouble(fileName, "calib", "CenterColumn", 0);
            PlatformCalibData.MmPerPixel = IniTool.GetDouble(fileName, "calib", "MmPerPixel", 1);

            //读取Mark点
            PlatformCalibData.MarkRow = IniTool.GetDouble(fileName, "mark", "row", 0);
            PlatformCalibData.MarkColumn = IniTool.GetDouble(fileName, "mark", "column", 0);
            //PlatformCalibData.MarkRadian = IniTool.GetDouble(fileName, "mark", "radian", 0);
            MeasureMgr.GetInstance().OffsetDia = IniTool.GetDouble(fileName, "offset", "dia", 0);

            //HTuple degree;
            //HOperatorSet.TupleDeg(PlatformCalibData.MarkRadian, out degree);

            nudMarkRow.Value = (decimal)PlatformCalibData.MarkRow.D;
            nudMarkColumn.Value = (decimal)PlatformCalibData.MarkColumn.D;
            //nudOffsetDia.Value = (decimal)degree.D;
            nudOffsetDia.Value = (decimal)MeasureMgr.GetInstance().OffsetDia;

            //读取检测区域
            string filename = $@"{System.Environment.CurrentDirectory}\Product\PlatformRegion.hobj".Replace("\\", "/");
            if (System.IO.File.Exists(filename))
            {
                HOperatorSet.ReadRegion(out ProductMgr.GetInstance().Param.PlatformRegion, filename);
            }

            filename = $@"{System.Environment.CurrentDirectory}\Product\RobotRegion.hobj".Replace("\\", "/");
            if (System.IO.File.Exists(filename))
            {
                HOperatorSet.ReadRegion(out ProductMgr.GetInstance().Param.RobotRegion, filename);
            }
        }

        public void LoadMeasure()
        {
            MeasureMgr.GetInstance().Load($"{ProductMgr.GetInstance().ProductPath}Measure\\");

            lstMeasureList.Items.Clear();
            var measureList = MeasureMgr.GetInstance().MeasureList;
            for (int i = 0; i < measureList.Count; i++)
            {
                lstMeasureList.Items.Add($"ROI{i}");
                ShowLog($"加载ROI{i}");
            }

            lstMeasureList.SelectedIndex = lstMeasureList.Items.Count - 1;
        }

        public bool LoadShapeModel()
        {
            string path = $"{ProductMgr.GetInstance().ProductPath}ShapeModel.sm";

            if (!System.IO.File.Exists(path))
            {
                return false;
            }
            //int i = ProductMgr.GetInstance().Param.ModelID;
            //if (ProductMgr.GetInstance().Param.ModelID != null)
            //{
            //    HOperatorSet.ClearShapeModel(ProductMgr.GetInstance().Param.ModelID);

            //}

            HOperatorSet.ReadShapeModel(path, out ProductMgr.GetInstance().Param.ModelID);

            HTuple numLevels, angleStart, angleExtent, angleStep, degStart, degExtent;
            HTuple scaleMin, scaleMax, scaleStep, metric, minContrast;
            HOperatorSet.GetShapeModelParams(ProductMgr.GetInstance().Param.ModelID,
                out numLevels, out angleStart, out angleExtent, out angleStep,
                out scaleMin, out scaleMax, out scaleStep, out metric, out minContrast);

            //弧度转角度
            HOperatorSet.TupleDeg(angleStart, out degStart);
            HOperatorSet.TupleDeg(angleExtent, out degExtent);

            nudNumLevels.Value = (decimal)numLevels.D;
            nudAngleStart.Value = (decimal)degStart.D;
            nudAngleExtent.Value = (decimal)degExtent.D;
            nudScaleMin.Value = (decimal)scaleMin.D;
            nudScaleMax.Value = (decimal)scaleMax.D;
            cmbMetric.Text = metric;
            nudMinContrast.Value = (decimal)minContrast.D;

            ProductMgr.GetInstance().Param.FindAngleStart = degStart;
            ProductMgr.GetInstance().Param.FindAngleExtent = degExtent;
            //ProductMgr.GetInstance().LoadParam();

            //ProductMgr.GetInstance().Param.ModelID =

            nudContrastLow.Value = (decimal)ProductMgr.GetInstance().Param.ContrastLow.D;
            nudContrastHigh.Value = (decimal)ProductMgr.GetInstance().Param.ContrastHigh.D;

            nudMinScore.Value = (decimal)ProductMgr.GetInstance().Param.FindScore.D;
            nudNumMatches.Value = (decimal)ProductMgr.GetInstance().Param.FindNumMatches.D;
            nudGreediness.Value = (decimal)ProductMgr.GetInstance().Param.FindGreediness.D;
            nudMaxOverlap.Value = (decimal)ProductMgr.GetInstance().Param.FindMaxOverlap.D;
            cmbSubPixel.Text = ProductMgr.GetInstance().Param.FindSubPixel;
            nudFindLeves.Value = (decimal)ProductMgr.GetInstance().Param.FindLevels.D;

            ckbSecondPos.Checked = ProductMgr.GetInstance().Param.IsSecondPos;

            ShowLog($"模板加载成功");

            return true;
        }

        public void ChangeProduct(string name, string path)
        {
            ProductMgr.GetInstance().Param.Clear();
            MeasureMgr.GetInstance().DelAll();
            label41.Text = $@"当前产品-{ProductMgr.GetInstance().ProductName}";

            LoadShapeModel();
            LoadMeasure();

            foreach (var v in VisionMgr.GetInstance().m_dicVision.Values)
            {
                v.imgSrc?.Dispose();
                v.imgWindow?.Dispose();
            }

            HOperatorSet.ClearWindow(visionControl1.GetHalconWindow());
        }

        public void SaveShapeModel()
        {
            if (ProductMgr.GetInstance().Param.ModelID != null)
            {
                string path = $"{ProductMgr.GetInstance().ProductPath}ShapeModel.sm";

                HOperatorSet.WriteShapeModel(ProductMgr.GetInstance().Param.ModelID, path);

                ProductMgr.GetInstance().Param.ContrastLow = (double)nudContrastLow.Value;
                ProductMgr.GetInstance().Param.ContrastHigh = (double)nudContrastHigh.Value;

                ProductMgr.GetInstance().Param.FindScore = (double)nudMinScore.Value;
                ProductMgr.GetInstance().Param.FindNumMatches = (double)nudNumMatches.Value;
                ProductMgr.GetInstance().Param.FindGreediness = (double)nudGreediness.Value;
                ProductMgr.GetInstance().Param.FindMaxOverlap = (double)nudMaxOverlap.Value;
                ProductMgr.GetInstance().Param.FindSubPixel = cmbSubPixel.Text;
                ProductMgr.GetInstance().Param.FindLevels = (double)nudFindLeves.Value;

                ProductMgr.GetInstance().SaveParam();

                ShowLog("保存模板完成");
            }
        }

        public void CreateScaledShapeModel()
        {
            try
            {
                if (vision.imgSrc == null || ProductMgr.GetInstance().Param.Roi == null)
                {
                    ShowLog("没有图像或ROI");
                    return;
                }
                HTuple angleStart, angleExtent;
                HTuple contrast;
                HObject image;

                HTuple model = ProductMgr.GetInstance().Param.ModelID;
                if (model != null && model.Length > 0)
                {
                    try
                    {
                        HOperatorSet.ClearShapeModel(ProductMgr.GetInstance().Param.ModelID);
                    }
                    catch (Exception)
                    {
                    }
                }

                ProductMgr.GetInstance().Param.ModelContours?.Dispose();
                ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();

                HOperatorSet.TupleRad((double)nudAngleStart.Value, out angleStart);
                HOperatorSet.TupleRad((double)nudAngleExtent.Value, out angleExtent);

                if (nudContrastLow.Value != nudContrastHigh.Value)
                {
                    //contrast = $@"[{nudContrastLow.Value},{nudContrastHigh.Value}]";
                    contrast = (int)nudContrastLow.Value;
                    contrast.Append((int)nudContrastHigh.Value);
                }
                else
                {
                    contrast = (int)nudContrastHigh.Value;
                }

                HOperatorSet.ReduceDomain(vision.GetSrcImage(), ProductMgr.GetInstance().Param.Roi, out image);

                HOperatorSet.CreateScaledShapeModel(image, (int)nudNumLevels.Value,
                    angleStart, angleExtent, 0, (double)nudScaleMin.Value, (double)nudScaleMax.Value, 0,
                    cmbOptimization.Text, cmbMetric.Text, contrast, (int)nudMinContrast.Value,
                    out ProductMgr.GetInstance().Param.ModelID);

                //HOperatorSet.GetShapeModelContours(out ProductMgr.GetInstance().Param.ModelContours,
                //    ProductMgr.GetInstance().Param.ModelID, 1);

                //HOperatorSet.GetShapeModelOrigin(ProductMgr.GetInstance().Param.ModelID,
                //    out ProductMgr.GetInstance().Param.ModelOriginRow,
                //    out ProductMgr.GetInstance().Param.ModelOriginColumn);
            }
            catch (Exception)
            {
                ShowLog("创建模板失败");
            }
        }

        public void SetShapeModelOrigin()
        {
            HTuple row, column, radian, scale, score;
            HTuple angleStart, angleExtent;

            HOperatorSet.TupleRad((double)nudAngleStart.Value, out angleStart);
            HOperatorSet.TupleRad((double)nudAngleExtent.Value, out angleExtent);

            HOperatorSet.SetShapeModelOrigin(ProductMgr.GetInstance().Param.ModelID, 0, 0);

            HOperatorSet.FindScaledShapeModel(vision.GetSrcImage(), ProductMgr.GetInstance().Param.ModelID,
                angleStart, angleExtent, (double)nudScaleMin.Value, (double)nudScaleMax.Value, (double)nudMinScore.Value,
                (int)nudNumMatches.Value, (double)nudMaxOverlap.Value, cmbSubPixel.Text, (int)nudFindLeves.Value,
                (double)nudGreediness.Value, out row, out column, out radian, out scale, out score);

            if (score.Length > 0)
            {
                HTuple originRow = (double)nudRow.Value - row;
                HTuple originColumn = (double)nudColumn.Value - column;

                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dRotate(homMat2D, -radian, 0, 0, out homMat2D);
                HOperatorSet.AffineTransPixel(homMat2D, originRow, originColumn, out originRow, out originColumn);

                HOperatorSet.SetShapeModelOrigin(ProductMgr.GetInstance().Param.ModelID, originRow, originColumn);

                ProductMgr.GetInstance().Param.ModelOriginRow = originRow;
                ProductMgr.GetInstance().Param.ModelOriginColumn = originColumn;

                ShowLog($"模板原点位置：{originRow.D:F2},{originColumn.D:F2}");

                HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.ModelOriginContours, row, column, 60, 0);
            }
            else
            {
                MessageBox.Show("查找模板失败");
            }
        }

        public void GetShapeModelOrigin()
        {
            HTuple row, column, angle, scale, score;
            HTuple angleStart, angleExtent;

            HOperatorSet.TupleRad((double)nudAngleStart.Value, out angleStart);
            HOperatorSet.TupleRad((double)nudAngleExtent.Value, out angleExtent);

            HOperatorSet.FindScaledShapeModel(vision.GetSrcImage(), ProductMgr.GetInstance().Param.ModelID,
                angleStart, angleExtent, (double)nudScaleMin.Value, (double)nudScaleMax.Value, (double)nudMinScore.Value,
                (int)nudNumMatches.Value, (double)nudMaxOverlap.Value, cmbSubPixel.Text, (int)nudFindLeves.Value,
                (double)nudGreediness.Value, out row, out column, out angle, out scale, out score);

            //HTuple originRow = (double)nudRow.Value - row;
            //HTuple originColumn = (double)nudColumn.Value - column;

            //HTuple originRow;
            //HTuple originColumn;

            //HOperatorSet.GetShapeModelOrigin(ProductMgr.GetInstance().Param.ModelID, out originRow, out originColumn);

            //ProductMgr.GetInstance().Param.ModelOriginRow = originRow;
            //ProductMgr.GetInstance().Param.ModelOriginColumn = originColumn;

            nudRow.Value = row /*+ originRow*/;
            nudColumn.Value = column /*+ originColumn*/;
        }

        private void OperatorSet(HObject region2)
        {
            if (ProductMgr.GetInstance().Param.Roi == null)
            {
                ProductMgr.GetInstance().Param.Roi = region2;
            }
            else
            {
                HObject newRoi;
                HOperatorSet.GenEmptyObj(out newRoi);

                if (rdbUnion.Checked)
                {
                    HOperatorSet.Union2(ProductMgr.GetInstance().Param.Roi, region2, out newRoi);
                }
                else if (rdbIntersection.Checked)
                {
                    HOperatorSet.Intersection(ProductMgr.GetInstance().Param.Roi, region2, out newRoi);
                }
                else if (rdbDifference.Checked)
                {
                    HOperatorSet.Difference(ProductMgr.GetInstance().Param.Roi, region2, out newRoi);
                }

                ProductMgr.GetInstance().Param.Roi.Dispose();
                ProductMgr.GetInstance().Param.Roi = newRoi;
            }

            //CreateScaledShapeModel();
            //FindScaledShapeModel();

            AddStack();
            visionControl1.DisplayResults();
            AddStack();

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;
            groupBox1.Enabled = true;
            tabControl1.Enabled = true;
        }

        /// <summary>
        /// 显示对象
        /// </summary>
        private void AddStack()
        {
            if (ProductMgr.GetInstance().Param.Roi != null && ProductMgr.GetInstance().Param.Roi.IsInitialized())
            {
                visionControl1.AddToStack(ProductMgr.GetInstance().Param.Roi);
            }

            if (ProductMgr.GetInstance().Param.ModelContours != null && ProductMgr.GetInstance().Param.ModelContours.IsInitialized())
            {
                visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelContours);
            }

            if (ProductMgr.GetInstance().Param.ModelOriginContours != null && ProductMgr.GetInstance().Param.ModelOriginContours.IsInitialized())
            {
                visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelOriginContours);
            }

            if (ProductMgr.GetInstance().Param.MarkContours != null && ProductMgr.GetInstance().Param.MarkContours.IsInitialized())
            {
                visionControl1.AddToStack(ProductMgr.GetInstance().Param.MarkContours);
            }
            //for (int i = 0; i < MeasureMgr.GetInstance().MeasureList.Count; i++)
            //{
            /*int index = lstMeasureList.SelectedIndex;
            if (index >= 0)
            {
                if (MeasureMgr.GetInstance().MeasureList[index].Line != null)
                {
                    visionControl1.AddToStack(MeasureMgr.GetInstance().MeasureList[index].Line);
                }

                if (MeasureMgr.GetInstance().MeasureList[index].LinesFirst != null)
                {
                    for (int j = 0; j < MeasureMgr.GetInstance().MeasureList[index].LinesFirst.CountObj(); j++)
                    {
                        HObject line;
                        HOperatorSet.SelectObj(MeasureMgr.GetInstance().MeasureList[index].LinesFirst, out line, j + 1);
                        visionControl1.AddToStack(line);
                    }
                }

                //if (MeasureMgr.GetInstance().MeasureList[index].LinesSecond != null)
                //{
                //    for (int j = 0; j < MeasureMgr.GetInstance().MeasureList[index].LinesSecond.CountObj(); j++)
                //    {
                //        HObject line;
                //        HOperatorSet.SelectObj(MeasureMgr.GetInstance().MeasureList[index].LinesSecond, out line, j + 1);
                //        visionControl1.AddToStack(line);
                //    }
                //}
            }
            */
            //}
        }

        #region 事件

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.AddRange(new DataGridViewTextBoxCell(),
                    new DataGridViewTextBoxCell(),
                    new DataGridViewTextBoxCell(),
                    new DataGridViewTextBoxCell());

                dgvCalib.Rows.Add(row);
            }

            //初始化窗口
            visionControl1.ImageWidth = 5472;
            visionControl1.ImageHeight = 3648;
            visionControl1.InitWindow();

            ////添加相机并绑定到窗口
            VisionMgr.GetInstance().BindWindow(VisionStepName.MainPos, visionControl1);
            VisionMgr.GetInstance().BindWindow(VisionStepName.MainMea, visionControl1);

            //图像分割
            //ckbPerprocess.Checked = ProductMgr.GetInstance().Param.IsPerprocess;

            //将流程添加到下拉框
            cmbProcess.Items.Add(VisionStepName.MainPos);
            cmbProcess.Items.Add(VisionStepName.MainMea);
            cmbProcess.SelectedIndex = 1;

            cmbMetric.SelectedIndex = 0;
            cmbOptimization.SelectedIndex = 2;
            cmbSubPixel.SelectedIndex = 3;

            cmbInterpolation.SelectedIndex = 0;
            cmbTransition.SelectedIndex = 0;
            cmbSelect.SelectedIndex = 0;

            dgvData.Columns.Add(DataColumns.Index, "序号");
            dgvData.Columns.Add(DataColumns.Diameter, "直径");
            dgvData.Columns.Add(DataColumns.DisLeft, "左边距");
            dgvData.Columns.Add(DataColumns.DisRight, "右边距");
            dgvData.Columns.Add(DataColumns.DisTop, "上边距");

            //dgvData.Columns[0].Width = 50;
            dgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            // 隔行背景色
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            label41.Text = $@"当前产品-{ProductMgr.GetInstance().ProductName}";
            LoadParam();
            LoadShapeModel();
            LoadMeasure();
        }

        private void MainCameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ProductMgr.GetInstance().SaveParam();
        }

        #region 图像

        /// <summary>
        /// 内容更新后，滚动到最后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            if (txtLog.TextLength >= 65536)
            {
                txtLog.Clear();
            }

            if (txtLog.TextLength <= 0)
            {
                return;
            }

            txtLog.Select(txtLog.TextLength - 1, 1);
            txtLog.ScrollToCaret();
        }

        private void btnReadImage_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }

            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                HObjectDispose();

                HObject image;
                string name = f.FileName.Replace('\\', '/');
                HOperatorSet.ReadImage(out image, name);

                vision.SetSrcImage(image);
                visionControl1.DispImageFull(image);
            }
        }

        private void btnGrabOne_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }
            continuGrab = false;

            HObjectDispose();

            vision.Snap();
            visionControl1.DispImageFull(vision.GetSrcImage());
        }

        private void btnContinuGrab_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }

            if (continuGrab)
            {
                return;
            }
            else
            {
                btnGrabOne.Enabled = false;
                btnContinuGrab.Enabled = false;
                tabControl1.Enabled = false;

                continuGrab = true;
            }

            Task.Run(() =>
            {
                while (continuGrab)
                {
                    HObjectDispose();

                    VisionMgr.GetInstance().GetCam(CameraName.MainCamera).Grab();
                    vision.imgSrc = VisionMgr.GetInstance().GetCam(CameraName.MainCamera).m_image;
                    visionControl1.DisplayResults();
                }
            });
        }

        private void btnStopGrab_Click(object sender, EventArgs e)
        {
            continuGrab = false;
            btnGrabOne.Enabled = true;
            btnContinuGrab.Enabled = true;
            tabControl1.Enabled = true;
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            vision = VisionMgr.GetInstance().GetVisionBase(cmbProcess.Text);
            visionControl1.RegisterUpdateInterface(vision);
            HOperatorSet.ClearWindow(visionControl1.GetHalconWindow());
            visionControl1.DisplayResults();
            nudExposure.Value = vision.m_ExposureTime;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                Log.Show("请选择流程");
                return;
            }

            if (vision.imgSrc == null)
            {
                Log.Show("没有图像");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存图像";
            sfd.Filter = "Tag图像文件格式(*.tiff)|*.tiff";
            //sfd.Filter = "可移植网络图形格式(*.png)|*.png|Tag图像文件格式(*.tiff)|*.tiff|设备无关位图(*.bmp)|*.bmp|文件交换格式(*.jpeg)|*.jpeg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.WriteImage(vision.GetSrcImage(), "tiff", 0, sfd.FileName.Replace('\\', '/'));
            }

            //string path = $@"{ProductMgr.GetInstance().ProductPath}MainCameraImage\";
            //if (!System.IO.Directory.Exists(path))
            //{
            //    System.IO.Directory.CreateDirectory(path);
            //}
            //string fileName = $@"{path}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            //HOperatorSet.WriteImage(vision.GetSrcImage(), "tiff", 0, fileName);
        }

        private void btnProcessImage_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }

            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                SendData.Clear();
                vision.ProcessImage(visionControl1);
                //visionControl1.DisplayResults();
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        #endregion 图像

        #region 模板

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                groupBox1.Enabled = false;
                tabControl1.Enabled = false;
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
                HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");
                HOperatorSet.SetDraw(visionControl1.GetHalconWindow(), "margin");

                HObject line;
                HTuple row1, column1, row2, column2;
                HOperatorSet.DrawLine(visionControl1.GetHalconWindow(), out row1, out column1, out row2, out column2);
                HOperatorSet.GenRegionLine(out line, row1, column1, row2, column2);
                OperatorSet(line);
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                groupBox1.Enabled = false;
                tabControl1.Enabled = false;
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
                HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");
                HOperatorSet.SetDraw(visionControl1.GetHalconWindow(), "margin");

                HObject circle;
                HTuple row, column, radius;
                HOperatorSet.DrawCircle(visionControl1.GetHalconWindow(), out row, out column, out radius);
                HOperatorSet.GenCircle(out circle, row, column, radius);
                OperatorSet(circle);
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void btnDrawRectangle1_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                groupBox1.Enabled = false;
                tabControl1.Enabled = false;
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
                HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");
                HOperatorSet.SetDraw(visionControl1.GetHalconWindow(), "margin");

                HObject rectangle;
                HTuple row1, column1, row2, column2;
                HOperatorSet.DrawRectangle1(visionControl1.GetHalconWindow(), out row1, out column1, out row2, out column2);
                HOperatorSet.GenRectangle1(out rectangle, row1, column1, row2, column2);
                OperatorSet(rectangle);
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void btnDrawRectangle2_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                groupBox1.Enabled = false;
                tabControl1.Enabled = false;
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
                HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");
                HOperatorSet.SetDraw(visionControl1.GetHalconWindow(), "margin");

                HObject rectangle;
                HTuple row, column, phi, length1, length2;
                HOperatorSet.DrawRectangle2(visionControl1.GetHalconWindow(), out row, out column, out phi, out length1, out length2);
                HOperatorSet.GenRectangle2(out rectangle, row, column, phi, length1, length2);
                OperatorSet(rectangle);
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void visionControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AddStack();
            }
        }

        private void visionControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                AddStack();
            }
        }

        private void visionControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            AddStack();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.Roi?.Dispose();
            ProductMgr.GetInstance().Param.ModelContours?.Dispose();
            ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();

            ProductMgr.GetInstance().Param.Roi = null;
            ProductMgr.GetInstance().Param.ModelContours = null;
            ProductMgr.GetInstance().Param.ModelOriginContours = null;

            visionControl1.DisplayResults();
        }

        private void btnExposure_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }

            int exposure = (int)nudExposure.Value;
            vision?.SetExposureTime(exposure);
        }

        private void btnGetPos_Click(object sender, EventArgs e)
        {
            if (vision.GetSrcImage() == null)
            {
                MessageBox.Show("请先取像");
                return;
            }

            groupBox1.Enabled = false;
            tabControl1.Enabled = false;

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
            visionControl1.Focus();

            //HObject cross;
            HTuple row, column;
            HOperatorSet.DrawPoint(visionControl1.GetHalconWindow(), out row, out column);

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;

            ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();
            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.ModelOriginContours, row, column, 60, 0);

            //SetShapeModelOrigin();
            AddStack();
            visionControl1.DisplayResults();

            nudRow.Value = (decimal)row.D;
            nudColumn.Value = (decimal)column.D;

            //visionControl1.AddToStack(cross);

            groupBox1.Enabled = true;
            tabControl1.Enabled = true;
        }

        private void btnSetOrigin_Click(object sender, EventArgs e)
        {
            if (ProductMgr.GetInstance().Param.ModelID != null)
            {
                SetShapeModelOrigin();
            }
            else
            {
                MessageBox.Show("没有模板");
                return;
            }
        }

        private void btnFindModel_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                var p = ProductMgr.GetInstance().Param;
                p.ModelOriginContours?.Dispose();
                HTuple row, column, radian, transRow, transColumn, transRadian;
                HDevelopExport.FindModelProcess(vision.imgSrc, visionControl1, out row, out column, out radian);
                if (p.IsSecondPos && row.Length > 0)
                {
                    HDevelopExport.FindPinCenter(vision.imgSrc, row, column, radian, out transRow, out transColumn, out transRadian);
                    visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelContours);
                    visionControl1.DisplayResults();
                    visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelContours);
                }
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void nudRow_ValueChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();
            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.ModelOriginContours,
                (double)nudRow.Value, (double)nudColumn.Value, 60, 0);
            AddStack();
            visionControl1.DisplayResults();
        }

        private void nudColumn_ValueChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();
            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.ModelOriginContours,
                (double)nudRow.Value, (double)nudColumn.Value, 60, 0);
            AddStack();
            visionControl1.DisplayResults();
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            LoadShapeModel();
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            HTuple row, column, radian, edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, pinRow1, pinColumn1, pinRow2, pinColumn2;
            HTuple pointRow, pointColumn, isOverlapping;
            HDevelopExport.FindModelProcess(vision.imgSrc, visionControl1, out row, out column, out radian);
            HDevelopExport.MeasureEdge(vision.imgSrc, row, column, radian, out edgeRow1, out edgeColumn1, out edgeRow2, out edgeColumn2);
            HDevelopExport.MeasurePinFirst(vision.imgSrc, row, column, radian, out pinRow1, out pinColumn1, out pinRow2, out pinColumn2);

            if (edgeRow1.Length > 0 && pinRow1.Length > 0)
            {
                HTuple transRadian, transRow, transColumn;
                HOperatorSet.AngleLx(edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, out transRadian);
                HOperatorSet.IntersectionLines(edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, pinRow1, pinColumn1, pinRow2, pinColumn2,
                    out pointRow, out pointColumn, out isOverlapping);

                var p = ProductMgr.GetInstance().Param;
                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                //HOperatorSet.HomMat2dTranslate(homMat2D, p.SecondRow, p.SecondColumn, out homMat2D);
                HOperatorSet.HomMat2dRotate(homMat2D, -transRadian, pointRow, pointColumn, out homMat2D);
                HOperatorSet.AffineTransPixel(homMat2D, row, column, out transRow, out transColumn);

                p.SecondRow = transRow - pointRow;
                p.SecondColumn = transColumn - pointColumn;
                p.SecondRadianDiff = transRadian - radian;

                SaveShapeModel();
                MessageBox.Show("保存模板完成");

            }
            else
            {
                MessageBox.Show("保存模板失败");
            }
        }

        private void btnSaveFindConfig_Click(object sender, EventArgs e)
        {
            var param = ProductMgr.GetInstance().Param;

            param.FindAngleStart = (double)nudAngleStart.Value;
            param.FindAngleExtent = (double)nudAngleExtent.Value;
            param.FindScaleMin = (double)nudScaleMin.Value;
            param.FindScaleMax = (double)nudScaleMax.Value;
            param.FindScore = (double)nudMinScore.Value;
            param.FindNumMatches = (double)nudNumMatches.Value;
            param.FindMaxOverlap = (double)nudMaxOverlap.Value;
            param.FindSubPixel = cmbSubPixel.Text;
            param.FindLevels = (int)nudFindLeves.Value;
            param.FindGreediness = (double)nudGreediness.Value;

            ProductMgr.GetInstance().SaveParam();
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                CreateScaledShapeModel();
                btnFindModel_Click(btnFindModel, null);
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void nudAngleStart_ValueChanged(object sender, EventArgs e)
        {
            tcbAngleStart.Value = (int)nudAngleStart.Value;
            ProductMgr.GetInstance().Param.FindAngleStart = (double)nudAngleStart.Value;
        }

        private void nudAngleExtent_ValueChanged(object sender, EventArgs e)
        {
            tcbAngleExtent.Value = (int)nudAngleExtent.Value;
            ProductMgr.GetInstance().Param.FindAngleExtent = (double)nudAngleExtent.Value;
        }

        private void nudScaleMin_ValueChanged(object sender, EventArgs e)
        {
            tcbScaleMin.Value = (int)(nudScaleMin.Value * 10);
            ProductMgr.GetInstance().Param.FindScaleMin = (double)nudScaleMin.Value;
        }

        private void nudScaleMax_ValueChanged(object sender, EventArgs e)
        {
            tcbScaleMax.Value = (int)(nudScaleMax.Value * 10);
            ProductMgr.GetInstance().Param.FindScaleMax = (double)nudScaleMax.Value;
        }

        private void nudContrastLow_ValueChanged(object sender, EventArgs e)
        {
            if (nudContrastLow.Value > nudContrastHigh.Value)
            {
                nudContrastHigh.Value = nudContrastLow.Value;
                return;
            }

            tcbContrastLow.Value = (int)nudContrastLow.Value;
            ProductMgr.GetInstance().Param.ContrastLow = (int)nudContrastLow.Value;
        }

        private void nudContrastHigh_ValueChanged(object sender, EventArgs e)
        {
            if (nudContrastHigh.Value < nudContrastLow.Value)
            {
                nudContrastLow.Value = nudContrastHigh.Value;
                return;
            }

            tcbContrastHigh.Value = (int)nudContrastHigh.Value;
            ProductMgr.GetInstance().Param.ContrastHigh = (int)nudContrastHigh.Value;
        }

        private void nudNumLevels_ValueChanged(object sender, EventArgs e)
        {
            tcbNumLevels.Value = (int)nudNumLevels.Value;
        }

        private void cmbMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbOptimization_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void nudMinContrast_ValueChanged(object sender, EventArgs e)
        {
            tcbMinContrast.Value = (int)nudMinContrast.Value;
        }

        private void nudMinScore_ValueChanged(object sender, EventArgs e)
        {
            tcbMinScore.Value = (int)(nudMinScore.Value * 10);
            ProductMgr.GetInstance().Param.FindScore = (double)nudMinScore.Value;
        }

        private void nudNumMatches_ValueChanged(object sender, EventArgs e)
        {
            tcbNumMatches.Value = (int)nudNumMatches.Value;
            ProductMgr.GetInstance().Param.FindNumMatches = (int)nudNumMatches.Value;
        }

        private void nudGreediness_ValueChanged(object sender, EventArgs e)
        {
            tcbGreediness.Value = (int)(nudGreediness.Value * 10);
            ProductMgr.GetInstance().Param.FindGreediness = (double)nudGreediness.Value;
        }

        private void nudMaxOverlap_ValueChanged(object sender, EventArgs e)
        {
            tcbMaxOverlap.Value = (int)(nudMaxOverlap.Value * 10);
            ProductMgr.GetInstance().Param.FindMaxOverlap = (double)nudMaxOverlap.Value;
        }

        private void cmbSubPixel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.FindSubPixel = cmbSubPixel.Text;
        }

        private void nudFindLeves_ValueChanged(object sender, EventArgs e)
        {
            tcbFindLevels.Value = (int)nudFindLeves.Value;
            ProductMgr.GetInstance().Param.FindLevels = (double)nudFindLeves.Value;
        }

        private void tcbContrastLow_Scroll(object sender, EventArgs e)
        {
            nudContrastLow.Value = tcbContrastLow.Value;
        }

        private void tcbContrastHigh_Scroll(object sender, EventArgs e)
        {
            nudContrastHigh.Value = tcbContrastHigh.Value;
        }

        private void tcbNumLevels_Scroll(object sender, EventArgs e)
        {
            nudNumLevels.Value = tcbNumLevels.Value;
        }

        private void tcbAngleStart_Scroll(object sender, EventArgs e)
        {
            nudAngleStart.Value = tcbAngleStart.Value;
        }

        private void tcbAngleExtent_Scroll(object sender, EventArgs e)
        {
            nudAngleExtent.Value = tcbAngleExtent.Value;
        }

        private void tcbScaleMin_Scroll(object sender, EventArgs e)
        {
            nudScaleMin.Value = tcbScaleMin.Value / 10;
        }

        private void tcbScaleMax_Scroll(object sender, EventArgs e)
        {
            nudScaleMax.Value = tcbScaleMax.Value / 10;
        }

        private void tcbMinContrast_Scroll(object sender, EventArgs e)
        {
            nudMinContrast.Value = tcbMinContrast.Value;
        }

        private void tcbMinScore_Scroll(object sender, EventArgs e)
        {
            nudMinScore.Value = tcbMinScore.Value / 10;
        }

        private void tcbNumMatches_Scroll(object sender, EventArgs e)
        {
            nudNumMatches.Value = tcbNumMatches.Value;
        }

        private void tcbGreediness_Scroll(object sender, EventArgs e)
        {
            nudGreediness.Value = tcbGreediness.Value;
        }

        private void tcbMaxOverlap_Scroll(object sender, EventArgs e)
        {
            nudMaxOverlap.Value = tcbMaxOverlap.Value;
        }

        private void tcbFindLevels_Scroll(object sender, EventArgs e)
        {
            nudFindLeves.Value = tcbFindLevels.Value;
        }

        private void tbpPickScreen_Click(object sender, EventArgs e)
        {
        }

        private void ckbPreprocess_CheckedChanged(object sender, EventArgs e)
        {
            //ProductMgr.GetInstance().Param.IsPerprocess = ckbPerprocess.Checked;
            return;
            if (ckbPerprocess.Checked)
            {
                nudEmphasize.Enabled = true;
                ckbAdjustImage.Enabled = true;
                btnImagePer.Enabled = true;
                label49.Enabled = true;

                ProductMgr.GetInstance().Param.Emphasize = (int)nudEmphasize.Value;
            }
            else
            {
                nudEmphasize.Enabled = false;
                ckbAdjustImage.Enabled = false;
                btnImagePer.Enabled = false;
                label49.Enabled = false;
            }

            ProductMgr.GetInstance().SaveParam();
        }

        #endregion 模板

        #region 测量

        private void lstMeasureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstMeasureList.SelectedIndex;

            if (index >= 0)
            {
                //清理数据结果
                foreach (var m in MeasureMgr.GetInstance().MeasureList)
                {
                    m.ClearResult();
                }

                visionControl1.clearObj();

                var mea = MeasureMgr.GetInstance().MeasureList[index];

                SubValueChanged();
                UpdataControl(mea);
                MeasurePos();
                AddValueChanged();
            }
        }

        private void btnDrawMeasure_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc == null)
            {
                Log.Show("没有图像");
                return;
            }

            //清理数据结果
            foreach (var m in MeasureMgr.GetInstance().MeasureList)
            {
                m.ClearResult();
            }

            visionControl1.clearObj();
            visionControl1.DisplayResults();

            groupBox1.Enabled = false;
            tabControl1.Enabled = false;

            visionControl1.Focus();
            visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;

            HTuple row, column;
            HOperatorSet.DrawPoint(visionControl1.GetHalconWindow(), out row, out column);

            var mea = new MeasureMgr.MeasurePin();
            mea.Gen(row, column, 0);
            MeasureMgr.GetInstance().MeasureList.Add(mea);

            lstMeasureList.Items.Clear();
            var measureList = MeasureMgr.GetInstance().MeasureList;
            for (int i = 0; i < measureList.Count; i++)
            {
                lstMeasureList.Items.Add($"ROI{i}");
            }

            lstMeasureList.SelectedIndex = lstMeasureList.Items.Count - 1;

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;

            groupBox1.Enabled = true;
            tabControl1.Enabled = true;
        }

        private void SubValueChanged()
        {
            nudMeasureRoiRow.ValueChanged -= nudMeasureRoiRow_ValueChanged;
            nudMeasureRoiColumn.ValueChanged -= nudMeasureRoiColumn_ValueChanged;
            nudMeasureRoiWidth.ValueChanged -= nudMeasureRoiWidth_ValueChanged;
            nudMeasureRoiHeight.ValueChanged -= nudMeasureRoHeight_ValueChanged;
            nudMeasureRoiPhi.ValueChanged -= nudMeasureRoiPhi_ValueChanged;
            nudDisEdge.ValueChanged -= nudDisEdge_ValueChanged;

            nudThreshold.ValueChanged -= nudThreshold_ValueChanged;
            nudSigma.ValueChanged -= nudSigma_ValueChanged;

            nudPinCount.ValueChanged -= nudPinCount_ValueChanged;
            nudPinDistance.ValueChanged -= nudPinDistance_ValueChanged;
            nudDiameterMax.ValueChanged -= nudDiameterMax_ValueChanged;
            nudDiameterMin.ValueChanged -= nudDiameterMin_ValueChanged;
            nudMaginLeft.ValueChanged -= nudMaginLeft_ValueChanged;
            nudMaginRight.ValueChanged -= nudMaginRight_ValueChanged;
            nudMaginTop.ValueChanged -= nudMaginTop_ValueChanged;
        }

        private void AddValueChanged()
        {
            nudMeasureRoiRow.ValueChanged += nudMeasureRoiRow_ValueChanged;
            nudMeasureRoiColumn.ValueChanged += nudMeasureRoiColumn_ValueChanged;
            nudMeasureRoiWidth.ValueChanged += nudMeasureRoiWidth_ValueChanged;
            nudMeasureRoiHeight.ValueChanged += nudMeasureRoHeight_ValueChanged;
            nudMeasureRoiPhi.ValueChanged += nudMeasureRoiPhi_ValueChanged;
            nudDisEdge.ValueChanged += nudDisEdge_ValueChanged;

            nudThreshold.ValueChanged += nudThreshold_ValueChanged;
            nudSigma.ValueChanged += nudSigma_ValueChanged;

            nudPinCount.ValueChanged += nudPinCount_ValueChanged;
            nudPinDistance.ValueChanged += nudPinDistance_ValueChanged;
            nudDiameterMax.ValueChanged += nudDiameterMax_ValueChanged;
            nudDiameterMin.ValueChanged += nudDiameterMin_ValueChanged;
            nudMaginLeft.ValueChanged += nudMaginLeft_ValueChanged;
            nudMaginRight.ValueChanged += nudMaginRight_ValueChanged;
            nudMaginTop.ValueChanged += nudMaginTop_ValueChanged;
        }

        private void UpdataControl(MeasureMgr.MeasurePin mea)
        {
            nudMeasureRoiRow.Value = (decimal)mea.CenterRow;
            nudMeasureRoiColumn.Value = (decimal)mea.CenterColumn;
            nudMeasureRoiWidth.Value = (decimal)mea.Width;
            nudMeasureRoiHeight.Value = (decimal)mea.Height;
            HTuple degree;
            HOperatorSet.TupleDeg(mea.Radian, out degree);
            nudMeasureRoiPhi.Value = (decimal)degree.D;
            nudDisEdge.Value = (decimal)mea.DisHanldeRow;

            nudThreshold.Value = (decimal)mea.Threshold;
            nudSigma.Value = (decimal)mea.Sigma;

            nudPinCount.Value = mea.PinCount;
            nudPinDistance.Value = (decimal)PlatformCalibData.PixelToMm(mea.PinDistance);
            nudDiameterMax.Value = (decimal)mea.LimiteDiameterMax;
            nudDiameterMin.Value = (decimal)mea.LimiteDiameterMin;
            nudMaginLeft.Value = (decimal)mea.LimiteLeft;
            nudMaginRight.Value = (decimal)mea.LimiteRight;
            nudMaginTop.Value = (decimal)mea.LimiteTopMin;
            nudMaginTopMax.Value = (decimal)mea.LimiteTopMax;
        }

        private void MeasurePos()
        {
            int index = lstMeasureList.SelectedIndex;
            if (index >= 0 && vision.imgSrc != null)
            {
                var mea = MeasureMgr.GetInstance().MeasureList[index];
                mea.ClearResult();

                mea.Sigma = (double)nudSigma.Value;
                mea.Threshold = (double)nudThreshold.Value;

                mea.PinCount = (int)nudPinCount.Value;
                mea.PinDistance = PlatformCalibData.MmToPixel((double)nudPinDistance.Value);
                mea.LimiteDiameterMax = (double)nudDiameterMax.Value;
                mea.LimiteDiameterMin = (double)nudDiameterMin.Value;
                mea.LimiteLeft = (double)nudMaginLeft.Value;
                mea.LimiteRight = (double)nudMaginRight.Value;
                mea.LimiteTopMin = (double)nudMaginTop.Value;
                mea.LimiteTopMax = (double)nudMaginTopMax.Value;

                mea.MeasurePos(vision.imgSrc);

                visionControl1.DisplayResults();
            }
        }

        private void btnDelMeasure_Click(object sender, EventArgs e)
        {
            int index = lstMeasureList.SelectedIndex;

            if (index >= 0)
            {
                MeasureMgr.GetInstance().Del(index);

                lstMeasureList.Items.Clear();
                var measureList = MeasureMgr.GetInstance().MeasureList;
                for (int i = 0; i < measureList.Count; i++)
                {
                    lstMeasureList.Items.Add($"ROI{i}");
                }

                lstMeasureList.SelectedIndex = lstMeasureList.Items.Count - 1;

                AddStack();
                visionControl1.DisplayResults();
                AddStack();
            }
        }

        private void nudMeasureRoiRow_ValueChanged(object sender, EventArgs e)
        {
            GenMeasure();
        }

        private void nudMeasureRoiColumn_ValueChanged(object sender, EventArgs e)
        {
            GenMeasure();
        }

        private void nudMeasureRoiPhi_ValueChanged(object sender, EventArgs e)
        {
            GenMeasure();
        }

        private void nudMeasureRoiWidth_ValueChanged(object sender, EventArgs e)
        {
            GenMeasure();
        }

        private void nudMeasureRoHeight_ValueChanged(object sender, EventArgs e)
        {
            GenMeasure();
        }

        private void GenMeasure()
        {
            int index = lstMeasureList.SelectedIndex;
            if (index >= 0 && tabControl1.Enabled == true && vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                var mea = MeasureMgr.GetInstance().MeasureList[index];

                double rowCenter = (double)nudMeasureRoiRow.Value;
                double columnCenter = (double)nudMeasureRoiColumn.Value;
                double degree = (double)nudMeasureRoiPhi.Value;
                HTuple radian;
                HOperatorSet.TupleRad(degree, out radian);

                double width = (double)nudMeasureRoiWidth.Value;
                double height = (double)nudMeasureRoiHeight.Value;
                double disLine = (double)nudDisEdge.Value;
                double disPin = (double)nudPinDistance.Value;
                int count = (int)nudPinCount.Value;

                mea.Close();
                mea.Gen(rowCenter, columnCenter, radian.D, width, height, disLine, disPin, count);

                MeasurePos();
            }
        }

        private void cmbInterpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChangeMeasurePos();
        }

        private void ckbPairs_CheckedChanged(object sender, EventArgs e)
        {
            //ChangeMeasurePos();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            tcbThreshold.Value = (int)nudThreshold.Value;

            MeasurePos();
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            tcbSigma.Value = (int)(nudSigma.Value * 10);

            MeasurePos();
        }

        private void cmbTransition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MeasurePos();
        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MeasurePos();
        }

        private void tcbThreshold_Scroll(object sender, EventArgs e)
        {
            nudThreshold.Value = tcbThreshold.Value;
        }

        private void tcbSigma_Scroll(object sender, EventArgs e)
        {
            nudSigma.Value = (decimal)(tcbSigma.Value * 1.0 / 10);
        }

        private void btnSaveMeasure_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                //获取图像
                HObject image = vision.GetSrcImage();

                //查找模板
                HTuple row, column, radModel;
                bool result = HDevelopExport.FindModelProcess(image, visionControl1, out row, out column, out radModel);

                //显示轮廓
                //HDevelopExport.dev_display_shape_matching_results(visionControl1.GetHalconWindow(),
                //    ProductMgr.GetInstance().Param.ModelID, "blue", row, column, angle, scale, scale, 0);

                if (result && ProductMgr.GetInstance().Param.IsSecondPos)
                {
                    HTuple transRow, transColumn, transRadian;
                    result = HDevelopExport.FindPinCenter(vision.imgSrc, row, column, radModel, out transRow, out transColumn, out transRadian);

                    if (result)
                    {
                        row = transRow;
                        column = transColumn;
                        radModel = transRadian;
                    }

                    //ctl.DisplayResults();
                }

                if (row.Length > 0)
                {
                    //计算每个测量对象与模板的相对位置关系
                    foreach (var mea in MeasureMgr.GetInstance().MeasureList)
                    {
                        mea.MeasurePos(image);

                        HTuple homMat2D;
                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dTranslate(homMat2D, mea.CenterRow - row, mea.CenterColumn - column, out homMat2D);

                        mea.PosHomMat2d = homMat2D;
                        mea.PosRadianDiff = mea.Radian - radModel;
                        //mea.DisHanldeRow = -ProductMgr.GetInstance().Param.SecondRow;
                    }

                    //保存测量所有数据
                    MeasureMgr.GetInstance().Save($"{ProductMgr.GetInstance().ProductPath}Measure\\");

                    ShowLog("保存测量数据完成");
                }
                else
                {
                    ShowLog("模板查找失败，无法保存测量数据");
                }
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void btnMeasureTest_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                HTuple row, column, angle;
                bool result = HDevelopExport.FindModelProcess(vision.imgSrc, visionControl1, out row, out column, out angle);

                if (row.Length > 0)
                {
                    MeasureMgr.GetInstance().MeasureAll(vision.imgSrc, row, column, angle);
                }
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void btnImagePer_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                HObject image;
                if (ProductMgr.GetInstance().Param.PlatformRegion != null)
                {
                    HOperatorSet.ReduceDomain(vision.imgSrc, ProductMgr.GetInstance().Param.PlatformRegion, out image);
                }
                else
                {
                    //HOperatorSet.CopyImage(vision.imgSrc, out image);
                    ShowLog("请先绘制图像检测区域");
                    return;
                }

                vision.imgSrc = HDevelopExport.Preprocess(image, ProductMgr.GetInstance().Param.Emphasize, ckbAdjustImage.Checked);

                visionControl1.DisplayResults();
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void nudDiameterMax_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudDiameterMin_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudMaginLeft_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudMaginRight_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudMaginTop_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudMaginTopMax_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void btnPlatformRegion_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                groupBox1.Enabled = false;
                tabControl1.Enabled = false;
                HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
                visionControl1.Focus();

                //绘制
                HObject rect;
                HTuple row1, column1, row2, column2;
                HOperatorSet.DrawRectangle1(visionControl1.GetHalconWindow(), out row1, out column1, out row2, out column2);
                HOperatorSet.GenRectangle1(out rect, row1, column1, row2, column2);

                ProductMgr.GetInstance().Param.PlatformRegion?.Dispose();
                ProductMgr.GetInstance().Param.PlatformRegion = rect;

                //写入文件
                string filename = $@"{System.Environment.CurrentDirectory}\Product\PlatformRegion".Replace("\\", "/");
                HOperatorSet.WriteRegion(rect, filename);

                ShowLog($"区域设置成功");
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;
                groupBox1.Enabled = true;
                tabControl1.Enabled = true;
            }
        }

        private void btnRobotRegion_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                groupBox1.Enabled = false;
                tabControl1.Enabled = false;
                HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");
                visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
                visionControl1.Focus();

                //绘制
                HObject rect;
                HTuple row1, column1, row2, column2;
                HOperatorSet.DrawRectangle1(visionControl1.GetHalconWindow(), out row1, out column1, out row2, out column2);
                HOperatorSet.GenRectangle1(out rect, row1, column1, row2, column2);

                ProductMgr.GetInstance().Param.RobotRegion?.Dispose();
                ProductMgr.GetInstance().Param.RobotRegion = rect;

                //写入文件
                string filename = $@"{System.Environment.CurrentDirectory}\Product\RobotRegion".Replace("\\", "/");
                HOperatorSet.WriteRegion(rect, filename);

                ShowLog($"区域设置成功");

                visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;
                groupBox1.Enabled = true;
                tabControl1.Enabled = true;
            }
        }

        private void nudExposure_ValueChanged(object sender, EventArgs e)
        {
            int exposure = (int)nudExposure.Value;
            vision?.SetExposureTime(exposure);
        }

        private void btnCalibFindModel_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                HTuple row, column, radian;
                bool result = HDevelopExport.FindModelProcess(vision.imgSrc, visionControl1, out row, out column, out radian);

                if (result)
                {
                    int index = -1;
                    if (dgvCalib.SelectedCells.Count > 0)
                    {
                        index = dgvCalib.SelectedCells[0].RowIndex;
                    }

                    if (index >= 0)
                    {
                        dgvCalib.Rows[index].Cells[2].Value = column.D;
                        dgvCalib.Rows[index].Cells[3].Value = row.D;
                    }
                }
                else
                {
                    MessageBox.Show("模板查找失败");
                }
            }
            else
            {
                ShowLog("没有图像");
            }
        }

        private void btnCalibData_Click(object sender, EventArgs e)
        {
            try
            {
                //标定
                HObject ho_ContCircle;
                HTuple hv_radius;

                //三点标定
                HTuple hv_pixelRows = new HTuple();
                HTuple hv_pixelColumns = new HTuple();
                HTuple hv_worldY = new HTuple();
                HTuple hv_worldX = new HTuple();

                for (int i = 0; i < 3; i++)
                {
                    hv_worldX.Append(Convert.ToDouble(dgvCalib.Rows[i].Cells[0].Value));
                    hv_worldY.Append(Convert.ToDouble(dgvCalib.Rows[i].Cells[1].Value));
                    hv_pixelColumns.Append(Convert.ToDouble(dgvCalib.Rows[i].Cells[2].Value));
                    hv_pixelRows.Append(Convert.ToDouble(dgvCalib.Rows[i].Cells[3].Value));
                }

                HDevelopExport.calib_three_point(hv_pixelRows, hv_pixelColumns, hv_worldY, hv_worldX,
                    out PlatformCalibData.HomMat2D, out PlatformCalibData.RowError, out PlatformCalibData.ColumnError);

                Log.Show($"三点标定成功，最大误差：{PlatformCalibData.RowError.D:F3},{PlatformCalibData.ColumnError.D:F3}");

                //毫米每像素  3-邻边/4-对边/5-斜边
                HTuple pixelRow1, pixelCol1, pixelRow2, pixelCol2, diffRow, diffCol, hypotenuse/*斜边*/;

                HOperatorSet.AffineTransPoint2d(PlatformCalibData.HomMat2D, 0, 0, out pixelCol1, out pixelRow1);
                HOperatorSet.AffineTransPoint2d(PlatformCalibData.HomMat2D, 3, 4, out pixelCol2, out pixelRow2);

                HOperatorSet.TupleSub(pixelCol2, pixelCol1, out diffCol);
                HOperatorSet.TupleSub(pixelRow2, pixelRow1, out diffRow);
                HOperatorSet.TupleSqrt(diffCol * diffCol + diffRow * diffRow, out hypotenuse);
                HOperatorSet.TupleDiv(hypotenuse, 5, out PlatformCalibData.MmPerPixel);

                Log.Show($"{PlatformCalibData.MmPerPixel.D:F3}毫米每像素");

                //标定旋转中心
                //HTuple pixelRows = new HTuple();
                //HTuple pixelColumns = new HTuple();

                //int length = hv_pixelRows.Length;

                //for (int i = 3; i < length; i++)
                //{
                //    pixelRows.Append(hv_pixelRows[i]);
                //    pixelColumns.Append(hv_pixelColumns[i]);
                //}

                //标定旋转中心
                //HDevelopExport.calib_rotate_center(out ho_ContCircle, pixelRows, pixelColumns,
                //    out PlatformCalibData.CenterRow, out PlatformCalibData.CenterColumn, out hv_radius, out PlatformCalibData.CircleError);

                //Log.Show($"旋转标定成功，中心点：{PlatformCalibData.CenterRow.D:F3},{PlatformCalibData.CenterColumn.D:F3},最大误差：{PlatformCalibData.CircleError.D:F3}");

                //标定的数据保存到Product文件夹下
                string fileName = $@"{System.Environment.CurrentDirectory}\Product\Calib.ini";

                //IniTool.Set(fileName, "calib", "CenterRow", PlatformCalibData.CenterRow.ToString());
                //IniTool.Set(fileName, "calib", "CenterColumn", PlatformCalibData.CenterColumn.ToString());
                IniTool.Set(fileName, "calib", "MmPerPixel", PlatformCalibData.MmPerPixel.ToString());

                //写入矩阵
                if (PlatformCalibData.HomMat2D != null)
                {
                    string path = $@"{System.Environment.CurrentDirectory}\Product\HomMat2D.hm".Replace("\\", "/");
                    HOperatorSet.WriteTuple(PlatformCalibData.HomMat2D, path);
                }

                MessageBox.Show("标定成功");

                return;
            }
            catch (Exception)
            {
                MessageBox.Show("标定失败");
                return;
            }
        }

        private void btnGetMark_Click(object sender, EventArgs e)
        {
            if (vision.GetSrcImage() == null)
            {
                MessageBox.Show("请先取像");
                return;
            }

            groupBox1.Enabled = false;
            tabControl1.Enabled = false;

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
            visionControl1.Focus();

            HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "blue");

            //HObject cross;
            HTuple row, column;
            HOperatorSet.DrawPoint(visionControl1.GetHalconWindow(), out row, out column);

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;

            ProductMgr.GetInstance().Param.MarkContours?.Dispose();
            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.MarkContours, row, column, 60, 0);

            //SetShapeModelOrigin();
            AddStack();
            visionControl1.DisplayResults();

            nudMarkRow.Value = (decimal)row.D;
            nudMarkColumn.Value = (decimal)column.D;

            //visionControl1.AddToStack(cross);

            groupBox1.Enabled = true;
            tabControl1.Enabled = true;
        }

        private void btnSaveMark_Click(object sender, EventArgs e)
        {
            //标定的数据保存到Product文件夹下
            string fileName = $@"{System.Environment.CurrentDirectory}\Product\Calib.ini";

            HTuple rad;
            HOperatorSet.TupleRad((double)nudMarkColumn.Value, out rad);

            PlatformCalibData.MarkRow = (double)nudMarkRow.Value;
            PlatformCalibData.MarkColumn = (double)nudMarkColumn.Value;
            //PlatformCalibData.MarkRadian = rad;

            IniTool.Set(fileName, "mark", "row", PlatformCalibData.MarkRow.ToString());
            IniTool.Set(fileName, "mark", "column", PlatformCalibData.MarkColumn.ToString());
            //IniTool.Set(fileName, "mark", "radian", rad.ToString());

            ShowLog($"保存平台Mark点成功");
        }

        private void nudMarkRow_ValueChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.MarkContours?.Dispose();
            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.MarkContours,
                (double)nudMarkRow.Value, (double)nudMarkColumn.Value, 60, 0);
            AddStack();
            visionControl1.DisplayResults();
        }

        private void nudMarkColumn_ValueChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.MarkContours?.Dispose();
            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.MarkContours,
                (double)nudMarkRow.Value, (double)nudMarkColumn.Value, 60, 0);
            AddStack();
            visionControl1.DisplayResults();
        }

        private void nudEmphasize_ValueChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.Emphasize = (double)nudEmphasize.Value;
        }

        private void nudDisEdge_ValueChanged(object sender, EventArgs e)
        {
            GenMeasure();
        }

        private void nudPinCount_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudPinDistance_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void ckbSecondPos_CheckedChanged(object sender, EventArgs e)
        {
            ProductMgr.GetInstance().Param.IsSecondPos = ckbSecondPos.Checked;
        }

        private void nudOffsetDia_ValueChanged(object sender, EventArgs e)
        {
            string fileName = $@"{System.Environment.CurrentDirectory}\Product\Calib.ini";
            MeasureMgr.GetInstance().OffsetDia = (double)nudOffsetDia.Value;
            IniTool.Set(fileName, "offset", "dia", MeasureMgr.GetInstance().OffsetDia.ToString());
        }

        private void tetb1_TextChanged(object sender, EventArgs e)
        {

        }





        #endregion 测量

        #endregion 事件

        ///////////////
    }
}