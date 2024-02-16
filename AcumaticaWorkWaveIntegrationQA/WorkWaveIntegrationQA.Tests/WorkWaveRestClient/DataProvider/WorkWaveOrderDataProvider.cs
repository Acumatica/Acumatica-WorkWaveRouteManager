using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using Newtonsoft.Json;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.DataProvider;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider
{
    public class WorkWaveOrderDataProvider : WorkWaveBaseDataProvider
    {
        protected override string GetListUrl => "/api/v1/territories/{territoryId}/orders?include=all";
        protected override string SingleOrderUrl => "/api/v1/territories/{territoryId}/orders";
        protected override string PostUpdateWWOrderUrl => "/api/v1/territories/{territoryId}/orders/{orderId}";
        public WorkWaveOrderDataProvider(IWorkWaveRestOptions options) : base(options) { }

        public WorkWaveOrderResponse GetAll(string territoryId)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            return Get<Dictionary<string, object>, WorkWaveOrderResponse>(GetListUrl, segments);
        }

        public WorkWaveOrderResponse GetById(string territoryId, string id)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            WorkWaveRequestParameters parameters = new WorkWaveRequestParameters();
            parameters.AddIds(id);
            return Get<Dictionary<string, object>, WorkWaveOrderResponse>(SingleOrderUrl, segments, parameters);
        }

        public Dictionary<string, string> Update(WorkWaveOrder item, string territoryId)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            segments.AddOrderId(item.Id);
            var response = Post<object>(item, segments, null);
            var json = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public bool DeleteOrder(string territoryId, string orderId)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            segments.AddOrderId(orderId);
            return Delete(segments);
        }
    }

    public class WorkWaveOrderDataHelper
    {
        private readonly IWorkWaveRestOptions _options;

        public WorkWaveOrderDataHelper(IWorkWaveRestOptions options)
        {
            _options = options;
        }
        public WorkWaveOrderResponse GetAll()
        {
            using (var dataProvider = new WorkWaveOrderDataProvider(_options))
            {
                return dataProvider.GetAll(_options.territoryId);
            }
        }

        public List<WorkWaveOrder> GetOrderList()
        {
            using (var dataProvider = new WorkWaveOrderDataProvider(_options))
            {
                var response = dataProvider.GetAll(_options.territoryId);
                var tempDictionary = response.Results;
                List<WorkWaveOrder> resultList = new List<WorkWaveOrder>();
                foreach (var pair in tempDictionary)
                {
                    var json = JsonConvert.SerializeObject(pair.Value);
                    var tempOrder = JsonConvert.DeserializeObject<WorkWaveOrder>(json);
                    resultList.Add(tempOrder);
                }
                return resultList;
            }
        }

        public WorkWaveOrder GetOrderById(string id)
        {
            using (var dataProvider = new WorkWaveOrderDataProvider(_options))
            {
                var response = dataProvider.GetById(_options.territoryId, id);
                var tempDictionary = response.Results;
                var result = new WorkWaveOrder();
                foreach (var pair in tempDictionary)
                {
                    var json = JsonConvert.SerializeObject(pair.Value);
                    result = JsonConvert.DeserializeObject<WorkWaveOrder>(json);
                }
                return result;
            }
        }

        public Dictionary<string, string> SetVehicle(WorkWaveOrder order, string vehicleId)
        {
            using (var dataProvider = new WorkWaveOrderDataProvider(_options))
            {
                order.ForceVehicleId = vehicleId;
                order.Pickup.TimeWindows = null;
                return dataProvider.Update(order, _options.territoryId);
            }
        }

        public bool RemoveOrder(string orderId)
        {
            using (var dataProvider = new WorkWaveOrderDataProvider(_options))
            {
                return dataProvider.DeleteOrder(_options.territoryId, orderId);
            }
        }
    }
}
