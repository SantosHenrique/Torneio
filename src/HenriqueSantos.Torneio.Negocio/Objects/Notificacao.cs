using System.Collections.Generic;

namespace HenriqueSantos.Torneio.Negocio.Objects
{
    public class Notificacao
    {
        public List<string> Messages { get; private set; } = new List<string>();

        public Notificacao()
        {
        }

        public void AdicionarMensagem(string mensagem)
        {
            Messages.Add(mensagem);
        }

        public void AdicionarMensagem(IEnumerable<string> mensagens)
        {
            Messages.AddRange(mensagens);
        }
    }
}
