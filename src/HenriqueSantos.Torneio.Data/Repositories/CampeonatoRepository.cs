using HenriqueSantos.Torneio.Data.Context;
using HenriqueSantos.Torneio.Negocio.Entities;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;

namespace HenriqueSantos.Torneio.Data.Repositories
{
    public class CampeonatoRepository : Repository<Campeonato>, ICampeonatoRepository
    {
        public CampeonatoRepository(TorneioContext context) : base(context) { }
    }
}
