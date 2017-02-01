using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class PriceResearchMap : BaseMap<PriceResearch>
    {
        public PriceResearchMap()
        {
            Property(x => x.Price)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.SearchDate)
                .HasColumnType("DateTime")
                .IsRequired();

            HasRequired(x => x.Material)
                .WithMany(x => x.ListPriceResearch)
                .HasForeignKey(x => x.MaterialId);
        }
    }
}
