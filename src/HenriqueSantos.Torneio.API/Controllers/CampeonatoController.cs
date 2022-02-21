using AutoMapper;
using HenriqueSantos.Torneio.API.Extensions;
using HenriqueSantos.Torneio.Aplicacao.Dto;
using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Negocio.Entities;
using HenriqueSantos.Torneio.Negocio.Interfaces;
using HenriqueSantos.Torneio.Negocio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueSantos.Torneio.API.Controllers
{
    [Route("api/campeonatos")]
    [Authorize]
    public class CampeonatoController : MainController
    {
        private ICampeonatoService _campeonatoService;

        public CampeonatoController(IMapper mapper,
            ICampeonatoService campeonatoService,
            INotificaService notificaService, 
            IUsuario usuario) : base(mapper, notificaService, usuario)
        {
            _campeonatoService = campeonatoService;
        }

        /// <summary>
        /// Obtêm todos os campeonatos
        /// </summary>
        /// <returns>Uma lista de campeonatos</returns>
        /// <response code="200">Uma lista de campeonatos</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<CampeonatoDto>> ObterTodos() =>
            _mapper.Map<IEnumerable<CampeonatoDto>>(await _campeonatoService.ObterTodosAsNoTrack());

        /// <summary>
        /// Edita um campeonato 
        /// </summary>
        /// <param name="id">Identificador do campeonato</param>
        /// <returns>Campeonato editado</returns>
        /// <response code="200">Campeonato editado</response>
        /// <response code="404">Identificador inválido</response>
        [Authorize]
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CampeonatoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampeonatoDto>> ObterPorId(Guid id)
        {
            var campeonato = await _campeonatoService.ObterAsNoTrack(c => c.Id == id);

            if (campeonato is null)
                return NotFound();

            return CustomResponse(campeonato);
        }

        /// <summary>
        /// Adiciona um campeonato
        /// </summary>
        /// <param name="campeonatoDto">Objeto com as propriedades para um novo campeonato</param>
        /// <returns>Campeonato adicionado</returns>
        /// <response code="200">Novo campeonato</response>
        /// <response code="400">Coleção de erros</response>
        [CustomAuthorize("Campeonato", "Adicionar")]
        [HttpPost]
        [ProducesResponseType(typeof(CampeonatoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampeonatoDto>> Adicionar(CampeonatoDto campeonatoDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var campeonato = _mapper.Map<Campeonato>(campeonatoDto);
            await _campeonatoService.Adicionar(campeonato);
            await _campeonatoService.SalvarAsync();

            return CustomResponse(campeonato);
        }

        /// <summary>
        /// Atualiza o campeonato
        /// </summary>
        /// <param name="id">Identificador do campeonato</param>
        /// <param name="campeonatoDto">Objeto com as propriedades necessárias para atualização do campeonato</param>
        /// <returns>Campeonato atualizado</returns>
        /// <reponse code="200">Campeonato atualizado</reponse>
        /// <reponse code="400">Coleção de erros</reponse>
        [CustomAuthorize("Campeonato", "Atualizar")]
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(CampeonatoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CampeonatoDto>> Atualizar(Guid id, CampeonatoDto campeonatoDto)
        {
            if (id != campeonatoDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var campeonato = _mapper.Map<Campeonato>(campeonatoDto);
            _campeonatoService.Atualizar(campeonato);
            await _campeonatoService.SalvarAsync();

            return CustomResponse(campeonato);
        }

        /// <summary>
        /// Exclui o campeonato
        /// </summary>
        /// <param name="id">Identificador do campeonato</param>
        /// <response code="404">Identificador inválido</response>
        [CustomAuthorize("Campeonato", "Excluir")]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(CampeonatoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var campeonato = await _campeonatoService.ObterAsNoTrack(c => c.Id == id);

            if (campeonato is null)
                return NotFound();

            _campeonatoService.Remover(campeonato);
            await _campeonatoService.SalvarAsync();

            return CustomResponse();
        }
    }
}