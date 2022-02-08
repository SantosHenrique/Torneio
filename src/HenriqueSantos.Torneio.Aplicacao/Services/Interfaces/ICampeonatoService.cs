using HenriqueSantos.Torneio.Negocio.Entities;

namespace HenriqueSantos.Torneio.Aplicacao.Services.Interfaces
{
    public interface ICampeonatoService : IService<Campeonato>
    {
        void Remover(Campeonato campeonato);
    }
}
