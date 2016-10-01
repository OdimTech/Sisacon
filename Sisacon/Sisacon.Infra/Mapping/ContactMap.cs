using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            HasKey(x => x.Id);

            Property(x => x.LandLine)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(x => x.CellPhone)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.UrlSite)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
