using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatAPIDataCore.Entidade
{
    [Table("Raca")]
    public class Raca : EntidadeBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Temperament { get; set; }
        public string Description { get; set; }
        
    }
}
