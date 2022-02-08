using AutoMapper;
using HenriqueSantos.Torneio.Aplicacao.Dto;
using HenriqueSantos.Torneio.Negocio.Entities;

namespace HenriqueSantos.Torneio.Aplicacao.Mappings
{
    public class AutoMapperMap : Profile
    {
        public AutoMapperMap()
        {
            CreateMap<CampeonatoDto, Campeonato>().ReverseMap();
        }
    }
}