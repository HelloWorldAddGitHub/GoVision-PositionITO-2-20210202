using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using HalconDotNet;

namespace GoVision
{
    /// <summary>
    /// 测量管理
    /// </summary>
    public class MeasureMgr : SingletonTemplate<MeasureMgr>, IDisposable
    {
        public double OffsetDia;//测量直径补偿

        /// <summary>
        /// 所有测量对象
        /// </summary>
        public List<MeasurePin> MeasureList = new List<MeasurePin>();

        /// <summary>
        /// 删除测量对象
        /// </summary>
        /// <param name="index"></param>
        public void Del(int index)
        {
            MeasureList[index].LineEdge?.Dispose();
            MeasureList[index].ContourOk?.Dispose();
            MeasureList[index].ContourAreaNG?.Dispose();
            MeasureList[index].ContourPosNG?.Dispose();

            MeasureList[index].Close();

            MeasureList.RemoveAt(index);
        }

        /// <summary>
        /// 删除所有测量对象
        /// </summary>
        /// <param name="index"></param>
        public void DelAll()
        {
            try
            {
                foreach (var mea in MeasureList)
                {
                    mea.LineEdge?.Dispose();
                    mea.ContourOk?.Dispose();
                    mea.ContourAreaNG?.Dispose();
                    mea.ContourPosNG?.Dispose();

                    mea.Close();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                MeasureList.Clear();
            }
        }

        public void Load(string path)
        {
            //清理
            DelAll();

            //加载
            if (System.IO.Directory.Exists(path))
            {
                string[] files = System.IO.Directory.GetFiles(path, $"measure*.bin", System.IO.SearchOption.TopDirectoryOnly);

                for (int i = 0; i < files.Length; i++)
                {
                    BinaryFormatter binFormat = new BinaryFormatter();

                    System.IO.FileStream fs = new System.IO.FileStream(files[i], System.IO.FileMode.Open);
                    var mea = (MeasurePin)binFormat.Deserialize(fs);
                    fs.Close();

                    MeasureList.Add(mea);
                }
            }
        }

        public void Save(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }

            System.IO.Directory.CreateDirectory(path);

            BinaryFormatter binFormat = new BinaryFormatter();

            for (int i = 0; i < MeasureList.Count; i++)
            {
                string fileName = $@"{path}measure{i}.bin";
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                binFormat.Serialize(fs, MeasureList[i]);
                fs.Close();
            }
        }

        /// <summary>
        /// 提取产品轮廓
        /// </summary>
        /// <param name="image">输入图像</param>
        /// <param name="contour">输出产品轮廓</param>
        public void ExtractContourXld(HObject image, out HObject contour)
        {
            // Local iconic variables 
            HObject ho_ImageMedian, ho_ImageScaled, ho_Regions, ho_RegionClosing, ho_RegionTrans;

            HOperatorSet.GenEmptyObj(out contour);

            HOperatorSet.ScaleImage(image, out ho_ImageScaled, 4.25, -425);
            HOperatorSet.MedianImage(ho_ImageScaled, out ho_ImageMedian, "square", 15, "mirrored");
            HOperatorSet.Threshold(ho_ImageMedian, out ho_Regions, 60, 255);
            HOperatorSet.ClosingCircle(ho_Regions, out ho_RegionClosing, 19.5);
            HOperatorSet.ShapeTrans(ho_RegionClosing, out ho_RegionTrans, "convex");
            HOperatorSet.GenContourRegionXld(ho_RegionTrans, out contour, "border");
        }

        /// <summary>
        /// 测量所有碳点
        /// </summary>
        /// <param name="image"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radian"></param>
        public void MeasureAll(HObject image, double row, double column, double radian)
        {
            HObject contour;
            ExtractContourXld(image, out contour);


            foreach (var mea in MeasureList)
            {
                mea.ClearResult();

                HTuple rowTrans, columnTrans;
                HOperatorSet.AffineTransPixel(mea.PosHomMat2d, row, column, out rowTrans, out columnTrans);

                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dRotate(homMat2D, radian - mea.ModelRadian, row, column, out homMat2D);
                HOperatorSet.AffineTransPixel(homMat2D, rowTrans, columnTrans, out rowTrans, out columnTrans);

                mea.Gen(rowTrans, columnTrans, radian);
                mea.MeasurePos(image, contour);
                mea.Close();
            }

        }

        [Serializable]
        public class MeasurePin
        {
            //测量句柄
            [NonSerialized]
            private HTuple Handle1;

            [NonSerialized]
            private HTuple Handle2;

            [NonSerialized]
            private HTuple HandleLine;

            //位置变换矩阵和角度
            public double[] PosHomMat2d;

            public double PosRadianDiff;
            public double ModelRadian;
            //测量矩形
            public double CenterRow;

            public double CenterColumn;
            public double Radian;
            public double Width = 58;
            public double Height = 40;

            public double ImageWidth = 5472;
            public double ImageHeight = 3648;
            public string Interpolation = "nearest_neighbor";

            //边缘测量矩形与碳点测量矩形的距离
            public double DisHanldeRow = 25;

            //测量参数
            public double Sigma = 1;

            public double Threshold = 20;

            //测量数量和间距
            public int PinCount = 19;

            //public double PinDistance = 48.54;//pixel
            public double PinDistance = 75.82;//pixel

            //测量结果数据，mm
            public HTuple DisLeft;

            public HTuple DisRight;
            public HTuple DisTop;
            public HTuple DiameterMax;
            public HTuple DiameterMin;

            public HTuple CountOK;//面积NG数量
            public HTuple CountAreaNG;//面积NG数量
            public HTuple CountPosNG;//位置NG数量



            [NonSerialized]
            public HObject LineEdge;

            [NonSerialized]
            public HObject ContourOk;

            [NonSerialized]
            public HObject ContourAreaNG;

            [NonSerialized]
            public HObject ContourPosNG;

            //测量碳点位置界限，mm
            public double LimiteDiameterMax = 1;

            public double LimiteDiameterMin = 0.5;
            public double LimiteLeft = 0.1;
            public double LimiteRight = 0.1;
            public double LimiteTopMin = 0.1;
            public double LimiteTopMax = 0.95;

            public void Gen()
            {
                //生成水平方向测量矩形
                HOperatorSet.GenMeasureRectangle2(CenterRow, CenterColumn, Radian, Width / 2, Height / 2,
                    ImageWidth, ImageHeight, Interpolation, out Handle1);

                //生成垂直方向测量矩形
                HOperatorSet.GenMeasureRectangle2(CenterRow, CenterColumn, Radian - Math.PI / 2, Width / 2, Height / 2,
                    ImageWidth, ImageHeight, Interpolation, out Handle2);

                //生成屏幕边缘测量矩形
                HOperatorSet.GenMeasureRectangle2(CenterRow + DisHanldeRow, CenterColumn /*+ DisHanldeColumn*/, Radian + Math.PI / 2,
                    /*Math.Abs(DisHanldeRow * 2)*/20, Height / 2, ImageWidth, ImageHeight, Interpolation, out HandleLine);

            }

            public void Gen(double row, double column, double radian)
            {
                CenterRow = row;
                CenterColumn = column;
                Radian = radian + PosRadianDiff;

                //生成水平方向测量矩形
                HOperatorSet.GenMeasureRectangle2(row, column, Radian, Width / 2, Height / 2,
                    ImageWidth, ImageHeight, Interpolation, out Handle1);

                //生成垂直方向测量矩形
                HOperatorSet.GenMeasureRectangle2(row, column, Radian - Math.PI / 2, Width / 2, Height / 2,
                    ImageWidth, ImageHeight, Interpolation, out Handle2);

                //生成屏幕边缘测量矩形
                HOperatorSet.GenMeasureRectangle2(row + DisHanldeRow, column /*+ DisHanldeColumn*/, Radian + Math.PI / 2,
                    /*Math.Abs(DisHanldeRow * 2)*/20, Height / 2, ImageWidth, ImageHeight, Interpolation, out HandleLine);
            }

            public void Gen(double row, double column, double radian, double width, double height, double disLine, double pinDistance, int pinCount)
            {
                CenterRow = row;
                CenterColumn = column;
                Radian = radian + PosRadianDiff;

                Width = width;
                Height = height;
                PinDistance = pinDistance;
                PinCount = pinCount;

                //生成水平方向测量矩形
                HOperatorSet.GenMeasureRectangle2(row, column, Radian, width / 2, height / 2,
                    ImageWidth, ImageHeight, Interpolation, out Handle1);

                //生成垂直方向测量矩形
                HOperatorSet.GenMeasureRectangle2(row, column, Radian - Math.PI / 2, width / 2, height / 2,
                    ImageWidth, ImageHeight, Interpolation, out Handle2);

                //生成屏幕边缘测量矩形
                DisHanldeRow = disLine;
                //DisHanldeColumn = pinDistance * pinCount / 2;

                HOperatorSet.GenMeasureRectangle2(row + DisHanldeRow, column /*+ DisHanldeColumn*/, Radian + Math.PI / 2, 20, height / 2,
                    ImageWidth, ImageHeight, Interpolation, out HandleLine);
            }

            public void MeasureRoundness(HObject image, out HObject region, /*out HTuple area,*/ out HTuple roundness, out HTuple numHoles, out HTuple diameter)
            {
                //area = new HTuple();
                roundness = new HTuple();
                numHoles = new HTuple();
                diameter = new HTuple();
                region = new HObject();

                try
                {

                    HTuple absoluteHisto, relativeHisto, minThresh, maxThresh;
                    HTuple distance, sigma, /*roundness,*/ sides, row, column;

                    HOperatorSet.GrayHisto(image, image, out absoluteHisto, out relativeHisto);
                    HOperatorSet.HistoToThresh(relativeHisto, 8, out minThresh, out maxThresh);

                    HTuple threshMax = maxThresh[maxThresh.Length - 2];

                    for (int i = maxThresh.Length - 3; threshMax > 160 && i >= 0; i--)
                    {
                        threshMax = maxThresh[i];
                    }

                    threshMax = threshMax.I < 140 ? 140 : threshMax.I;

                    HTuple numConnected, /*numHoles,*/ row1, column1, row2, column2/*, diameter*/, area, indices;

                    HOperatorSet.Threshold(image, out region, minThresh[0], threshMax);

                    HObject connectedRegions;
                    HOperatorSet.Connection(region, out connectedRegions);
                    HOperatorSet.AreaCenter(connectedRegions, out area, out row, out column);

                    HOperatorSet.TupleSortIndex(area, out indices);
                    HOperatorSet.TupleInverse(indices, out indices);
                    HOperatorSet.SelectObj(connectedRegions, out region, indices[0] + 1);


                    HOperatorSet.ConnectAndHoles(region, out numConnected, out numHoles);
                    HOperatorSet.DiameterRegion(region, out row1, out column1, out row2, out column2, out diameter);
                    HOperatorSet.Roundness(region, out distance, out sigma, out roundness, out sides);
                    //HOperatorSet.AreaCenter(region, out area, out row, out column);

                }
                catch (Exception e)
                {
                    Log.Show($"{e}");
                }
            }

            public void MeasureCircle(HObject image, double row, double column, double radian, out HTuple diameterMax, out HTuple diameterMin,
                out HTuple disLeft, out HTuple disRight, out HTuple edgeRow, out HTuple edgeColumn, out HObject contour)
            {
                diameterMax = new HTuple(999);
                diameterMin = new HTuple(999);
                disLeft = new HTuple(999);
                disRight = new HTuple(999);
                edgeRow = new HTuple(999);
                edgeColumn = new HTuple(999);

                HOperatorSet.GenEmptyObj(out contour);

                try
                {
                    //平移测量对象
                    HOperatorSet.TranslateMeasure(Handle1, row, column);
                    HOperatorSet.TranslateMeasure(Handle2, row, column);

                    //测量矩形中点
                    HObject cross;
                    HOperatorSet.GenCrossContourXld(out cross, row, column, 5, radian);
                    HOperatorSet.ConcatObj(contour, cross, out contour);

                    //HTuple leftRow, leftCol, topRow, topCol, rightRow, rightCol, bottomRow, bottomCol;
                    HTuple centerRow = null, centerCol = null;

                    HTuple rowEdgeFirst = new HTuple();
                    HTuple columnEdgeFirst = new HTuple();
                    HTuple amplitudeFirst = new HTuple();
                    HTuple rowEdgeSecond = new HTuple();
                    HTuple columnEdgeSecond = new HTuple();
                    HTuple amplitudeSecond = new HTuple();
                    HTuple intraDistance = new HTuple();
                    HTuple interDistance = new HTuple();

                    //左右测量边缘对
                    for (int i = 0; i <= 5; i++)
                    {
                        HTuple threshold = Threshold - i * 2;
                        if (threshold < 1)
                        {
                            threshold = 1;
                        }

                        HOperatorSet.MeasurePairs(image, Handle1, Sigma, threshold, "all", "all",
                            out rowEdgeFirst, out columnEdgeFirst, out amplitudeFirst,
                            out rowEdgeSecond, out columnEdgeSecond, out amplitudeSecond,
                            out intraDistance, out interDistance);

                        if (intraDistance.Length >= 2)
                        {
                            break;
                        }
                    }

                    if (intraDistance.Length >= 2)
                    {
                        diameterMax = interDistance[0];
                        disLeft = intraDistance[0];
                        disRight = intraDistance[1];


                        //centerRow = (rowEdgeSecond[0] + rowEdgeFirst[1]) / 2;
                        centerCol = (columnEdgeSecond[0] + columnEdgeFirst[1]) / 2;
                    }

                    //显示
                    for (int j = 0; j < rowEdgeFirst.Length; j++)
                    {
                        HTuple rowEdgeFirstBegin;
                        HTuple rowEdgeFirstEnd;
                        HTuple rowEdgeSecondBegin;
                        HTuple rowEdgeSecondEnd;
                        HOperatorSet.TupleAdd(rowEdgeFirst, Height / 2, out rowEdgeFirstBegin);
                        HOperatorSet.TupleSub(rowEdgeFirst, Height / 2, out rowEdgeFirstEnd);

                        HOperatorSet.TupleAdd(rowEdgeSecond, Height / 2, out rowEdgeSecondBegin);
                        HOperatorSet.TupleSub(rowEdgeSecond, Height / 2, out rowEdgeSecondEnd);

                        HTuple columnEdgeFirstBegin = new HTuple();
                        HTuple columnEdgeFirstEnd = new HTuple();
                        HTuple columnEdgeSecondBegin = new HTuple();
                        HTuple columnEdgeSecondEnd = new HTuple();

                        HTuple homMat2D;
                        HTuple rowBegin1;
                        HTuple columnBegin1;
                        HTuple rowEnd1;
                        HTuple columnEnd1;
                        HTuple rowBegin2;
                        HTuple columnBegin2;
                        HTuple rowEnd2;
                        HTuple columnEnd2;

                        HObject lineFirst;

                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dRotate(homMat2D, radian, rowEdgeFirst[j], columnEdgeFirst[j], out homMat2D);
                        HOperatorSet.AffineTransPixel(homMat2D, rowEdgeFirstBegin[j], columnEdgeFirst[j], out rowBegin1, out columnBegin1);
                        HOperatorSet.AffineTransPixel(homMat2D, rowEdgeFirstEnd[j], columnEdgeFirst[j], out rowEnd1, out columnEnd1);

                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dRotate(homMat2D, radian, rowEdgeSecond[j], columnEdgeSecond[j], out homMat2D);
                        HOperatorSet.AffineTransPixel(homMat2D, rowEdgeSecondBegin[j], columnEdgeSecond[j], out rowBegin2, out columnBegin2);
                        HOperatorSet.AffineTransPixel(homMat2D, rowEdgeSecondEnd[j], columnEdgeSecond[j], out rowEnd2, out columnEnd2);

                        HOperatorSet.GenContourPolygonXld(out lineFirst,
                            new HTuple(rowBegin1, rowEnd1, rowEnd2, rowBegin2, rowBegin1),
                            new HTuple(columnBegin1, columnEnd1, columnEnd2, columnBegin2, columnBegin1));

                        HOperatorSet.ConcatObj(contour, lineFirst, out contour);
                    }

                    //测量碳点垂直方向直径
                    for (int i = 0; i <= 5; i++)
                    {
                        HTuple threshold = Threshold - i * 2;
                        if (threshold < 1)
                        {
                            threshold = 1;
                        }

                        HOperatorSet.MeasurePairs(image, Handle2, Sigma, threshold, "negative", "all",
                            out rowEdgeFirst, out columnEdgeFirst, out amplitudeFirst,
                            out rowEdgeSecond, out columnEdgeSecond, out amplitudeSecond,
                            out intraDistance, out interDistance);

                        if (intraDistance.Length >= 1)
                        {
                            break;
                        }
                    }

                    //获得结果，当没有测量到边缘对
                    if (intraDistance.Length < 1)
                    {
                        diameterMin = diameterMax;

                        edgeRow = 0;
                        edgeColumn = 0;
                    }

                    //测量到边缘对
                    if (intraDistance.Length >= 1)
                    {
                        if (diameterMax.D == 999)
                        {
                            diameterMin = intraDistance[0];
                            diameterMax = intraDistance[0];

                            centerCol = (columnEdgeSecond[0] + columnEdgeFirst[0]) / 2;
                        }
                        else
                        {
                            if (intraDistance[0] < diameterMax)
                            {
                                diameterMin = intraDistance[0];
                            }
                            else
                            {
                                diameterMin = diameterMax[0];
                                diameterMax = intraDistance[0];
                            }
                        }

                        centerRow = (rowEdgeSecond[0] + rowEdgeFirst[0]) / 2;

                        edgeRow = rowEdgeSecond[0];
                        edgeColumn = columnEdgeSecond[0];
                    }

                    //显示
                    if (intraDistance.Length > 0)
                    {
                        HTuple columnEdgeFirstBegin, columnEdgeFirstEnd, columnEdgeSecondBegin, columnEdgeSecondEnd;
                        HTuple rowBegin1, columnBegin1, rowEnd1, columnEnd1, rowBegin2, columnBegin2, rowEnd2, columnEnd2;

                        HOperatorSet.TupleAdd(columnEdgeFirst, Width / 2, out columnEdgeFirstBegin);
                        HOperatorSet.TupleSub(columnEdgeFirst, Width / 2, out columnEdgeFirstEnd);

                        HOperatorSet.TupleAdd(columnEdgeSecond, Width / 2, out columnEdgeSecondBegin);
                        HOperatorSet.TupleSub(columnEdgeSecond, Width / 2, out columnEdgeSecondEnd);

                        for (int i = 0; i < intraDistance.Length; i++)
                        {
                            HTuple homMat2D;
                            HOperatorSet.HomMat2dIdentity(out homMat2D);
                            HOperatorSet.HomMat2dRotate(homMat2D, radian, rowEdgeFirst[i], columnEdgeFirst[i], out homMat2D);
                            HOperatorSet.AffineTransPixel(homMat2D, rowEdgeFirst[i], columnEdgeFirstBegin[i], out rowBegin1, out columnBegin1);
                            HOperatorSet.AffineTransPixel(homMat2D, rowEdgeFirst[i], columnEdgeFirstEnd[i], out rowEnd1, out columnEnd1);

                            HOperatorSet.HomMat2dIdentity(out homMat2D);
                            HOperatorSet.HomMat2dRotate(homMat2D, radian, rowEdgeSecond[i], columnEdgeSecond[i], out homMat2D);
                            HOperatorSet.AffineTransPixel(homMat2D, rowEdgeSecond[i], columnEdgeSecondBegin[i], out rowBegin2, out columnBegin2);
                            HOperatorSet.AffineTransPixel(homMat2D, rowEdgeSecond[i], columnEdgeSecondEnd[i], out rowEnd2, out columnEnd2);

                            HObject lineFirst;
                            HOperatorSet.GenContourPolygonXld(out lineFirst,
                                new HTuple(rowBegin1, rowEnd1, rowEnd2, rowBegin2, rowBegin1),
                                new HTuple(columnBegin1, columnEnd1, columnEnd2, columnBegin2, columnBegin1));

                            HOperatorSet.ConcatObj(contour, lineFirst, out contour);
                        }
                    }


                    if (diameterMax.D != 999 && disLeft.D != 999 && disRight.D != 999
                        && centerRow != null && centerCol != null)
                    {
                        HObject rect, imageReduced, region;
                        HTuple numHoles, roundness, diameter;
                        HTuple length = (int)(diameterMax.D / 2 + 5);
                        HOperatorSet.GenRectangle2(out rect, centerRow, centerCol, radian, length, length);
                        HOperatorSet.ReduceDomain(image, rect, out imageReduced);
                        MeasureRoundness(imageReduced, out region, out roundness, out numHoles, out diameter);
                        //MeasureRoundness(imageReduced, out region, out roundness, out numHoles, out diameter);
                        //HOperatorSet.ConcatObj(contour, region, out contour);
                        if (roundness < 0.9 || numHoles > 0)
                        {
                            diameterMax = 999;
                            //HOperatorSet.ConcatObj(contour, region, out contour);
                        }

                        //diameterMax = diameterMax > diameter ? diameterMax : diameter;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public void MeasurePos(HObject image, HObject edgeContour)
            {
                //记录测量数量
                int meaCount = 0;

                try
                {
                    HTuple row = CenterRow;
                    HTuple column = CenterColumn;
                    HTuple radian = Radian;

                    HTuple homMat2D, rowTrans, columnTrans;
                    /*
                    HOperatorSet.HomMat2dIdentity(out homMat2D);
                    HOperatorSet.HomMat2dTranslate(homMat2D, 0, PinDistance * PinCount / 2, out homMat2D);
                    HOperatorSet.HomMat2dRotate(homMat2D, radian, row, column, out homMat2D);
                    HOperatorSet.AffineTransPixel(homMat2D, row, column, out rowTrans, out columnTrans);

                    HObject rect;
                    HOperatorSet.GenRectangle2(out rect, rowTrans, columnTrans, radian, PinDistance * PinCount / 2 + Width, 100);
                    HOperatorSet.ReduceDomain(image, rect, out image);

                    HOperatorSet.AnisotropicDiffusion(image, out image, "weickert", 5, 1, 10);
                    HOperatorSet.Emphasize(image, out image, 15, 15, 1);

                    HOperatorSet.ConcatObj(LineEdge, image, out LineEdge);
                    */

                    //HTuple edgeRow1, edgeColumn1, edgeRow2, edgeColumn2;
                    //FindEdge(image, row, column, radian, out edgeRow1, out edgeColumn1, out edgeRow2, out edgeColumn2);
                    HOperatorSet.ConcatObj(LineEdge, edgeContour, out LineEdge);

                    //测量所有碳碳点
                    for (int i = 0; i < PinCount; i++)
                    {
                        //变换检测位置
                        //HTuple homMat2D, rowTrans, columnTrans;
                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dTranslate(homMat2D, 0, i * PinDistance, out homMat2D);
                        HOperatorSet.HomMat2dRotate(homMat2D, radian, row, column, out homMat2D);
                        HOperatorSet.AffineTransPixel(homMat2D, row, column, out rowTrans, out columnTrans);

                        //检测碳点
                        HObject contour;
                        HTuple diameterMax, diameterMin, disLeft, disRight, edgeRow, edgeColumn;
                        MeasureCircle(image, rowTrans, columnTrans, radian, out diameterMax, out diameterMin, out disLeft, out disRight,
                            out edgeRow, out edgeColumn, out contour);

                        //测量碳点到玻璃边缘的距离
                        HTuple disTop, distanceMax;
                        //HOperatorSet.DistancePl(edgeRow, edgeColumn, edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, out disTop);
                        HOperatorSet.DistancePc(edgeContour, edgeRow, edgeColumn, out disTop, out distanceMax);


                        //像素转毫米
                        double maxDiameter = Math.Round((PlatformCalibData.PixelToMm(diameterMax) + MeasureMgr.GetInstance().OffsetDia), 2);
                        double minDiameter = Math.Round(PlatformCalibData.PixelToMm(diameterMin), 2);
                        double leftPos = Math.Round(PlatformCalibData.PixelToMm(disLeft), 2);
                        double reghtPos = Math.Round(PlatformCalibData.PixelToMm(disRight), 2);
                        double topPos = Math.Round(PlatformCalibData.PixelToMm(disTop), 2);

                        //优先判断面积NG，后判断位置NG
                        double LimiteMax = PlatformCalibData.PixelToMm(PinDistance);
                        if (maxDiameter > LimiteDiameterMax || maxDiameter < LimiteDiameterMin)
                        {
                            HOperatorSet.ConcatObj(ContourAreaNG, contour, out ContourAreaNG);
                            CountAreaNG++;
                        }
                        else if (leftPos < LimiteLeft || leftPos > LimiteMax
                            || reghtPos < LimiteRight || reghtPos > LimiteMax
                            || topPos < LimiteTopMin || topPos > LimiteTopMax)
                        {
                            HOperatorSet.ConcatObj(ContourPosNG, contour, out ContourPosNG);
                            CountPosNG++;
                        }
                        else
                        {
                            HOperatorSet.ConcatObj(ContourOk, contour, out ContourOk);
                            CountOK++;
                        }

                        //添加到参数列表
                        DiameterMax.Append(maxDiameter);
                        DiameterMin.Append(minDiameter);
                        DisLeft.Append(leftPos);
                        DisRight.Append(reghtPos);
                        DisTop.Append(topPos);

                        //计数
                        meaCount++;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //未测量完成计入面积NG
                    if (PinCount != meaCount)
                    {
                        CountAreaNG += PinCount - meaCount;
                    }
                }
            }

            public void FindEdge(HObject image, HTuple row, HTuple column, HTuple radian, out HTuple edgeRow1, out HTuple edgeColumn1, out HTuple edgeRow2, out HTuple edgeColumn2)
            {
                HTuple homMat2D, rowTrans, columnTrans;

                //测量外边缘
                edgeRow1 = 0;
                edgeColumn1 = 0;
                edgeRow2 = 0;
                edgeColumn2 = 0;

                /*
                // Local iconic variables 

                //HObject ho_Image, ho_ImageEmphasize, ho_ROI_0;
                //HObject ho_ImageReduced, ho_ImageScaled, ho_Regions, ho_Connection;
                //HObject ho_RegionOpening, ho_RegionClosing, ho_ObjectSelected;
                //HObject ho_RegionTrans, ho_ImageMean, ho_ImageResult;

                // Local control variables 

                HTuple hv_Area = null, hv_Row = null, hv_Column = null;
                HTuple hv_Indices = null, hv_Inverted = null;

                HOperatorSet.ScaleImage(image, out ho_ImageScaled, 4.25, -425);
                HOperatorSet.Threshold(ho_ImageScaled, out ho_Regions, 100, 255);
                HOperatorSet.OpeningCircle(ho_Regions, out ho_RegionOpening, 3.5);
                HOperatorSet.ClosingCircle(ho_RegionOpening, out ho_RegionClosing, 19.5);
                HOperatorSet.Connection(ho_RegionClosing, out ho_Connection);
                HOperatorSet.AreaCenter(ho_Connection, out hv_Area, out hv_Row, out hv_Column);
                HOperatorSet.TupleSortIndex(hv_Area, out hv_Indices);
                HOperatorSet.TupleInverse(hv_Indices, out hv_Inverted);
                HOperatorSet.SelectObj(ho_Connection, out ho_ObjectSelected, (hv_Inverted.TupleSelect(0)) + 1);
                HOperatorSet.ShapeTrans(ho_ObjectSelected, out ho_RegionTrans, "rectangle2");
                HOperatorSet.MeanImage(ho_ImageScaled, out ho_ImageMean, 15, 15);
                HOperatorSet.PaintRegion(ho_RegionTrans, ho_ImageMean, out ho_ImageResult, 255, "fill");
                */

                HOperatorSet.GenMeasureRectangle2(row + DisHanldeRow, column /*+ DisHanldeColumn*/, Radian + Math.PI / 2, 20, 40,
                    ImageWidth, ImageHeight, Interpolation, out HandleLine);

                for (int i = 0; i <= 5; i++)
                {
                    //设置幅度值
                    HTuple threshold = Threshold - 10 - i * 2;
                    if (threshold < 1)
                    {
                        threshold = 1;
                    }

                    HTuple rows = new HTuple();
                    HTuple columns = new HTuple();

                    for (int j = 0; j < PinCount; j++)
                    {
                        HTuple rowEdge, columnEdge, amplitude, distance;

                        //变换检测位置
                        //HTuple homMat2D, rowTrans, columnTrans;
                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dTranslate(homMat2D, DisHanldeRow, j * PinDistance, out homMat2D);
                        HOperatorSet.HomMat2dRotate(homMat2D, radian, row, column, out homMat2D);
                        HOperatorSet.AffineTransPixel(homMat2D, row, column, out rowTrans, out columnTrans);

                        HOperatorSet.TranslateMeasure(HandleLine, rowTrans, columnTrans);

                        HOperatorSet.MeasurePos(image, HandleLine, Sigma, threshold, "negative", "first",
                            out rowEdge, out columnEdge, out amplitude, out distance);

                        //HOperatorSet.MeasurePos(ho_ImageResult, HandleLine, Sigma, threshold, "positive", "first",
                        //    out rowEdge, out columnEdge, out amplitude, out distance);

                        if (rowEdge.Length > 0)
                        {
                            rows.Append(rowEdge);
                            columns.Append(columnEdge);
                        }
                    }

                    if (rows.Length >= PinCount / 2)
                    {
                        //生成轮廓
                        HObject contour;
                        HTuple nr, nc, dist;
                        HOperatorSet.GenContourPolygonXld(out contour, rows, columns);

                        //拟合
                        HOperatorSet.FitLineContourXld(contour, "tukey", -1, 0, 5, 2,
                            out edgeRow1, out edgeColumn1, out edgeRow2, out edgeColumn2,
                            out nr, out nc, out dist);

                        //生成直线，用于显示
                        contour?.Dispose();
                        HOperatorSet.GenContourPolygonXld(out contour, new HTuple(edgeRow1, edgeRow2), new HTuple(edgeColumn1, edgeColumn2));
                        HOperatorSet.ConcatObj(LineEdge, contour, out LineEdge);

                        break;
                    }
                }

                HOperatorSet.CloseMeasure(HandleLine);
            }

            public void ClearResult()
            {
                DisLeft = new HTuple();
                DisRight = new HTuple();
                DisTop = new HTuple();
                DiameterMax = new HTuple();
                DiameterMin = new HTuple();

                CountAreaNG = 0;
                CountPosNG = 0;
                CountOK = 0;

                LineEdge?.Dispose();
                ContourOk?.Dispose();
                ContourAreaNG?.Dispose();
                ContourPosNG?.Dispose();

                HOperatorSet.GenEmptyObj(out LineEdge);
                HOperatorSet.GenEmptyObj(out ContourOk);
                HOperatorSet.GenEmptyObj(out ContourAreaNG);
                HOperatorSet.GenEmptyObj(out ContourPosNG);
            }

            public void Close()
            {
                try
                {
                    if (Handle1 != null)
                    {
                        HOperatorSet.CloseMeasure(Handle1);
                    }
                    if (Handle2 != null)
                    {
                        HOperatorSet.CloseMeasure(Handle2);
                    }
                    if (HandleLine != null)
                    {
                        HOperatorSet.CloseMeasure(HandleLine);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                HOperatorSet.CloseAllMeasures();
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MeasureMgr() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}