using System;

namespace AcumaticaWorkWave.API.Client
{
    public class WWRestOptions : IWWRestOptions
    {
        public string BaseUrl { get; set; }

        public Guid ApiKey { get; set; }
        public string SignaturePassword { get; set; }
    }
}