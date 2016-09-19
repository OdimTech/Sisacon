using Sisacon.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("ADDRESS");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("ID");

            Property(x => x.Cep)
                .HasColumnName("CEP")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(x => x.Logradouro)
                .HasColumnName("LOGRADOURO")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Numero)
                .HasColumnName("NUMERO")
                .HasColumnType("int");

            Property(x => x.Complemento)
                .HasColumnName("COMPLEMENTO")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Bairro)
                .HasColumnName("BAIRRO")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Cidade)
                .HasColumnName("CIDADE")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Estado)
                .HasColumnName("ESTADO")
                .HasColumnType("varchar")
                .HasMaxLength(30);
        }
    }
}
