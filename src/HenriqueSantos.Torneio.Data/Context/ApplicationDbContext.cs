using HenriqueSantos.Torneio.Negocio.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HenriqueSantos.Torneio.Data.Context
{
    public class TorneioContext : DbContext
    {
        public TorneioContext(DbContextOptions<TorneioContext> options)
            : base(options) { }

        public DbSet<Campeonato> Campeonatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Varre um determinado assembly, identifica todos que implementam IEntityTypeConfiguration e os registra
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
