using CatAPICore.Modelos;
using CatAPICore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace CatAPIIntegration.Servicos
{
    public class CatAPIService : ICatAPIService
    {
        readonly SimpleRestHelper _restapiSvc;
        readonly CatAPISettings _setting;

        public CatAPIService(string xApiKey = null, string baseURL = null)
        {
            _setting = new CatAPISettings();
            _setting.baseUrl = baseURL ?? _setting.baseUrl;
            _setting.Xapikey = xApiKey ?? _setting.Xapikey;
            _restapiSvc = new SimpleRestHelper(_setting);
        }

        public Categorias GetListaCategorias()
        {
            var urlGet = _setting.GetMethodUrl("categories");
            HttpStatusCode? responseStatusCode;
            return _restapiSvc.SendRequest<Categorias>(SimpleRestHelper.Methods.Get, urlGet, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }


        public Racas GetListaRacas()
        {
            var urlGet = _setting.GetMethodUrl("breeds");

            HttpStatusCode? responseStatusCode;
            return _restapiSvc.SendRequest<Racas>(SimpleRestHelper.Methods.Get, urlGet, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }


        public Racas GetListaRacaEspecifica(string raca)
        {
            var urlCategorias = _setting.GetMethodUrl($"breeds/search?q={Encode(raca)}");

            HttpStatusCode? responseStatusCode;
            return _restapiSvc.SendRequest<Racas>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }


        public PorRacas GetListaImagemRaca(string idraca, int limit)
        {
            var urlCategorias = _setting.GetMethodUrl($"images/search?breed_id={Encode(idraca)}&limit={limit}");

            HttpStatusCode? responseStatusCode;
            return _restapiSvc.SendRequest<PorRacas>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        private PorCategorias GetListaImagensPortCategoria(int categoryId, int limit)
        {
            var urlCategorias = _setting.GetMethodUrl($"images/search?category_ids={categoryId}&limit={limit}");

            HttpStatusCode ? responseStatusCode;
            return _restapiSvc.SendRequest<PorCategorias>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        public PorCategorias GetImagemCategoriaChapeu(int limit) => GetListaImagensPortCategoria(1, limit);

        public PorCategorias GetImagemCategoriaOculos(int limit) => GetListaImagensPortCategoria(4, limit);

        private string Encode(string value) => HttpUtility.UrlEncode(value);
    }
}
