using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class VariableCostMap : EntityTypeConfiguration<VariableCost>
    {
        public VariableCostMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Desc)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Value)
                .HasColumnType("decimal")
                .IsRequired();

            HasRequired(x => x.Cost)
                .WithMany(x => x.VariableCosts);
        }
    }
}
