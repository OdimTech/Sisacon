using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Message)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.eNotificationClass)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Link)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Ignore(x => x.NotificationClassCSS);

            Ignore(x => x.TimeSinceCreation);

            Property(x => x.Visualized)
                .HasColumnType("bit")
                .IsRequired();

            HasRequired(x => x.User);
        }
    }
}
