
using HenriqueSantos.Torneio.Negocio.Objects;
using System.Collections.Generic;

namespace HenriqueSantos.Torneio.Negocio.Services
{
    public interface INotificaService
    {
        void Adicionar(IEnumerable<string> mensagens, string chave = null);
        IList<Notificacao> Notificacoes { get; }
        bool TemNotificacao();
    }
}
