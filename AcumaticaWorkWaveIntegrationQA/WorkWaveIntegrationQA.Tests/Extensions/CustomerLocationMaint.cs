using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Wrappers;


namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class CustomerLocationMaint : AR303020_CustomerLocationMaint
    {
        public c_location_frmheader LocationHeader => base.Location_frmHeader;
        public c_locationcurrent_tab LocationCurrentTab => base.LocationCurrent_tab;

        public CustomerLocationDetails GenerateCustomerLocationDetails(string customerId)
        {
            return new CustomerLocationDetails()
            {
                LocationId = "SECONDARY",
                CustomerId = customerId,
                LocationName = "Second Location",
                TimeWindowStart = "3:00 AM",
                TimeWindowEnd = "3:00 PM"
            };
        }

        public void CreateNewCustomerLocation(CustomerLocationDetails customerLocationDetails)
        {
            Log.Information($"Create a new Customer Location: {customerLocationDetails.LocationId} - {customerLocationDetails.CustomerId}");
            OpenScreen();
            Insert();
            LocationHeader.BAccountID.Select(customerLocationDetails.CustomerId);
            LocationHeader.LocationCD.Type(customerLocationDetails.LocationId);
            LocationCurrentTab.Descr.Type(customerLocationDetails.LocationName);
            LocationCurrentTab.UsrWWStartSec.Select(customerLocationDetails.TimeWindowStart);
            LocationCurrentTab.UsrWWEndSec.Select(customerLocationDetails.TimeWindowEnd);
            SaveChanges();
        }

        public void SaveChanges()
        {
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Save();
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public void AssertTimeWindowsInputs(CustomerLocationDetails customerLocationDetails)
        {
            Log.Information($"Validate Time Window Start and End inputs for Customer Location: {customerLocationDetails.LocationId}");
            OpenScreen();
            LocationHeader.BAccountID.Select(customerLocationDetails.CustomerId);
            LocationHeader.LocationCD.Select(customerLocationDetails.LocationId);
            var timeWindowStart = LocationCurrentTab.UsrWWStartSec.GetValue().ToString();
            var timeWindowEnd = LocationCurrentTab.UsrWWEndSec.GetValue().ToString();
            var expectedTimeWindowStartList = customerLocationDetails.TimeWindowStart.Split(' ').ToList();
            var expectedTimeWindowEndList = customerLocationDetails.TimeWindowEnd.Split(' ').ToList();
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.First());
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.Last());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.First());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.Last());
        }
    }
}
