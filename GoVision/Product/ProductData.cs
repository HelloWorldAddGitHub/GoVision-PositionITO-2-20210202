using System;

namespace GoVision
{
    public class ProductData
    {
        private string path;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
        }

        public void WriteLine(string value)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            if (!System.IO.File.Exists($@"{path}{date}.csv"))
            {
                value = $"time,index,diameter,left,right,top\r\n{value}";
            }

            using (System.IO.StreamWriter w = new System.IO.StreamWriter($@"{path}{date}.csv", true))
            {
                w.Write(value);
                w.Close();
            }
        }
    }
}