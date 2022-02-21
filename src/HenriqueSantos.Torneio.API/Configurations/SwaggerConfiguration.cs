using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HenriqueSantos.Torneio.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Torneio API",
                    Description = "Uma API Rest .NET 6 para fins de estudos",
                    Contact = new OpenApiContact
                    {
                        Name = "Henrique Fernandes Santos",
                        Email = "fernandeshenrique01@gmail.com"
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo de entrada. \r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer asX12sdplja'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                var arquivoXml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, arquivoXml));
            });
        }

        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
