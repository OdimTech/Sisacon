﻿using Sisacon.Domain.Entities;
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
                .HasMaxLength(1000)
                .IsRequired();

            Property(x => x.InnerException)
                .HasColumnType("varchar")
                .HasMaxLength(500)
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
