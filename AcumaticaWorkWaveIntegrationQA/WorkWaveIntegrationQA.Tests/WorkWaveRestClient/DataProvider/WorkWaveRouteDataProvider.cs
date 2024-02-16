using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider
{
    public class WorkWaveRouteDataProvider : WorkWaveBaseDataProvider
    {
        protected override string GetListUrl => "/api/v1/territories/{territoryId}/toa/routes";
        protected override string SingleOrderUrl => "";
        protected override string PostUpdateWWOrderUrl => "";

        protected string BuildRoutesUrl = "/api/v1/territories/{territoryId}/scheduling/buildroutes";
        protected string ApprovedUrl = "/api/v1/territories/{territoryId}/approved/{date}";
        public WorkWaveRouteDataProvider(IWorkWaveRestOptions options) : base(options) { }

        public Dictionary<string, string> BuildRoutes(string territoryId, Dictionary<string, string> dateDictionary)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            var response = Post<object>(BuildRoutesUrl, dateDictionary, segments, null);
            var json = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public WorkWaveRouteResponse GetAll(string territoryId)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            return Get<Dictionary<string, object>, WorkWaveRouteResponse>(GetListUrl, segments);
        }

        public Dictionary<string, string> ApproveRoutes(string territoryId, string date)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            segments.AddDate(date);
            var response = Post<object>(ApprovedUrl, null, segments, null);
            var json = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }

    public class WorkWaveRouteDataHelper
    {
        private readonly IWorkWaveRestOptions _options;

        public WorkWaveRouteDataHelper(IWorkWaveRestOptions options)
        {
            _options = options;
        }

        public Dictionary<string, string> DefineRoutes(Dictionary<string, string> dateDictionary)
        {
            using (var dataProvider = new WorkWaveRouteDataProvider(_options))
            {
                return dataProvider.BuildRoutes(_options.territoryId, dateDictionary);
            }
        }

        public List<WorkWaveRoute> GetRouteList()
        {
            using (var dataProvider = new WorkWaveRouteDataProvider(_options))
            {
                var response = dataProvider.GetAll(_options.territoryId);
                var tempDictionary = response.Results;
                List<WorkWaveRoute> resultList = new List<WorkWaveRoute>();
                foreach (var pair in tempDictionary)
                {
                    var json = JsonConvert.SerializeObject(pair.Value);
                    var tempOrder = JsonConvert.DeserializeObject<WorkWaveRoute>(json);
                    resultList.Add(tempOrder);
                }
                return resultList;
            }
        }

        public string GetRouteIdByOrderId(string orderId)
        {
            var routeList = GetRouteList();
            var foundRoute = routeList.FirstOrDefault(r => r.Steps.FirstOrDefault(e => e.OrderId != null && e.OrderId.Equals(orderId)) != null);
            if (foundRoute == null)
                throw new Exception($"Route is not found by order id: {orderId}");
            return foundRoute.Id;
        }

        public Dictionary<string, string> ApproveRoutes(string date)
        {
            using (var dataProvider = new WorkWaveRouteDataProvider(_options))
            {
                return dataProvider.ApproveRoutes(_options.territoryId, date);
            }
        }
    }
}
