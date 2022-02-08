using AutoMapper;
using HenriqueSantos.Torneio.Aplicacao.Dto;
using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Negocio.Entities;
using HenriqueSantos.Torneio.Negocio.Services;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueSantos.Torneio.API.Controllers
{
    [Route("api/campeonatos")]
    public class CampeonatoController : MainController
    {
        private ICampeonatoService _campeonatoService;

        public CampeonatoController(IMapper mapper,
            ICampeonatoService campeonatoService,
            INotificaService notificaService) : base(mapper, notificaService)
        {
            _campeonatoService = campeonatoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CampeonatoDto>> ObterTodos() =>
            _mapper.Map<IEnumerable<CampeonatoDto>>(await _campeonatoService.ObterTodosAsNoTrack());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CampeonatoDto>> ObterPorId(Guid id)
        {
            var campeonato = await _campeonatoService.ObterAsNoTrack(c => c.Id == id);

            if (campeonato is null)
                return NotFound();

            return CustomResponse(campeonato);
        }

        [HttpPost]
        public async Task<ActionResult<CampeonatoDto>> Adicionar(CampeonatoDto campeonatoDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var campeonato = _mapper.Map<Campeonato>(campeonatoDto);
            await _campeonatoService.Adicionar(campeonato);
            await _campeonatoService.SalvarAsync();

            return CustomResponse(campeonato);
        }

        [HttpPut("{id:guid}")]
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

        [HttpDelete("{id:guid}")]
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