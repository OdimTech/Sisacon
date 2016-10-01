using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Message)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(5000);

            Property(x => x.InnerException)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(5000);

            Property(x => x.ErrorDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.IdUser)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.eErrorGravity)
                .IsRequired();


        }
    }
}
