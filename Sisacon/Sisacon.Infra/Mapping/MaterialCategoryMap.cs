using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class MaterialCategoryMap : EntityTypeConfiguration<MaterialCategory>
    {
        public MaterialCategoryMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Description)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            HasRequired(x => x.User);
        }
    }
}
