using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.Helpers
{
    public class JsonFileHelper
    {
        public static T Read<T>(string filePath = "appSettings.json")
        {
            using (StreamReader file = File.OpenText($@"{filePath}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                T result = (T)serializer.Deserialize(file, typeof(T));
                return result;
            }
        }
    }

    public class JsonSettings
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
    }
}
