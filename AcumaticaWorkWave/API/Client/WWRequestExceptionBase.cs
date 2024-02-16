using System;
using System.Runtime.Serialization;
using PX.Common;
using PX.Data;

namespace AcumaticaWorkWave.API.Client
{
    public class WWRequestExceptionBase : Exception
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public override string Message => $"{ErrorCode}: {ErrorMessage}";

    }
}