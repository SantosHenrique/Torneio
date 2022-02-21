using HenriqueSantos.Torneio.Aplicacao.Constantes;
using HenriqueSantos.Torneio.Aplicacao.Dto;
using HenriqueSantos.Torneio.Aplicacao.Extensions;
using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Negocio.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HenriqueSantos.Torneio.Aplicacao.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly INotificaService _notificaService;
        private readonly AppSettings _appSettings;

        public AutenticacaoService(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            INotificaService notificaService,
            IOptions<AppSettings> _options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _notificaService = notificaService;
            _appSettings = _options.Value;
        }

        public async Task<object?> Registrar(RegistroUsuarioDto usuarioDto)
        {
            var usuario = new IdentityUser
            {
                UserName = usuarioDto.Email,
                Email = usuarioDto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(usuario, usuarioDto.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, false);
                return await GerarJWTResponse(usuario.Email);
            }
            else
                _notificaService.Adicionar(result.Errors.Select(e => e.Description));

            return null;
        }

        public async Task<object?> Logar(LoginUsuarioDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Senha, false, true);

            List<string> erros = new();

            if (result.Succeeded)
            {
                return await GerarJWTResponse(loginDto.Email);
            }
            else
                erros.Add(MensagensErro.AcessoNegado);

            if (result.IsLockedOut)
                erros.Add(MensagensErro.UsuarioBloqueado);

            if (erros.Any())
                _notificaService.Adicionar(erros);

            return null;
        }

        private async Task<LoginResponseDto> GerarJWTResponse(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            var claims = await GerarClaims(usuario);

            var response = new LoginResponseDto(GerarToken(new ClaimsIdentity(claims)), 
                TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                new UsuarioTokenDto(usuario.Id, usuario.Email, claims.Select(c => new ClaimDto(c.Value, c.Type))));

            return response;
        }

        private string GerarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            });

            return tokenHandler.WriteToken(token);
        }

        private async Task<IList<Claim>> GerarClaims(IdentityUser usuario)
        {
            var claims = await _userManager.GetClaimsAsync(usuario);
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            return claims;
        }

        private static long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
