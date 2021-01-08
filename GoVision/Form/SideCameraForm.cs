using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace GoVision
{
    public partial class SideCameraForm : Form
    {
        private VisionBase vision;  //图像处理对象
        private bool continuGrab;   //连续采集

        public SideCameraForm()
        {
            InitializeComponent();
        }

        private void MeasurePos()
        {
            if (vision.imgSrc == null)
            {
                return;
            }

            double sigma = (double)nudSigma.Value;
            double threshold = (double)nudThreshold.Value;

            var v = vision as ProcessSideMea;
            v.Sigma = sigma;
            v.Threshold = threshold;
            v.Measuer();

            visionControl1.DisplayResults();
        }

        private void SideCameraForm_Load(object sender, EventArgs e)
        {
            //添加相机并绑定到窗口
            VisionMgr.GetInstance().BindWindow(VisionStepName.SideMea, visionControl1);

            visionControl1.InitWindow();
            visionControl1.RegisterUpdateInterface(vision);

            cmbProcess.Items.Add(VisionStepName.SideMea);
            cmbProcess.SelectedIndex = 0;

            for (int i = 0; i < 2; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.AddRange(new DataGridViewTextBoxCell(),
                    new DataGridViewTextBoxCell(),
                    new DataGridViewTextBoxCell(),
                    new DataGridViewTextBoxCell());

                dgvCalib.Rows.Add(row);
            }
        }

        private void btnGrabOne_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }

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
                continuGrab = true;
            }

            Task.Run(() =>
            {
                while (continuGrab)
                {
                    VisionMgr.GetInstance().GetCam(CameraName.SideCamera).Grab();
                    vision.imgSrc = VisionMgr.GetInstance().GetCam(CameraName.MainCamera).m_image;

                    if (vision is ProcessSideMea)
                    {
                        vision.Process();
                    }

                    visionControl1.DisplayResults();
                }
            });
        }

        private void btnStopGrab_Click(object sender, EventArgs e)
        {
            continuGrab = false;
            btnGrabOne.Enabled = true;
            btnContinuGrab.Enabled = true;
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
                vision.ProcessImage(visionControl1);
            }
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
                HObject image;
                HOperatorSet.ReadImage(out image, f.FileName.Replace('\\', '/'));

                vision.SetSrcImage(image);
                visionControl1.DispImageFull(image);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (vision == null)
            {
                MessageBox.Show("请选择流程");
                return;
            }

            if (vision.imgSrc != null && vision.imgSrc.IsInitialized())
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "保存图像";
                sfd.Filter = "Tag图像文件格式(*.tiff)|*.tiff";
                //sfd.Filter = "可移植网络图形格式(*.png)|*.png|Tag图像文件格式(*.tiff)|*.tiff|设备无关位图(*.bmp)|*.bmp|文件交换格式(*.jpeg)|*.jpeg";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    HOperatorSet.WriteImage(vision.GetSrcImage(), "tiff", 0, sfd.FileName.Replace('\\', '/'));
                }

                //string path = $@"{ProductMgr.GetInstance().ProductPath}SideCameraImage\";
                //if (!System.IO.Directory.Exists(path))
                //{
                //    System.IO.Directory.CreateDirectory(path);
                //}
                //string fileName = $@"{path}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                //HOperatorSet.WriteImage(vision.GetSrcImage(), "tiff", 0, fileName);
            }
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得当前图像处理流程
            vision = VisionMgr.GetInstance().GetVisionBase(cmbProcess.Text);
            visionControl1.RegisterUpdateInterface(vision);

            //获取曝光
            nudExposure.Value = vision.m_ExposureTime;

            var v = vision as ProcessSideMea;
            nudSigma.Value = (decimal)v.Sigma.D;
            nudThreshold.Value = (decimal)v.Threshold.D;

            HOperatorSet.ClearWindow(visionControl1.GetHalconWindow());
            visionControl1.DisplayResults();
        }

        private void btnDrawMeaRect_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc == null || !vision.imgSrc.IsInitialized())
            {
                return;
            }

            groupBox1.Enabled = false;
            visionControl1.Focus();
            visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
            HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");

            var v = vision as ProcessSideMea;
            v.CloseScreen();
            visionControl1.DisplayResults();

            HObject rect;
            HTuple row, column, radian, length1, length2, imageWidth, imageHeight, measureHandle;
            HOperatorSet.DrawRectangle2(visionControl1.GetHalconWindow(),
                out row, out column, out radian, out length1, out length2);

            HOperatorSet.GetImageSize(vision.imgSrc, out imageWidth, out imageHeight);

            HOperatorSet.GenMeasureRectangle2(row, column, radian, length1, length2, imageWidth, imageHeight, "nearest_neighbor", out measureHandle);
            HOperatorSet.GenRectangle2(out rect, row, column, radian, length1, length2);
            HOperatorSet.GenContourRegionXld(rect, out rect, "border");

            v.HandleScreen = measureHandle;
            //v.MeasureRect = rect;

            MeasurePos();

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;
            groupBox1.Enabled = true;
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            MeasurePos();
        }

        private void nudExposure_ValueChanged(object sender, EventArgs e)
        {
            int exposure = (int)nudExposure.Value;
            vision?.SetExposureTime(exposure);
        }

        private void btnDrawMeaNeedle_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc == null || !vision.imgSrc.IsInitialized())
            {
                return;
            }

            groupBox1.Enabled = false;
            visionControl1.Focus();
            visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
            HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");

            var v = vision as ProcessSideMea;
            v.CloseNeedle();
            visionControl1.DisplayResults();

            HObject rect;
            HTuple row, column, radian, length1, length2, imageWidth, imageHeight, measureHandle;
            HOperatorSet.DrawRectangle2(visionControl1.GetHalconWindow(),
                out row, out column, out radian, out length1, out length2);

            HOperatorSet.GetImageSize(vision.imgSrc, out imageWidth, out imageHeight);

            HOperatorSet.GenMeasureRectangle2(row, column, radian, length1, length2, imageWidth, imageHeight, "nearest_neighbor", out measureHandle);
            HOperatorSet.GenRectangle2(out rect, row, column, radian, length1, length2);
            HOperatorSet.GenContourRegionXld(rect, out rect, "border");

            v.HandleNeedle = measureHandle;
            //v.MeasureRect = rect;

            MeasurePos();

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;
            groupBox1.Enabled = true;
        }

        private void btnDrawCalib_Click(object sender, EventArgs e)
        {
            if (vision.imgSrc == null || !vision.imgSrc.IsInitialized())
            {
                return;
            }

            groupBox1.Enabled = false;
            visionControl1.Focus();
            visionControl1.MouseMode = VisionControl.WindowMouseMode.Select;
            HOperatorSet.SetColor(visionControl1.GetHalconWindow(), "red");

            var v = vision as ProcessSideMea;
            v.CloseNeedle();
            visionControl1.DisplayResults();

            HObject rect;
            HTuple row, column, radian, length1, length2, imageWidth, imageHeight, measureHandle;
            HOperatorSet.DrawRectangle2(visionControl1.GetHalconWindow(),
                out row, out column, out radian, out length1, out length2);

            HOperatorSet.GetImageSize(vision.imgSrc, out imageWidth, out imageHeight);

            HOperatorSet.GenMeasureRectangle2(row, column, radian, length1, length2, imageWidth, imageHeight, "nearest_neighbor", out measureHandle);
            HOperatorSet.GenRectangle2(out rect, row, column, radian, length1, length2);
            HOperatorSet.GenContourRegionXld(rect, out rect, "border");

            for (int i = 0; i <= 5; i++)
            {
                HTuple threshold = v.Threshold - i * 2;
                HTuple rowEdge, columnEdge, amplitude, distance;
                HOperatorSet.MeasurePos(vision.imgSrc, measureHandle, v.Sigma, threshold, "all", "first", out rowEdge, out columnEdge, out amplitude, out distance);

                if (rowEdge.Length > 0)
                {
                    int index = -1;
                    if (dgvCalib.SelectedCells.Count > 0)
                    {
                        index = dgvCalib.SelectedCells[0].RowIndex;
                    }

                    if (index < 0)
                    {
                        break;
                    }

                    dgvCalib.Rows[index].Cells[2].Value = columnEdge.D;
                    dgvCalib.Rows[index].Cells[3].Value = rowEdge.D;

                    HTuple homMat2D, rowTrans1, colTrans1, rowTrans2, colTrans2;
                    HOperatorSet.HomMat2dIdentity(out homMat2D);
                    HOperatorSet.HomMat2dRotate(homMat2D, radian, rowEdge, columnEdge, out homMat2D);
                    HOperatorSet.AffineTransPixel(homMat2D, rowEdge - length2, columnEdge, out rowTrans1, out colTrans1);
                    HOperatorSet.AffineTransPixel(homMat2D, rowEdge + length2, columnEdge, out rowTrans2, out colTrans2);

                    v.Lines?.Dispose();
                    HOperatorSet.GenContourPolygonXld(out v.Lines,
                        new HTuple(rowTrans1, rowTrans2), new HTuple(colTrans1, colTrans2));
                }
            }

            HOperatorSet.CloseMeasure(measureHandle);
            visionControl1.DisplayResults();

            visionControl1.MouseMode = VisionControl.WindowMouseMode.Move;
            groupBox1.Enabled = true;
        }

        private void btnCalib_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(dgvCalib.Rows[0].Cells[0].Value);
            double y1 = Convert.ToDouble(dgvCalib.Rows[0].Cells[1].Value);
            double row1 = Convert.ToDouble(dgvCalib.Rows[0].Cells[3].Value);
            double col1 = Convert.ToDouble(dgvCalib.Rows[0].Cells[2].Value);

            double x2 = Convert.ToDouble(dgvCalib.Rows[1].Cells[0].Value);
            double y2 = Convert.ToDouble(dgvCalib.Rows[1].Cells[1].Value);
            double row2 = Convert.ToDouble(dgvCalib.Rows[1].Cells[3].Value);
            double col2 = Convert.ToDouble(dgvCalib.Rows[1].Cells[2].Value);

            double disW = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            double disP = Math.Sqrt((row2 - row1) * (row2 - row1) + (col2 - col1) * (col2 - col1));

            SideCameraCalibData.MmPerPixel = disW / disP;

            var v = vision as ProcessSideMea;
            v.IntraDistance = $"{SideCameraCalibData.MmPerPixel.D:F2}mm/pixel";

            visionControl1.DisplayResults();
        }
    }
}