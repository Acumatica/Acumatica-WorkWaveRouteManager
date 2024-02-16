using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core.Browser;
using Core.Log;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class DifferentWorkWaveTerritories : TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private Dictionary<string, dynamic> _content;

        private string _company = "PRODUCTS";
        private string _branch = "PRODWHOLE";
        private string _warehouse = "WHOLESALE";
        private string _customerId = "AACUSTOMER";
        private string _territory = "API DEMO";
        private AddressDetail _warehouseAddressDetail;
        private AddressDetail _customerAddressDetail;
        private AddressDetail _branchAddressDetail;
        private AddressDetail _companyAddressDetail;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Check different combination of the WorkWave territories (Company, Branch and Warehouse)"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Company, Branch and Warehouse of the WorkWave territory"))
                {
                    var territory = new CarrierWorkWaveTerritory()
                    {
                        Company = _company,
                        Branch = _branch,
                        Warehouse = _warehouse,
                        Territory = _territory,
                        Active = true
                    };
                    SetCarrierWorkWaveTerritory(territory);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Set the warehouse address"))
                {
                    SetWarehouseAddressDetail(_warehouse);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Get the warehouse address"))
                {
                    _warehouseAddressDetail = GetWarehouseAddressDetail(_warehouse);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Set the customer address"))
                {
                    SetCustomerAddressDetail(_customerId);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Get the customer address"))
                {
                    _customerAddressDetail = GetCustomerAddressDetail(_customerId);
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Create new sales order and shipment"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003668";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Validate the just created WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 9 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 11 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 12 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 13 - Validate address of the WorkWave order"))
                {
                    AssertWorkWaveAddresses(_orderId, _warehouseAddressDetail, _customerAddressDetail);
                }
            }

            using (TestExecution.CreateTestCaseGroup("Check different combination of the WorkWave territories (Company, Branch)"))
            {
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Company, Branch of the WorkWave territory"))
                {
                    var territory = new CarrierWorkWaveTerritory()
                    {
                        Company = _company,
                        Branch = _branch,
                        Territory = _territory,
                        Active = true
                    };
                    SetCarrierWorkWaveTerritory(territory);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Set the branch address"))
                {
                    SetBranchAddressDetail(_branch);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Get the branch address"))
                {
                    _branchAddressDetail = GetBranchAddressDetail(_branch);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Set the customer address"))
                {
                    SetCustomerAddressDetail(_customerId);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Get the customer address"))
                {
                    _customerAddressDetail = GetCustomerAddressDetail(_customerId);
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Create new sales order and shipment"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003668";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Validate the just created WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 9 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 11 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 12 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 13 - Validate address of the WorkWave order"))
                {
                    AssertWorkWaveAddresses(_orderId, _branchAddressDetail, _customerAddressDetail);
                }
            }

            using (TestExecution.CreateTestCaseGroup("Check different combination of the WorkWave territories (Company)"))
            {
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Company of the WorkWave territory"))
                {
                    var territory = new CarrierWorkWaveTerritory()
                    {
                        Company = _company,
                        Territory = _territory,
                        Active = true
                    };
                    SetCarrierWorkWaveTerritory(territory);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Set the company address"))
                {
                    SetCompanyAddressDetail(_company);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Get the company address"))
                {
                    _companyAddressDetail = GetCompanyAddressDetail(_company);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Set the customer address"))
                {
                    SetCustomerAddressDetail(_customerId);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Get the customer address"))
                {
                    _customerAddressDetail = GetCustomerAddressDetail(_customerId);
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Create new sales order and shipment"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003668";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Validate the just created WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 9 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 11 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 12 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 13 - Validate address of the WorkWave order"))
                {
                    AssertWorkWaveAddresses(_orderId, _companyAddressDetail, _customerAddressDetail);
                }
            }
        }

        public override void AfterExecute()
        {
            using (TestExecution.CreateTestStepGroup("Restore the Company, Branch and Warehouse of the WorkWave territory"))
            {
                var territory = new CarrierWorkWaveTerritory()
                {
                    Company = _company,
                    Branch = _branch,
                    Warehouse = _warehouse,
                    Territory = _territory,
                    Active = true
                };
                SetCarrierWorkWaveTerritory(territory);
            }
            Log.Information("Stop all browser windows");
            Browser.Stop();
            base.AfterExecute();
        }
    }
}
