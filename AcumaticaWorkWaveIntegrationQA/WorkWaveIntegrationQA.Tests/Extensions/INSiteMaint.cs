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
    public class INSiteMaint : IN204000_INSiteMaint
    {
        public c_site_form MainForm => base.Site_form;
        public c_address_addrform AddressInformation => base.Address_addrForm;

        public AddressDetail GenerateAddressDetail()
        {
            return new AddressDetail()
            {
                AddressLine1 = "236 Summit Blvd",
                City = "Birmingham",
                Country = "US",
                State = "AL",
                PostalCode = "35243"
            };
        }

        public AddressDetail GenerateAddressDetailNY()
        {
            return new AddressDetail()
            {
                AddressLine1 = "1st Ave",
                City = "New York",
                Country = "US",
                State = "NY",
                PostalCode = "10010"
            };
        }

        public AddressDetail GetAddressDetail(string warehouseId)
        {
            Log.Information($"Get the Address for warehouse: {warehouseId}");
            OpenScreen();
            MainForm.SiteCD.Select(warehouseId.ToUpper());
            var addressDetail = new AddressDetail()
            {
                AddressLine1 = AddressInformation.AddressLine1.GetValue().ToString(),
                AddressLine2 = AddressInformation.AddressLine2.GetValue().ToString(),
                City = AddressInformation.City.GetValue().ToString(),
                Country = AddressInformation.CountryID.GetValue().ToString().Split('-')[0].Trim(),
                State = AddressInformation.State.GetValue().ToString().Split('-')[0].Trim(),
                PostalCode = AddressInformation.PostalCode.GetValue().ToString()
            };
            Log.Information($"{addressDetail}");
            return addressDetail;
        }

        public AddressDetail GetFullAddressDetail(string warehouseId)
        {
            Log.Information($"Get the full address for warehouse: {warehouseId}");
            OpenScreen();
            MainForm.SiteCD.Select(warehouseId.ToUpper());
            var addressDetail = new AddressDetail()
            {
                AddressLine1 = AddressInformation.AddressLine1.GetValue().ToString(),
                AddressLine2 = AddressInformation.AddressLine2.GetValue().ToString(),
                City = AddressInformation.City.GetValue().ToString(),
                Country = AddressInformation.CountryID.GetValue().ToString(),
                State = AddressInformation.State.GetValue().ToString(),
                PostalCode = AddressInformation.PostalCode.GetValue().ToString()
            };
            Log.Information($"{addressDetail}");
            return addressDetail;
        }

        public void SetAddress(string warehouseId, AddressDetail addressDetail)
        {
            var currentAddress = GetAddressDetail(warehouseId);
            if (!currentAddress.Equals(addressDetail))
            {
                Log.Information($"Set the Address for warehouse: {warehouseId}");
                OpenScreen();
                MainForm.SiteCD.Select(warehouseId.ToUpper());
                AddressInformation.AddressLine1.Reset();
                AddressInformation.AddressLine2.Reset();
                AddressInformation.City.Reset();
                if (!string.IsNullOrEmpty(addressDetail.AddressLine1))
                    AddressInformation.AddressLine1.Type(addressDetail.AddressLine1);
                if (!string.IsNullOrEmpty(addressDetail.AddressLine2))
                    AddressInformation.AddressLine2.Type(addressDetail.AddressLine2);
                if (!string.IsNullOrEmpty(addressDetail.City))
                    AddressInformation.City.Type(addressDetail.City);
                AddressInformation.CountryID.Select(addressDetail.Country);
                AddressInformation.State.Select(addressDetail.State);
                AddressInformation.PostalCode.Type(addressDetail.PostalCode);
                Log.Information("Wait the enabled Save button");
                WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
                Save();
                WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
                return;
            }
            Log.Information($"Address is already set: {addressDetail}");
        }

    }
}
