using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider
{
    public class WorkWaveExecutionEventDataProvider : WorkWaveBaseDataProvider
    {
        protected override string GetListUrl => "";
        protected override string SingleOrderUrl => "";
        protected override string PostUpdateWWOrderUrl => "";

        protected string ExecutionEventUrl = "/api/v1/territories/{territoryId}/toa/executionevents";
        public WorkWaveExecutionEventDataProvider(IWorkWaveRestOptions options) : base(options) { }

        public Dictionary<string, string> SetExecutionEvent(string territoryId, List<WorkWaveExecutionEvent> executionEventList)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            Dictionary<string, List<WorkWaveExecutionEvent>> requestBody =
                new Dictionary<string, List<WorkWaveExecutionEvent>>()
                {
                    { "events",  executionEventList}
                };
            var response = Post<object>(ExecutionEventUrl, requestBody, segments, null);
            var json = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }

    public class WorkWaveExecutionEventDataHelper
    {
        private readonly IWorkWaveRestOptions _options;

        public WorkWaveExecutionEventDataHelper(IWorkWaveRestOptions options)
        {
            _options = options;
        }

        public Dictionary<string, string> SetExecutionEvent(List<WorkWaveExecutionEvent> executionEventList)
        {
            using (var dataProvider = new WorkWaveExecutionEventDataProvider(_options))
            {
                return dataProvider.SetExecutionEvent(_options.territoryId, executionEventList);
            }
        }

        public List<WorkWaveExecutionEvent> SetEventDeliveryBarcode(string orderId, string vehicleId, string dateString, string barcode)
        {
            var barcodeList = new WorkWaveExecutionEventDataBarcodeList()
            {
                Barcodes = new List<WorkWaveExecutionEventDataBarcode>()
                {
                    new WorkWaveExecutionEventDataBarcode()
                    {
                        Barcode = barcode,
                        BarcodeStatus = "UNREADABLE",
                        Sec = 4500
                    }
                }
            };
            return new List<WorkWaveExecutionEvent>()
            {
                new WorkWaveExecutionEvent() {Type = "podBarcodes", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = barcodeList},
            };
        }

        public List<WorkWaveExecutionEvent> SetEventPickUp(string orderId, string vehicleId, string dateString)
        {
            return new List<WorkWaveExecutionEvent>()
            {
                new WorkWaveExecutionEvent() {Type = "timeIn", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "pickup", Date = dateString, 
                    Data = new WorkWaveExecutionEventData() {Sec = 36000}},
                new WorkWaveExecutionEvent() {Type = "timeOut", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "pickup", Date = dateString,
                    Data = new WorkWaveExecutionEventData() {Sec = 38000}},
                new WorkWaveExecutionEvent() {Type = "statusUpdate", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "pickup", Date = dateString,
                    Data = new WorkWaveExecutionEventData() {Sec = 37000, Status = "done"}},
            };
        }

        public List<WorkWaveExecutionEvent> SetEventDelivery(string orderId, string vehicleId, string dateString)
        {
            return new List<WorkWaveExecutionEvent>()
            {
                new WorkWaveExecutionEvent() {Type = "timeIn", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData() {Sec = 46000}},
                new WorkWaveExecutionEvent() {Type = "timeOut", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData() {Sec = 48000}},
                new WorkWaveExecutionEvent() {Type = "statusUpdate", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData() {Sec = 47000, Status = "done"}},
            };
        }

        public List<WorkWaveExecutionEvent> SetEventDeliveryFiles(string orderId, string vehicleId, string dateString)
        {
            return new List<WorkWaveExecutionEvent>()
            {
                new WorkWaveExecutionEvent() {Type = "podNote", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData() {Sec = 46000, Text = "Test Note 6"}},
                new WorkWaveExecutionEvent() {Type = "podPicture", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData()
                    {
                        Id = "picture-1",
                        Sec = 46000,
                        Text = "Minor damage in lower left corner",
                        Mime = "image/png",
                        Data = GetBase64String("Images\\image1.png")
                    }},
                new WorkWaveExecutionEvent() {Type = "podPicture", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData()
                    {
                        Id = "picture-2",
                        Sec = 46000,
                        Text = "Minor damage in lower left corner2",
                        Mime = "image/png",
                        Data = GetBase64String("Images\\image2.png")
                    }},
                new WorkWaveExecutionEvent() {Type = "podSignature", OrderId = orderId, VehicleId = vehicleId, OrderStepType = "delivery", Date = dateString,
                    Data = new WorkWaveExecutionEventData()
                    {
                        Id = "customer",
                        Sec = 46000,
                        Text = "John Black",
                        Mime = "image/png",
                        Data = GetBase64String("Images\\signature.png")
                    }},
            };
        }

        public string GetBase64String(string path)
        {
            byte[] imageArray = File.ReadAllBytes(path);
            return Convert.ToBase64String(imageArray);
        }
    }
}
