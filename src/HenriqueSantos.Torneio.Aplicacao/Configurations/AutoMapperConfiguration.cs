using Microsoft.Extensions.DependencyInjection;

namespace HenriqueSantos.Torneio.Aplicacao.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
