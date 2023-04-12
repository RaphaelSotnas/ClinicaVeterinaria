using ClinicaVeterinaria.Data.Map;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;


namespace ClinicaVeterinaria.Data
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

        public DbSet<TipoAnimalModel> TiposDeAnimais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new VeterinarioMap());
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new AtendimentoMap());
            modelBuilder.ApplyConfiguration(new TipoAnimalMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
