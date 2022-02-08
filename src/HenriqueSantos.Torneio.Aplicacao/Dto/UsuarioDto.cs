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

        [Compare(nameof(Senha), ErrorMessage = "Teste")]
        public string ConfirmaSenha { get; set; } = null!;
    }

    public record UsuarioDto([Required(ErrorMessage = MensagensErro.Requerido)]
        [EmailAddress(ErrorMessage = MensagensErro.FormatoInvalido)]string Email, 
        [Required(ErrorMessage = MensagensErro.Requerido)]string Senha);
}
