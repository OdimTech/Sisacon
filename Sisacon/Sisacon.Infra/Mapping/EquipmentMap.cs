using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class EquipmentMap : EntityTypeConfiguration<Equipment>
    {
        public EquipmentMap()
        {
            HasKey(x => x.Id);

            Property(x => x.CodEquipment)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.Desc)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.AcquisitionDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.LifeSpan)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.ExcluisionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            HasRequired(x => x.User);

        }
    }
}
