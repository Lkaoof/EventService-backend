using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlatform.Database.ModelsConfiguration
{
    public class EventMoodConfiguration : IEntityTypeConfiguration<EventMood>
    {
        public void Configure(EntityTypeBuilder<EventMood> builder)
        {
            builder.ToTable("event_moods");

            builder.HasKey(em => em.Id);
            builder.Property(em => em.Id)
                .HasColumnName("id");

            builder.Property(em => em.Title)
                .HasColumnName("title")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
