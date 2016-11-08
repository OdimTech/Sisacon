using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    class ConfigurationMap : EntityTypeConfiguration<Configuration>
    {
        public ConfigurationMap()
        {
            HasKey(x => x.Id);

            Property(x => x.DefaultPage)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.CodAutoClient)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoProvider)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoMaterial)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoProduct)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoEstimate)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoRequest)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoEquipment)
                .HasColumnType("bit")
                .IsRequired();

            HasRequired(x => x.User);

        }
    }
}
