using ClinicaVeterinaria.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaVeterinaria.Data.Map
{
    public class AgendamentoMap : IEntityTypeConfiguration<AgendamentoModel>
    {
        public void Configure(EntityTypeBuilder<AgendamentoModel> builder)
        {
            builder.HasKey(x => x.AgendamentoId);
            builder.Property(x => x.DataConsulta).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.VeterinarioNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Disponivel);
            builder.Property(x => x.VeterinarioId);
            builder.Property(x => x.AnimalId);
            //builder.Property(x => x.AnimalNome).IsRequired().HasMaxLength(100);
            //builder.Property(x => x.VeterinarioGeriatria).IsRequired();

            builder.HasOne(x => x.Veterinario);
            builder.HasOne(x => x.Animal);
        }
    }
}
