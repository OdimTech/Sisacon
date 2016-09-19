using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            ToTable("LOG");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            Property(x => x.Message)
                .HasColumnName("MESSAGE")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(5000);

            Property(x => x.InnerException)
                .HasColumnName("INNER_EXCEPTION")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(5000);

            Property(x => x.ErrorDate)
                .HasColumnName("ERROR_DATE")
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.IdUser)
                .HasColumnName("ID_USER")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.eErrorGravity)
                .HasColumnName("ERROR_GRAVITY")
                .IsRequired();


        }
    }
}
