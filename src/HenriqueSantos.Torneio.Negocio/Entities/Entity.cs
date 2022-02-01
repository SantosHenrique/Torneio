using HenriqueSantos.Torneio.Negocio.Interfaces;
using System;

namespace HenriqueSantos.Torneio.Negocio.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AlteradoEm { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            AtualizarDatas();
        }

        protected void AtualizarDatas()
        {
            AtualizarDataCriacao();
            AtualizarDataAlteracao();
        }

        protected void AtualizarDataCriacao() => CriadoEm = DateTime.Now;
        protected void AtualizarDataAlteracao() => AlteradoEm = DateTime.Now;
    }
}
