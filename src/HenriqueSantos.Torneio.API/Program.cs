
using HenriqueSantos.Torneio.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("Dev");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseCors("Prod");
    app.UseHsts(); ;
}

app.UseApiConfiguration();

app.Run();
