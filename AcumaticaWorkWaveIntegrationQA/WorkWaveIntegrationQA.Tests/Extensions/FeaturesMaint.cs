using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using Core.TestExecution;
using Core.Wait;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Wrappers;
using Controls.CheckBox;
using static System.Windows.Forms.AxHost;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class FeaturesMaint : CS100000_FeaturesMaint
    {
        public c_features_form Summary => base.Features_form;
        public void ActivateFeatureList(List<CheckBox> featureList)
        {
            OpenScreen();
            Insert();
            Log.Information("Wait the disabled 'Modify' button");
            WaitBase.WaitForCondition(() => !ToolBar.Insert.IsEnabled(), WaitBase.LongTimeOut);
            foreach (var feature in featureList)
            {
                if (!Convert.ToBoolean(feature.GetValue()))
                {
                    Log.Information($"Update a feature: {feature.ControlName}");
                    feature.Set(true);
                }
            }
            RequestValidation();
        }

        public void ActivateFeature(CheckBox field, bool state)
        {
            Log.Information($"Update the Feature: {field.ControlName}");
            OpenScreen();
            Insert();
            Log.Information("Wait the disabled 'Modify' button");
            WaitBase.WaitForCondition(() => !ToolBar.Insert.IsEnabled(), WaitBase.LongTimeOut);
            var currentState = Convert.ToBoolean(field.GetValue());
            if (!currentState.Equals(state))
            {
                Log.Information($"Set a new state: {state}");
                field.Set(state);
                RequestValidation();
            }
            else
            {
                Log.Information($"Required state is defined. Feature: {field.ControlName}. State: {currentState}");
                Cancel();
            }
        }

        public override void RequestValidation()
        {
            Log.Information($"Click the button: {ToolBar.RequestValidation.ControlName}");
            Log.Information("Wait the enabled 'Enable' button");
            WaitBase.WaitForCondition(() => ToolBar.RequestValidation.IsEnabled(), WaitBase.LongTimeOut);
            ToolBar.RequestValidation.Click();
            Log.Information("Wait the disabled 'Enable' Validate button");
            WaitBase.WaitForCondition(() => !ToolBar.RequestValidation.IsEnabled(), WaitBase.LongTimeOut);
            Wait.WaitForPageToLoad(WaitBase.LongTimeOut);
        }

        public void AssertShippingCarrierIntegration()
        {
            Log.Information("Validate the Shipping Carrier Integration");
            OpenScreen();
            Insert();
            Log.Information("Wait the disabled 'Modify' button");
            WaitBase.WaitForCondition(() => !ToolBar.Insert.IsEnabled(), WaitBase.LongTimeOut);
            var featureList = new List<CheckBox>() { Summary.ShipEngineCarrierIntegration, Summary.FedExCarrierIntegration, 
                Summary.UPSCarrierIntegration, Summary.StampsCarrierIntegration, Summary.ShipEngineCarrierIntegration, 
                Summary.EasyPostCarrierIntegration, Summary.CustomCarrierIntegration};
            foreach (var item in featureList)
            {
                var currentState = Convert.ToBoolean(item.GetValue());
                item.IsVisible().VerifyEquals(true);
                item.IsEnabled().VerifyEquals(true);
                if (currentState != true)
                {
                    item.Set(true);
                    RequestValidation();
                }
            }
            Cancel();
        }
    }
}
