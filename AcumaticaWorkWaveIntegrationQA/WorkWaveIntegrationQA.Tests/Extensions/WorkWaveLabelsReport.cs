using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Controls.Editors.Selector;
using Core;
using Core.Core.Browser;
using Core.Log;
using Core.Comparators;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Helpers;
using WorkWaveIntegrationQA.Tests.Extensions;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class WorkWaveLabelsReport : SO645000
    {
        private int _timeout = 60000;
        public c__pform ReportParametersForm => base._pForm;
        public void CreateReport(string shipmentNumber)
        {
            Log.Information($"Create a report for shipment: {shipmentNumber}");
            OpenScreen();
            ResetReportParameters();
            ReportParametersForm.EdshipmentNbr.Select(shipmentNumber);
            Log.Information($"Wait the enabled {ToolBar.Run.ControlName} button");
            WaitBase.WaitForCondition(() => ToolBar.Run.IsVisible() && ToolBar.Run.IsEnabled(), _timeout);
            Run();
        }
        public void ResetReportParameters()
        {
            Log.Information("Reset report parameters");
            ReportParametersForm.EdshipmentNbr.Reset();
        }

        public string GetReportContentFromExcel()
        {
            Log.Information("Export into XLSX file");
            Log.Information($"Wait the enabled {ToolBar.Excel.ControlName} button");
            WaitBase.WaitForCondition(() => ToolBar.Excel.IsEnabled(), _timeout);
            Excel();
            Thread.Sleep(_timeout / 6);
            var lastDownloadedFile = Browser.Downloads.GetLastFile().FullName;
            var inputFile = new FileInfo(lastDownloadedFile);
            return lastDownloadedFile;
        }

        public string GetReportContentFromPdf()
        {
            Log.Information("Export into PDF file");
            Log.Information($"Wait the enabled {ToolBar.PDF.ControlName} button");
            WaitBase.WaitForCondition(() => ToolBar.PDF.IsEnabled(), _timeout);
            PDF();
            Thread.Sleep(_timeout / 6);
            var pdfHelper = new PdfHelper();
            var lastDownloadedFile = Browser.Downloads.GetLastFile().Name;
            return lastDownloadedFile;
        }

        public void ValidateReport(string content, Dictionary<string, dynamic> expectedData, string barcodeLimiter = ";")
        {
            Log.Information("Validate the report");
            foreach (var pair in expectedData)
            {
                if (pair.Value.GetType().Equals(typeof(string)))
                {
                    if (!content.Contains(pair.Value))
                        Log.Error($"Key: {pair.Key}. Value: {pair.Value} is not found in the report");
                }
            }
            Log.Information("Check the Box Ids");
            var actualBoxIdList = GetActualBoxIdList(content);
            if (!actualBoxIdList.Count.Equals(expectedData["Packages"].Count))
                Log.Error($"Counts do not equal. Actual: {actualBoxIdList.Count}, Expected: {expectedData["Packages"].Count}");
            foreach (var item in expectedData["Packages"])
            {
                if (!actualBoxIdList.Contains(item))
                    Log.Error($"Box Id is not found: {item.ToString()}");
            }
            Log.Information("Check the Barcodes");
            var actualBarcodeList = GetActualBarcodeList(content);
            if (!actualBarcodeList.Count.Equals(expectedData["Packages"].Count))
                Log.Error($"Counts do not equal. Actual: {actualBarcodeList.Count}, Expected: {expectedData["Packages"].Count}");
            for (int i = 0; i < expectedData["Packages"].Count; i++)
            {
                var tempBarcode = $"{expectedData["ShipmentNumber"]}{barcodeLimiter}{i + 1}";
                if (!actualBarcodeList.Contains(tempBarcode))
                    Log.Error($"Barcode is not found: {tempBarcode}");
            }
        }

        public void ValidatePackagesAbsence(string content, Dictionary<string, dynamic> expectedData)
        {
            Log.Information("Validate the report");
            foreach (var pair in expectedData)
            {
                if (pair.Value.GetType().Equals(typeof(string)))
                {
                    if (!content.Contains(pair.Value))
                        Log.Error($"Key: {pair.Key}. Value: {pair.Value} is not found in the report");
                }
            }
            Log.Information("Check the absence of Box Ids");
            var actualBoxIdList = GetActualBoxIdList(content);
            if (actualBoxIdList.Any())
                Log.Error($"Box Ids are present");
            Log.Information("Check the Barcode of shipment");
            var actualBarcodeList = GetActualBarcodeList(content);
            if (!actualBarcodeList.Any())
                Log.Error($"Barcodes are not found");
            if (!actualBarcodeList.Count.Equals(1))
                Log.Error($"Barcodes are more than 1");
            var actualShipmentBarcode = actualBarcodeList.First();
            if (!actualShipmentBarcode.Equals(expectedData["ShipmentNumber"]))
                Log.Error($"Actual barcode: {actualShipmentBarcode}, Expected barcode: {expectedData["ShipmentNumber"]}");
        }

        public List<string> GetActualBoxIdList(string reportContent)
        {
            Log.Information("Get a list of actual box id");
            string pattern = @".*Box ID:.*\n";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedBoxIdLines = rg.Matches(reportContent);
            var resultList = new List<string>();
            for (int count = 0; count < matchedBoxIdLines.Count; count++)
            {
                var tempBoxIdByPattern = matchedBoxIdLines[count].Value;
                var tempBoxId = tempBoxIdByPattern.Replace("Box ID:", "").Trim();
                resultList.Add(tempBoxId);
            }
            return resultList;
        }

        public void ValidateSubstringAmount(string reportContent, string pattern = @".*Barcode:.*\n", int expectedAmount = 4)
        {
            Log.Information($"Get a list of substring by pattern: {pattern}");
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedSubstring = rg.Matches(reportContent);
            matchedSubstring.Count.VerifyEquals(expectedAmount);
        }

        public List<string> GetActualBarcodeList(string reportContent)
        {
            Log.Information("Get a list of actual barcodes");
            string pattern = @".*Barcode:.*\n";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedBarcodeLines = rg.Matches(reportContent);
            var resultList = new List<string>();
            for (int count = 0; count < matchedBarcodeLines.Count; count++)
            {
                var tempBarcodeByPattern = matchedBarcodeLines[count].Value;
                var tempBarcode = tempBarcodeByPattern.Replace("Barcode:", "").Trim();
                resultList.Add(tempBarcode);
            }
            return resultList;
        }

        public void CheckAbsenceOfShipmentNumber(string shipmentNumber)
        {
            Log.Information($"Check an absence of the shipment number without the WorkWave ship code: {shipmentNumber}");
            OpenScreen();
            ReportParametersForm.EdshipmentNbr.Open();
            ReportParametersForm.EdshipmentNbr.QuickSearch(shipmentNumber);
            var rows = ReportParametersForm.EdshipmentNbr.Grid.Columns.DynamicControl<SelectorColumnFilter>("Shipment Nbr.").GetValues().ToList();
            foreach (var row in rows)
            {
                if (row.Contains(shipmentNumber))
                    Log.Error("Shipment without WorkWave ship code is present in the drop-down list");
            }
        }

        public void CompareExcelFiles(string expectedPath, string actualPath, string[] ignoredStrings)
        {
            Log.Information($"Validate the Excel files. Expected path: {expectedPath}, Actual path: {actualPath}");
            var inputFile = new FileInfo(actualPath);
            var outputFile = new FileInfo(expectedPath);
            Comparator.Table.Compare(outputFile, inputFile, stringsToIgnore: ignoredStrings);
        }
    }
}
