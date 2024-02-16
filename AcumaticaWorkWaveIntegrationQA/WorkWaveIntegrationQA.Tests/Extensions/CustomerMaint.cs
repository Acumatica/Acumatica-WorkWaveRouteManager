using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Editors.Selector;
using Core.Log;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class CustomerMaint : AR303000_CustomerMaint
    {
        public c_baccount_baccount MainForm => base.BAccount_BAccount;
        public c_defaddress_defaddress AccountAddressDetail => base.DefAddress_DefAddress;
        public c_currentcustomer_tab CurrentCustomerTab => base.CurrentCustomer_tab;
        public c_currentcustomer_cstformview6 TimeWindowInputs => base.CurrentCustomer_CstFormView6;
        public c_defcontact_defcontact1 DefContact => base.DefContact_DefContact1;
        public c_locations_grdlocations LocationsTab => base.Locations_grdLocations;

        public AddressDetail GenerateAddressDetail()
        {
            return new AddressDetail()
            {
                AddressLine1 = "2200 5th Ave N",
                City = "Birmingham",
                Country = "US",
                State = "AL",
                PostalCode = "35203"
            };
        }

        public AddressDetail GenerateAddressDetailNY()
        {
            return new AddressDetail()
            {
                AddressLine1 = "65 Broadway",
                City = "New York",
                Country = "US",
                State = "NY",
                PostalCode = "10006"
            };
        }

        public CustomerDetails GenerateCustomerDetails(string customerId, string classId)
        {
            return new CustomerDetails()
            {
                CustomerId = customerId,
                Status = "Active",
                CustomerClass = classId,
                AccountName = "Test01",
                AccountEmail = "test01@gmail.com",
                AccountAddress = GenerateAddressDetail(),
            };
        }

        public AddressDetail GetAddressDetail(string customerId)
        {
            Log.Information($"Get the Address for customer: {customerId}");
            OpenScreen();
            MainForm.AcctCD.Select(customerId.ToUpper());
            var addressDetail = new AddressDetail()
            {
                AddressLine1 = AccountAddressDetail.AddressLine1.GetValue().ToString(),
                AddressLine2 = AccountAddressDetail.AddressLine2.GetValue().ToString(),
                City = AccountAddressDetail.City.GetValue().ToString(),
                Country = AccountAddressDetail.CountryID.GetValue().ToString().Split('-')[0].Trim(),
                State = AccountAddressDetail.State.GetValue().ToString().Split('-')[0].Trim(),
                PostalCode = AccountAddressDetail.PostalCode.GetValue().ToString()
            };
            Log.Information($"{addressDetail}");
            return addressDetail;
        }

        public void SetAddress(string customerId, AddressDetail addressDetail)
        {
            var currentAddress = GetAddressDetail(customerId);
            if (!currentAddress.Equals(addressDetail))
            {
                Log.Information($"Set the Address for customer: {customerId}");
                OpenScreen();
                MainForm.AcctCD.Select(customerId.ToUpper());
                SetAccountAddress(addressDetail);
                SaveChanges();
                return;
            }
            Log.Information($"Address is already set: {addressDetail}");
        }

        public void SetAccountAddress(AddressDetail addressDetail)
        {
            AccountAddressDetail.AddressLine1.Reset();
            AccountAddressDetail.AddressLine2.Reset();
            AccountAddressDetail.City.Reset();
            if (!string.IsNullOrEmpty(addressDetail.AddressLine1))
                AccountAddressDetail.AddressLine1.Type(addressDetail.AddressLine1);
            if (!string.IsNullOrEmpty(addressDetail.AddressLine2))
                AccountAddressDetail.AddressLine2.Type(addressDetail.AddressLine2);
            if (!string.IsNullOrEmpty(addressDetail.City))
                AccountAddressDetail.City.Type(addressDetail.City);
            AccountAddressDetail.CountryID.Select(addressDetail.Country);
            AccountAddressDetail.State.Select(addressDetail.State);
            AccountAddressDetail.PostalCode.Type(addressDetail.PostalCode);
        }

        public void SaveChanges()
        {
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Save();
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public void CreateNewCustomer(CustomerDetails customerDetails)
        {
            Log.Information($"Create a new Customer: {customerDetails.CustomerId} - {customerDetails.CustomerClass}");
            OpenScreen();
            Insert();
            MainForm.AcctCD.Type(customerDetails.CustomerId);
            MainForm.Status.Select(customerDetails.Status);
            MainForm.CustomerClassID.Select(customerDetails.CustomerClass);
            CurrentCustomerTab.AcctName.Type(customerDetails.AccountName);
            DefContact.EMail.Type(customerDetails.AccountEmail);
            SetAccountAddress(customerDetails.AccountAddress);
            if (!string.IsNullOrEmpty(customerDetails.TimeWindowStart))
                TimeWindowInputs.UsrWWStartSec.Select(customerDetails.TimeWindowStart);
            if (!string.IsNullOrEmpty(customerDetails.TimeWindowEnd))
                TimeWindowInputs.UsrWWEndSec.Select(customerDetails.TimeWindowEnd);
            SaveChanges();
        }

        public void AssertTimeWindowsInputs(CustomerDetails customerDetails)
        {
            Log.Information($"Validate Time Window Start and End inputs for Customer Id: {customerDetails.CustomerId}");
            OpenScreen();
            MainForm.AcctCD.Select(customerDetails.CustomerId);
            var timeWindowStart = TimeWindowInputs.UsrWWStartSec.GetValue().ToString();
            var timeWindowEnd = TimeWindowInputs.UsrWWEndSec.GetValue().ToString();
            var expectedTimeWindowStartList = customerDetails.TimeWindowStart.Split(' ').ToList();
            var expectedTimeWindowEndList = customerDetails.TimeWindowEnd.Split(' ').ToList();
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.First());
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.Last());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.First());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.Last());
        }

        public void RemoveCustomer(string customerId)
        {
            if (SearchCustomerId(customerId))
            {
                Log.Information($"Remove the Customer: {customerId}");
                OpenScreen();
                MainForm.AcctCD.Select(customerId);
                Log.Information("Wait the enabled Delete button");
                WaitBase.WaitForCondition(() => ToolBar.Delete.IsVisible() && ToolBar.Delete.IsEnabled(),
                    WaitBase.LongTimeOut);
                Delete();
            }
        }

        public void SetDefaultLocation(string customerId, string locationId)
        {
            Log.Information($"Set the Default location: {locationId}. Customer Id: {customerId}");
            OpenScreen();
            MainForm.AcctCD.Select(customerId);
            var records = LocationsTab.AllPageData().ToList();
            var foundRecord = records.FirstOrDefault(r => r.LocationCD.Value.Equals(locationId));
            if (foundRecord == null)
                throw new Exception($"Record is not found by id: {locationId}");
            LocationsTab.SelectRow(LocationsTab.Columns.LocationCD, foundRecord.LocationCD.Value);
            Log.Information("Wait the enabled Set As Default button");
            WaitBase.WaitForCondition(() => LocationsTab.ToolBar.SetDefaultLocation.IsVisible()
                                            && LocationsTab.ToolBar.SetDefaultLocation.IsEnabled(), WaitBase.LongTimeOut);
            LocationsTab.SetDefaultLocation();
            SaveChanges();
        }

        public void SetCustomerClass(string customerId, string classId)
        {
            Log.Information($"Set the Customer Class: {classId}. Customer Id: {customerId}");
            OpenScreen();
            MainForm.AcctCD.Select(customerId);
            MainForm.CustomerClassID.Select(classId);
            if (MessageBox.Buttons.Yes.IsVisible())
            {
                MessageBox.Yes();
            }
            SaveChanges();
        }

        public bool SearchCustomerId(string customerId = "TEST01")
        {
            Log.Information($"Search the customer id: {customerId}");
            OpenScreen();
            MainForm.AcctCD.Open();
            var actualCustomerList = MainForm.AcctCD.Grid.Columns.DynamicControl<SelectorColumnFilter>("Customer ID")
                .GetValues().ToList();
            MainForm.AcctCD.Close();
            var foundRecord = actualCustomerList.FirstOrDefault(r => r.Equals(customerId.ToUpper()));
            if (foundRecord == null)
            {
                Log.Information($"Record is not found by {customerId}");
                return false;
            }
            Log.Information("Record is found");
            return true;
        }

    }
}
