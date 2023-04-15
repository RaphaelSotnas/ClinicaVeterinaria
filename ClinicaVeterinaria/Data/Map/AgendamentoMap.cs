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

            builder.HasOne(x => x.Veterinario);
        }
    }
}
