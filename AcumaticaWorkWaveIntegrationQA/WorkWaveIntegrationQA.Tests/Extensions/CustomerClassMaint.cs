using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using WorkWaveIntegrationQA.Tests.Wrappers;
using WorkWaveIntegrationQA.Tests.Entity;
using PX.QA.Tools;
using Controls.Editors.Selector;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class CustomerClassMaint : AR201000_CustomerClassMaint
    {
        public c_customerclassrecord_form MainForm => base.CustomerClassRecord_form;
        public c_curcustomerclassrecord_tab CustomerClassRecordTab => base.CurCustomerClassRecord_tab;
        public void CreateCustomerClass(CustomerClassDetails customerClassDetails)
        {
            Log.Information($"Create a new Customer Class: {customerClassDetails.ClassId} - {customerClassDetails.Description}");
            OpenScreen();
            Insert();
            MainForm.CustomerClassID.Type(customerClassDetails.ClassId);
            MainForm.Descr.Type(customerClassDetails.Description);
            CustomerClassRecordTab.UsrWWStartSec.Select(customerClassDetails.TimeWindowStart);
            CustomerClassRecordTab.UsrWWEndSec.Select(customerClassDetails.TimeWindowEnd);
            SaveChanges();
        }

        public void RemoveCustomerClass(string classId)
        {
            if (SearchCustomerClassId(classId))
            {
                Log.Information($"Remove the Customer Class by Id: {classId}");
                OpenScreen();
                MainForm.CustomerClassID.Select(classId);
                Log.Information("Wait the enabled Delete button");
                WaitBase.WaitForCondition(() => ToolBar.Delete.IsVisible() && ToolBar.Delete.IsEnabled(),
                    WaitBase.LongTimeOut);
                Delete();
            }
        }

        public void AssertTimeWindowsInputs(CustomerClassDetails customerClassDetails)
        {
            Log.Information($"Validate Time Window Start and End inputs for Customer Class Id: {customerClassDetails.ClassId}");
            OpenScreen();
            MainForm.CustomerClassID.Select(customerClassDetails.ClassId);
            var timeWindowStart = CustomerClassRecordTab.UsrWWStartSec.GetValue().ToString();
            var timeWindowEnd = CustomerClassRecordTab.UsrWWEndSec.GetValue().ToString();
            var expectedTimeWindowStartList = customerClassDetails.TimeWindowStart.Split(' ').ToList();
            var expectedTimeWindowEndList = customerClassDetails.TimeWindowEnd.Split(' ').ToList();
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.First());
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.Last());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.First());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.Last());
        }

        public void SaveChanges()
        {
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Save();
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public bool SearchCustomerClassId(string customerClassId = "TEST01")
        {
            Log.Information($"Search the customer class id: {customerClassId}");
            OpenScreen();
            MainForm.CustomerClassID.Open();
            var actualCustomerClassList = MainForm.CustomerClassID.Grid.Columns.DynamicControl<SelectorColumnFilter>("Class ID")
                .GetValues().ToList();
            MainForm.CustomerClassID.Close();
            var foundRecord = actualCustomerClassList.FirstOrDefault(r => r.Equals(customerClassId.ToUpper()));
            if (foundRecord == null)
            {
                Log.Information($"Record is not found by {customerClassId}");
                return false;
            }
            Log.Information("Record is found");
            return true;
        }

        public CustomerClassDetails GenerateCustomerClassDetails(string classId)
        {
            return new CustomerClassDetails()
            {
                ClassId = classId,
                Description = "Test01",
                TimeWindowStart = "8:00 AM",
                TimeWindowEnd = "6:00 PM"
            };
        }
    }
}
