using System.Configuration;

namespace GoCommon
{
    internal class ConfigTool
    {
        public static string Get(string key, string defaultValue = "")
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                return config.AppSettings.Settings[key]?.Value ?? defaultValue;
            }
            catch { return defaultValue; }
        }

        public static string GetExe(string exePath, string key, string defaultValue = "")
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);
                return config.AppSettings.Settings[key]?.Value ?? defaultValue;
            }
            catch { return defaultValue; }
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            int value;
            string s = Get(key: key);
            if (int.TryParse(s, out value)) return value;
            return defaultValue;
        }

        public static int GetExeInt(string exePath, string key, int defaultValue = 0)
        {
            int value;
            string s = GetExe(exePath: exePath, key: key);
            if (int.TryParse(s, out value)) return value;
            return defaultValue;
        }

        public static bool Set(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                return true;
            }
            catch { return false; }
        }

        public static bool SetExe(string exePath, string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                return true;
            }
            catch { return false; }
        }
    }
}