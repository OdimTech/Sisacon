using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class CostMap : EntityTypeConfiguration<Cost>
    {
        public CostMap()
        {
            HasKey(x => x.Id);

            Property(x => x.ReferenceMonth)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.WorkedHours)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Remuneration)
                .HasColumnType("Decimal")
                .IsRequired();

            Property(x => x.IsReferenceCost)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.TotalCost)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.TotalCostPerHour)
                .HasColumnType("decimal")
                .IsRequired();

            HasRequired(x => x.User);

        }
    }
}
