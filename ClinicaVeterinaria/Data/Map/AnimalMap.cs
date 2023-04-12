using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaVeterinaria.Data.Map
{
    public class AnimalMap : IEntityTypeConfiguration<AnimalModel>
    {
        public void Configure(EntityTypeBuilder<AnimalModel> builder)
        {
            builder.HasKey(x => x.AnimalId);
            builder.Property(x => x.NomeAnimal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CategoriaAnimal).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Geriatria).IsRequired();
            builder.Property(x => x.ClienteId);

            builder.HasOne(x => x.Cliente);
        }
    }
}
