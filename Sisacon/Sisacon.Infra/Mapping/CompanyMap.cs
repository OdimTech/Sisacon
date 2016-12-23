using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    class CompanyMap : BaseMap<Company>
    {
        public CompanyMap()
        {
            Property(x => x.ePersonType)
                .IsRequired();

            Property(x => x.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.CompanyName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.FantasyName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.SocialReasonName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.UrlPathLogo)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsOptional();

            Property(x => x.eFormatImg)
                .HasColumnType("int")
                .IsOptional();

            HasOptional(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.IdAddress);

            HasOptional(x => x.Contact)
                .WithMany()
                .HasForeignKey(x => x.IdContact);

            HasOptional(x => x.OccupationArea)
                .WithMany()
                .HasForeignKey(x => x.IdOccupationArea);

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
