using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.ToolBarButton;
using Core.Log;
using PX.QA.Tools;
using PX.QA.Tools.TestPortal;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class PickPackShipHost : SO302020_PickPackShipHost
    {
        public c_headerview_formheader MainForm => base.HeaderView_formHeader;
        private int _timeout = 60000;

        public void ScanShipment(string shipmentNumber)
        {
            Log.Information($"Scan a shipment: {shipmentNumber}");
            OpenScreen();
            MainForm.Barcode.Type(shipmentNumber);
            MainForm.Barcode.PressEnter();
            Log.Information("Wait the loaded Shipment Nbr");
            WaitBase.WaitForCondition(() => !string.IsNullOrEmpty(MainForm.RefNbr.GetValue().ToString()), _timeout);
        }

        public void CancelProcess()
        {
            Log.Information($"Cancel the scanning for: {MainForm.RefNbr.GetValue()}");
            //OpenScreen();
            Log.Information($"Wait the enabled {ToolBar.Cancel.ControlName} button");
            WaitBase.WaitForCondition(() => ToolBar.Cancel.IsVisible() && ToolBar.Cancel.IsEnabled(), _timeout);
            Cancel();
        }

        public void CheckToolBarButton(ToolBarButton toolBarButton, bool visible = true, bool enabled = true)
        {
            Log.Information($"Validate the toolbar button: {toolBarButton.ControlName} by state visible: {visible} and enabled: {enabled}");
            toolBarButton.IsVisible().VerifyEquals(visible);
            if (visible)
            {
                toolBarButton.IsEnabled().VerifyEquals(enabled);
            }
        }

        public void CreateNewWorkWaveOrder()
        {
            Log.Information("Create the WorkWave order");
            Log.Information($"Wait the enabled {ToolBar.CreateWorkWaveOrder.ControlName} button");
            WaitBase.WaitForCondition(
                () => ToolBar.CreateWorkWaveOrder.IsVisible() && ToolBar.CreateWorkWaveOrder.IsEnabled(), _timeout);
            CreateWorkWaveOrder();
            Log.Information("Wait the successful operation");
            WaitBase.WaitForCondition(() => ToolBar.LongRun.GetValue().ToString().Equals("The operation has completed."), WaitBase.LongTimeOut);
        }
    }
}
