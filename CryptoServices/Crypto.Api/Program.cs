
using Crypto.Api.Discovery;
using AutoMapper;
using Crypto.Api.Validations;
using Crypto.Shared.Configurations;
using FluentValidation.AspNetCore;

namespace Crypto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.RegisterCryptoServices();
            builder.Services.AddControllers()
                .AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<Program>());;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            ConfigureSettings(builder);
            
            var app = builder.Build();
            
            app.MapDefaultEndpoints();

            // Configure the HTTP request pipeline.
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

        private static void ConfigureSettings(WebApplicationBuilder builder)
        {
            builder.Services.Configure<ProvidersKeys>(builder.Configuration.GetSection("ProvidersKeys"));
        }
    }
}
