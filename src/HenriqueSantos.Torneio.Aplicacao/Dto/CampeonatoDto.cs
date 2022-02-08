using HenriqueSantos.Torneio.Aplicacao.Constantes;
using System.ComponentModel.DataAnnotations;

namespace HenriqueSantos.Torneio.Aplicacao.Dto
{
    public record CampeonatoDto(Guid Id, [Required(ErrorMessage = MensagensErro.Requerido)]DateTime Inicio,
        [Required(ErrorMessage = MensagensErro.Requerido)] DateTime Fim,
        [Required(ErrorMessage = MensagensErro.Requerido)] string Nome,
        [Required(ErrorMessage = MensagensErro.Requerido)] string Descricao);
}
