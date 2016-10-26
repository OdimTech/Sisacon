using Sisacon.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            HasKey(x => x.Id);

            Property(x => x.ePersonType)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.Rg)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(x => x.ClientName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Birthday)
                .HasColumnType("DateTime")
                .IsOptional();

            Property(x => x.eSex)
                .HasColumnType("int")
                .IsOptional();

            Property(x => x.FantasyName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.SocialReasonName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.SendAutomaticMsg)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.AddBirthdayToCalendar)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Note)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsOptional();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            HasOptional(x => x.Address);

            HasOptional(x => x.Contact);

            HasRequired(x => x.User);
        }
    }
}
