using Sisacon.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    class OccupationAreaMap : EntityTypeConfiguration<OccupationArea>
    {
        public OccupationAreaMap()
        {
            ToTable("OccupationArea");

            HasKey(x => x.Id);

            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
