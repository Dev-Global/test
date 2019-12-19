using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP8_VersionControl
{
    static class ReadIniFile
    {
        public static String fromIniFile() 
        {
            String Path = Application.StartupPath + @"\KP8VersionControl.ini";
            var inifile = new IniFile.IniFile(Path);
            String strURL = inifile.IniReadValue("AgentURL", "URL");
            return strURL;
        }

        public static String fromIniFile(String MetaDataMethodService, String ServiceMethodURL)
        {
            String Path = Application.StartupPath + @"\KP8VersionControl.ini";
            var inifile = new IniFile.IniFile(Path);
            String strURL = inifile.IniReadValue(MetaDataMethodService, ServiceMethodURL);
            return strURL;
        }

        public static string fromIniFile(String ServiceMethodURL)
        {
            string path = Application.StartupPath + @"\KP8VersionControl.ini";
            FileInfo file = new FileInfo(path);
            StreamReader fileReader = file.OpenText();
            var configline = from line in fileReader.ReadToEnd().Split((Environment.NewLine).ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
            select line;
            foreach (var item in configline)
            {
                if (item.Contains(ServiceMethodURL + "="))
                {
                    return item.Substring(item.IndexOf('=') + 1);
                }
            }
            return null;
        }

    }
}
