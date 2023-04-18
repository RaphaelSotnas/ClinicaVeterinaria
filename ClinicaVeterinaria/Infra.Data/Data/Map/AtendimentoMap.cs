using ClinicaVeterinaria.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaVeterinaria.Data.Map
{
    public class AtendimentoMap : IEntityTypeConfiguration<AtendimentoModel>
    {
        public void Configure(EntityTypeBuilder<AtendimentoModel> builder)
        {
            builder.HasKey(x => x.AtendimentoId);
            builder.Property(x => x.Diagnostico).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAtendimento).IsRequired();
            builder.Property(x => x.VeterinarioId);
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.VeterinarioNome).HasMaxLength(100);
            builder.Property(x => x.AnimalNome).HasMaxLength(100);

            builder.HasOne(x => x.Veterinario);
            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Animal);
        }
    }
}
