using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class CostConfigurationMap : EntityTypeConfiguration<CostConfiguration>
    {
        public CostConfigurationMap()
        {
            HasKey(x => x.Id);

            Property(x => x.MaxCost)
                .HasColumnType("decimal")
                .IsRequired();

            HasRequired(x => x.User);
        }
    }
}
