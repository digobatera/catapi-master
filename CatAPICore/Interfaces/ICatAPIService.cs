using CatAPICore.Modelos;

namespace CatAPICore.Interfaces
{
    public interface ICatAPIService
    {
        PorCategorias GetImagemCategoriaChapeu(int limit);
        PorCategorias GetImagemCategoriaOculos(int limit);
        Categorias GetListaCategorias();
        PorRacas GetListaImagemRaca(string idraca, int limit);
        Racas GetListaRacaEspecifica(string raca);
        Racas GetListaRacas();
    }
}