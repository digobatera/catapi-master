using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPIDataCore.Interfaces
{
    public interface IDataProvider
    {
        CatAPIDataCore.Contexto GetContexto();
    }
}
