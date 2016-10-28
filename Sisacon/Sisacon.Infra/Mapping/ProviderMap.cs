using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            HasKey(x => x.Id);

            Property(x => x.CodProvider)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.SocialReasonName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.FantasyName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            HasRequired(x => x.Address);

            HasRequired(x => x.Contact);

            HasRequired(x => x.User);

        }
    }
}
