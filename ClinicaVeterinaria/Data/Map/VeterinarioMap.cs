using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaVeterinaria.Data.Map
{
    public class VeterinarioMap : IEntityTypeConfiguration<VeterinarioModel>
    {
        public void Configure(EntityTypeBuilder<VeterinarioModel> builder)
        {
            builder.HasKey(x => x.VeterinarioId);
            builder.Property(x => x.NomeVeterinario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Geriatria).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired(); ;
            builder.Property(x => x.DataContratacao).IsRequired(); ;
        }
    }
}
