using HenriqueSantos.Torneio.Negocio.Interfaces;
using System.Linq.Expressions;

namespace HenriqueSantos.Torneio.Aplicacao.Services.Interfaces
{
    public interface IService<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> ObterTodosAsNoTrack(Expression<Func<T, bool>>? predicate = null);
        Task<T> Obter(Expression<Func<T, bool>>? predicate = null);
        Task<T> ObterAsNoTrack(Expression<Func<T, bool>>? predicate = null);
        Task Adicionar(T entidade);
        void Atualizar(T entidade);
        Task SalvarAsync();
    }
}
