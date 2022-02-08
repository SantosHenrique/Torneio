using AutoMapper;
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

        public MainController(IMapper mapper,
            INotificaService notificaService)
        {
            _mapper = mapper;
            _notificaService = notificaService;
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    data = result,
                    errors = _notificaService.Notificacoes
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
            _notificaService.Adicionar(new List<string> { mensagem }, string.Empty);
        }

        private bool OperacaoValida() =>
            !_notificaService.TemNotificacao();

    }
}