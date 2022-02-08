using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Negocio.Interfaces;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;
using System.Linq.Expressions;

namespace HenriqueSantos.Torneio.Aplicacao.Services
{
    public class Service<T> : IService<T> where T : class, IEntity
    {
        protected IRepository<T> _repository;
        protected IUnitOfWork _uow;

        public Service(IUnitOfWork uow, IRepository<T> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Adicionar(T entidade) =>
           await _repository.Adicionar(entidade);

        public void Atualizar(T entidade) =>
            _repository.Atualizar(entidade);

        public async Task<T> Obter(Expression<Func<T, bool>>? predicate = null) =>
           await _repository.Obter(predicate);

        public async Task<T> ObterAsNoTrack(Expression<Func<T, bool>>? predicate = null) =>
            await _repository.ObterAsNoTrack(predicate);

        public async Task<IEnumerable<T>> ObterTodosAsNoTrack(Expression<Func<T, bool>>? predicate = null) =>
            await _repository.ObterTodosAsNoTrack(predicate);

        public async Task SalvarAsync() => await _uow.SaveChangesAsync();
    }
}
