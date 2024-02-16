using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain.Callback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcumaticaWorkWave.API.Provider
{
    class WWCallbackProvider : WWBaseProvider
    {
        private readonly string url = $"/api/v1/callback";

        public WWCallbackProvider(IWWRestOptions options) : base(options)
        {
        }

        public CallbackResponce Get<T>() where T : CallbackResponce
        {
            return Get<CallbackResponce>(url);
        }

        public CallbackResponce Set<T>(Callback obj) where T : CallbackResponce
        {
            return Post<CallbackResponce, Callback>(obj, url);
        }

        public CallbackResponce Delete<T>() where T : CallbackResponce
        {
            return Delete<CallbackResponce>(url);
        }
    }
}
