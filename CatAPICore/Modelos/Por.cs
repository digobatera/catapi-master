
using System;
using System.Collections.Generic;
using System.Text;

namespace CatAPICore.Modelos
{
    public class Por<T>
    {
        public IList<Raca> Breeds { get; set; }
        public IList<Modelos.Categoria> Categories { get; set; }
        public T Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
