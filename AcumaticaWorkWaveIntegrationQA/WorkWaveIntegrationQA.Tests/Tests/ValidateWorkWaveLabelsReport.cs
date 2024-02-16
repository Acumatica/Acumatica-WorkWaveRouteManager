using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using Core.TestExecution;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Extensions;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class ValidateWorkWaveLabelsReport : TestBase
    {
        private string _reportContentPdf;
        private string _reportContentExcel;
        private string _shipmentNumber;
        private string _salesOrderNumber;
        private Dictionary<string, dynamic> _expectedData;
        private string _barcodeDelimiter;
        private string _shipViaDescription;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("WorkWave Labels report"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                    _shipViaDescription = GetShipViaDescription();
                }
                using (TestExecution.CreateTestStepGroup("Prepare data: a new shipment with the delivered WorkWave order"))
                {
                    _salesOrderNumber = CreateSalesOrder(quantity: "20");
                    _shipmentNumber = CreateShipment(_salesOrderNumber);
                    AddShipmentPackage(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Get expected data from shipment"))
                {
                    //_shipmentNumber = "003870";
                    _expectedData = GetWorkWaveLabelReportData(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Get expected data from the WorkWave carrier"))
                {
                    _barcodeDelimiter = GetCarrierWorkWaveLabelReportData();
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Generate a report by shipment number from PDF"))
                {
                    //_shipmentNumber = "005087";
                    _reportContentPdf = GenerateWorkWaveLabelReportFromPDF(_shipmentNumber);
                    if (string.IsNullOrEmpty(_reportContentPdf))
                        Log.Error("Report content is not found from PDF file");
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Generate a report by shipment number from Excel"))
                {
                    _reportContentExcel = GenerateWorkWaveLabelReportFromExcel(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Validate the report"))
                {
                    string[] ignoredStrings = new[]
                    {
                        "005079", _shipmentNumber,
                        "SO007504", _salesOrderNumber,
                        "WorkWave_20230621175932", _shipViaDescription,
                        "005087;1", $"{_shipmentNumber}{_barcodeDelimiter}1",
                        "005087;2", $"{_shipmentNumber}{_barcodeDelimiter}2",
                        "005087;3", $"{_shipmentNumber}{_barcodeDelimiter}3",
                        "005087;4", $"{_shipmentNumber}{_barcodeDelimiter}4",
                    };
                    AssertWorkWaveLabelReportExcelFiles("TestData\\CarrierLabels01.xlsx", _reportContentExcel, ignoredStrings);
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Remove packages from shipment"))
                {
                    //_shipmentNumber = "003937";
                    SetShipmentPackage(_shipmentNumber, 0);
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Generate a report by shipment number from Excel without packages"))
                {
                    _reportContentExcel = GenerateWorkWaveLabelReportFromExcel(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Validate the report without packages"))
                {
                    string[] ignoredStrings = new[]
                    {
                        "005079", _shipmentNumber,
                        "SO007504", _salesOrderNumber,
                        "WorkWave_20230621175932", _shipViaDescription,
                    };
                    AssertWorkWaveLabelReportExcelFiles("TestData\\CarrierLabels02.xlsx", _reportContentExcel, ignoredStrings);
                }
            }
        }
    }
}
