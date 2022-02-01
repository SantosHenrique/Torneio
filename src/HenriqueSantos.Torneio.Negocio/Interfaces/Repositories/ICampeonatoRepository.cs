using HenriqueSantos.Torneio.Negocio.Entities;
using System;
using System.Threading.Tasks;

namespace HenriqueSantos.Torneio.Negocio.Interfaces.Repositories
{
    public interface ICampeonatoRepository : IRepository<Campeonato>
    {
        void Remover(Campeonato campeonato);
    }
}
