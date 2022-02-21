using HenriqueSantos.Torneio.Negocio.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HenriqueSantos.Torneio.API.Extensions
{
    public class Usuario : IUsuario
    {
        private readonly IHttpContextAccessor _acessor;

        public Usuario(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public string Nome => _acessor.HttpContext?.User.Identity?.Name ?? String.Empty;

        public bool Autenticado() => _acessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

        public bool NaRole(string role)
        {
            return _acessor.HttpContext?.User.IsInRole(role) ?? false;
        }

        public IEnumerable<Claim>? ObterClaimsIdentity() =>
            _acessor.HttpContext?.User?.Claims ?? null;

        public string ObterEmail()
        {
            if (Autenticado())
                return _acessor.HttpContext?.User.Claims?.Where(c => c.Type == JwtRegisteredClaimNames.Email).FirstOrDefault()?
                    .Value ?? String.Empty;

            return String.Empty;
        }

        public Guid ObterId()
        {
            if (Autenticado())
            {
                var id = _acessor.HttpContext?.User.Claims?.Where(c => c.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault()?
                    .Value;
                if (!string.IsNullOrEmpty(id))
                {
                    return Guid.Parse(id);
                }
            }

            return Guid.Empty;
        }
    }
}
