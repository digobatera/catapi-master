using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatAPIDataCore.Entidade
{
    [Table("Log")]
    public class Log : EntidadeBase
    {
        public int Id { get; set; }
        public DateTime Dt_created { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }

    }
}
