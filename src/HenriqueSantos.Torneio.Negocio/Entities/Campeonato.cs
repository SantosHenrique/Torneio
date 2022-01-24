using System;

namespace HenriqueSantos.Torneio.Negocio.Entities
{
    public class Campeonato : Entity
    {
        public DateOnly Inicio { get; private set; }
        public DateOnly Fim { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}
