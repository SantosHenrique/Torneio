
using AutoMapper;
using HenriqueSantos.Torneio.Negocio.Services;

namespace HenriqueSantos.Torneio.API.Controllers
{
    public class AutenticacaoController : MainController
    {
        public AutenticacaoController(IMapper mapper, INotificaService notificaService)
            : base(mapper, notificaService) { }
    }
}
