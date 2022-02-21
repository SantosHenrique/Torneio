using HenriqueSantos.Torneio.Aplicacao.Constantes;
using System.ComponentModel.DataAnnotations;

namespace HenriqueSantos.Torneio.Aplicacao.Dto
{
    public class RegistroUsuarioDto
    {
        [Required(ErrorMessage = MensagensErro.Requerido)]
        [EmailAddress(ErrorMessage = MensagensErro.FormatoInvalido)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = MensagensErro.Requerido)]
        [StringLength(20, ErrorMessage = MensagensErro.QtdCaracteres, MinimumLength = 6)]
        public string Senha { get; set; } = null!;

        [Compare(nameof(Senha), ErrorMessage = MensagensErro.SenhasNaoConferem)]
        public string ConfirmaSenha { get; set; } = null!;
    }

    public record LoginUsuarioDto([Required(ErrorMessage = MensagensErro.Requerido)]
        [EmailAddress(ErrorMessage = MensagensErro.FormatoInvalido)]string Email, 
        [Required(ErrorMessage = MensagensErro.Requerido)]string Senha);

    public record UsuarioTokenDto(string Id, string Email, IEnumerable<ClaimDto> Claims);
    
    public record ClaimDto(string Value, string Type);

    public record LoginResponseDto(string AcessToken, double ExpiresIn, UsuarioTokenDto User);
}
