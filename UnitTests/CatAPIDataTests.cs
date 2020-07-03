using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CatAPIDataCore.Servicos;
using CatAPICore.Modelos;
using Microsoft.EntityFrameworkCore;
using CatAPIDataCore;
using Microsoft.Extensions.Configuration;
using CatAPIDataCore.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class CatAPIDataCoreTests
    {
        readonly Contexto _conexaoComBanco;
        readonly IDataProvider _dataProvider;

        public CatAPIDataCoreTests(IConfiguration configuration)
        {
            //Cria conexao com banco, utilizando o contexto do EF.
            var cn = configuration.GetValue<string>("ConnectionString");
            _conexaoComBanco = new CatAPIDataCore.Contexto(new DbContextOptionsBuilder().UseMySql(cn).Options);
            _dataProvider = new CatAPIDataCore.Servicos.DataProvider(_conexaoComBanco);
        }

        [TestMethod]
        public void TestaEF()
        {   
            //Utiliza a entidade "StreamsInfo" definida dentro da classe Contexto como "DbSet", faz um Where e Retorna o primeiro nome que achar 
            var result = _conexaoComBanco.Categorias.Where(d => d.Id == 1);
        }


        [TestMethod]
        public void TestaAdicionaRacas()
        {
            RacasDataProvider rdp = new RacasDataProvider(_dataProvider);
            CatAPIIntegration.Servicos.CatAPIService catAPIService = new CatAPIIntegration.Servicos.CatAPIService();

            var listaRacas = catAPIService.GetListaRacas();
            rdp.AdicionaRacas(listaRacas);
        }

        [TestMethod]
        public void TestaAdicionaImagemRacas()
        {
            
            RacasDataProvider rdp = new RacasDataProvider(_dataProvider);
            CatAPIIntegration.Servicos.CatAPIService catAPIService = new CatAPIIntegration.Servicos.CatAPIService();

            var listaIds = rdp.GetRacaIds();
            var listaParaAdicionar = new PorRacas();
            foreach (var item in listaIds)
            {
                var listaImagemRacas = catAPIService.GetListaImagemRaca(item, 3);
                listaParaAdicionar.AddRange(listaImagemRacas);
            }
            rdp.AdicionaImagemRacas(listaParaAdicionar);

        }


        [TestMethod]
        public void TestaAdicionaCategorias()
        {
            
            CategoriasDataProvider rdp = new CategoriasDataProvider(_dataProvider);
            CatAPIIntegration.Servicos.CatAPIService catAPIService = new CatAPIIntegration.Servicos.CatAPIService();
            
            var listaCategorias = catAPIService.GetListaCategorias();
            rdp.AdicionaCategorias(listaCategorias);
        }

        [TestMethod]
        public void TestaAdicionaImagemCategorias()
        {
            
            CategoriasDataProvider rdp = new CategoriasDataProvider(_dataProvider);
            CatAPIIntegration.Servicos.CatAPIService catAPIService = new CatAPIIntegration.Servicos.CatAPIService();

            var listaParaAdicionar = new PorCategorias();
            var listaImagemChapeu = catAPIService.GetImagemCategoriaChapeu(3);
            listaParaAdicionar.AddRange(listaImagemChapeu);

            var listaImagemOculos = catAPIService.GetImagemCategoriaOculos(3);
            listaParaAdicionar.AddRange(listaImagemOculos);
            rdp.AdicionaImagemCategorias(listaParaAdicionar);
        }

    }

}
