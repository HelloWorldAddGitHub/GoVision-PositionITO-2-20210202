using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace GoVision
{
    public class ProductMgr : SingletonTemplate<ProductMgr>
    {
        /// <summary>
        /// 所有产品所在路径
        /// </summary>
        private string Path { get; set; }

        /// <summary>
        /// 当前产品名称
        /// </summary>
        public string ProductName { get; set; }

        public Action<string, string> ProductChangedMethod;

        public string ProductPath
        {
            get
            {
                return $@"{Path}{ProductName}\";
            }
        }

        public ProductParam Param { get; set; }

        public ProductData Data { get; set; }

        public ProductLog Log { get; set; }

        public ProductMgr()
        {
            //实例化
            Path = $@"{System.Environment.CurrentDirectory}\Product\";
            Param = new ProductParam();
            Data = new ProductData();
            Log = new ProductLog();
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Add(string name)
        {
            string path = $@"{Path}{name}\";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory($@"{path}Data");
                System.IO.Directory.CreateDirectory($@"{path}Log");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Delete(string name)
        {
            string path = $@"{Path}{name}\";
            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        public void LoadParam()
        {
            string path = $@"{Path}{ProductName}\Param.bin";
            if (System.IO.File.Exists(path))
            {
                //XmlSerializer xs = new XmlSerializer(typeof(ProductParam));
                BinaryFormatter binFormat = new BinaryFormatter();

                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);

                Param = (ProductParam)binFormat.Deserialize(fs);

                //Param = (ProductParam)xs.Deserialize(fs);
                fs.Close();
            }
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void SaveParam()
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            string path = $@"{Path}{ProductName}\Param.bin";
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);

            binFormat.Serialize(fs, Param);

            fs.Close();
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        public string[] GetProductList()
        {
            System.IO.DirectoryInfo product = new System.IO.DirectoryInfo(Path);
            System.IO.DirectoryInfo[] dirList = product.GetDirectories();

            int length = dirList.Length;
            string[] productList = new string[length];
            for (int i = 0; i < length; i++)
            {
                productList[i] = dirList[i].Name;
            }

            return productList;
        }

        /// <summary>
        /// 切换产品
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ChangeProduct(string name)
        {
            string path = $@"{Path}{name}\";
            if (!System.IO.Directory.Exists(path))
            {
                return false;
            }

            ProductName = name;
            Data.Path = $@"{path}Data\";
            Log.Path = $@"{path}Log\";
            LoadParam();

            ProductChangedMethod?.Invoke(name, path);

            return true;
        }
    }
}