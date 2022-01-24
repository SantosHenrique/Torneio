using System;

namespace HenriqueSantos.Torneio.Negocio.Entities
{
    public abstract class Entity 
    {
        protected Guid Id { get; private set; }
        protected DateTime CriadoEm { get; private set; }
        protected DateTime AlteradoEm { get; private set; }

        public Entity()
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
