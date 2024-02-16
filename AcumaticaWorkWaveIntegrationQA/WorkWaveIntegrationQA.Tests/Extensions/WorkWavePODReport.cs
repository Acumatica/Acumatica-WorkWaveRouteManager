using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Core;
using Core.Core.Browser;
using Core.Log;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Wrappers;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Helpers;
using Core.Comparators;
using Core.Verifications;
using Core.Comparators;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class WorkWavePODReport : SO611061
    {
        private int _timeout = 60000;
        public c__pform ReportParametersForm => base._pForm;

        public void CreateReport(ReportParameter parameters)
        {
            Log.Information($"Set parameters: {parameters}");
            OpenScreen();
            ResetReportParameters();
            if (!string.IsNullOrEmpty(parameters.StartDate))
                ReportParametersForm.EdStartDate.Type(parameters.StartDate);
            if (!string.IsNullOrEmpty(parameters.EndDate))
                ReportParametersForm.EdEndDate.Type(parameters.EndDate);
            if (!string.IsNullOrEmpty(parameters.ShipmentNbr))
                ReportParametersForm.EdShipmentNbr.Select(parameters.ShipmentNbr);
            if (!string.IsNullOrEmpty(parameters.CustomerId))
                ReportParametersForm.EdCustomerID.Select(parameters.CustomerId);
            if (!string.IsNullOrEmpty(parameters.Warehouse))
                ReportParametersForm.EdWarehouse.Select(parameters.Warehouse);
            if (!string.IsNullOrEmpty(parameters.InventoryId))
                ReportParametersForm.EdInventoryID.Select(parameters.InventoryId);
            ReportParametersForm.EdDriverNotes.Set(parameters.DriverNotes);
            ReportParametersForm.EdGPS.Set(parameters.GPS);
            ReportParametersForm.EdSignature.Set(parameters.Signature);
            ReportParametersForm.EdPicture.Set(parameters.Picture);
            ReportParametersForm.EdPackages.Set(parameters.Packages);
            Log.Information($"Wait the enabled {ToolBar.Run.ControlName} button");
            WaitBase.WaitForCondition(() => ToolBar.Run.IsVisible() && ToolBar.Run.IsEnabled(), _timeout);
            Run();
        }

        public void ResetReportParameters()
        {
            Log.Information("Reset report parameters");
            ReportParametersForm.EdStartDate.Reset();
            ReportParametersForm.EdEndDate.Reset();
            ReportParametersForm.EdShipmentNbr.Reset();
            ReportParametersForm.EdCustomerID.Reset();
            ReportParametersForm.EdWarehouse.Reset();
            ReportParametersForm.EdInventoryID.Reset();
        }

        public string GetReportContentPathFromExcel()
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

        public string GetReportContentPathFromPdf()
        {
            Log.Information("Export into PDF file");
            Log.Information($"Wait the enabled {ToolBar.PDF.ControlName} button");
            WaitBase.WaitForCondition(() => ToolBar.PDF.IsEnabled(), _timeout);
            PDF();
            Thread.Sleep(_timeout / 6);
            var pdfHelper = new PdfHelper();
            var lastDownloadedFile = Browser.Downloads.GetLastFile().Name;
            var contentPath = pdfHelper.GetFilePath(lastDownloadedFile);
            return contentPath;
        }

        public void CheckDeliveryStatus(string reportContent, List<string> expectedStatusList, string workWaveIdSubstring)
        {
            Log.Information("Validate the Delivery Statuses");
            string pattern = $".*{workWaveIdSubstring}.*\n";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedDeliveryStatusLines = rg.Matches(reportContent);
            if (matchedDeliveryStatusLines.Count == 0)
                Log.Error($"Statuses are not found by pattern: {pattern}");
            for (int count = 0; count < matchedDeliveryStatusLines.Count; count++)
            {
                var tempStatusByPattern = matchedDeliveryStatusLines[count].Value.Replace(workWaveIdSubstring, "");
                //var tempStatus = Regex.Split(tempStatusByPattern, @"\s+").Where(s => s != string.Empty).ToList()[1];
                Log.Information($"String with Status: {tempStatusByPattern}");
                if (!expectedStatusList.Any(s => tempStatusByPattern.Contains(s)))
                    Log.Error($"Status is not expected: {tempStatusByPattern}");
            }
        }

        public void CheckShippedQty(string reportContent, List<Dictionary<string, dynamic>> inventoryItemList)
        {
            Log.Information("Validate the Ord.Qty and Ship.Qty");
            string pattern = @".*SO.*\n";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedDeliveryStatusLines = rg.Matches(reportContent);
            if (matchedDeliveryStatusLines.Count == 0)
                Log.Error($"Records are not found by pattern: {pattern}");
            matchedDeliveryStatusLines.Count.VerifyEquals(inventoryItemList.Count);
            List<List<string>> tempList = new List<List<string>>();
            for (int count = 0; count < matchedDeliveryStatusLines.Count; count++)
            {
                var tempRecord = matchedDeliveryStatusLines[count].Value;
                var tempRecordSubstringList = Regex.Split(tempRecord, @"\s+").Where(s => s != string.Empty).ToList();
                tempList.Add(tempRecordSubstringList);
            }
            foreach (var item in inventoryItemList)
            {
                var foundSubstringList =
                    tempList.FirstOrDefault(e => e.Contains(item["InventoryID"].ToString()));
                if (foundSubstringList == null)
                    throw new Exception($"Inventory item {item["InventoryID"].ToString()} is not found");
                var foundQty = foundSubstringList.FirstOrDefault(e => e.Equals(item["OrderQty"].ToString()));
                if (foundQty == null)
                    throw new Exception($"Quantity {item["OrderQty"].ToString()} is not found for {item["InventoryID"].ToString()}");
            }

            Log.Information("Validate Total");
            pattern = @".*Total:.*\n";
            rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedTotal = rg.Matches(reportContent);
            if (matchedTotal.Count == 0)
                Log.Error($"Records are not found by pattern: {pattern}");
            if (matchedTotal.Count > 1)
                Log.Information("Total records are more than 1");
            double expectedSum = 0.0;
            foreach (var item in inventoryItemList)
            {
                expectedSum += item["OrderQty"];
            }
            List<string> actualShippedAndOrderedQtyStringList =
                Regex.Split(matchedTotal[0].Value.Replace("Total:", ""), @"\s+").Where(s => s != string.Empty).ToList();
            foreach (var item in actualShippedAndOrderedQtyStringList)
            {
                if (!Convert.ToDouble(item).Equals(expectedSum))
                    Log.Error($"Total is not expected: {expectedSum}. Actual: {item}");
            }

        }

        public void CheckAbsenceAttachments(string reportContent)
        {
            Log.Information("Validate the absence of GPS, Driver Notes, Signature comment, Picture comment");
            var exceptionList = new List<string>() { "GPS", "Driver Notes", "Signature comment", "Picture comment" };
            foreach (var item in exceptionList)
            {
                string pattern = $".*{item}.*\n";
                Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matchCollection = rg.Matches(reportContent);
                matchCollection.Count.VerifyEquals(0);
            }
        }

        public void CheckSingleShipment(string reportContent, ReportParameter parameters)
        {
            Log.Information($"Validate a single shipment by parameters: {parameters}");
            if (!string.IsNullOrEmpty(parameters.ShipmentNbr))
            {
                Log.Information("Check the ShipmentNbr");
                reportContent.VerifyContains(parameters.ShipmentNbr);
            }
            if (!string.IsNullOrEmpty(parameters.CustomerId))
            {
                Log.Information("Check the CustomerId");
                reportContent.VerifyContains(parameters.CustomerId);
            }
            if (!string.IsNullOrEmpty(parameters.Warehouse))
            {
                Log.Information("Check the Warehouse");
                reportContent.VerifyContains(parameters.Warehouse);
            }
            var attachmentList = new List<string>() { "GPS", "Driver Notes", "Signature comment", "Picture comment", "Box ID" };
            foreach (var item in attachmentList)
            {
                string pattern = $".*{item}.*\n";
                Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matchCollection = rg.Matches(reportContent);
                matchCollection.Count.VerifyIsGreaterThan(0);
            }
        }

        public void ValidateAttachmentValues(string reportContent, List<string> valueList)
        {
            Log.Information($"Validate a presence of values: {valueList.Aggregate((a, b) => $"{a}, {b}")}");
            foreach (var item in valueList)
            {
                reportContent.VerifyContains(item);
            }
        }

        public void CheckReportPages(string reportContent, int pageAmount = 1)
        {
            Log.Information("Validate amount of pages");
            string pattern = $".*Page: 1 of {pageAmount}.*\n";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedPages = rg.Matches(reportContent);
            if (matchedPages.Count == 0)
                Log.Error($"Amount of pages are not found by pattern {pattern}");
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
