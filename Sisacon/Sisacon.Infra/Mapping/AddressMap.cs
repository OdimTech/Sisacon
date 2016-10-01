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
            HasKey(x => x.Id);

            Property(x => x.Cep)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(x => x.Logradouro)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Numero)
                .HasColumnType("int");

            Property(x => x.Complemento)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Bairro)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Cidade)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Estado)
                .HasColumnType("varchar")
                .HasMaxLength(30);
        }
    }
}
