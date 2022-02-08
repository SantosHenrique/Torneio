using HenriqueSantos.Torneio.Negocio.Objects;
using System.Collections.Generic;
using System.Linq;

namespace HenriqueSantos.Torneio.Negocio.Services
{
    public class NotificaService : INotificaService
    {
        public IList<Notificacao> Notificacoes { get; private set; } = new List<Notificacao>();

        public void Adicionar(IEnumerable<string> mensagens, string chave = null)
        {
            Notificacoes.Add(new Notificacao(chave, mensagens));
        }

        public bool TemNotificacao() => Notificacoes.Any();
    }
}
