using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatAPICore.Modelos;


namespace CatAPIDataCore.Servicos

{
    public class RacasDataProvider
    {
        Interfaces.IDataProvider _provider;
        public RacasDataProvider(Interfaces.IDataProvider provider)
        {
            _provider = provider;
        }

        public List<string> GetRacaIds()
        {
            using (var ctx = _provider.GetContexto())
            {
                return ctx.Racas.Select(d => d.Id).ToList();
            }
        }
        
        public List<string> GetRacaName()
        {
            using (var ctx = _provider.GetContexto())
            {
                return ctx.Racas.Select(d => d.Name).ToList();
            }
        }
        public void AdicionaRaca(Raca raca)
        {
            using (var ctx = _provider.GetContexto())
            {
                if (!ctx.Racas.Where(linha => linha.Id == raca.Id).Any())
                {
                    ctx.Racas.Add(new CatAPIDataCore.Entidade.Raca
                    {
                        Id = raca.Id,
                        Description = raca.Description,
                        Origin = raca.Origin,
                        Temperament = raca.Temperament,
                        Name = raca.Name
                    });
                    ctx.SaveChanges();
                }
            }
        }

        public void AdicionaRacas(Racas racas)
        {
            using (var ctx = _provider.GetContexto())
            {
                var racasIds = racas.Select(a => a.Id).ToHashSet();
                var racasExistentes = ctx.Racas.Where(linha => racasIds.Contains(linha.Id)).Select(d => d.Id).ToList();
                var racasNaoExistentes = racasIds.Where(d => !racasExistentes.Contains(d)).ToList();

                racas.Where(f => racasNaoExistentes.Contains(f.Id)).ToList().ForEach(d =>
                {
                    ctx.Racas.Add(new CatAPIDataCore.Entidade.Raca
                    {
                        Id = d.Id,
                        Description = d.Description,
                        Origin = d.Origin,
                        Temperament = d.Temperament,
                        Name = d.Name
                    });
                });
                if (racasNaoExistentes.Any())
                {
                    ctx.SaveChanges();
                }
            }
        }

        public List<CatAPIDataCore.Entidade.Raca> GetInfRacaIds(string nomeRaca)
        {
            using (var ctx = _provider.GetContexto())
            {
                return ctx.Racas.Where(d => d.Name.Contains(nomeRaca)).ToList();
            }
        }

        public List<string> GetRacaIdsTemperamento(string nomeTemperamento)
        {
            using (var ctx = _provider.GetContexto())
            {
                return ctx.Racas.Where(d => d.Temperament.Contains(nomeTemperamento)).Select(d => d.Name).ToList();
            }
        }

        public List<string> GetRacaIdsOrigem(string nomeOrigem)
        {
            using (var ctx = _provider.GetContexto())
            {
                return ctx.Racas.Where(d => d.Origin == nomeOrigem).Select(d => d.Name).ToList();
            }
        }

        public void AdicionaImagemRaca(ImagemRaca imagemRaca)
        {
            using (var ctx = _provider.GetContexto())
            {
                ctx.ImagemRacas.Add(new CatAPIDataCore.Entidade.ImagemRaca
                {
                    RacaId = imagemRaca.Id,
                    Url = imagemRaca.Url
                });
                ctx.SaveChanges();
            }

        }

        public void AdicionaImagemRacas(PorRacas imagemracas)
        {
            using (var ctx = _provider.GetContexto())
            {

                imagemracas.ToList().ForEach(d =>
                {
                    ctx.ImagemRacas.Add(new CatAPIDataCore.Entidade.ImagemRaca
                    {
                        RacaId = d.Breeds.First().Id,
                        Url = d.Url,
                        Name = d.Breeds.First().Name
                    });
                });
                if (imagemracas.Any())
                {
                    ctx.SaveChanges();
                }
            }
        }
    }
}
