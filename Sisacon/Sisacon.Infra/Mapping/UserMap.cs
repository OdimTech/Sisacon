using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("USERS");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(null);

            Property(x => x.Active)
                .HasColumnName("ACTIVE")
                .IsRequired()
                .HasColumnType("bit");

            Property(x => x.eUserType)
                .HasColumnName("USER_TYPE")
                .IsRequired();

            Property(x => x.LastLogin)
                .HasColumnName("LAST_LOGIN")
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.RegistrationDate)
                .HasColumnName("REGISTRATION_DATE")
                .IsRequired()
                .HasColumnType("DateTime");

            Property(x => x.ExclusionDate)
                .HasColumnName("EXCLUSION_DATE")
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.ShowWellcomeMessage)
                .HasColumnName("SHOW_WELLCOME")
                .IsRequired()
                .HasColumnType("bit");
        }
    }
}
