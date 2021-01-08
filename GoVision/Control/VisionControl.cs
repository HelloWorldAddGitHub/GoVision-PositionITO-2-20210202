using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace GoVision
{
    /// <summary>
    /// 控件刷新接口,由当前占用该控件的类来负责刷新
    /// </summary>
    public interface IVisionControlUpdate
    {
        /// <summary>
        /// 界面刷新函数
        /// </summary>
        /// <param name="ctl"></param>
        void UpdateVisionControl(VisionControl ctl);
    }

    /// <summary>
    /// 图像处理显示控件
    /// </summary>
    public partial class VisionControl : PictureBox
    {
        private HTuple m_windowHandle = null;       //图像显示控件的句柄
        private Point ptMouse;
        private object imgLock = new object();
        private IVisionControlUpdate m_IVisionControlUpdate = null;
        private HObject m_img;

        public int ImageWidth = 2592;
        public int ImageHeight = 1944;

        public enum WindowMouseMode { Move, Select }

        public WindowMouseMode MouseMode { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public VisionControl()
        {
            InitializeComponent();
            //this.BackColor = System.Drawing.Color.Yellow;
            //Pen blackPen = new Pen(Color.Red, 3);
            //Point p1 = new Point(this.Width/2, 0);
            //Point p2 = new Point(this.Width/2, this.Height);
            //Graphics g = this.CreateGraphics();
            //g.DrawLine(blackPen, p1, p2);
        }

        /// <summary>
        /// 初始化halcon窗口,分辨率为2592 * 1944
        /// </summary>
        ///
   //     [DllImport("user32.dll")]static extern IntPtr GetWindowDC(IntPtr hWnd);
        public void InitWindow()
        {
            try
            {
                //          HOperatorSet.NewExternWindow(this.Handle, 0, 0, this.Width, this.Height, out m_windowHandle);
                //          HOperatorSet.SetWindowDc(m_windowHandle, GetWindowDC(this.Handle));
                HOperatorSet.OpenWindow(0, 0, this.Width, this.Height, this.Handle, "", "", out m_windowHandle);
                HOperatorSet.SetWindowParam(m_windowHandle, "background_color", "#000040");
                HOperatorSet.ClearWindow(m_windowHandle);
                HOperatorSet.SetPart(m_windowHandle, 0, 0, ImageHeight - 1, ImageWidth - 1);
            }
            catch (HalconException HDevExpDefaultException1)
            {
                System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
            }
        }

        /// <summary>
        /// 关闭halcon窗口
        /// </summary>
        public void DeinitWindow()
        {
            if (isOpen())
            {
                HOperatorSet.CloseWindow(m_windowHandle);
            }
        }

        /// <summary>
        /// 注册新的显示接口
        /// </summary>
        /// <param name="vsu"></param>
        public void RegisterUpdateInterface(IVisionControlUpdate vsu)
        {
            if (m_IVisionControlUpdate != vsu)
            {
                m_IVisionControlUpdate = vsu;
            }
        }

        /// <summary>
        /// 判断当前halcon窗口是否已经打开
        /// </summary>
        /// <returns></returns>
        private bool isOpen()
        {
            return m_windowHandle != null;
        }

        /// <summary>
        /// 获取当前的halcon句柄
        /// </summary>
        /// <returns></returns>
        public HTuple GetHalconWindow()
        {
            return m_windowHandle;
        }

        /// <summary>
        /// 锁定控件显示,其它线程不得进入
        /// </summary>
        public void LockDisplay()
        {
            System.Threading.Monitor.Enter(imgLock);
        }

        /// <summary>
        /// 解锁控件显示,其它线程可操作
        /// </summary>
        public void UnlockDisplay()
        {
            System.Threading.Monitor.Exit(imgLock);
        }

        #region 画图

        private List<HDrawingObject> drawing_objects = new List<HDrawingObject>();
        public List<string> operations = new List<string>();
        private HDrawingObject selected_drawing_object = new HDrawingObject();

        //private HDrawingObject selected_drawing_object = new HDrawingObject(250, 250, 100);
        private Stack<HObject> graphic_stack = new Stack<HObject>();

        private object stack_lock = new object();

        public void clearObj()
        {
            lock (stack_lock)
            {
                foreach (HDrawingObject dobj in drawing_objects)
                {
                    dobj.Dispose();
                }
                drawing_objects.Clear();
                graphic_stack.Clear();
                operations.Clear();
            }
            DisplayGraphicStack();
        }

        public Stack<HObject> getStack()
        {
            return graphic_stack;
        }

        public List<HDrawingObject> getDrawObjs()
        {
            return drawing_objects;
        }

        public List<string> getOperations()
        {
            operations[0] = "none";
            return operations;
        }

        public void AddDrawingObject(HDrawingObject Drawing)
        {
            drawing_objects.Add(Drawing);
        }

        public void AddOperations(string op)
        {
            operations.Add(op);
        }

        public void AddToStack(HObject obj)
        {
            lock (stack_lock)
            {
                graphic_stack.Push(obj);
            }
        }

        private void OnSelectDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            selected_drawing_object = dobj;
            SobelFilter(dobj, hwin, type);
        }

        public void AttachDrawObj(HDrawingObject obj)
        {
            drawing_objects.Add(obj);
            obj.OnDrag(SobelFilter);
            obj.OnAttach(SobelFilter);
            obj.OnResize(SobelFilter);
            obj.OnSelect(OnSelectDrawingObject);
            obj.OnAttach(SobelFilter);

            //HObject region = null;

            //if (obj.GetDrawingObjectParams("type") == "line")
            //{
            //    HTuple a = obj.GetDrawingObjectParams("row1");
            //    HOperatorSet.GenRegionLine(out region, obj.GetDrawingObjectParams("row1"),
            //        obj.GetDrawingObjectParams("column1"), obj.GetDrawingObjectParams("row2"),
            //        obj.GetDrawingObjectParams("column2"));
            //}
            //else
            //{
            //    region = new HRegion(obj.GetDrawingObjectIconic());
            //}

            //AddToStack(region);
            if (selected_drawing_object == null)
                selected_drawing_object = obj;
            // hsmartControl.HalconWindow.AttachDrawingObjectToWindow(obj);
            HOperatorSet.AttachDrawingObjectToWindow(m_windowHandle, obj);
        }

        public void SobelFilter(HDrawingObject dobj, HWindow hwin, string type)
        {
            try
            {
                HObject region = null;

                if (dobj.GetDrawingObjectParams("type") == "line")
                {
                    HTuple a = dobj.GetDrawingObjectParams("row1");
                    HOperatorSet.GenRegionLine(out region, dobj.GetDrawingObjectParams("row1"),
                        dobj.GetDrawingObjectParams("column1"), dobj.GetDrawingObjectParams("row2"),
                        dobj.GetDrawingObjectParams("column2"));
                }
                else
                {
                    region = new HRegion(dobj.GetDrawingObjectIconic());
                }

                AddToStack(region);
                DisplayResults();
            }
            catch (HalconException hex)
            {
                MessageBox.Show(hex.GetErrorMessage(), "HALCON error", MessageBoxButtons.OK);
            }
        }

        private void DisplayGraphicStack()
        {
            //清理窗口前关闭刷新，以免闪烁
            HOperatorSet.SetSystem("flush_graphic", "false");
            HOperatorSet.ClearWindow(m_windowHandle);
            HOperatorSet.SetSystem("flush_graphic", "true");

            m_IVisionControlUpdate.UpdateVisionControl(this);
            //lock (stack_lock)
            //{
            //    HOperatorSet.SetSystem("flush_graphic", "false");
            //    HOperatorSet.ClearWindow(m_windowHandle);
            //    while (graphic_stack.Count > 0)
            //    {
            //        halconWindow.HalconWindow.DispObj(graphic_stack.Pop());
            //    }
            //    HOperatorSet.SetSystem("flush_graphic", "true");
            //}
            //halconWindow.HalconWindow.DispCross(-10.0, -10.0, 3.0, 0.0);
        }

        public void DisplayResults()
        {
            try
            {
                Invoke((MethodInvoker)delegate () { DisplayGraphicStack(); });
            }
            catch (HalconException hex)
            {
                MessageBox.Show(hex.GetErrorMessage(), "HALCON error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "HALCON error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 画图

        /// <summary>
        /// 全屏显示图像
        /// </summary>
        /// <param name="img"></param>
        public void DispImageFull(HObject img)
        {
            if (img == null || !img.IsInitialized())
            {
                return;
            }
            m_img = img;
            if (!isOpen())
            {
                InitWindow();
            }
            HTuple hv_Width = null, hv_Height = null;
            HOperatorSet.GetImageSize(img, out hv_Width, out hv_Height);

            if (hv_Width == null || hv_Width.Length < 1)
            {
                return;
            }

            if (hv_Width != ImageWidth || hv_Height != ImageHeight && hv_Width != null)
            {
                ImageWidth = hv_Width;
                ImageHeight = hv_Height;
                HOperatorSet.SetPart(m_windowHandle, 0, 0, ImageHeight - 1, ImageWidth - 1);
            }
            HOperatorSet.DispObj(img, m_windowHandle);
            //HOperatorSet.DispImage(img, m_windowHandle);
            //HObject ht_CrossLineV, ht_CrossLineH;
            //HOperatorSet.SetColor(m_windowHandle, "red");
            //HOperatorSet.GenRegionLine(out ht_CrossLineV, 0, m_nWidth/2, m_nHeight, m_nWidth/2);
            //HOperatorSet.GenRegionLine(out ht_CrossLineH, m_nHeight/2, 0, m_nHeight/2, m_nWidth);
            //HOperatorSet.DispObj(ht_CrossLineV, m_windowHandle);
            //HOperatorSet.DispObj(ht_CrossLineH, m_windowHandle);
        }

        /// <summary>
        /// 鼠标滚动时缩放图片大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisionControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (MouseMode == WindowMouseMode.Move && isOpen())
            {
                HTuple row, col, button;
                HTuple row0, col0, row1, col1;
                bool bUpdate = false;

                LockDisplay();
                try
                {
                    HOperatorSet.GetMposition(m_windowHandle, out row, out col, out button);
                    HOperatorSet.GetPart(m_windowHandle, out row0, out col0, out row1, out col1);

                    HTuple width = col1 - col0;
                    HTuple height = row1 - row0;
                    float k = (float)width / ImageWidth;

                    if ((k < 50 && e.Delta < 0) || (k > 0.02 && e.Delta > 0))
                    {
                        HTuple Zoom;
                        if (e.Delta > 0)
                        {
                            Zoom = 1.3;
                        }
                        else
                        {
                            Zoom = 1 / 1.3;
                        }

                        HTuple r1 = (row0 + ((1 - (1.0 / Zoom)) * (row - row0)));
                        HTuple c1 = (col0 + ((1 - (1.0 / Zoom)) * (col - col0)));
                        HTuple r2 = r1 + (height / Zoom);
                        HTuple c2 = c1 + (width / Zoom);

                        HOperatorSet.SetPart(m_windowHandle, r1, c1, r2, c2);

                        //清理窗口前关闭刷新，以免闪烁
                        HOperatorSet.SetSystem("flush_graphic", "false");
                        HOperatorSet.ClearWindow(m_windowHandle);
                        HOperatorSet.SetSystem("flush_graphic", "true");

                        bUpdate = true;
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
                    UnlockDisplay();
                }
                if (bUpdate && m_IVisionControlUpdate != null)
                {
                    Action<object> action = (object obj) =>
                    {
                        m_IVisionControlUpdate.UpdateVisionControl(this);
                    };
                    Task t1 = new Task(action, "");
                    t1.Start();
                    t1.Wait();
                }
            }
        }

        /// <summary>
        /// 鼠标按下时切换光标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisionControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Focused == false)
            {
                this.Focus();
            }

            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Hand;
                ptMouse.X = e.X;
                ptMouse.Y = e.Y;
            }
        }

        /// <summary>
        /// 平移图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisionControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMode == WindowMouseMode.Move && isOpen())
            {
                if (this.Cursor == Cursors.Hand)
                {
                    int x = e.X - ptMouse.X;
                    int y = e.Y - ptMouse.Y;

                    if (Math.Abs(x) > 2 || Math.Abs(y) > 2)
                    {
                        ptMouse.X = e.X;
                        ptMouse.Y = e.Y;

                        HTuple row0, col0, row1, col1;
                        bool bUpdate = false;

                        LockDisplay();

                        try
                        {
                            HOperatorSet.GetPart(m_windowHandle, out row0, out col0, out row1, out col1);
                            double zoom = 1.0 * (row1 - row0) / this.Height;
                            x = (int)(x * zoom);
                            y = (int)(y * zoom);

                            HOperatorSet.SetPart(m_windowHandle, row0 - y, col0 - x, row1 - y, col1 - x);

                            //清理窗口前关闭刷新，以免闪烁
                            HOperatorSet.SetSystem("flush_graphic", "false");
                            HOperatorSet.ClearWindow(m_windowHandle);
                            HOperatorSet.SetSystem("flush_graphic", "true");

                            bUpdate = true;
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
                            UnlockDisplay();
                        }

                        if (bUpdate && m_IVisionControlUpdate != null)
                        {
                            Action<object> action = (object obj) =>
                            {
                                m_IVisionControlUpdate.UpdateVisionControl(this);
                            };
                            Task t1 = new Task(action, "");
                            t1.Start();
                            t1.Wait();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标右键按下时返回全屏显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisionControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseMode == WindowMouseMode.Move && e.Button == MouseButtons.Middle)
            {
                if (isOpen())
                {
                    //Action<object> action = (object obj) =>
                    //{
                    bool bUpdate = false;
                    HTuple row0, col0, row1, col1;
                    LockDisplay();
                    try
                    {
                        HOperatorSet.GetPart(m_windowHandle, out row0, out col0, out row1, out col1);

                        if (row0 != 0 || col0 != 0 || col1 - col0 != ImageWidth || row1 - row0 != ImageHeight)
                        {
                            HOperatorSet.SetPart(m_windowHandle, 0, 0, ImageHeight, ImageWidth);
                            bUpdate = true;
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
                        UnlockDisplay();
                    }

                    if (bUpdate && m_IVisionControlUpdate != null)
                    {
                        m_IVisionControlUpdate.UpdateVisionControl(this);
                    }
                    //};
                    //Task t1 = new Task(action, "");
                    //t1.Start();
                    //t1.Wait();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (this.Cursor == Cursors.Hand)
                    this.Cursor = Cursors.Arrow;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (this.Cursor == Cursors.Hand)
                    this.Cursor = Cursors.Arrow;
            }
        }

        private void VisionControl_MouseEnter(object sender, EventArgs e)
        {
            if (this.Focused == false)
                this.Focus();
        }

        private void VisionControl_MouseLeave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 控件缩放时自动调整halcon窗口的大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisionControl_SizeChanged(object sender, EventArgs e)
        {
            if (m_windowHandle != null)
            {
                bool bUpdate = false;
                LockDisplay();
                try
                {
                    HOperatorSet.SetWindowExtents(m_windowHandle, this.ClientRectangle.Y, this.ClientRectangle.X, this.ClientRectangle.Width, this.ClientRectangle.Height);
                    bUpdate = true;
                }
                catch (HalconException HDevExpDefaultException1)
                {
                    System.Diagnostics.Debug.WriteLine(HDevExpDefaultException1.ToString());
                }
                catch (Exception exp)
                {
                    System.Diagnostics.Debug.WriteLine(exp.ToString());
                }
                finally { UnlockDisplay(); }
                if (bUpdate && m_IVisionControlUpdate != null)
                {
                    m_IVisionControlUpdate.UpdateVisionControl(this);
                }
            }
        }

        private void VisionControl_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics ht;
            ht = e.Graphics;
            Pen ok = new Pen(System.Drawing.Color.Red, 1);
            Point p1 = new Point(this.Width / 2, 0);
            Point p2 = new Point(this.Width / 2, this.Height);
            Point p3 = new Point(0, this.Height / 2);
            Point p4 = new Point(this.Width, this.Height / 2);
            ht.DrawLine(ok, p1, p2);
            ht.DrawLine(ok, p3, p4);
            Pen ok2 = new Pen(System.Drawing.Color.Yellow, 1);
            ht.DrawEllipse(ok2, this.Width / 2 - 5, this.Height / 2 - 5, 10, 10);
        }
    }
}