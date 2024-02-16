using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Log;

namespace WorkWaveIntegrationQA.Tests.Helpers
{
    public class PdfHelper
    {
        List<string> downloadFolders;
        private string downloadedFolder1;
        private string downloadedFolder2;
        private string downloadedFolder3;
        public const string path1 = @"C:\Share\download\";

        public DirectoryInfo BinFolder { get; set; }

        public PdfHelper()
        {
            downloadedFolder1 = Config.BROWSER_DOWNLOADS_FOLDER;
            downloadedFolder2 = path1;
            downloadedFolder3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            BinFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
            downloadFolders = new List<string>() { downloadedFolder1, downloadedFolder2, downloadedFolder3 };
        }

        public string GetFilePath(string fileName)
        {
            var path = downloadFolders.FirstOrDefault(x => File.Exists(Path.Combine(x, fileName)));
            if (path == null)
            {
                Log.Information("File does not exist in the download folders");
            }
            return Path.Combine(path, fileName);
        }

    }
}
