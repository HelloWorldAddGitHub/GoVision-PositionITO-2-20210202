using System;
using HalconDotNet;

namespace GoVision
{
    [Serializable]
    public class ProductParam
    {
        //public string ModelPath;

        //创建模板参数
        public HTuple ModelID;

        public HTuple ContrastLow;

        public HTuple ContrastHigh;

        public HTuple ModelOriginRow;

        public HTuple ModelOriginColumn;

        public HTuple FindAngleStart = -15;

        public HTuple FindAngleExtent = 30;

        public HTuple FindScaleMin = 1;

        public HTuple FindScaleMax = 1;

        [NonSerialized]
        public HObject Roi;

        [NonSerialized]
        public HObject ModelContours;

        [NonSerialized]
        public HObject ModelOriginContours;

        //[NonSerialized]
        public HObject MarkContours;

        //查找模板参数
        public HTuple FindScore = 0.5;

        public HTuple FindNumMatches = 1;

        public HTuple FindGreediness = 0.9;

        public HTuple FindMaxOverlap = 0.5;

        public HTuple FindSubPixel = "least_squares_high";

        public HTuple FindLevels = 0;

        public bool IsSecondPos;
        public HTuple SecondRow = -20;
        public HTuple SecondColumn = -10;
        public HTuple SecondRadianDiff = 0;

        //是否启用图像预处理
        //public bool IsPerprocess;

        public HTuple Emphasize = 15;//对比度增强

        public HObject PlatformRegion;//平台定位检测区域
        public HObject RobotRegion;//机械手定位检测区域

        public void Clear()
        {
            try
            {
                if (ModelID != null)
                {
                    HOperatorSet.ClearShapeModel(ModelID);
                    ModelID = null;
                    Roi?.Dispose();
                    ModelContours?.Dispose();
                    ModelOriginContours?.Dispose();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}