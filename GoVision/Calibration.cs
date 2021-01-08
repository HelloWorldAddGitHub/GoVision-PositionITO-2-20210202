using HalconDotNet;

namespace GoVision
{
    /// <summary>
    /// 平台标定结果数据
    /// </summary>
    public class PlatformCalibData
    {
        //仿射变换矩阵
        public static HTuple HomMat2D;

        public static HTuple RowError;//像素
        public static HTuple ColumnError;//像素

        //旋转中心
        public static HTuple CenterRow;

        public static HTuple CenterColumn;
        public static HTuple CircleError;//像素

        //角度差
        public static HTuple AngleDiff;

        public static HTuple AngleError;//像素

        //毫米每像素
        public static HTuple MmPerPixel = 1;

        public static HTuple MmPerPixelError;//毫米

        //平台MARK点位置
        public static HTuple MarkRow;

        public static HTuple MarkColumn;
        public static HTuple MarkRadian;

        /// <summary>
        /// 像素转毫米
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double PixelToMm(double value)
        {
            return value * MmPerPixel;
        }

        /// <summary>
        /// 毫米转像素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double MmToPixel(double value)
        {
            return value / MmPerPixel;
        }
    }

    public class SideCameraCalibData
    {
        //毫米每像素
        public static HTuple MmPerPixel = 1;

        /// <summary>
        /// 像素转毫米
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double PixelToMm(double value)
        {
            return value * MmPerPixel;
        }

        /// <summary>
        /// 毫米转像素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double MmToPixel(double value)
        {
            return value / MmPerPixel;
        }
    }
}