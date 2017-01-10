using Sisacon.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class LogMap : BaseMap<Log>
    {
        public LogMap()
        {
            Property(x => x.Message)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.InnerException)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.StackTrace)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.eErrorGravity)
                .HasColumnType("int")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
