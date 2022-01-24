using HenriqueSantos.Torneio.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HenriqueSantos.Torneio.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TorneioContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
