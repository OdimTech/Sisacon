using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Email.Address)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(Email.EMAIL_MAX_LENGTH)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true }));

            Property(x => x.Password)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            Property(x => x.eUserType)
                .HasColumnName("UserType")
                .IsRequired();

            Property(x => x.LastLogin)
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.RegistrationDate)
                .IsRequired()
                .HasColumnType("DateTime");

            Property(x => x.ExclusionDate)
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.ShowWellcomeMessage)
                .IsRequired()
                .HasColumnType("bit");
        }
    }
}
