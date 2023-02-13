using Microsoft.OpenApi.Models;
using TickTick.App.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        
        builder.Services.RegisterServices();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "TickTick your ticks and tickles",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Email = "elmos@elm.os",
                        Name = "Deweloper Yusup",
                        Url = new Uri("https://chat.openai.com/")
                    }
                });
        });
        /*
        builder.Services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion();

            //TODO: add versioning to the API :)
        });
        **/

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}