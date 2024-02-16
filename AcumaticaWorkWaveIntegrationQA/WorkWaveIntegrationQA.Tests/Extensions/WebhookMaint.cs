using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class WebhookMaint : SM304000_WebhookMaint
    {
        public c_webhook_form MainForm => base.Webhook_form;

        public string GetUrlByWebhookName(string name = "WWTest")
        {
            OpenScreen();
            MainForm.Name.Select(name);
            var url = MainForm.Url.GetValue().ToString();
            if (string.IsNullOrEmpty(url))
                throw new Exception($"URL is not defined for webhook: {name}");
            Log.Information($"Local webhook url for {name}: {url}");
            return url;
        }
    }
}
