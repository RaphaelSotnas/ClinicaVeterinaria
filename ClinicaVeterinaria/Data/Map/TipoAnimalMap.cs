using ClinicaVeterinaria.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaVeterinaria.Data.Map
{
    public class TipoAnimalMap : IEntityTypeConfiguration<TipoAnimalModel>
    {
        public void Configure(EntityTypeBuilder<TipoAnimalModel> builder)
        {
            builder.HasKey(x => x.TipoAnimalId);
            builder.Property(x => x.CategoriaAnimal).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}
