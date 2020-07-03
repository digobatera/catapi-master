using CatAPICore.Interfaces;
using CatAPICore.Modelos;
using CatAPIDataCore;
using CatAPIDataCore.Interfaces;
using CatAPIIntegration;
using CatAPIIntegration.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class CatAPILoggingTest
    {
        #region Testa Servico CatAPILoggingTest
        [TestClass]
        public class LoggingTest
        {

            readonly Contexto _conexaoComBanco;
            readonly IDataProvider _dataProvider;

            public LoggingTest(IConfiguration configuration)
            {
                //Cria conexao com banco, utilizando o contexto do EF.
                var cn = configuration.GetValue<string>("ConnectionString");
                _conexaoComBanco = new CatAPIDataCore.Contexto(new DbContextOptionsBuilder().UseMySql(cn).Options);
                _dataProvider = new CatAPIDataCore.Servicos.DataProvider(_conexaoComBanco);
            }

            [TestMethod]
            public void WriteLogs()
            {
                var logService = new CatAPIDataCore.Servicos.LogsDataProvider(_dataProvider);

                logService.Escreve(200, "Funciona", "http://www.google.com/");

            }

        }
        #endregion

    }
}
