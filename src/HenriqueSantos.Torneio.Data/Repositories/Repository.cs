using HenriqueSantos.Torneio.Data.Context;
using HenriqueSantos.Torneio.Negocio.Interfaces;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HenriqueSantos.Torneio.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected TorneioContext _context;
        protected DbSet<T> _dbSet;

        public Repository(TorneioContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Adicionar(T entidade) => await _dbSet.AddAsync(entidade);

        public void Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public async Task<T> Obter(Expression<Func<T, bool>> predicate = null) => await _dbSet.Where(predicate).FirstOrDefaultAsync();

        public async Task<T> ObterAsNoTrack(Expression<Func<T, bool>> predicate = null) =>
            await _dbSet.Where(predicate)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> ObterTodosAsNoTrack(Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbSet
                .AsNoTrackingWithIdentityResolution();

            if (predicate is not null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }
    }
}
