using AutoMapper;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueSantos.Torneio.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public MainController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}