using System;
using HalconDotNet;

namespace GoVision
{
    public class HDevelopExport
    {
        /// <summary>
        /// 从三点生成九点
        /// </summary>
        /// <param name="hv_threeRow"></param>
        /// <param name="hv_threeColumn"></param>
        /// <param name="hv_nineRow"></param>
        /// <param name="hv_nineColumn"></param>
        public static void gen_nine_point(HTuple hv_threeRow, HTuple hv_threeColumn, out HTuple hv_nineRow, out HTuple hv_nineColumn)
        {
            // Local iconic variables

            // Local control variables

            HTuple hv_row1 = null, hv_row2 = null, hv_row3 = null;
            HTuple hv_column1 = null, hv_column2 = null, hv_column3 = null;
            HTuple hv_HomMat2DIdentity = null, hv_HomMat2DRotate = null;
            HTuple hv_row4 = null, hv_column4 = null, hv_row7 = null;
            HTuple hv_column7 = null, hv_HomMat2DTranslate = null;
            HTuple hv_row5 = null, hv_column5 = null, hv_row6 = null;
            HTuple hv_column6 = null, hv_row8 = null, hv_column8 = null;
            HTuple hv_row9 = null, hv_column9 = null;
            // Initialize local and output iconic variables
            hv_nineRow = new HTuple();
            hv_nineColumn = new HTuple();
            //获得输入的三点
            hv_row1 = hv_threeRow[0];
            hv_row2 = hv_threeRow[1];
            hv_row3 = hv_threeRow[2];
            hv_column1 = hv_threeColumn[0];
            hv_column2 = hv_threeColumn[1];
            hv_column3 = hv_threeColumn[2];

            //第四点和第七点
            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
            HOperatorSet.HomMat2dRotate(hv_HomMat2DIdentity, -Math.PI / 2, hv_row1, hv_column1, out hv_HomMat2DRotate);
            HOperatorSet.AffineTransPixel(hv_HomMat2DRotate, hv_row2, hv_column2, out hv_row4, out hv_column4);
            HOperatorSet.AffineTransPixel(hv_HomMat2DRotate, hv_row3, hv_column3, out hv_row7, out hv_column7);

            //第五点和第六点
            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
            HOperatorSet.HomMat2dTranslate(hv_HomMat2DIdentity, hv_row4 - hv_row1, hv_column4 - hv_column1, out hv_HomMat2DTranslate);
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_row2, hv_column2, out hv_row5, out hv_column5);
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_row3, hv_column3, out hv_row6, out hv_column6);

            //第八点和第九点
            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
            HOperatorSet.HomMat2dTranslate(hv_HomMat2DIdentity, hv_row7 - hv_row1, hv_column7 - hv_column1, out hv_HomMat2DTranslate);
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_row2, hv_column2, out hv_row8, out hv_column8);
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_row3, hv_column3, out hv_row9, out hv_column9);

            //赋值
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[0] = hv_row1;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[1] = hv_row2;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[2] = hv_row3;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[3] = hv_row4;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[4] = hv_row5;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[5] = hv_row6;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[6] = hv_row7;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[7] = hv_row8;
            if (hv_nineRow == null)
                hv_nineRow = new HTuple();
            hv_nineRow[8] = hv_row9;

            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[0] = hv_column1;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[1] = hv_column2;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[2] = hv_column3;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[3] = hv_column4;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[4] = hv_column5;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[5] = hv_column6;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[6] = hv_column7;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[7] = hv_column8;
            if (hv_nineColumn == null)
                hv_nineColumn = new HTuple();
            hv_nineColumn[8] = hv_column9;

            return;
        }

        /// <summary>
        /// 三点标定
        /// </summary>
        /// <param name="hv_pixelRows"></param>
        /// <param name="hv_pixelColumns"></param>
        /// <param name="hv_worldY"></param>
        /// <param name="hv_worldX"></param>
        /// <param name="hv_HomMat2D"></param>
        /// <param name="hv_errorRow"></param>
        /// <param name="hv_errorColumn"></param>
        public static void calib_three_point(HTuple hv_pixelRows, HTuple hv_pixelColumns, HTuple hv_worldY,
            HTuple hv_worldX, out HTuple hv_HomMat2D, out HTuple hv_errorRow, out HTuple hv_errorColumn)
        {
            // Local control variables

            HTuple hv_y1 = null, hv_x1 = null, hv_y2 = null;
            HTuple hv_x2 = null, hv_Qx = null, hv_Qy = null;
            // Initialize local and output iconic variables
            //从三点生成九点
            gen_nine_point(hv_pixelRows, hv_pixelColumns, out hv_y1, out hv_x1);
            gen_nine_point(hv_worldY, hv_worldX, out hv_y2, out hv_x2);

            //生成矩阵
            HOperatorSet.VectorToHomMat2d(hv_x1, hv_y1, hv_x2, hv_y2, out hv_HomMat2D);

            //通过矩阵仿射变换
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_x1, hv_y1, out hv_Qx, out hv_Qy);

            //最大误差
            HOperatorSet.TupleMax(hv_Qy - hv_y2, out hv_errorRow);
            HOperatorSet.TupleMax(hv_Qx - hv_x2, out hv_errorColumn);

            return;
        }

        public static void calib_nine_point(HTuple hv_pixelRows, HTuple hv_pixelColumns, HTuple hv_worldY,
            HTuple hv_worldX, out HTuple hv_HomMat2D, out HTuple hv_errorRow, out HTuple hv_errorColumn)
        {
            // Local control variables
            HTuple hv_Qx = null, hv_Qy = null;

            //生成矩阵
            HOperatorSet.VectorToHomMat2d(hv_pixelColumns, hv_pixelRows, hv_worldX, hv_worldY, out hv_HomMat2D);

            //通过矩阵仿射变换
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_pixelColumns, hv_pixelRows, out hv_Qx, out hv_Qy);

            //最大误差
            HOperatorSet.TupleMax(hv_Qy - hv_worldY, out hv_errorRow);
            HOperatorSet.TupleMax(hv_Qx - hv_worldX, out hv_errorColumn);

            return;
        }

        /// <summary>
        /// 标定旋转中心
        /// </summary>
        /// <param name="ho_ContCircle"></param>
        /// <param name="hv_rows"></param>
        /// <param name="hv_columns"></param>
        /// <param name="hv_centerRow"></param>
        /// <param name="hv_centerColumn"></param>
        /// <param name="hv_radius"></param>
        /// <param name="hv_error"></param>
        public static void calib_rotate_center(out HObject ho_ContCircle, HTuple hv_rows, HTuple hv_columns,
            out HTuple hv_centerRow, out HTuple hv_centerColumn, out HTuple hv_radius, out HTuple hv_error)
        {
            // Local iconic variables

            HObject ho_Contour = null;

            // Local control variables

            HTuple hv_LengthRow = null, hv_LengthColumn = null;
            HTuple hv_StartPhi = new HTuple(), hv_EndPhi = new HTuple();
            HTuple hv_PointOrder = new HTuple(), hv_DistanceMin = new HTuple();
            HTuple hv_DistanceMax = new HTuple();
            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            hv_centerRow = new HTuple();
            hv_centerColumn = new HTuple();
            hv_radius = new HTuple();
            hv_error = new HTuple();
            //点数量
            HOperatorSet.TupleLength(hv_rows, out hv_LengthRow);
            HOperatorSet.TupleLength(hv_columns, out hv_LengthColumn);

            if ((int)((new HTuple((new HTuple(hv_LengthRow.TupleGreaterEqual(3))).TupleAnd(
                new HTuple(hv_LengthColumn.TupleGreaterEqual(3))))).TupleAnd(new HTuple(hv_LengthRow.TupleEqual(
                hv_LengthColumn)))) != 0)
            {
                //生成轮廓并拟合圆
                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_rows, hv_columns);
                HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out hv_centerRow,
                    out hv_centerColumn, out hv_radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);

                //最大误差
                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_centerRow, hv_centerColumn,
                    hv_radius, 0, 6.28318, "positive", 1);
                HOperatorSet.DistancePc(ho_ContCircle, hv_rows, hv_columns, out hv_DistanceMin,
                    out hv_DistanceMax);
                HOperatorSet.TupleMax(hv_DistanceMin, out hv_error);
            }

            ho_Contour.Dispose();

            return;
        }

        public static void disp_message(HTuple hv_ExpDefaultWinHandle, HTuple hv_String, HTuple hv_CoordSystem,
            HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {
            // Local iconic variables

            // Local control variables

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = new HTuple(), hv_HeightWin = null;
            HTuple hv_MaxAscent = null, hv_MaxDescent = null, hv_MaxWidth = null;
            HTuple hv_MaxHeight = null, hv_R1 = new HTuple(), hv_C1 = new HTuple();
            HTuple hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_UseShadow = null, hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow (same as if no second value is given)
            //       otherwise -> use given string as color string for the shadow color
            //
            //Prepare window
            HOperatorSet.GetRgb(hv_ExpDefaultWinHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_ExpDefaultWinHandle, out hv_Row1Part, out hv_Column1Part,
                out hv_Row2Part, out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_ExpDefaultWinHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_ExpDefaultWinHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_ExpDefaultWinHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 1;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                hv_ShadowColor = "#f28d26";
            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception)
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                        0));
                }
                // catch (Exception)
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_ExpDefaultWinHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_ExpDefaultWinHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_ExpDefaultWinHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1,
                        hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                    0));
                HOperatorSet.DispRectangle1(hv_ExpDefaultWinHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_ExpDefaultWinHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_ExpDefaultWinHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_ExpDefaultWinHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_ExpDefaultWinHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_ExpDefaultWinHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }

        public static void dev_display_shape_matching_results(HTuple hv_ExpDefaultWinHandle, HTuple hv_ModelID, HTuple hv_Color,
            HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle, HTuple hv_ScaleR, HTuple hv_ScaleC, HTuple hv_Model)
        {
            //HTuple hv_ExpDefaultWinHandle = visionControl1.GetHalconWindow();

            // Local iconic variables

            HObject ho_ModelContours = null, ho_ContoursAffinTrans = null;

            // Local control variables

            HTuple hv_NumMatches = null, hv_Index = new HTuple();
            HTuple hv_Match = new HTuple(), hv_HomMat2DIdentity = new HTuple();
            HTuple hv_HomMat2DScale = new HTuple(), hv_HomMat2DRotate = new HTuple();
            HTuple hv_HomMat2DTranslate = new HTuple();
            HTuple hv_Model_COPY_INP_TMP = hv_Model.Clone();
            HTuple hv_ScaleC_COPY_INP_TMP = hv_ScaleC.Clone();
            HTuple hv_ScaleR_COPY_INP_TMP = hv_ScaleR.Clone();

            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);
            //This procedure displays the results of Shape-Based Matching.
            //

            //ProductMgr.GetInstance().Param.Roi?.Dispose();
            ProductMgr.GetInstance().Param.ModelContours?.Dispose();
            ProductMgr.GetInstance().Param.ModelOriginContours?.Dispose();

            hv_NumMatches = new HTuple(hv_Row.TupleLength());
            if ((int)(new HTuple(hv_NumMatches.TupleGreater(0))) != 0)
            {
                if ((int)(new HTuple((new HTuple(hv_ScaleR_COPY_INP_TMP.TupleLength())).TupleEqual(
                    1))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, hv_ScaleR_COPY_INP_TMP, out hv_ScaleR_COPY_INP_TMP);
                }
                if ((int)(new HTuple((new HTuple(hv_ScaleC_COPY_INP_TMP.TupleLength())).TupleEqual(
                    1))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, hv_ScaleC_COPY_INP_TMP, out hv_ScaleC_COPY_INP_TMP);
                }
                if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(
                    0))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, 0, out hv_Model_COPY_INP_TMP);
                }
                else if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength()
                    )).TupleEqual(1))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, hv_Model_COPY_INP_TMP, out hv_Model_COPY_INP_TMP);
                }
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ModelID.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    ho_ModelContours.Dispose();
                    HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID.TupleSelect(
                        hv_Index), 1);
                    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, hv_Color.TupleSelect(hv_Index % (new HTuple(hv_Color.TupleLength()
                        ))));
                    HTuple end_val18 = hv_NumMatches - 1;
                    HTuple step_val18 = 1;
                    for (hv_Match = 0; hv_Match.Continue(end_val18, step_val18); hv_Match = hv_Match.TupleAdd(step_val18))
                    {
                        if ((int)(new HTuple(hv_Index.TupleEqual(hv_Model_COPY_INP_TMP.TupleSelect(
                            hv_Match)))) != 0)
                        {
                            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                            HOperatorSet.HomMat2dScale(hv_HomMat2DIdentity, hv_ScaleR_COPY_INP_TMP.TupleSelect(
                                hv_Match), hv_ScaleC_COPY_INP_TMP.TupleSelect(hv_Match), 0, 0, out hv_HomMat2DScale);
                            HOperatorSet.HomMat2dRotate(hv_HomMat2DScale, hv_Angle.TupleSelect(hv_Match),
                                0, 0, out hv_HomMat2DRotate);
                            HOperatorSet.HomMat2dTranslate(hv_HomMat2DRotate, hv_Row.TupleSelect(
                                hv_Match), hv_Column.TupleSelect(hv_Match), out hv_HomMat2DTranslate);
                            ho_ContoursAffinTrans.Dispose();
                            HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans,
                                hv_HomMat2DTranslate);
                            //HOperatorSet.DispObj(ho_ContoursAffinTrans, hv_ExpDefaultWinHandle);

                            ProductMgr.GetInstance().Param.ModelContours = ho_ContoursAffinTrans.Clone();
                            //HOperatorSet.GetShapeModelOrigin(hv_ModelID,
                            //    out ProductMgr.GetInstance().Param.ModelOriginRow,
                            //    out ProductMgr.GetInstance().Param.ModelOriginColumn);
                            HOperatorSet.GenCrossContourXld(out ProductMgr.GetInstance().Param.ModelOriginContours,
                                 hv_Row, hv_Column, 60, hv_Angle);
                        }
                    }
                }
            }
            ho_ModelContours.Dispose();
            ho_ContoursAffinTrans.Dispose();

            return;
        }

        public static bool FindScaleShapeModel(HObject image, out HTuple row, out HTuple column, out HTuple angle,
            out HTuple scale, out HTuple score)
        {
            row = 0;
            column = 0;
            angle = 0;
            scale = 0;
            score = 0;

            try
            {
                var param = ProductMgr.GetInstance().Param;

                HTuple radStart, radExtent;
                HOperatorSet.TupleRad(param.FindAngleStart, out radStart);
                HOperatorSet.TupleRad(param.FindAngleExtent, out radExtent);

                HOperatorSet.FindScaledShapeModel(image, param.ModelID,
                    radStart, radExtent,
                    param.FindScaleMin, param.FindScaleMax,
                    param.FindScore, param.FindNumMatches,
                    param.FindMaxOverlap, param.FindSubPixel,
                    param.FindLevels, param.FindGreediness,
                    out row, out column, out angle, out scale, out score);

                if (score.Length > 0)
                {
                    //HOperatorSet.TupleDeg(angle, out angle);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="image"></param>
        /// <param name="visionControl1"></param>
        /// <returns></returns>
        public static bool FindModelProcess(HObject image, VisionControl visionControl1)
        {
            HObject domain;
            HOperatorSet.GetDomain(image, out domain);
            HTuple area, row, column;
            HOperatorSet.AreaCenter(domain, out area, out row, out column);

            //if (area > 1000000)
            //{
            //    image = HDevelopExport.Preprocess(image, false, false);
            //}

            HTuple /*row, column,*/ radian, scale, score;
            bool result = HDevelopExport.FindScaleShapeModel(image, out row, out column, out radian, out scale, out score);

            if (result)
            {
                HTuple degree;
                HOperatorSet.TupleDeg(radian, out degree);

                //visionControl1.DisplayResults();
                //Log.Show($"查找模板:{row.D:F2},{column.D:F2},{degree.D:F2}  缩放：{scale.D:F2}  分数：{score.D:F2}");
                Log.Show($"查找模板:row:{row.D:F2},column:{column.D:F2},degree:{degree.D:F2},分数：{score.D:F2}");

                HDevelopExport.dev_display_shape_matching_results(visionControl1.GetHalconWindow(),
                    ProductMgr.GetInstance().Param.ModelID, "blue", row, column, radian, scale, scale, 0);

                visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelContours);
                visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelOriginContours);

                visionControl1.DisplayResults();

                HDevelopExport.disp_message(visionControl1.GetHalconWindow(),
                    $"位置：{row.D:F2},{column.D:F2},{degree.D:F2}", "window", 10, -1, "green", "false");
                HDevelopExport.disp_message(visionControl1.GetHalconWindow(),
                    $"分数：{score.D:F2}", "window", 30, -1, "green", "false");
            }
            else
            {
                Log.Show("查找模板失败");
            }

            return result;
        }

        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="image"></param>
        /// <param name="visionControl1"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static bool FindModelProcess(HObject image, VisionControl visionControl1, out HTuple row, out HTuple column, out HTuple radian)
        {
            HTuple /*row, column, angle,*/ scale, score;
            bool result = HDevelopExport.FindScaleShapeModel(image, out row, out column, out radian, out scale, out score);

            if (result)
            {
                HTuple degree;
                HOperatorSet.TupleDeg(radian, out degree);

                //visionControl1.DisplayResults();
                Log.Show($"查找模板:row:{row.D:F2},column:{column.D:F2},degree:{degree.D:F2},分数：{score.D:F2}");

                HTuple model = ProductMgr.GetInstance().Param.ModelID;
                HDevelopExport.dev_display_shape_matching_results(visionControl1.GetHalconWindow(),
                    model, "blue", row, column, radian, scale, scale, 0);

                visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelContours);
                visionControl1.AddToStack(ProductMgr.GetInstance().Param.ModelOriginContours);

                visionControl1.DisplayResults();

                HDevelopExport.disp_message(visionControl1.GetHalconWindow(),
                    $"位置：{row.D:F2},{column.D:F2},{degree.D:F2}", "window", 10, -1, "green", "false");
                HDevelopExport.disp_message(visionControl1.GetHalconWindow(),
                    $"分数：{score.D:F2}", "window", 30, -1, "green", "false");
            }
            else
            {
                Log.Show("查找模板失败");
            }

            return result;
        }

        public static void MeasureEdge(HObject image, HTuple row, HTuple column, HTuple radian, out HTuple edgeRow1, out HTuple edgeColumn1, out HTuple edgeRow2, out HTuple edgeColumn2)
        {
            //测量外边缘
            /*HTuple*/
            edgeRow1 = new HTuple();
            edgeColumn1 = new HTuple();
            edgeRow2 = new HTuple();
            edgeColumn2 = new HTuple();

            HTuple handle;
            HOperatorSet.GenMeasureRectangle2(row, column, radian + Math.PI / 2, 20, 40, 5472, 3648, "nearest_neighbor", out handle);

            for (int i = 0; i < 5; i++)
            {
                //设置幅度值
                //HTuple threshold = 10 - i * 2;
                //if (threshold < 1)
                //{
                //    threshold = 1;
                //}

                //HTuple width, height;
                //HOperatorSet.GetImageSize(image, out width, out height);

                HTuple rows = new HTuple();
                HTuple columns = new HTuple();

                HTuple threshold = 10;

                int length = 10;
                if (MeasureMgr.GetInstance().MeasureList.Count > 0)
                {
                    length = MeasureMgr.GetInstance().MeasureList[0].PinCount;
                    //MeasureMgr.GetInstance().MeasureList[0].FindEdge(image, row, column, radian, out edgeRow1, out edgeColumn1, out edgeRow2, out edgeColumn2);
                }

                for (int j = 0; j < length; j++)
                {
                    HTuple rowEdge, columnEdge, amplitude, distance;

                    //变换检测位置
                    HTuple homMat2D, rowTrans, columnTrans;
                    HOperatorSet.HomMat2dIdentity(out homMat2D);
                    HOperatorSet.HomMat2dTranslate(homMat2D, 80 - i * 15, j * 40, out homMat2D);
                    HOperatorSet.HomMat2dRotate(homMat2D, radian, row, column, out homMat2D);
                    HOperatorSet.AffineTransPixel(homMat2D, row, column, out rowTrans, out columnTrans);

                    HOperatorSet.TranslateMeasure(handle, rowTrans, columnTrans);

                    HOperatorSet.MeasurePos(image, handle, 1, threshold, "negative", "first",
                        out rowEdge, out columnEdge, out amplitude, out distance);

                    if (rowEdge.Length > 0)
                    {
                        rows.Append(rowEdge);
                        columns.Append(columnEdge);
                    }

                    if (j == 4 && rows.Length < 5 && threshold > 5)
                    {
                        threshold -= 2;
                        j = 0;

                        rows = new HTuple();
                        columns = new HTuple();
                    }
                }

                if (rows.Length >= 3)
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
                    //contour?.Dispose();
                    //HOperatorSet.GenContourPolygonXld(out contour, new HTuple(edgeRow1, edgeRow2), new HTuple(edgeColumn1, edgeColumn2));
                    //HOperatorSet.ConcatObj(LineEdge, contour, out LineEdge);

                    break;
                }
            }

            HOperatorSet.CloseMeasure(handle);
        }

        public static void MeasurePinFirst(HObject image, HTuple row, HTuple column, HTuple radian, out HTuple edgeRow1, out HTuple edgeColumn1, out HTuple edgeRow2, out HTuple edgeColumn2)
        {
            edgeRow1 = new HTuple();
            edgeColumn1 = new HTuple();
            edgeRow2 = new HTuple();
            edgeColumn2 = new HTuple();

            HTuple handle = null;
            HOperatorSet.GenMeasureRectangle2(row, column, radian, 25, 20, 5472, 3648, "nearest_neighbor", out handle);


            for (int i = 0; i <= 5; i++)
            {
                //设置幅度值
                HTuple threshold = 20 - i * 2;
                if (threshold < 1)
                {
                    threshold = 1;
                }

                HTuple rows = new HTuple();
                HTuple columns = new HTuple();

                for (int j = 0; j < 3; j++)
                {
                    HTuple rowEdge, columnEdge, amplitude, distance;

                    //变换检测位置
                    HTuple homMat2D, rowTrans, columnTrans;
                    HOperatorSet.HomMat2dIdentity(out homMat2D);
                    HOperatorSet.HomMat2dTranslate(homMat2D, (j % 3 - 1) * 10, 0, out homMat2D);
                    HOperatorSet.HomMat2dRotate(homMat2D, radian, row, column, out homMat2D);
                    HOperatorSet.AffineTransPixel(homMat2D, row, column, out rowTrans, out columnTrans);

                    HOperatorSet.TranslateMeasure(handle, rowTrans, columnTrans);

                    HOperatorSet.MeasurePos(image, handle, 1, threshold, "positive", "first",
                        out rowEdge, out columnEdge, out amplitude, out distance);

                    if (rowEdge.Length > 0)
                    {
                        rows.Append(rowEdge);
                        columns.Append(columnEdge);
                    }
                }

                if (rows.Length >= 3)
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
                    //contour?.Dispose();
                    //HOperatorSet.GenContourPolygonXld(out contour, new HTuple(edgeRow1, edgeRow2), new HTuple(edgeColumn1, edgeColumn2));
                    //HOperatorSet.ConcatObj(LineEdge, contour, out LineEdge);

                    break;
                }
            }

            HOperatorSet.CloseMeasure(handle);
        }

        /// <summary>
        /// 二次定位
        /// </summary>
        /// <param name="image"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radian"></param>
        /// <param name="transRow"></param>
        /// <param name="transColumn"></param>
        /// <param name="transRadian"></param>
        /// <returns></returns>
        public static bool FindPinCenter(HObject image, HTuple row, HTuple column, HTuple radian, out HTuple transRow, out HTuple transColumn, out HTuple transRadian)
        {
            //transRow = new HTuple();
            //transColumn = new HTuple();
            //transRadian = new HTuple();

            transRow = row;
            transColumn = column;
            transRadian = radian;

            var p = ProductMgr.GetInstance().Param;

            //查找产品边缘
            HTuple edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, pinRow1, pinColumn1, pinRow2, pinColumn2;
            HTuple pointRow, pointColumn, isOverlapping;

            if (MeasureMgr.GetInstance().MeasureList.Count > 0)
            {
                MeasureMgr.GetInstance().MeasureList[0].FindEdge(image, row, column, radian, out edgeRow1, out edgeColumn1, out edgeRow2, out edgeColumn2);

            }
            else
            {
                MeasureEdge(image, row, column, radian, out edgeRow1, out edgeColumn1, out edgeRow2, out edgeColumn2);
            }

            if (edgeRow1.Length > 0)
            {
                //判断产品边缘角度
                HOperatorSet.AngleLx(edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, out transRadian);
                var r = transRadian - p.SecondRadianDiff - radian;

                if (r > 0.017 || r < -0.017)
                {
                    return false;
                }

                //查找第一个引脚边
                pinRow1 = new HTuple();
                pinColumn1 = new HTuple();
                pinRow2 = new HTuple();
                pinColumn2 = new HTuple();
                MeasurePinFirst(image, row, column, radian, out pinRow1, out pinColumn1, out pinRow2, out pinColumn2);
                HTuple angle, deg = 0;
                if (pinRow1.Length > 0)
                {
                    HOperatorSet.AngleLl(edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, pinRow1, pinColumn1, pinRow2, pinColumn2, out angle);
                    HOperatorSet.TupleDeg(angle, out deg);
                }



                HTuple homMat2D;
                HObject contour1, contour2, cross;

                HOperatorSet.GenEmptyObj(out contour1);
                HOperatorSet.GenEmptyObj(out contour2);
                HOperatorSet.GenEmptyObj(out cross);

                if (pinRow1.Length > 0 && deg > -91 && deg < -89)
                {
                    //当产品边缘和引脚边缘都找到且角度差为-90时，则求交点并转换
                    HOperatorSet.IntersectionLines(edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, pinRow1, pinColumn1, pinRow2, pinColumn2,
                        out pointRow, out pointColumn, out isOverlapping);

                    if (pointRow.Length > 0)
                    {
                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dTranslate(homMat2D, p.SecondRow, p.SecondColumn, out homMat2D);
                        HOperatorSet.HomMat2dRotate(homMat2D, transRadian, pointRow, pointColumn, out homMat2D);
                        HOperatorSet.AffineTransPixel(homMat2D, pointRow, pointColumn, out transRow, out transColumn);

                        HOperatorSet.GenContourPolygonXld(out contour1, new HTuple(edgeRow1, edgeRow2), new HTuple(edgeColumn1, edgeColumn2));
                        HOperatorSet.GenContourPolygonXld(out contour2, new HTuple(pinRow1, pinRow2), new HTuple(pinColumn1, pinColumn2));
                        HOperatorSet.GenCrossContourXld(out cross, transRow, transColumn, 20, transRadian);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //当只找到产品边缘或角度错误时，则只转换Row
                    HTuple distance;
                    HOperatorSet.DistancePl(row, column, edgeRow1, edgeColumn1, edgeRow2, edgeColumn2, out distance);

                    HOperatorSet.HomMat2dIdentity(out homMat2D);
                    HOperatorSet.HomMat2dTranslate(homMat2D, p.SecondRow + distance, 0, out homMat2D);
                    HOperatorSet.HomMat2dRotate(homMat2D, transRadian, row, column, out homMat2D);
                    HOperatorSet.AffineTransPixel(homMat2D, row, column, out transRow, out transColumn);

                    HOperatorSet.GenContourPolygonXld(out contour1, new HTuple(edgeRow1, edgeRow2), new HTuple(edgeColumn1, edgeColumn2));
                    HOperatorSet.GenCrossContourXld(out cross, transRow, transColumn, 20, transRadian);
                }

                HOperatorSet.ConcatObj(ProductMgr.GetInstance().Param.ModelContours, contour1, out ProductMgr.GetInstance().Param.ModelContours);
                HOperatorSet.ConcatObj(ProductMgr.GetInstance().Param.ModelContours, contour2, out ProductMgr.GetInstance().Param.ModelContours);
                HOperatorSet.ConcatObj(ProductMgr.GetInstance().Param.ModelContours, cross, out ProductMgr.GetInstance().Param.ModelContours);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 图像预处理
        /// </summary>
        /// <param name="ho_Image">图像</param>
        /// <param name="isAdjust">是否矫正</param>
        /// <param name="isThreshold">是否阈值处理图像</param>
        /// <returns></returns>
        public static HObject Preprocess(HObject ho_Image, HTuple contrast, bool isAdjust)
        {
            // Stack for temporary objects
            //HObject[] OTemp = new HObject[20];

            // Local iconic variables

            HObject /*ho_Image, */ho_Regions1, ho_Connection1;
            HObject ho_RegionOpening1, ho_SelectedRegions1, ho_RegionTrans1;
            HObject ho_ImageReduced, ho_ImageScaled, ho_Regions, ho_Connection;
            HObject ho_RegionOpening, ho_SelectedRegions, ho_RegionTrans;
            HObject ho_RegionDilation = null, ho_ImageReduced2 = null, ho_Edges = null;
            HObject ho_ContoursSplit = null, ho_ObjectSelected = null, ho_ImageAniso;
            HObject ho_ImageEmphasize;

            // Local control variables

            HTuple hv_Length = new HTuple(), hv_Indices = new HTuple();
            HTuple hv_Inverted = new HTuple(), hv_RowBegin = new HTuple();
            HTuple hv_ColBegin = new HTuple(), hv_RowEnd = new HTuple();
            HTuple hv_ColEnd = new HTuple(), hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_phi = new HTuple();
            HTuple hv_HomMat2DIdentity = new HTuple(), hv_HomMat2DRotate = new HTuple();
            // Initialize local and output iconic variables
            //HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Regions1);
            HOperatorSet.GenEmptyObj(out ho_Connection1);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening1);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans1);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_Connection);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced2);
            HOperatorSet.GenEmptyObj(out ho_Edges);
            HOperatorSet.GenEmptyObj(out ho_ContoursSplit);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            HOperatorSet.GenEmptyObj(out ho_ImageAniso);
            HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);

            //read_image (Image, 'F:/ruifei/图片/11 (2).bmp')
            //read_image (Image, 'F:/ruifei/图片/14 (3).bmp')
            //read_image (Image, 'F:/ruifei/图片/11 (3).bmp')
            //read_image (Image, 'F:/ruifei/图片/11 (4).bmp')
            //ho_Image.Dispose();
            //HOperatorSet.ReadImage(out ho_Image, "F:/ruifei/图片/14 (4).bmp");
            /*
            if (region!=null && region.IsInitialized())
            {
                HOperatorSet.ReduceDomain(ho_Image, region, out ho_ImageReduced);
                ho_ImageScaled.Dispose();
                HOperatorSet.ScaleImage(ho_ImageReduced, out ho_ImageScaled, 6.375, -892);
            }
            else
            {
                //提取平台
                ho_Regions1.Dispose();
                HOperatorSet.Threshold(ho_Image, out ho_Regions1, 41, 100);
                ho_Connection1.Dispose();
                HOperatorSet.Connection(ho_Regions1, out ho_Connection1);
                ho_RegionOpening1.Dispose();
                HOperatorSet.OpeningRectangle1(ho_Connection1, out ho_RegionOpening1, 50, 50);
                ho_Connection1.Dispose();
                HOperatorSet.Connection(ho_RegionOpening1, out ho_Connection1);
                ho_SelectedRegions1.Dispose();
                HOperatorSet.SelectShape(ho_Connection1, out ho_SelectedRegions1, "area", "and",
                    5000000, 20000000);
                ho_RegionTrans1.Dispose();
                HOperatorSet.ShapeTrans(ho_SelectedRegions1, out ho_RegionTrans1, "convex");
                //gen_rectangle1 (ROI_0, 83.7166, 1057.35, 3623.43, 4951.6)
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_Image, ho_RegionTrans1, out ho_ImageReduced);
            }
            */

            ho_ImageReduced = ho_Image;

            //提取产品区域
            ho_ImageScaled.Dispose();
            HOperatorSet.ScaleImage(ho_ImageReduced, out ho_ImageScaled, 6.375, -892);
            ho_Regions.Dispose();
            HOperatorSet.Threshold(ho_ImageScaled, out ho_Regions, 160, 255);
            ho_Connection.Dispose();
            HOperatorSet.Connection(ho_Regions, out ho_Connection);

            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningCircle(ho_Connection, out ho_RegionOpening, 9);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShape(ho_RegionOpening, out ho_SelectedRegions, "area", "and",
                5000, 99999999);
            ho_RegionTrans.Dispose();
            HOperatorSet.ShapeTrans(ho_SelectedRegions, out ho_RegionTrans, "convex");
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.ShapeTrans(ho_RegionTrans, out ExpTmpOutVar_0, "rectangle2");
                ho_RegionTrans.Dispose();
                ho_RegionTrans = ExpTmpOutVar_0;
            }

            //矫正图像
            if (isAdjust)
            {
                ho_RegionDilation.Dispose();
                HOperatorSet.DilationCircle(ho_RegionTrans, out ho_RegionDilation, 11);
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ShapeTrans(ho_RegionDilation, out ExpTmpOutVar_0, "rectangle2");
                    ho_RegionDilation.Dispose();
                    ho_RegionDilation = ExpTmpOutVar_0;
                }
                ho_ImageReduced2.Dispose();
                HOperatorSet.ReduceDomain(ho_ImageReduced, ho_RegionDilation, out ho_ImageReduced2
                    );

                //提取边缘
                ho_Edges.Dispose();
                HOperatorSet.EdgesSubPix(ho_ImageReduced2, out ho_Edges, "canny", 5, 40, 60);
                ho_ContoursSplit.Dispose();
                HOperatorSet.SegmentContoursXld(ho_Edges, out ho_ContoursSplit, "lines_circles",
                    5, 6, 4);
                HOperatorSet.LengthXld(ho_ContoursSplit, out hv_Length);
                HOperatorSet.TupleSortIndex(hv_Length, out hv_Indices);
                HOperatorSet.TupleInverse(hv_Indices, out hv_Inverted);
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(ho_ContoursSplit, out ho_ObjectSelected, (hv_Inverted.TupleSelect(
                    0)) + 1);

                HOperatorSet.FitLineContourXld(ho_ObjectSelected, "tukey", -1, 0, 5, 2, out hv_RowBegin,
                    out hv_ColBegin, out hv_RowEnd, out hv_ColEnd, out hv_Nr, out hv_Nc, out hv_Dist);
                //disp_line (3600, RowBegin, ColBegin, RowEnd, ColEnd)

                if ((int)(new HTuple(hv_ColBegin.TupleLess(hv_ColEnd))) != 0)
                {
                    HOperatorSet.AngleLx(hv_RowBegin, hv_ColBegin, hv_RowEnd, hv_ColEnd, out hv_phi);
                }
                else
                {
                    HOperatorSet.AngleLx(hv_RowEnd, hv_ColEnd, hv_RowBegin, hv_ColBegin, out hv_phi);
                }

                HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                HOperatorSet.HomMat2dRotateLocal(hv_HomMat2DIdentity, -hv_phi, out hv_HomMat2DRotate);

                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.AffineTransImage(ho_ImageReduced, out ExpTmpOutVar_0, hv_HomMat2DRotate,
                        "constant", "false");
                    ho_ImageReduced.Dispose();
                    ho_ImageReduced = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.AffineTransRegion(ho_RegionTrans, out ExpTmpOutVar_0, hv_HomMat2DRotate,
                        "constant");
                    ho_RegionTrans.Dispose();
                    ho_RegionTrans = ExpTmpOutVar_0;
                }
            }

            //膨胀
            ho_RegionDilation.Dispose();
            HOperatorSet.DilationCircle(ho_RegionTrans, out ho_RegionDilation, 25.5);
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.ShapeTrans(ho_RegionDilation, out ExpTmpOutVar_0, "rectangle1");
                ho_RegionDilation.Dispose();
                ho_RegionDilation = ExpTmpOutVar_0;
            }
            ho_ImageReduced2.Dispose();
            HOperatorSet.ReduceDomain(ho_ImageReduced, ho_RegionDilation, out ho_ImageReduced2);

            //去除椒盐噪声
            ho_ImageAniso.Dispose();
            HOperatorSet.AnisotropicDiffusion(ho_ImageReduced2, out ho_ImageAniso, "weickert",
                5, 1, 10);
            //增强图像对比度
            ho_ImageEmphasize.Dispose();
            HOperatorSet.Emphasize(ho_ImageAniso, out ho_ImageEmphasize, contrast, contrast, 1);

            //ho_Image.Dispose();
            ho_Regions1.Dispose();
            ho_Connection1.Dispose();
            ho_RegionOpening1.Dispose();
            ho_SelectedRegions1.Dispose();
            ho_RegionTrans1.Dispose();
            ho_ImageReduced.Dispose();
            ho_ImageScaled.Dispose();
            ho_Regions.Dispose();
            ho_Connection.Dispose();
            ho_RegionOpening.Dispose();
            ho_SelectedRegions.Dispose();
            ho_RegionTrans.Dispose();
            ho_RegionDilation.Dispose();
            ho_ImageReduced2.Dispose();
            ho_Edges.Dispose();
            ho_ContoursSplit.Dispose();
            ho_ObjectSelected.Dispose();
            ho_ImageAniso.Dispose();
            //ho_ImageEmphasize.Dispose();

            return ho_ImageEmphasize;
        }

        /// <summary>
        /// 写入图像
        /// </summary>
        /// <param name="image">图像</param>
        /// <param name="fileName">文件名称</param>
        public static void WriteImage(HObject image, string fileName)
        {
            string name = fileName.Replace("\\", "/");
            string ext = System.IO.Path.GetExtension(fileName).Replace(".", "");
            HOperatorSet.WriteImage(image, ext, 0, name);
        }

        /// <summary>
        /// 写入窗口内容到文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        public static void DumpWindow(HTuple windowHandle, string fileName)
        {
            string name = fileName.Replace("\\", "/");
            string ext = System.IO.Path.GetExtension(fileName).Replace(".", "");
            HOperatorSet.DumpWindow(windowHandle, ext, name);
        }
    }
}