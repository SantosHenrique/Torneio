using System.Collections.Generic;

namespace HenriqueSantos.Torneio.Negocio.Objects
{
    public class Notificacao
    {
        public string Key { get; private set; }
        public IEnumerable<string> Messages { get; private set; }

        public Notificacao(string chave, IEnumerable<string> mensagens)
        {
            Key = chave;
            Messages = mensagens;
        }
    }
}
