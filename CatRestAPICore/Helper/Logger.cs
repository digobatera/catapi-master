using CatAPIDataCore.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CatRestAPICore.Helper
{
    public class Logger

    {
        readonly IDataProvider _dataProvider;
        public Logger(IDataProvider dataProvider) => _dataProvider = dataProvider;

        public void SaveLog(HttpStatusCode statusCode, string message, string url = null)
        {            
            var logService = new CatAPIDataCore.Servicos.LogsDataProvider(_dataProvider);
            logService.Escreve((int)statusCode, message, url);
        }

    }
}