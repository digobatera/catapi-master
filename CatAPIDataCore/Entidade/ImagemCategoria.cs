using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatAPIDataCore.Entidade
{
    [Table(nameof(ImagemCategoria))]
    public class ImagemCategoria : EntidadeBase
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        
        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
    }
}
