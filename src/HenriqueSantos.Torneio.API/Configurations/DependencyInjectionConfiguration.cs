using HenriqueSantos.Torneio.Aplicacao.Services;
using HenriqueSantos.Torneio.Aplicacao.Services.Interfaces;
using HenriqueSantos.Torneio.Data.Context;
using HenriqueSantos.Torneio.Data.Repositories;
using HenriqueSantos.Torneio.Negocio.Interfaces.Repositories;
using HenriqueSantos.Torneio.Negocio.Services;

namespace HenriqueSantos.Torneio.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<TorneioContext>();

            services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INotificaService, NotificaService>();
            services.AddScoped<ICampeonatoService, CampeonatoService>();
        }
    }
}
