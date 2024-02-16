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
    public class BranchMaint : CS102000_BranchMaint
    {
        public c_baccount_pxformview1 MainForm => base.BAccount_PXFormView1;
        public c_defaddress_defaddress BranchAddressDetail => base.DefAddress_DefAddress;

        public AddressDetail GenerateAddressDetail()
        {
            return new AddressDetail()
            {
                AddressLine1 = "900 Arkadelphia Rd",
                City = "Birmingham",
                Country = "US",
                State = "AL",
                PostalCode = "35254"
            };
        }

        public AddressDetail GetAddressDetail(string branchId)
        {
            Log.Information($"Get the Address for branch: {branchId}");
            OpenScreen();
            MainForm.AcctCD.Select(branchId.ToUpper());
            var addressDetail = new AddressDetail()
            {
                AddressLine1 = BranchAddressDetail.AddressLine1.GetValue().ToString(),
                AddressLine2 = BranchAddressDetail.AddressLine2.GetValue().ToString(),
                City = BranchAddressDetail.City.GetValue().ToString(),
                Country = BranchAddressDetail.CountryID.GetValue().ToString().Split('-')[0].Trim(),
                State = BranchAddressDetail.State.GetValue().ToString().Split('-')[0].Trim(),
                PostalCode = BranchAddressDetail.PostalCode.GetValue().ToString()
            };
            Log.Information($"{addressDetail}");
            return addressDetail;
        }

        public void SetAddress(string branchId, AddressDetail addressDetail)
        {
            var currentAddress = GetAddressDetail(branchId);
            if (!currentAddress.Equals(addressDetail))
            {
                Log.Information($"Set the Address for branch: {branchId}");
                OpenScreen();
                MainForm.AcctCD.Select(branchId.ToUpper());
                BranchAddressDetail.AddressLine1.Reset();
                BranchAddressDetail.AddressLine2.Reset();
                BranchAddressDetail.City.Reset();
                if (!string.IsNullOrEmpty(addressDetail.AddressLine1))
                    BranchAddressDetail.AddressLine1.Type(addressDetail.AddressLine1);
                if (!string.IsNullOrEmpty(addressDetail.AddressLine2))
                    BranchAddressDetail.AddressLine2.Type(addressDetail.AddressLine2);
                if (!string.IsNullOrEmpty(addressDetail.City))
                    BranchAddressDetail.City.Type(addressDetail.City);
                BranchAddressDetail.CountryID.Select(addressDetail.Country);
                BranchAddressDetail.State.Select(addressDetail.State);
                BranchAddressDetail.PostalCode.Type(addressDetail.PostalCode);
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
