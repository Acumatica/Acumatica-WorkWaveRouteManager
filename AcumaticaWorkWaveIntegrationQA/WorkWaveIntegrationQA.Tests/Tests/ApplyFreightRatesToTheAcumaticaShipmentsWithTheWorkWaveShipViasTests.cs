using System;
using System.Collections.Generic;
using System.Linq;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;
using WorkWaveIntegrationQA.Tests.WebhookRestClient;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class ApplyFreightRatesToTheAcumaticaShipmentsWithTheWorkWaveShipViasTests : TestBase
    {
        private string _shipmentNumber;
        private string _salesNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        private string _shipViaCodesId = "WW2";
        private string _calculationMethodInit = "Manual";
        private string _calculationMethod = "Net";
        private double _baseRate = 100.00;
        private double _cost = 250.00;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("AWV-138. Apply freight rates to the Acumatica shipments with the WorkWave ship vias"))
            {
                Precondition();
                TestCase01();
                TestCase02();
                TestCase03();
                TestCase04();
                TestCase05();
                TestCase06();
            }
        }

        private void Precondition()
        {
            using (TestExecution.CreateTestStepGroup("Precondition"))
            {
                AssertWorkWaveCarrier();
            }
        }

        private void TestCase01()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #1. Step 1 - Create a new Ship via Codes"))
            {
                AddNewShipViaCodeForFreightRates(_shipViaCodesId);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Validate elements"))
            {
                AssertFreightRatesFieldsShipViaCode(_shipViaCodesId);
            }
        }

        private void TestCase02()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #2. Step 1 - Update the Calculation Method"))
            {
                UpdateCalculationMethodAndBaseRateShipViaCode(_shipViaCodesId, _calculationMethod, _baseRate);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Create the Sales Order and Shipment"))
            {
                _shipmentNumber = CreateSalesOrderAndShipment(shipVia: _shipViaCodesId);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Shipment. Validate the Freight Rates"))
            {
                AssertFreightRatesShipment(_shipmentNumber, _baseRate);
            }
        }

        private void TestCase03()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #3. Step 1 - Update the Calculation Method"))
            {
                UpdateCalculationMethodAndBaseRateShipViaCode(_shipViaCodesId, _calculationMethod, _baseRate);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Ship Via Codes. Add the Freight Rate"))
            {
                AddFreightRateShipViaCodes(id: _shipViaCodesId, rate: _baseRate);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Create the Sales Order and Shipment"))
            {
                _salesNumber = CreateSalesOrder(shipVia: _shipViaCodesId);
                SetShippingZoneSalesOrder(_salesNumber);
                _shipmentNumber = CreateShipment(_salesNumber);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Shipment. Validate the Freight Rates"))
            {
                AssertFreightRatesShipment(_shipmentNumber, _baseRate + _baseRate);
            }
        }

        private void TestCase04()
        {
            double multiplication = 0.00;
            using (TestExecution.CreateTestStepGroup("TestCase #4. Step 1 - Update the Calculation Method"))
            {
                UpdateCalculationMethodAndBaseRateShipViaCode(_shipViaCodesId, "Per Unit", _baseRate);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Ship Via Codes. Add the Freight Rate"))
            {
                AddFreightRateShipViaCodes(id: _shipViaCodesId, rate: _baseRate);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Create the Sales Order and Shipment. Get the Multiplication"))
            {
                _salesNumber = CreateSalesOrder(shipVia: _shipViaCodesId);
                SetShippingZoneSalesOrder(_salesNumber);
                _shipmentNumber = CreateShipment(_salesNumber);
                var volume = GetShippedVolumeShipment(_shipmentNumber);
                multiplication = GetFreightRateMultiplicationShipViaCode(_shipViaCodesId, volume);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Shipment. Validate the Freight Rates"))
            {
                AssertFreightRatesShipment(_shipmentNumber, _baseRate + multiplication);
            }
        }

        private void TestCase05()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #5. Step 1 - Update the Calculation Method"))
            {
                UpdateCalculationMethodAndBaseRateShipViaCode(_shipViaCodesId, _calculationMethodInit);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Ship Via Codes. Add the Freight Rate. Get the Multiplication"))
            {
                AddFreightRateShipViaCodes(id: _shipViaCodesId, rate: _baseRate);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Create the Sales Order and Shipment"))
            {
                _salesNumber = CreateSalesOrder(shipVia: _shipViaCodesId);
                SetShippingZoneSalesOrder(_salesNumber);
                SetFreightCostSalesOrder(_salesNumber, _cost);
                _shipmentNumber = CreateShipment(_salesNumber);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Shipment. Validate the Freight Rates"))
            {
                AssertFreightRatesShipment(_shipmentNumber, _cost);
            }
        }

        private void TestCase06()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #6 (Send data to the Work Wave Route Manager). " +
                                                     "Step 1 - Create a new WorkWave order"))
            {
                //_shipmentNumber = "004399";
                _requestId = CreateWorkWaveOrder(_shipmentNumber);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Validate the just created WorkWave order"))
            {
                //_shipmentNumber = "003669";
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Pending"},
                        {"WWOrderID", ""},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Partially Routed", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Get the content from Webhook by Request Id"))
            {
                //_requestId = "c38db0b8-12f4-4ed2-9d26-1b105fe478a6";
                _content = GetWebhookContentByGuid(_requestId);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Send the POST request to update the WorkWave order in the Acumatica"))
            {
                UpdateWorkWaveOrder(_content);
            }
            using (TestExecution.CreateTestStepGroup("Step 5 - Get the WorkWave order Ids"))
            {
                var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                _orderId = orderIdList.First();
            }
            using (TestExecution.CreateTestStepGroup("Step 6 - Validate the updated WorkWave order"))
            {
                //_shipmentNumber = "003669";
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "TBS"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Route Planning", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 7 - Validate the WorkWave order"))
            {
                AssertWorkWaveOrder(_orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 8 - Set the Vehicle by WorkWave Api"))
            {
                _vehicleId = SetVehicleByWorkWaveApi(_orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 9 - Build and approve routes by WorkWave Api"))
            {
                BuildAndApproveRoutes();
            }
            using (TestExecution.CreateTestStepGroup("Step 10 - Validate the updated WorkWave order"))
            {
                GetUpdatedDeliveryStatus(_shipmentNumber);
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Route Assigned"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Route Assigned", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 11 - Complete PickUp and Delivery orders by Api"))
            {
                var dateString = DateTime.Now.ToString("yyyyMMdd");
                HandlePickUpAndDelivery(_orderId, _vehicleId, dateString);
            }
            using (TestExecution.CreateTestStepGroup("Step 12 - Validate the updated WorkWave order"))
            {
                GetUpdatedDeliveryStatus(_shipmentNumber, _timeout);
                var gpsString = GetGPSByOrderId(_shipmentNumber, _orderId);
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Delivered"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", gpsString},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Confirmed", expectedWorkWaveOrderData);
            }
        }
    }
}
