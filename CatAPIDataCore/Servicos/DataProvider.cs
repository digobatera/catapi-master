using CatAPIDataCore;
using CatAPIDataCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatAPIDataCore.Servicos
{
    public class DataProvider : Interfaces.IDataProvider
    {
        readonly Contexto _contexto;
        public DataProvider(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Contexto GetContexto()
        {
            return _contexto;
        }
    }
}
