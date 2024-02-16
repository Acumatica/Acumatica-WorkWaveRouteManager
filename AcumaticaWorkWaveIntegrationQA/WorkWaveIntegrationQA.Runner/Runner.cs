using System.Configuration;
using System.Linq;

namespace WorkWaveIntegrationQA.Runner
{
    internal class Runner
    {
        private static int Main(string[] args)
        {
            var tempArgsList = args.ToList();
            tempArgsList.Add(ConfigurationManager.AppSettings["config"]);
            tempArgsList.Add(ConfigurationManager.AppSettings["xmlpath"]);
            var newArgs = tempArgsList.ToArray();

            return Execution.Launcher.Main(newArgs);
        }
    }
}