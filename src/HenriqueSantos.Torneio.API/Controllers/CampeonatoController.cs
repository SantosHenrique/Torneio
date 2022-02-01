using AutoMapper;
using HenriqueSantos.Torneio.API.Dto;
using HenriqueSantos.Torneio.Negocio.Entities;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueSantos.Torneio.API.Controllers
{
    [Route("api/campeonatos")]
    public class CampeonatoController : MainController
    {
        public CampeonatoController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<CampeonatoDto>> ObterTodos() =>
            _mapper.Map<IEnumerable<CampeonatoDto>>(await _uow.CampeonatoRepository.ObterTodosAsNoTrack());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CampeonatoDto>> ObterPorId(Guid id)
        {
            var campeonato = await _uow.CampeonatoRepository
                .ObterAsNoTrack(c => c.Id == id);

            if (campeonato is null)
                return NotFound();

            return Ok(campeonato);
        }

        [HttpPost]
        public async Task<ActionResult<CampeonatoDto>> Adicionar(CampeonatoDto campeonatoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var campeonato = _mapper.Map<Campeonato>(campeonatoDto);
                await _uow.CampeonatoRepository.Adicionar(campeonato);
                await _uow.SaveChangesAsync();
                return Ok(campeonato);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CampeonatoDto>> Atualizar(Guid id, CampeonatoDto campeonatoDto)
        {
            if (id != campeonatoDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var campeonato = _mapper.Map<Campeonato>(campeonatoDto);
                _uow.CampeonatoRepository.Atualizar(campeonato);
                await _uow.SaveChangesAsync();
                return Ok(campeonato);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var campeonato = await _uow.CampeonatoRepository.ObterAsNoTrack(c => c.Id == id);

            if (campeonato is null) 
                return NotFound();

            _uow.CampeonatoRepository.Remover(campeonato);
            await _uow.SaveChangesAsync();
            return Ok();
        }

    }
}