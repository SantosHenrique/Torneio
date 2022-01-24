using HenriqueSantos.Torneio.Negocio.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HenriqueSantos.Torneio.Negocio.Interfaces.Repositories
{
    public interface IRepository<T> : IEntity<T> where T : Entity
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<IEnumerable<T>> ObterTodos(Expression<Func<T, bool>> predicate = null);
        Task<T> Obter(Expression<Func<T, bool>> predicate = null);
        Task Adicionar(T entidade);
        Task Atualizar(T entidade);
    }
}
