using HenriqueSantos.Torneio.Data.Context;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace HenriqueSantos.Torneio.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public TorneioContext _context;
        private CampeonatoRepository _campeonatoRepository;

        public UnitOfWork(TorneioContext context)
        {
            _context = context;
        }

        public ICampeonatoRepository CampeonatoRepository => _campeonatoRepository ??= new CampeonatoRepository(_context);
        
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
