using Microsoft.AspNetCore.Http;
using PX.Api.Webhooks;
using System;
using System.Reflection;
using System.Text;

namespace AcumaticaWorkWave.WebHook
{
    public class WWWebhookContentHelper
    {
        private readonly WebhookContext _context;

        public WWWebhookContentHelper(WebhookContext context)
        {
            _context = context;
        }

        public Uri GetRequestUri()
        {
            Uri uri = null;
            var webhookRequest = GetProperty<WebhookRequest>(nameof(_context.Request), _context);
            var request = GetField<HttpRequest>("_request", webhookRequest);
            if (request != null)
            {
                var sb = new StringBuilder();
                sb.Append(request.Scheme).Append("://").Append(request.Host.Value);
                if (request.Host.Port.HasValue)
                {
                    sb.Append(":").Append(request.Host.Port);
                }

                sb.Append(request.PathBase).Append(request.Path);
                sb.Append(request.QueryString);

                uri = new Uri(sb.ToString());
            }

            return uri;
        }

        private static T GetProperty<T>(string propertyName, object obj)
        {
            return (T) obj.GetType()
                          .GetProperty(propertyName, BindingFlags.Instance 
                                                     | BindingFlags.NonPublic
                                                     |BindingFlags.Public)
                          ?.GetValue(obj);
        }

        private static T GetField<T>(string propertyName, object obj)
        {
            return (T) obj.GetType()
                          .GetField(propertyName, BindingFlags.Instance 
                                                  | BindingFlags.NonPublic
                                                  | BindingFlags.Public)
                          ?.GetValue(obj);
        }
    }
}
