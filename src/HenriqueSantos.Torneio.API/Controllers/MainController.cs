using AutoMapper;
using HenriqueSantos.Torneio.Negocio.Interfaces;
using HenriqueSantos.Torneio.Negocio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HenriqueSantos.Torneio.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly IMapper _mapper;
        private readonly INotificaService _notificaService;
        protected readonly IUsuario _usuario;
        protected readonly bool UsuarioAutenticado;
        protected readonly Guid UsuarioId;

        public MainController(IMapper mapper,
            INotificaService notificaService,
            IUsuario usuario)
        {
            _mapper = mapper;
            _notificaService = notificaService;
            _usuario = usuario;

            UsuarioAutenticado = _usuario.Autenticado();
            UsuarioId = _usuario.ObterId();
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    data = result,
                    errors = _notificaService.Notificacao.Messages
                });
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            _notificaService.Adicionar(modelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.Exception?.Message ?? e.ErrorMessage));

            return CustomResponse();
        }

        protected void AddErro(string mensagem)
        {
            _notificaService.Adicionar(mensagem);
        }

        private bool OperacaoValida() =>
            !_notificaService.TemNotificacao();

    }
}