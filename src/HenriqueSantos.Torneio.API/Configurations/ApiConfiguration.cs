using HenriqueSantos.Torneio.Aplicacao.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueSantos.Torneio.API.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapperConfiguration();
            services.Register();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Dev", builder => 
                { 
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Prod", builder =>
                {
                    builder.WithOrigins("dominio-do-front");
                    builder.WithMethods("GET,POST");
                    builder.WithHeaders("...");
                    builder.WithExposedHeaders("...");
                });
            });
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
