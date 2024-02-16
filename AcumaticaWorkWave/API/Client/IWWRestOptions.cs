using System;

namespace AcumaticaWorkWave.API.Client
{
    public interface IWWRestOptions
    {
        string BaseUrl { get; }
        Guid ApiKey { get; set; }
    }
}