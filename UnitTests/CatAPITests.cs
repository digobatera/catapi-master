using CatAPICore.Interfaces;
using CatAPICore.Modelos;
using CatAPIIntegration;
using CatAPIIntegration.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class CatAPITests
    {
        private readonly string _xapikey= "207eda2d-c0d4-49f5-b4ad-445f8200cc0b";

        #region Testa Servico CatAPI
        [TestMethod]
        public void TestaCatAPIService()
        {            
            var svc = new CatAPIService();
            var GetImagemCategoriaChapeu = svc.GetImagemCategoriaChapeu(3);
            var GetImagemCategoriaOculos = svc.GetImagemCategoriaOculos(3);
            var GetListaCategorias = svc.GetListaCategorias();
            var GetListaImagemRaca = svc.GetListaImagemRaca("sibe",3);
            var GetListaRacaEspecifica = svc.GetListaRacaEspecifica("box");
            var GetListaRacas = svc.GetListaRacas();
        }
        

        #endregion

        #region Testa cada get separadamente
        [TestMethod]
        public void GetCategorias()
        {
            var setting = new CatAPISettings { Xapikey = _xapikey };
            var restSrv = new SimpleRestHelper(setting);
            var urlCategorias = setting.GetMethodUrl("categories");
            
            HttpStatusCode? responseStatusCode;
            var categorias = restSrv.SendRequest<Categorias>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        [TestMethod]
        public void GetRacas()
        {
            var setting = new CatAPISettings { Xapikey = _xapikey };
            var restSrv = new SimpleRestHelper(setting);
            var urlCategorias = setting.GetMethodUrl("breeds");

            HttpStatusCode? responseStatusCode;
            var categorias = restSrv.SendRequest<Racas>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        [TestMethod]
        public void GetRacaEspecifica()
        {
            var setting = new CatAPISettings { Xapikey = _xapikey };
            var restSrv = new SimpleRestHelper(setting);
            var urlCategorias = setting.GetMethodUrl("breeds");

            HttpStatusCode? responseStatusCode;
            var categorias = restSrv.SendRequest<Racas>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        [TestMethod]
        public void GetImagemRaca()
        {
            var setting = new CatAPISettings { Xapikey = _xapikey };
            var restSrv = new SimpleRestHelper(setting);
            var urlCategorias = setting.GetMethodUrl("images/search?breed_id=sibe&limit=3");

            HttpStatusCode? responseStatusCode;
            var categorias = restSrv.SendRequest<PorCategorias>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        [TestMethod]
        public void GetImagePorCategoriaChapeu()
        {
            var setting = new CatAPISettings { Xapikey = _xapikey };
            var restSrv = new SimpleRestHelper(setting);
            var urlCategorias = setting.GetMethodUrl("images/search?breed_id=sibe&limit=3");

            HttpStatusCode? responseStatusCode;
            var categorias = restSrv.SendRequest<PorCategorias>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }

        [TestMethod]
        public void GetImagemCategoriaOculos()
        {
            var setting = new CatAPISettings { Xapikey = _xapikey };
            var restSrv = new SimpleRestHelper(setting);
            var urlCategorias = setting.GetMethodUrl("images/search?category_ids=4&limit=3");

            HttpStatusCode? responseStatusCode;
            var categorias = restSrv.SendRequest<PorCategorias>(SimpleRestHelper.Methods.Get, urlCategorias, null, SimpleRestHelper.ContentType.Json, out responseStatusCode);
        }
        #endregion
    }
}
