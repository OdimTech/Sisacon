using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            HasKey(x => x.Id);

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
                .HasMaxLength(500);

            Property(x => x.eFormatImg)
                .HasColumnType("int");

            HasOptional(x => x.Address);

            HasOptional(x => x.Contact);

            HasRequired(x => x.User);

            HasRequired(x => x.OccupationArea);
        }
    }
}
