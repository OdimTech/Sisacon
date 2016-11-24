using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class PriceResearchMap : EntityTypeConfiguration<PriceResearch>
    {
        public PriceResearchMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Price)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.SearchDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

        }
    }
}
