using HenriqueSantos.Torneio.Negocio.Entities;
using System;

namespace HenriqueSantos.Torneio.Negocio.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; }
        public DateTime CriadoEm { get; }
        public DateTime AlteradoEm { get; }
    }
}
