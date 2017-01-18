using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class EquipmentMap : BaseMap<Equipment>
    {
        public EquipmentMap()
        {
            Property(x => x.CodEquipment)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.Desc)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_DESC)
                .IsRequired();

            Property(x => x.AcquisitionDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.LifeSpan)
                .HasColumnType("int")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
