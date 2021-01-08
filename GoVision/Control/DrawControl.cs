using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using HalconDotNet;

namespace GoVision
{
    public partial class DrawControl : UserControl
    {
        public DrawControl()
        {
            InitializeComponent();
            cboOpera.SelectedIndex = 0;
            ckbToolVis.Checked = false;
        }

        public void InitWindow()
        {
            visionControl1.InitWindow();
        }

        public void RegisterUpdateInterface(IVisionControlUpdate vsu)
        {
            visionControl1.RegisterUpdateInterface(vsu);
        }

        public void DispImageFull(HObject m_image)
        {
            visionControl1.DispImageFull(m_image);
        }

        /// <summary>
        /// 返回当前界面的Region
        /// </summary>
        public HObject getRegions()
        {
            List<HObject> regions = new List<HObject>();
            HObject region = null, r = null;
            int i;
            List<HDrawingObject> _objs = visionControl1.getDrawObjs();
            foreach (HDrawingObject _obj in _objs)
            {
                if (_obj.GetDrawingObjectParams("type") == "line")
                {
                    HOperatorSet.GenRegionLine(out region, _obj.GetDrawingObjectParams("row1"),
                        _obj.GetDrawingObjectParams("column1"), _obj.GetDrawingObjectParams("row2"),
                        _obj.GetDrawingObjectParams("column2"));
                }
                else
                {
                    region = new HRegion(_obj.GetDrawingObjectIconic());
                }
                regions.Add(region);
            }

            for (i = 0; i < regions.Count; i++)
            {
                switch (visionControl1.getOperations()[i])
                {
                    case "none":
                        r = regions[i];
                        break;

                    case "union":
                        HOperatorSet.Union2(r, regions[i], out r);
                        break;

                    case "intersection":
                        HOperatorSet.Intersection(r, regions[i], out r);
                        break;

                    case "difference":
                        HOperatorSet.Difference(r, regions[i], out r);
                        break;
                }
            }
            return r;
        }

        public HTuple GetHalconWindow()
        {
            return visionControl1.GetHalconWindow();
        }

        private void BtnDrawLine_Click(object sender, EventArgs e)
        {
            HDrawingObject line = HDrawingObject.CreateDrawingObject(
                HDrawingObject.HDrawingObjectType.LINE, 100, 100, 210, 210);
            line.SetDrawingObjectParams("color", "green");
            visionControl1.AddOperations(cboOpera.Text);
            visionControl1.AttachDrawObj(line);
        }

        private void BtnDrawCircle_Click(object sender, EventArgs e)
        {
            HDrawingObject circle = HDrawingObject.CreateDrawingObject(
              HDrawingObject.HDrawingObjectType.CIRCLE, 200, 200, 70);
            circle.SetDrawingObjectParams("color", "green");
            visionControl1.AddOperations(cboOpera.Text);
            visionControl1.AttachDrawObj(circle);
        }

        private void BtnDrawRectangle1_Click(object sender, EventArgs e)
        {
            HDrawingObject rect1 = HDrawingObject.CreateDrawingObject(
                HDrawingObject.HDrawingObjectType.RECTANGLE1, 100, 100, 210, 210);
            //  rect1.GetDrawingObjectParams(r);
            rect1.SetDrawingObjectParams("color", "green");
            visionControl1.AddOperations(cboOpera.Text);
            visionControl1.AttachDrawObj(rect1);
        }

        private void BtnDrawRectangle2_Click(object sender, EventArgs e)
        {
            HDrawingObject rect2 = HDrawingObject.CreateDrawingObject(
                HDrawingObject.HDrawingObjectType.RECTANGLE2, 100, 100, 0, 100, 50);
            rect2.SetDrawingObjectParams("color", "green");
            visionControl1.AddOperations(cboOpera.Text);
            visionControl1.AttachDrawObj(rect2);
        }

        private void BtnClearRoi_Click(object sender, EventArgs e)
        {
            visionControl1.clearObj();
        }

        private void BtnLoadRoi_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "ROI文件(.roi)|*.roi;";
            HTuple[] _params;
            if (f.ShowDialog() == DialogResult.OK)
            {
                List<ROI> r = LoadRoi(f.FileName);
                foreach (ROI region in r)
                {
                    _params = new HTuple[region.data.Count];
                    for (int i = 0; i < region.data.Count; i++)
                    {
                        _params[i] = region.data[i];
                    }
                    HDrawingObject obj = HDrawingObject.CreateDrawingObject(region.type, _params);
                    obj.SetDrawingObjectParams("color", "green");
                    visionControl1.AddOperations(region.operation);
                    visionControl1.AttachDrawObj(obj);
                }
            }
        }

        public struct ROI
        {
            public HDrawingObject.HDrawingObjectType type;
            public string operation;
            public List<double> data;
        }

        private void BtnSaveRoi_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.RestoreDirectory = true;
            f.FileName = "ROI.roi";
            f.Filter = "ROI文件(.roi)|*.roi;";

            if (f.ShowDialog() == DialogResult.OK)
            {
                visionControl1.operations[0] = "none";
                Write(visionControl1.getDrawObjs(), visionControl1.getOperations(), f.FileName);
            }
        }

        static public List<ROI> LoadRoi(string fileName)
        {
            List<ROI> regions = new List<ROI>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode rootRoi in root.ChildNodes)
            {
                foreach (XmlNode local in rootRoi.ChildNodes)
                {
                    ROI region = new ROI();
                    region.data = new List<double>();

                    region.operation = ((XmlElement)local).GetAttribute("operation");

                    foreach (XmlNode data in local.ChildNodes)
                    {
                        //XmlAttributeCollection text = data.Attributes;

                        //foreach (XmlAttribute s in text)
                        //{
                        //    region.data.Add(Convert.ToDouble(s.Value));
                        //}
                        switch (local.LocalName)
                        {
                            case "rect1":
                                region.type = HDrawingObject.HDrawingObjectType.RECTANGLE1;
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("row1")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("col1")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("row2")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("col2")));
                                break;

                            case "rect2":
                                region.type = HDrawingObject.HDrawingObjectType.RECTANGLE2;
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("row")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("col")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("phi")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("length1")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("length2")));
                                break;

                            case "circle":
                                region.type = HDrawingObject.HDrawingObjectType.CIRCLE;
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("row")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("col")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("radius")));
                                break;

                            case "line":
                                region.type = HDrawingObject.HDrawingObjectType.LINE;
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("row1")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("col1")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("row2")));
                                region.data.Add(Convert.ToDouble(((XmlElement)data).GetAttribute("col2")));
                                break;
                        }
                    }

                    regions.Add(region);
                }
            }

            return regions;
        }

        static public void Write(List<HDrawingObject> objects, List<string> operations, string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("roi_coll");
            root.SetAttribute("mode", "region");
            root.SetAttribute("name", "ROI");
            doc.AppendChild(root);

            XmlElement roi = doc.CreateElement("roi");
            roi.SetAttribute("name", "ROI [0]");
            root.AppendChild(roi);

            int i = 0;
            foreach (HDrawingObject obj in objects)
            {
                List<string> _params = getParams(obj.GetDrawingObjectParams("type"));
                XmlElement type = doc.CreateElement(_params[0]);
                type.SetAttribute("operation", operations[i]);
                roi.AppendChild(type);
                _params.RemoveAt(0);

                XmlElement data = doc.CreateElement("data");
                foreach (string _param in _params)
                {
                    string _p = "";
                    switch (_param)
                    {
                        case "column":
                            _p = "col";
                            break;

                        case "column1":
                            _p = "col1";
                            break;

                        case "column2":
                            _p = "col2";
                            break;

                        default:
                            _p = _param;
                            break;
                    }
                    data.SetAttribute(_p, obj.GetDrawingObjectParams(_param).ToString());
                }
                type.AppendChild(data);
                i++;
            }

            doc.Save(filename);
        }

        //'rectangle1', 'rectangle2', 'line',circle'
        // 'column', 'column1', 'column2', 'end_angle', 'font', 'length1', 'length2', 'line_style', 'line_width', 'phi',
        //'radius', 'radius1', 'radius2', 'row', 'row1', 'row2', 'start_angle',
        static public List<string> getParams(string _type)
        {
            List<string> _params = new List<string>();
            if (_type == "rectangle1")
            {
                _params.Add("rect1");
                _params.Add("row1");
                _params.Add("column1");
                _params.Add("row2");
                _params.Add("column2");
            }
            if (_type == "rectangle2")
            {
                _params.Add("rect2");
                _params.Add("row");
                _params.Add("column");
                _params.Add("phi");
                _params.Add("length1");
                _params.Add("length2");
            }
            if (_type == "circle")
            {
                _params.Add("circle");
                _params.Add("row");
                _params.Add("column");
                _params.Add("radius");
            }
            if (_type == "line")
            {
                _params.Add("line");
                _params.Add("row1");
                _params.Add("column1");
                _params.Add("row2");
                _params.Add("column2");
            }
            return _params;
        }

        private void ckbToolVis_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbToolVis.Checked == true)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }
    }
}