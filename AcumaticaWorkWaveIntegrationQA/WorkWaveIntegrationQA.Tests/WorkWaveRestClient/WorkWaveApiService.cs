using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient
{
    public static class WorkWaveApiService
    {
        static WorkWaveApiService()
        {
            var _options = GetRestOptions();
            WorkWaveOrderDataHelper = new WorkWaveOrderDataHelper(_options);
            WorkWaveVehicleDataHelper = new WorkWaveVehicleDataHelper(_options);
            WorkWaveRouteDataHelper = new WorkWaveRouteDataHelper(_options);
            WorkWaveExecutionEventDataHelper = new WorkWaveExecutionEventDataHelper(_options);
        }

        #region DataProviders

        public static WorkWaveOrderDataHelper WorkWaveOrderDataHelper;
        public static WorkWaveVehicleDataHelper WorkWaveVehicleDataHelper;
        public static WorkWaveRouteDataHelper WorkWaveRouteDataHelper;
        public static WorkWaveExecutionEventDataHelper WorkWaveExecutionEventDataHelper;

        #endregion

        private static IWorkWaveRestOptions GetRestOptions()
        {
            return new WorkWaveRestOptions();
        }

    }
}
