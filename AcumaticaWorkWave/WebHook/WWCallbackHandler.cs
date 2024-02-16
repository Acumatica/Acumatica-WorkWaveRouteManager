using System;
using System.Threading;
using System.Threading.Tasks;
using AcumaticaWorkWave.API.Converter;
using AcumaticaWorkWave.API.Domain;
using AcumaticaWorkWave.BLC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PX.Api.Webhooks;
using PX.Data;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace AcumaticaWorkWave.WebHook
{
    public class WWCallbackHandler : IWebhookHandler
    {
        private static readonly IWWCallbackAuthenticatorConfig _authenticatorConfig = new WWCallbackAuthenticatorConfig();
        private readonly IWWCallbackAuthenticator _authenticator = new WWCallbackAuthenticator(_authenticatorConfig);
        private static readonly JsonSerializer _serializer = new JsonSerializer();


        public async Task HandleAsync(WebhookContext context, CancellationToken cancellation)
        {
            var requestUri = new WWWebhookContentHelper(context).GetRequestUri();

            using (var scope = GetAdminScope())
            {
                if (_authenticator == null || !_authenticator.Authenticate(requestUri))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
            }

            using (var scope = GetAdminScope())
            {
                using (var result = new JsonTextReader(context.Request.CreateTextReader()))
                {
                    var res = await SaveRequestResult(result);
                    context.Response.StatusCode = res ? StatusCodes.Status202Accepted 
                                                      : StatusCodes.Status406NotAcceptable;
                }
            }
        }

        private Task<bool> SaveRequestResult(JsonTextReader reader)
        {
            return Task.Run(() =>
            {
                try
                {
                    var content = JObject.Load(reader).ToString();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        throw new Exception("Content is empty");
                    }

                    var result = JsonConvert.DeserializeObject<object> (content, new WWWebHookDataConverter());

                    switch (result)
                    {
                        case WWAsyncResponsePlain test:
                            return true;
                        case WWAsyncResponse data:
                            {
                                data.Content = content;
                                var graph = PXGraph.CreateInstance<WWSyncMaint>();
                                graph.UpdateResponse(data);
                                return true;
                            }
                        default:
                            return false;
                    }
                }
                catch (Exception e)
                {
                    PXTrace.WriteError(e);
                    return false;
                }
            });
        }

        private IDisposable GetAdminScope()
        {
            var userName = "admin";
            if (PXDatabase.Companies.Length > 0)
            {
                var company = PXAccess.GetCompanyName();
                if (string.IsNullOrEmpty(company))
                {
                    company = PXDatabase.Companies[0];
                }
                userName = userName + "@" + company;
            }
            return new PXLoginScope(userName);
        }

    }
}