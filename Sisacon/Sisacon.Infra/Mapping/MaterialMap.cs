using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class MaterialMap : BaseMap<Material>
    {
        public MaterialMap()
        {
            Property(x => x.CodMaterial)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(Material.MAX_LENGTH_DESC)
                .IsRequired();

            HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            HasRequired(x => x.User);

            HasMany(x => x.ListPriceResearch)
                .WithOptional();
        }
    }
}
