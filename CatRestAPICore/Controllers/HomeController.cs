using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//-----------------
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using CatAPIDataCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CatAPIDataCore.Servicos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CatRestAPICore.Controllers
{

    public class HomeController : ControllerBase
    {
        readonly RacasDataProvider rdp;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,  IDataProvider dataProvider)
        {
            rdp = new RacasDataProvider(dataProvider);
            _logger = logger;
        }

        [Route("racas")] 
        [HttpGet]
        //public List<string> GetRacas()
        public List<string> GetRacas()
        {
            try
            {
                //_meuLogger.SaveLog(HttpStatusCode.Found, "Inicio", Request.ToString());
                var result = rdp.GetRacaName();

                //_meuLogger.SaveLog(HttpStatusCode.OK, "Termino", Request.ToString());

                string logGeral = JsonConvert.SerializeObject(result);
                _logger.LogInformation("Payload: {0}", logGeral);

                return result;
            }
            catch(Exception ex)
            {
                //_meuLogger.SaveLog(HttpStatusCode.InternalServerError, ex.Message,Request.ToString());
                string logError = JsonConvert.SerializeObject(ex);
                _logger.LogError("Exception: {0}", logError);
                throw;
            }
            
        }

        [Route("racas/{nomeRaca}")] 
        [HttpGet] 
        public List<CatAPIDataCore.Entidade.Raca> GetRacas(string nomeRaca)
        {
            try
            {
                //_meuLogger.SaveLog(HttpStatusCode.Found, "Inicio",Request.ToString());


                var result = rdp.GetInfRacaIds(nomeRaca);

                //_meuLogger.SaveLog(HttpStatusCode.OK, "Termino",Request.ToString());

                string logGeral = JsonConvert.SerializeObject(result);
                _logger.LogInformation("Payload: {0}", logGeral);

                if (result == null)
                {
                    _logger.LogError("ID digitador, não encontardo: {0}", nomeRaca);
                }

                return result;
            }
            catch (Exception ex)
            {
                //_meuLogger.SaveLog(HttpStatusCode.InternalServerError, ex.Message,Request.ToString());
                string logError = JsonConvert.SerializeObject(ex);
                _logger.LogError("Exception: {0}", logError);
                throw;
            }
        }

        [Route("racasTemperamento/{nomeTemperamento}")]
        [HttpGet] 
        public List<string> GetRacasTemperamento(string nomeTemperamento)
        {
            try
            {
                //_meuLogger.SaveLog(HttpStatusCode.Found, "Inicio",Request.ToString());

                var result = rdp.GetRacaIdsTemperamento(nomeTemperamento);

                //_meuLogger.SaveLog(HttpStatusCode.OK, "Termino",Request.ToString());

                string logGeral = JsonConvert.SerializeObject(result);
                _logger.LogInformation("Payload: {0}", logGeral);

                if (result == null)
                {
                    _logger.LogError("ID digitador, não encontardo: {0}", nomeTemperamento);

                }
                return result;
            }
            catch (Exception ex)
            {
                //_meuLogger.SaveLog(HttpStatusCode.InternalServerError, ex.Message,Request.ToString());
                string logError = JsonConvert.SerializeObject(ex);
                _logger.LogError("Exception: {0}", logError);
                throw;
            }
        }

        [Route("racasOrigem/{nomeOrigem}")] 
        [HttpGet] 
        public List<string> GetRacasOrigem(string nomeOrigem)
        {
            try
            {
                //_meuLogger.SaveLog(HttpStatusCode.Found, "Inicio",Request.ToString());

                var result = rdp.GetRacaIdsOrigem(nomeOrigem);

                //_meuLogger.SaveLog(HttpStatusCode.OK, "Termino",Request.ToString());

                string logGeral = JsonConvert.SerializeObject(result);
                _logger.LogInformation("Payload: {0}", logGeral);

                if (result == null)
                {
                    _logger.LogError("ID digitador, não encontardo: {0}", nomeOrigem);

                }
                return result;
            }
            catch (Exception ex)
            {
                //_meuLogger.SaveLog(HttpStatusCode.InternalServerError, ex.Message,Request.ToString());
                string logError = JsonConvert.SerializeObject(ex);
                _logger.LogError("Exception: {0}", logError);
                throw;
            }
        }
    }
}
