using HenriqueSantos.Torneio.Data.Context;
using HenriqueSantos.Torneio.Data.Repositories;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;

namespace HenriqueSantos.Torneio.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<TorneioContext>();

            services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
