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
    public class AdjustmentEntry : IN303000_INAdjustmentEntry
    {
        public c_transactions_grid TransactionsGrid => base.Transactions_grid;
        public c_adjustment_form AdjustmentForm => base.Adjustment_form;
        private const double MinimumQty = 1000.00;
        private const string SubstringAvailable = "Available";

        public List<Dictionary<string, dynamic>> GenerateInventoryItemQuantityList()
        {
            return new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    {"InventoryID", "AACOMPUT01"},
                    {"Qty", 9999.0},
                    {"LotSerialNbr", null}
                },
                new Dictionary<string, dynamic>()
                {
                    {"InventoryID", "AAPOWERAID"},
                    {"Qty", 9999.0},
                    {"LotSerialNbr", "LREX15014"}
                },
            };
        }
        public void AddQuantityInventoryItems(List<Dictionary<string, dynamic>> itemList)
        {
            Log.Information("Add inventory items");
            OpenScreen();
            foreach (var item in itemList)
            {
                TransactionsGrid.New();
                TransactionsGrid.SelectRow(TransactionsGrid.Columns.InventoryID, "");
                TransactionsGrid.Row.InventoryID.Select(item["InventoryID"]);
                var statusBarString = TransactionsGrid.StatusBar.GetValue().ToString();
                var tempList = statusBarString.Split(' ').ToList();
                var availableSubStringIndex = tempList.FindIndex(e => e.Contains(SubstringAvailable));
                Log.Information($"Status Bar Qty: {tempList[availableSubStringIndex + 1]}");
                var availableQty = Convert.ToDouble(tempList[availableSubStringIndex + 1].Trim());
                if (availableQty < MinimumQty)
                {
                    Log.Information($"Available quantity is less than {MinimumQty}. Add new items");
                    TransactionsGrid.Row.Qty.Type(item["Qty"].ToString());
                    if (!string.IsNullOrWhiteSpace(item["LotSerialNbr"]))
                        TransactionsGrid.Row.LotSerialNbr.Select(item["LotSerialNbr"]);
                }
                else
                {
                    Log.Information("Quantity is suitable. Remove current inventory item");
                    TransactionsGrid.Delete();
                }
            }

            var rows = TransactionsGrid.AllPageData().ToList();
            if (rows.Any())
            {
                Log.Information("Wait the enabled Save button");
                WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(),
                    WaitBase.LongTimeOut);
                Save();
                WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
                ReleaseFromHold();
                Release();
                Log.Information("Wait the completed status");
                WaitBase.WaitForCondition(() => ToolBar.LongRun.GetValue().ToString().Equals("The operation has completed."),
                    WaitBase.LongTimeOut);
            }
            else
            {
                Cancel();
            }
        }
    }
}
