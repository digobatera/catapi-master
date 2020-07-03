using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatAPICore.Modelos;

namespace CatAPIDataCore.Servicos

{
    public class CategoriasDataProvider
    {
        Interfaces.IDataProvider _provider;
        public CategoriasDataProvider(Interfaces.IDataProvider provider)
        {
            _provider = provider;
        }

        public void AdicionaCategoria(Categoria categoria)
        {
            using (var ctx = _provider.GetContexto())
            {
                if (!ctx.Categorias.Where(linha => linha.Id == categoria.Id).Any())
                {
                    ctx.Categorias.Add(new CatAPIDataCore.Entidade.Categoria
                    {
                        Id = categoria.Id,
                        Name = categoria.Name
                    });
                    ctx.SaveChanges();
                }
            }
        }

        public void AdicionaCategorias(Categorias categorias)
        {
            using (var ctx = _provider.GetContexto())
            {
                var categoriasIds = categorias.Select(a => a.Id).ToHashSet();
                var categoriasExistentes = ctx.Categorias.Where(linha => categoriasIds.Contains(linha.Id)).Select(d => d.Id).ToList();
                var categoriasNaoExistentes = categoriasIds.Where(d => !categoriasExistentes.Contains(d)).ToList();

                categorias.Where(f => categoriasNaoExistentes.Contains(f.Id)).ToList().ForEach(d =>
                {
                    ctx.Categorias.Add(new CatAPIDataCore.Entidade.Categoria
                    {
                        Id = d.Id,
                        Name = d.Name
                    });
                });
                if (categoriasNaoExistentes.Any())
                {
                    ctx.SaveChanges();
                }
            }
        }

        public void AdicionaImagemCategorias(PorCategorias imagemcategorias)
        {
            using (var ctx = _provider.GetContexto())
            {

                imagemcategorias.ToList().ForEach(d =>
                {
                    ctx.ImagemCategorias.Add(new CatAPIDataCore.Entidade.ImagemCategoria
                    {
                        CategoriaId = d.Categories.First().Id,
                        Url = d.Url,
                        Name = d.Categories.First().Name
                    });
                });
                if (imagemcategorias.Any())
                {
                    ctx.SaveChanges();
                }
            }
        }
    }
}
