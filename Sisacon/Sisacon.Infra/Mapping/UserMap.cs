using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Sisacon.Infra.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Email)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Password)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(null);

            Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            Property(x => x.eUserType)
                .IsRequired();

            Property(x => x.LastLogin)
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.RegistrationDate)
                .IsRequired()
                .HasColumnType("DateTime");

            Property(x => x.ExclusionDate)
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.ShowWellcomeMessage)
                .IsRequired()
                .HasColumnType("bit");

            HasOptional(x => x.Company)
                .WithRequired(x => x.User)
                .Map(configurationAction: new System.Action<ForeignKeyAssociationMappingConfiguration>(x => x.MapKey("UserId")));
        }
    }
}
