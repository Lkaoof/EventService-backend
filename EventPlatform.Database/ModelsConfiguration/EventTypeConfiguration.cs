using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Database.ModelsConfiguration
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("types");

            builder.HasKey(et => et.Id);
            builder.Property(et => et.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(et => et.Title)
                .HasColumnName("title")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(et => et.IsAvailable)
                .HasColumnName("is_available")
                .HasDefaultValue(true);
        }
    }
}
