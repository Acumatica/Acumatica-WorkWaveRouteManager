using System;
using System.Collections.Generic;
using System.Linq;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class TimeWindowsToAcumaticaTests : TestBase
    {
        private string _classId = Guid.NewGuid().ToString().Substring(0, 8);
        private string _customerId = Guid.NewGuid().ToString().Substring(0, 8);
        private string _salesOrderNumber;
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("AWV-135. Bringing time windows to Acumatica"))
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
            using (TestExecution.CreateTestStepGroup("Test Case#1 (Customer Classes) the time window fields added in this form " +
                                                     "are used as the default values when creating a new customer record. " +
                                                     "Step 1 - Create a new Customer Class"))
            {
                _classId = CreateNewCustomerClass(_classId);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Customer Class. Validate Time Window Inputs"))
            {
                AssertCustomerClassDetailsTimeWindowInputs(_classId);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Create a new Customer"))
            {
                _customerId = CreateNewCustomer(_customerId, _classId);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Customer. Validate Time Window Inputs"))
            {
                AssertCustomerDetailsTimeWindowInputs(_customerId, _classId);
            }
        }

        private void TestCase02()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #2 (Customer Locations) - the time window fields added in this form can " +
                                                     "be applied as default to a customer with the Default checkbox in " +
                                                     "the Locations tab of the Customers form. Step 1 - Customer Location. Create a new entity"))
            {
                CreateNewCustomerLocation(_customerId);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Customer Location. Validate Time Window Inputs"))
            {
                AssertCustomerLocationDetailsTimeWindowInputs(_customerId);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Customer. Set the Default Location"))
            {
                SetDefaultLocationCustomer(_customerId);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Customer. Validate Time Window Inputs"))
            {
                AssertCustomerDetailsTimeWindowInputsAfterSetDefaultLocation(_customerId, _classId);
            }
        }

        private void TestCase03()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #3 (Customers) During new Customer record creation - from default " +
                                                     "Customer Location. If fields are empty - should be taken from Customer Class. " +
                                                     "Step 1 - Customer. Set the MAIN location as default"))
            {
                SetDefaultLocationCustomerMain(_customerId);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Customer. Update the Customer Class"))
            {
                UpdateCustomerClass(_customerId, _classId);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Customer. Validate Time Window Inputs"))
            {
                AssertCustomerDetailsTimeWindowInputs(_customerId, _classId);
            }
        }

        private void TestCase04()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #4 (Sales Orders) the time window fields in the sales order can be edited " +
                                                     "before creating the shipment in Acumatica. During Sales Order creation - from Customer " +
                                                     "Step 1 - Create a new Sales Order"))
            {
                //_customerId = "TEST01";
                _salesOrderNumber = CreateSalesOrder(customerID: _customerId);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Sales Order. Validate Time Window Inputs"))
            {
                //_salesOrderNumber = "SO006801";
                var data = CustomerClassMaint.GenerateCustomerClassDetails(_classId);
                AssertSalesOrderDetailsTimeWindowInputs(_salesOrderNumber, data.TimeWindowStart, data.TimeWindowEnd);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Sales Order. Update Time Window Inputs"))
            {
                //_salesOrderNumber = "SO006801";
                SetTimeWindowInputsSalesOrder(_salesOrderNumber, "3:00 AM", "3:00 PM");
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Sales Order. Validate Time Window Inputs after updating"))
            {
                //_salesOrderNumber = "SO006801";
                AssertSalesOrderDetailsTimeWindowInputs(_salesOrderNumber, "3:00 AM", "3:00 PM");
            }
        }

        private void TestCase05()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #5 (Shipments) the time window fields in the shipment can be edited before " +
                                                     "creating the WorkWave orders with the Create WorkWave Order action. During Shipment creation - " +
                                                     "from Sales Order. Step 1 - Create a new Shipment"))
            {
                //_salesOrderNumber = "SO006801";
                _shipmentNumber = CreateShipment(_salesOrderNumber);
            }

            using (TestExecution.CreateTestStepGroup("Step 2 - Shipment. Validate Time Window Inputs"))
            {
                //_shipmentNumber = "SO006801";
                AssertShipmentDetailsTimeWindowInputs(_shipmentNumber, "3:00 AM", "3:00 PM");
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Shipment. Update Time Window Inputs"))
            {
                //_shipmentNumber = "SO006801";
                SetTimeWindowInputsShipment(_shipmentNumber, "4:00 AM", "4:00 PM");
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Shipment. Validate Time Window Inputs after updating"))
            {
                //_shipmentNumber = "SO006801";
                AssertShipmentDetailsTimeWindowInputs(_shipmentNumber, "4:00 AM", "4:00 PM");
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
                AssertWorkWaveOrderWithTimeWindows(_orderId);
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
