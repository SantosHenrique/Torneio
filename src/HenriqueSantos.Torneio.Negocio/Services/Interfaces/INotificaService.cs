
using HenriqueSantos.Torneio.Negocio.Objects;
using System.Collections.Generic;

namespace HenriqueSantos.Torneio.Negocio.Services
{
    public interface INotificaService
    {
        void Adicionar(IEnumerable<string> mensagens);
        void Adicionar(string mensagem);
        Notificacao Notificacao { get; }
        bool TemNotificacao();
    }
}
