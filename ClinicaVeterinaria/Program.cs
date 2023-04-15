using ClinicaVeterinaria.API.Repository;
using ClinicaVeterinaria.API.Repository.Interfaces;
using ClinicaVeterinaria.API.Data;
using ClinicaVeterinaria.Repository;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.API.Services;

namespace ClinicaVeterinaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<ClinicaVeterinariaDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")) 
                );

            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
            builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            builder.Services.AddScoped<ITipoAnimalRepository, TipoAnimalRepository>();
            builder.Services.AddScoped<IClienteService, ClienteService>();
            var app = builder.Build();

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
    }
}