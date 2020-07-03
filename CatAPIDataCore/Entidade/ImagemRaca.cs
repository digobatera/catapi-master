using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatAPIDataCore.Entidade
{
    [Table(nameof(ImagemRaca))]
    public class ImagemRaca : EntidadeBase
    {
        public int Id { get; set; }
        public string RacaId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
