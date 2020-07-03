using System;
using System.Collections.Generic;
using System.Text;

namespace CatAPICore.Modelos
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Dt_created { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
    }
}
