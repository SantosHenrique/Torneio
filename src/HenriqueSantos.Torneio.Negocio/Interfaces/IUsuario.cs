using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace HenriqueSantos.Torneio.Negocio.Interfaces
{
    public interface IUsuario
    {
        string Nome { get; }
        Guid ObterId();
        string ObterEmail();
        bool Autenticado();
        bool NaRole(string role);
        IEnumerable<Claim> ObterClaimsIdentity();
    }
}
