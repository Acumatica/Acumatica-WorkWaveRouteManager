using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain;
using AcumaticaWorkWave.API.Domain.Orders;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Provider
{
    public class WWOrdersProvider : WWBaseProvider
    {
        private const string TERRITORY_ID = "territoryID";
        private const string ORDER_ID = "orderID";

        private readonly string listUrl = $"/api/v1/territories/{LB}{TERRITORY_ID}{RB}/orders";
        private readonly string singleUrl = $"/api/v1/territories/{LB}{TERRITORY_ID}{RB}/orders/{LB}{ORDER_ID}{RB}";

        public WWOrdersProvider(IWWRestOptions options) : base(options)
        {
        }

        public OrderHash List<T>(string territoryId) where T : OrderHash
        {
            var segments = AddTerritorySegment(territoryId);
            return Get<OrderHash>(listUrl, segments);
        }

        public WWSyncResponse Add(string territoryID, OrderInput orders)
        {
            var segments = AddTerritorySegment(territoryID);
            return Post<WWSyncResponse, OrderInput>(orders, listUrl, segments);
        }

        public WWSyncResponse Update(string territoryID, string orderID, Order order)
        {
            var segments = AddTerritorySegment(territoryID);
            segments.Add(ORDER_ID, orderID);
            return Post<WWSyncResponse, Order>(order, singleUrl, segments);
        }

        public WWSyncResponse ReplaceOrders(string territoryID, OrderList orders)
        {
            var segments = AddTerritorySegment(territoryID);
            return Put<WWSyncResponse, OrderList> (orders, listUrl, segments);
        }

        public WWSyncResponse Delete(string territoryID, string orderID)
        {
            var segments = AddTerritorySegment(territoryID);
            segments.Add(ORDER_ID, orderID);
            return Delete<WWSyncResponse>(singleUrl, segments);
        }

        public WWSyncResponse Delete(string territoryID, OrderIds orderIds)
        {
            var segments = AddTerritorySegment(territoryID);           
            return Delete<WWSyncResponse, OrderIds>(orderIds, listUrl, segments);
        }

        public OrderHash Get(string territoryID, string[] orderIDs)
        {
            var segments = AddTerritorySegment(territoryID);
            var parameters = GetOrderIdsParams(orderIDs);
            return Get<OrderHash>(listUrl, segments, parameters);
        }

        private WWRequestParameters GetOrderIdsParams(string[] orderIDs)
        {
            var parameters = new WWRequestParameters();
            parameters.Add("ids", string.Join(",", orderIDs));
            return parameters;
        }
    

        private static WWUrlSegments AddTerritorySegment(string territoryID)
        {
            var segments = new WWUrlSegments();
            segments.Add(TERRITORY_ID, territoryID);
            return segments;
        }
    }
}