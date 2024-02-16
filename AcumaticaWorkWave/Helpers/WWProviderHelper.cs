using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.Resources;

namespace AcumaticaWorkWave.Helpers
{
    public static class WWProviderHelper
    {
        public static (int code, string message) ExplainResponceException(WWRequestExceptionBase error)
        {
            if (error is WWAPIException e)
            {
                return (e.ErrorCode, $"{WWMessages.WWAPIException} : {e.ErrorMessage}");
            }
            else if (error is WWHTTPException eh)
            {
                return (eh.ErrorCode, $"{WWMessages.WWHTTPException} : {eh.ErrorMessage}");
            }
            else
            {
                return (0, error.Message);
            }
        }
    }
}