using HenriqueSantos.Torneio.Aplicacao.Dto;

namespace HenriqueSantos.Torneio.Aplicacao.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<object?> Registrar(RegistroUsuarioDto usuarioDto);
        Task<object?> Logar(LoginUsuarioDto loginDto);
    }
}
