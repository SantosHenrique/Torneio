using HenriqueSantos.Torneio.Negocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HenriqueSantos.Torneio.Data.Mappings
{
    public class CampeonatoConfiguration : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(500);
        }
    }
}
