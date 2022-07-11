using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mytest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Infra.Persistence.Configurations
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ValorUnitario).IsRequired().HasPrecision(12, 2);
            builder.Property(p => p.Total).IsRequired().HasPrecision(12, 2);

            builder
               .HasOne(p => p.PessoaCompradora)
               .WithMany(p => p.PessoasCompradoras)
               .HasForeignKey(p => p.CompradorId)
               .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasOne(v => v.ProdutoVendidoId)
                .WithMany(v => v.VendasProduto)
                .HasForeignKey(v => v.ProdutoId);
            builder.Property(p => p.DataCriacao).IsRequired();

        }
    }
}
