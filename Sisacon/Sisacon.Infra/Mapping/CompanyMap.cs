using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            ToTable("COMPANY");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            Property(x => x.ePersonType)
                .HasColumnName("PERSON_TYPE")
                .IsOptional();

            Property(x => x.Cpf)
                .HasColumnName("CPF")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.Cnpj)
                .HasColumnName("CNPJ")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.CompanyName)
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.FantasyName)
                .HasColumnName("FANTASY_NAME")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.SocialReasonName)
                .HasColumnName("SOCIAL_REASON_NAME")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.SocialReasonName)
                .HasColumnName("SOCIAL_REASON_NAME")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.UrlPathLogo)
                .HasColumnName("URL_PATH_LOGO")
                .HasColumnType("varchar")
                .HasMaxLength(500);

            HasOptional(x => x.Address);

            //HasRequired(x => x.Contact);
        }
    }
}
