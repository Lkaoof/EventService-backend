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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags");

            builder.HasKey(et => et.Id);
            builder.Property(et => et.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(et => et.Title)
                .HasColumnName("title")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
