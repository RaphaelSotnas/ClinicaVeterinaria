using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaVeterinaria.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(x => x.ClienteId);
            builder.Property(x => x.NomeCliente).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CpfCliente).IsRequired().HasMaxLength(11);
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}
