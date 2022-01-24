using HenriqueSantos.Torneio.Negocio.Entities;

namespace HenriqueSantos.Torneio.Negocio.Interfaces
{
    public interface IEntity<T> where T : Entity
    {
        protected void AtualizarDatas();
        protected void AtualizarDataCriacao();
        protected void AtualizarDataAlteracao();
    }
}
