using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class MaterialMap : EntityTypeConfiguration<Material>
    {
        public MaterialMap()
        {
            HasKey(x => x.Id);

            Property(x => x.CodMaterial)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(x => x.Desc)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            Property(x => x.CategoryId)
                .HasColumnType("int")
                .IsOptional();

            HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            HasOptional(x => x.User);

            HasMany(x => x.ListPriceResearch)
                .WithOptional();
        }
    }
}
