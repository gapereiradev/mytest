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
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired();
            
            builder.Property(p => p.Valor)
                .HasPrecision(12, 2)
                .IsRequired();
           
            builder.Property(p => p.QuantidadeEmEstoque).IsRequired();
            builder.Property(p => p.Active).IsRequired();
            builder.Property(p => p.DataCriacao).IsRequired();


            builder
               .HasOne(p => p.Pessoa)
               .WithMany(p => p.ProdutosAnunciados)
               .HasForeignKey(p => p.PessoaId)
               .OnDelete(DeleteBehavior.ClientCascade);


        }
    }
}
