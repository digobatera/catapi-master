using System;
using System.Collections.Generic;
using System.Text;

namespace CatAPIIntegration.Servicos
{
    public class CatAPISettings
    {
        public string Xapikey { get; set; } = "207eda2d-c0d4-49f5-b4ad-445f8200cc0b";
        public string baseUrl { get; set; } = "https://api.thecatapi.com/v1";

        public string GetMethodUrl(string methodName) => $"{baseUrl}/{methodName}";
    }
}
