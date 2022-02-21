
using AutoMapper;
using HenriqueSantos.Torneio.Aplicacao.Dto;
using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Negocio.Interfaces;
using HenriqueSantos.Torneio.Negocio.Services;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueSantos.Torneio.API.Controllers
{
    [Route("api/autenticacao")]
    public class AutenticacaoController : MainController
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IMapper mapper, INotificaService notificaService, 
            IAutenticacaoService autenticacaoService, IUsuario usuario)
            : base(mapper, notificaService, usuario)
        {
            _autenticacaoService = autenticacaoService;
        }

        /// <summary>
        /// Registra um usuário
        /// </summary>
        /// <param name="usuarioDto">Objeto esperado para a criação do usuário</param>
        /// <returns>Usuário registrado</returns>
        /// <response code="200">Usuário registrado</response>
        /// <response code="400">Coleção de erros</response>
        [HttpPost("nova-conta")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Registrar(RegistroUsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomResponse(await _autenticacaoService.Registrar(usuarioDto) ?? usuarioDto);
        }

        /// <summary>
        /// Loga no sistema
        /// </summary>
        /// <param name="loginDto">Objeto para a autenticação no sistema</param>
        /// <returns>Token do usuário junto às suas informações</returns>
        /// <response code="200">Usuário logado</response>
        /// <response code="400">Coleção de erros</response>
        [HttpPost("entrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUsuarioDto loginDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);
            
            return CustomResponse(await _autenticacaoService.Logar(loginDto) ?? loginDto);
        }
    }
}
