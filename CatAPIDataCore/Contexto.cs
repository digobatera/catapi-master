using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;

namespace CatAPIDataCore
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions opts) : base(opts)
        {

        }

        public static void ConfigureForMySql(IConfiguration config,  IServiceCollection service)
        {
            var cn = config.GetValue<string>("connectionString");
            service.AddDbContext<Contexto>(opt => opt.UseMySql(cn));
        }

        public DbSet<CatAPIDataCore.Entidade.Raca> Racas { get; set; }

        public DbSet<CatAPIDataCore.Entidade.ImagemRaca> ImagemRacas { get; set; }
        
        public DbSet<CatAPIDataCore.Entidade.Categoria> Categorias { get; set; }

        public DbSet<CatAPIDataCore.Entidade.ImagemCategoria> ImagemCategorias { get; set; }

        public DbSet<CatAPIDataCore.Entidade.Log> Logs { get; set; }
    }
}
