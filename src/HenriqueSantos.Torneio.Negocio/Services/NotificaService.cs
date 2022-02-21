using HenriqueSantos.Torneio.Negocio.Objects;
using System.Collections.Generic;
using System.Linq;

namespace HenriqueSantos.Torneio.Negocio.Services
{
    public class NotificaService : INotificaService
    {
        public Notificacao Notificacao { get; private set; } = new Notificacao();

        public void Adicionar(string mensagem)
        {
            Notificacao.AdicionarMensagem(mensagem);
        }

        public void Adicionar(IEnumerable<string> mensagem)
        {
            Notificacao.AdicionarMensagem(mensagem);
        }

        public bool TemNotificacao() => Notificacao.Messages.Any();
    }
}
