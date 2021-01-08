using System;

namespace GoVision
{
    public class ProductLog
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

        public void WritrLine(string value)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string name = $@"{path}{date}.txt";

            using (System.IO.StreamWriter w = new System.IO.StreamWriter(name, true))
            {
                w.WriteLine($@"{DateTime.Now.ToString("HH:mm:ss.fff")} {value}");
                w.Close();
            }
        }
    }
}