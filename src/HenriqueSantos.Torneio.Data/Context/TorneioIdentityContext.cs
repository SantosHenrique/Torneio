using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HenriqueSantos.Torneio.Data.Context
{
    public class TorneioIdentityContext : IdentityDbContext
    {
        public TorneioIdentityContext(DbContextOptions<TorneioIdentityContext> options)
            : base(options) { }
    }
}
