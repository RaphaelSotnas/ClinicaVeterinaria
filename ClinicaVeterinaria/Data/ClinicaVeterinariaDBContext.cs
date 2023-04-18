using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.Data.Map;
using Microsoft.EntityFrameworkCore;


namespace ClinicaVeterinaria.API.Data
{
    public class ClinicaVeterinariaDBContext : DbContext
    {
        public ClinicaVeterinariaDBContext(DbContextOptions<ClinicaVeterinariaDBContext> options)
            : base(options) 
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<AnimalModel> Animais { get; set; }

        public DbSet<VeterinarioModel> Veterinarios { get; set; }

        public DbSet<AtendimentoModel> Atendimento { get; set; }

        public DbSet<AgendamentoModel> Agendamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new VeterinarioMap());
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new AtendimentoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
