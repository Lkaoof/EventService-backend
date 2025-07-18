﻿using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlatform.Database.ModelsConfiguration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notifications");

            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(n => n.Subject)
                .HasColumnName("subject")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(n => n.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(n => n.Type)
                .HasColumnName("type")
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
