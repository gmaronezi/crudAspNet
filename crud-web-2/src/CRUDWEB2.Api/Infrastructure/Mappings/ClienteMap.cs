using CRUDWEB2.Api.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDWEB2.Api.Infrastructure.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable(nameof(Cliente));

            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(160)
                .IsRequired();
                
            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasMaxLength(11);

            builder.Property(x => x.Rua)
                .HasMaxLength(160);

            builder.Property(x => x.Numero)
                .HasMaxLength(6);

            builder.Property(x => x.Complemento)
                .HasMaxLength(200);

            builder.Property(x => x.Bairro)
                .HasMaxLength(160);

            builder.Property(x => x.Cep)
                .HasMaxLength(12);

            builder
                .HasOne(x => x.Cidade)
                .WithMany()
                .HasForeignKey(x => x.CidadeId);
        }
    }
}