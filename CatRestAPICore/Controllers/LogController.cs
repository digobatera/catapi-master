
using CatAPIDataCore.Interfaces;
using CatAPIDataCore.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace CatRestAPICore.Controllers
{
    public class LogController : ControllerBase
    {
        readonly LogsDataProvider _logsDataProvider;
        public LogController(IDataProvider dataProvider)
        {
            _logsDataProvider = new LogsDataProvider(dataProvider); ;
        }

        [Route("logging")]
        [HttpGet]
        public CatAPICore.Modelos.Logs GetLoggin()
        {
            try
            {
                var result = _logsDataProvider.GetLog();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
