using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class WorkWaveShipmentSummary: GI640096_PXGenericInqGrph
    {
        public c_filter_form FilterForm => base.Filter_form;
        public c_results_grid ResultsGrid => base.Results_grid;
        const string _notCreated = "Not Created";
        const string _pending = "Pending";
        const string _tbs = "TBS";
        const string _routeAssigned = "Route Assigned";
        const string _deliveredWithIssue = "Delivered with Issue";
        const string _delivered = "Delivered";
        const string _changingError = "Error";
        public List<string> ExpectedDeliveryStatusList = new List<string>() { _notCreated, _pending, _tbs, _routeAssigned, _deliveredWithIssue, 
            _delivered, _changingError};

        public void SetFilters(string shipmentNumber = "", string customer = "", string workWaveOrderStatus = "")
        {
            Log.Information($"Set filters: {FilterForm.ShipmentNbr.ControlName}={shipmentNumber}, " +
                            $"{FilterForm.CustomerID.ControlName}={customer}, {FilterForm.DeliveryStatus.ControlName}={workWaveOrderStatus}");
            OpenScreen();
            if (!string.IsNullOrEmpty(shipmentNumber))
                FilterForm.ShipmentNbr.Select(shipmentNumber);
            else
                FilterForm.ShipmentNbr.Reset();
            if (!string.IsNullOrEmpty(customer))
                FilterForm.CustomerID.Select(customer);
            else
                FilterForm.CustomerID.Reset();
            if (!string.IsNullOrEmpty(workWaveOrderStatus))
                FilterForm.DeliveryStatus.Select(workWaveOrderStatus);
            else
                FilterForm.DeliveryStatus.Reset();
        }

        public List<c_results_grid.c_grid_row> GetResultRows()
        {
            Log.Information("Get result rows");
            var rows = ResultsGrid.AllPageData().ToList();
            Log.Information($"Count: {rows.Count}");
            return rows;
        }

        public void AssertEmptyFilters()
        {
            AssertEmptyFilterShipmentNbr();
            SetFilters();
            var rows = GetResultRows();
            if (!rows.Any())
                throw new Exception("Shipments are not found with WorkWave orders");
            var actualDeliveryStatusList = FilterForm.DeliveryStatus.GetValues().ToList();
            foreach (var item in ExpectedDeliveryStatusList)
            {
                var foundStatus = actualDeliveryStatusList.FirstOrDefault(r => r.Contains(item));
                if (foundStatus == null)
                    throw new Exception($"Status is not found: {item}");
            }
        }

        public void AssertEmptyFilterShipmentNbr()
        {
            Log.Information("Validate the empty value of the Shipment Nbr. filter");
            OpenScreen();
            var actualValue = FilterForm.ShipmentNbr.GetValue().ToString();
            if (!string.IsNullOrEmpty(actualValue))
                throw new Exception("Filter is not reset for Shipment Nbr.");
        }

        public string GetShipmentNumberWithWorkWaveOrder()
        {
            SetFilters();
            var rows = GetResultRows();
            if (!rows.Any())
                throw new Exception("Shipments are not found with WorkWave orders");
            return rows.First().SOShipment_shipmentNbr.Value;
        }

        public void AssertCustomerFilter(string customer = "AACUSTOMER")
        {
            SetFilters(customer: customer);
            var rows = GetResultRows();
            if (!rows.Any())
                throw new Exception($"Shipments are not found with WorkWave orders by customer: {customer}");
            foreach (var item in rows)
            {
                item.SOShipment_customerID.Value.VerifyEquals(customer.ToUpper());
                var foundStatus =
                    ExpectedDeliveryStatusList.FirstOrDefault(r => r.Contains(item.SOShipment_usrWWStatus.Value));
                if (foundStatus == null)
                    throw new Exception($"Status is not found: {item.SOShipment_usrWWStatus.Value}");
            }
        }

        public void AssertStatusFilter(string status = "TBS")
        {
            SetFilters(workWaveOrderStatus: status);
            var rows = GetResultRows();
            if (!rows.Any())
                Log.Warning($"Shipments are not found with WorkWave orders by status: {status}");
            foreach (var item in rows)
            {
                item.SOShipment_usrWWStatus.Value.VerifyEquals(status);
            }
        }

        public void AssertShipmentNumberFilter(string shipmentNumber)
        {
            SetFilters(shipmentNumber: shipmentNumber);
            var rows = GetResultRows();
            if (!rows.Any())
                Log.Information($"Shipments are not found with WorkWave orders by shipment number: {shipmentNumber}");
            if (rows.Count > 1)
                throw new Exception("Found more than one shipment by number/id");
            foreach (var item in rows)
            {
                item.SOShipment_shipmentNbr.Value.VerifyEquals(shipmentNumber);
            }
        }

        public void AssertCustomerFilterWithoutWorkWaveIntegration(string customer = "ARTCAGES")
        {
            SetFilters(customer: customer);
            var rows = GetResultRows();
            if (rows.Any())
                throw new Exception("Shipments are found with WorkWave orders");
        }
    }
}
