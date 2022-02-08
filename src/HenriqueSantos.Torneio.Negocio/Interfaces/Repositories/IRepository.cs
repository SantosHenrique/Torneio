using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HenriqueSantos.Torneio.Negocio.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> ObterTodosAsNoTrack(Expression<Func<T, bool>> predicate = null);
        Task<T> Obter(Expression<Func<T, bool>> predicate = null);
        Task<T> ObterAsNoTrack(Expression<Func<T, bool>> predicate = null);
        Task Adicionar(T entidade);
        void Atualizar(T entidade);
    }
}
