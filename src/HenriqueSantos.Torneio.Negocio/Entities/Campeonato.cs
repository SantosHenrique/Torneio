using System;

namespace HenriqueSantos.Torneio.Negocio.Entities
{
    public class Campeonato : Entity
    {
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}
