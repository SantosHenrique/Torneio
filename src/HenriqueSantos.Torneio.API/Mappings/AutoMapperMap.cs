using AutoMapper;
using HenriqueSantos.Torneio.API.Dto;
using HenriqueSantos.Torneio.Negocio.Entities;

namespace HenriqueSantos.Torneio.API.Mappings
{
    public class AutoMapperMap : Profile
    {
        public AutoMapperMap()
        {
            CreateMap<CampeonatoDto, Campeonato>().ReverseMap();
        }
    }
}