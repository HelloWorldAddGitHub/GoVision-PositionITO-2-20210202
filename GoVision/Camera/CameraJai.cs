using System.Collections.Generic;
using HalconDotNet;
using Jai_FactoryDotNET;
using System;

namespace GoVision
{
    public class CameraJai : CameraBase, IDisposable
    {
        public CCamera Instance;
        private static CFactory Factory = new CFactory();
        private uint BufferCount = 5;

        public CameraJai(string strName) : base(strName)
        {
            Instance = new CCamera();
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="camera">CCamera对象</param>
        public CameraJai(string strName, CCamera camera) : base(strName)
        {
            Instance = camera;
        }

        /// <summary>
        /// 发现相机
        /// </summary>
        /// <returns></returns>
        public static CCamera[] FindCamera()
        {
            Factory.Open();
            Factory.UpdateCameraList(CFactory.EDriverType.FilterDriver);
            var cameraList = Factory.CameraList.ToArray();

            //foreach (var cam in cameraList)
            //{
            //    cam.Open();
            //}

            return cameraList;
        }

        /// <summary>
        /// 生成HObject对象
        /// </summary>
        /// <param name="info">图像信息</param>
        private void GenHImage(ref Jai_FactoryWrapper.ImageInfo info)
        {
            m_image?.Dispose();
            HOperatorSet.GenEmptyObj(out m_image);

            if (info.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
            {
                unsafe
                {
                    IntPtr p = new IntPtr(info.ImageBuffer.ToPointer());
                    HOperatorSet.GenImage1(out m_image, "byte", info.SizeX, info.SizeY, p);
                }
            }
        }

        public override bool Close()
        {
            if (Instance != null && Instance.IsOpen)
            {
                Instance.Close();
            }

            Instance = null;
            return true;
        }

        public override int Grab()
        {
            if (!Instance.IsOpen)
            {
                if (!Open())
                {
                    return 0;
                }
                //var e = Instance.Open();

                //if (e != Jai_FactoryWrapper.EFactoryError.Success)
                //{
                //    return 0;
                //}
            }

            if (Instance.IsAsyncImageRecordingRunning)
            {
                return 1;
            }

            var error = Instance.StartAsyncImageRecording((int)BufferCount, CCamera.AsyncImageRecordingMode.CyclicBuffer, 0);

            if (error != Jai_FactoryWrapper.EFactoryError.Success)
            {
                return 0;
            }

            return 1;
        }

        public override bool isOpen()
        {
            return Instance.IsOpen;
        }

        public override bool Open()
        {
            if (Instance == null)
            {
                return false;
            }

            if (Instance.IsOpen)
            {
                return true;
            }

            var error = Instance.Open();

            if (error == Jai_FactoryWrapper.EFactoryError.Success)
            {
                Instance.NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(GenHImage);
                return true;
            }

            return false;
        }

        public override void SetGrabParam(string strParam, int nValue)
        {
            if (!Instance.IsOpen)
            {
                if (!Open())
                {
                    return;
                }
                //var e = Instance.Open();

                //if (e != Jai_FactoryWrapper.EFactoryError.Success)
                //{
                //    return;
                //}
            }

            CNode node = Instance.GetNode(strParam);
            if (node != null)
            {
                node.Value = nValue;
            }
        }

        public override int Snap()
        {
            if (!Instance.IsOpen)
            {
                if (!Open())
                {
                    return 0;
                } 
                //var e = Instance.Open();

                //if (e != Jai_FactoryWrapper.EFactoryError.Success)
                //{
                //    return 0;
                //}
            }

            var error = Instance.StartImageAcquisition(false, BufferCount);

            if (error == Jai_FactoryWrapper.EFactoryError.Success)
            {
                Instance.StopImageAcquisition();
                return 1;
            }

            return 0;
        }

        public override bool StopGrab()
        {
            if (Instance.IsAsyncImageRecordingRunning)
            {
                Instance.StopAsyncImageRecording();
            }

            return true;
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
                Factory.Close();
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~CameraJai() {
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
        #endregion
    }
}