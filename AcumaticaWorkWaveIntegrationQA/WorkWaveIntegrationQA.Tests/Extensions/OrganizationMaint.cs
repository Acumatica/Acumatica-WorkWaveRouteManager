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
    public class OrganizationMaint : CS101500_OrganizationMaint
    {
        public c_baccount_pxformview1 MainForm => base.BAccount_PXFormView1;
        public c_defaddress_defaddress CompanyAddressDetail => base.DefAddress_DefAddress;

        public AddressDetail GenerateAddressDetail()
        {
            return new AddressDetail()
            {
                AddressLine1 = "2337 Bessemer Rd",
                City = "Birmingham",
                Country = "US",
                State = "AL",
                PostalCode = "35208"
            };
        }

        public AddressDetail GetAddressDetail(string companyId)
        {
            Log.Information($"Get the Address for company: {companyId}");
            OpenScreen();
            MainForm.AcctCD.Select(companyId.ToUpper());
            var addressDetail = new AddressDetail()
            {
                AddressLine1 = CompanyAddressDetail.AddressLine1.GetValue().ToString(),
                AddressLine2 = CompanyAddressDetail.AddressLine2.GetValue().ToString(),
                City = CompanyAddressDetail.City.GetValue().ToString(),
                Country = CompanyAddressDetail.CountryID.GetValue().ToString().Split('-')[0].Trim(),
                State = CompanyAddressDetail.State.GetValue().ToString().Split('-')[0].Trim(),
                PostalCode = CompanyAddressDetail.PostalCode.GetValue().ToString()
            };
            Log.Information($"{addressDetail}");
            return addressDetail;
        }

        public void SetAddress(string companyId, AddressDetail addressDetail)
        {
            var currentAddress = GetAddressDetail(companyId);
            if (!currentAddress.Equals(addressDetail))
            {
                Log.Information($"Set the Address for company: {companyId}");
                OpenScreen();
                MainForm.AcctCD.Select(companyId.ToUpper());
                CompanyAddressDetail.AddressLine1.Reset();
                CompanyAddressDetail.AddressLine2.Reset();
                CompanyAddressDetail.City.Reset();
                if (!string.IsNullOrEmpty(addressDetail.AddressLine1))
                    CompanyAddressDetail.AddressLine1.Type(addressDetail.AddressLine1);
                if (!string.IsNullOrEmpty(addressDetail.AddressLine2))
                    CompanyAddressDetail.AddressLine2.Type(addressDetail.AddressLine2);
                if (!string.IsNullOrEmpty(addressDetail.City))
                    CompanyAddressDetail.City.Type(addressDetail.City);
                CompanyAddressDetail.CountryID.Select(addressDetail.Country);
                CompanyAddressDetail.State.Select(addressDetail.State);
                CompanyAddressDetail.PostalCode.Type(addressDetail.PostalCode);
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
