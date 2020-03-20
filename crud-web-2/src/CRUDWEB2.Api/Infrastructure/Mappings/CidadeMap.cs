using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPMigracao.Api.Domain.Cidades;

namespace CRUDWEB2.Api.Infrastructure.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable(nameof(Cidade));

            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(160)
                .IsRequired();

            builder
                .Property(x => x.Uf)
                  .HasMaxLength(2)
                .IsRequired();
        }
    }
}