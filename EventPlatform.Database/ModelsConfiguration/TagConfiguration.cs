using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
