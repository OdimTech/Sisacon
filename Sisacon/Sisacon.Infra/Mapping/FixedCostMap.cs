using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class FixedCostMap : BaseMap<FixedCost>
    {
        public FixedCostMap()
        {
            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(FixedCost.MAX_LENGTH_DESCRIPTION)
                .IsRequired();

            Property(x => x.Value)
                .IsRequired();

            HasRequired(x => x.Cost)
                .WithMany(x => x.ListFixedCost)
                .HasForeignKey(x => x.CostId);

            HasRequired(x => x.CostCategory)
                .WithMany()
                .HasForeignKey(x => x.CostCategoryId);
        }
    }
}
