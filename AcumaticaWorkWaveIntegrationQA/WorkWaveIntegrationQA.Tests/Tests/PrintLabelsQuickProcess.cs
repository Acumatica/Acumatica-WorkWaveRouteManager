using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Extensions;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class PrintLabelsQuickProcess : TestBase
    {
        private string _reportContentExcel;
        private string _shipmentNumber;
        private string _salesOrderNumber;
        private string _shipViaDescription;
        private Dictionary<string, dynamic> _expectedData;
        private string _barcodeDelimiter;
        private Dictionary<string, string> _tempDictionary;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("WorkWave Labels report from Shipment screen"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                    _shipViaDescription = GetShipViaDescription();
                }
                using (TestExecution.CreateTestStepGroup("Enable the DeviceHub feature"))
                {
                    Features.ActivateFeature(Features.Summary.DeviceHub, true);
                }
                using (TestExecution.CreateTestStepGroup("Prepare data: a new shipment with the delivered WorkWave order"))
                {
                    _salesOrderNumber = CreateSalesOrder(quantity: "20");
                    _shipmentNumber = CreateShipment(_salesOrderNumber);
                    AddShipmentPackage(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Get expected data from shipment"))
                {
                    //_shipmentNumber = "004025";
                    _expectedData = GetWorkWaveLabelReportData(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Get expected data from the WorkWave carrier"))
                {
                    _barcodeDelimiter = GetCarrierWorkWaveLabelReportData();
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Generate a report by shipment number from Excel"))
                {
                    //_shipmentNumber = "004025";
                    _reportContentExcel = PrintLabelsFromShipment(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Validate the report"))
                {
                    string[] ignoredStrings = new[]
                    {
                        "005090", _shipmentNumber,
                        "WorkWave_20230621175932", _shipViaDescription,
                        "005090;1", $"{_shipmentNumber}{_barcodeDelimiter}1",
                        "005090;2", $"{_shipmentNumber}{_barcodeDelimiter}2",
                        "005090;3", $"{_shipmentNumber}{_barcodeDelimiter}3",
                        "005090;4", $"{_shipmentNumber}{_barcodeDelimiter}4",
                    };
                    AssertWorkWaveLabelReportExcelFiles("TestData\\CarrierLabels03.xlsx", _reportContentExcel, ignoredStrings);
                }
            }

            using (TestExecution.CreateTestCaseGroup("WorkWave Labels report from Process Shipments screen"))
            {
                using (TestExecution.CreateTestStepGroup("Prepare data: a new shipment with the delivered WorkWave order"))
                {
                    _salesOrderNumber = CreateSalesOrder(quantity: "20");
                    _shipmentNumber = CreateShipment(_salesOrderNumber);
                    AddShipmentPackage(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Get expected data from shipment"))
                {
                    //_shipmentNumber = "004025";
                    _expectedData = GetWorkWaveLabelReportData(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Get expected data from the WorkWave carrier"))
                {
                    _barcodeDelimiter = GetCarrierWorkWaveLabelReportData();
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Generate a report by shipment number from Excel"))
                {
                    //_shipmentNumber = "004025";
                    _reportContentExcel = PrintLabelsFromProcessShipment(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Validate the report"))
                {
                    string[] ignoredStrings = new[]
                    {
                        "005091", _shipmentNumber,
                        "WorkWave_20230621175932", _shipViaDescription,
                        "005091;1", $"{_shipmentNumber}{_barcodeDelimiter}1",
                        "005091;2", $"{_shipmentNumber}{_barcodeDelimiter}2",
                        "005091;3", $"{_shipmentNumber}{_barcodeDelimiter}3",
                        "005091;4", $"{_shipmentNumber}{_barcodeDelimiter}4",
                    };
                    AssertWorkWaveLabelReportExcelFiles("TestData\\CarrierLabels04.xlsx", _reportContentExcel, ignoredStrings);
                }
            }

            using (TestExecution.CreateTestCaseGroup("WorkWave Labels report from Sales Orders screen"))
            {
                using (TestExecution.CreateTestStepGroup("Prepare data: a new shipment with the delivered WorkWave order"))
                {
                    _salesOrderNumber = CreateSalesOrder(quantity: "20");
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Generate a report from Excel"))
                {
                    //_shipmentNumber = "004025";
                    _tempDictionary = PrintLabelsFromSalesOrder(_salesOrderNumber);
                    _shipmentNumber = _tempDictionary["ShipmentNumber"];
                    _reportContentExcel = _tempDictionary["Content"];
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Get expected data from shipment"))
                {
                    //_shipmentNumber = "004025";
                    _expectedData = GetWorkWaveLabelReportData(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Get expected data from the WorkWave carrier"))
                {
                    _barcodeDelimiter = GetCarrierWorkWaveLabelReportData();
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Validate the report"))
                {
                    string[] ignoredStrings = new[]
                    {
                        "005092", _shipmentNumber,
                        "WorkWave_20230621175932", _shipViaDescription,
                        "005092;1", $"{_shipmentNumber}{_barcodeDelimiter}1",
                        "005092;2", $"{_shipmentNumber}{_barcodeDelimiter}2",
                        "005092;3", $"{_shipmentNumber}{_barcodeDelimiter}3",
                    };
                    AssertWorkWaveLabelReportExcelFiles("TestData\\CarrierLabels05.xlsx", _reportContentExcel, ignoredStrings);
                }
            }
        }
    }
}
