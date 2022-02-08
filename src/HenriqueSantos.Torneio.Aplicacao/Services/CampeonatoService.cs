using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Negocio.Entities;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;

namespace HenriqueSantos.Torneio.Aplicacao.Services
{
    public class CampeonatoService : Service<Campeonato>, ICampeonatoService
    {
        public CampeonatoService(IUnitOfWork uow) 
            : base(uow, uow.CampeonatoRepository) { }

        public void Remover(Campeonato campeonato)
        {
            _uow.CampeonatoRepository.Remover(campeonato);
        }
    }
}
