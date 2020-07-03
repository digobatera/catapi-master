
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CatAPICore.Modelos;

namespace CatAPIDataCore.Servicos
{
    public class LogsDataProvider
    {
        readonly Interfaces.IDataProvider _provider;

        public LogsDataProvider(Interfaces.IDataProvider provider)
        {
            _provider = provider;
        }

        public void Escreve(int code, string message, string url = null)
        {            
            using (var ctx = _provider.GetContexto())
            {
                InsertLog(new Entidade.Log
                {
                    Dt_created = DateTime.Now,
                    Message = message,
                    Status = code,
                    Url = url
                });
            }
        }

        private void InsertLog(Entidade.Log log)
        {
            using (var ctx = _provider.GetContexto())
            {
                ctx.Logs.Add(log);
                ctx.SaveChanges();
            }

        }

        public Logs GetLog()
        {
            using (var ctx = _provider.GetContexto())
            {
                var tmp = ctx.Logs.Select(d =>
                    new Log()
                    {
                        Id = d.Id,
                        Dt_created = d.Dt_created,
                        Status = d.Status,
                        Url = d.Url,
                        Message = d.Message
                    }
                ).ToList();

                var a = new Logs();
                a.AddRange(tmp);
                return a;
            }

        }


    }
}
