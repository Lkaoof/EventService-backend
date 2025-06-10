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
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refresh_tokens");

            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id)
                .HasColumnName("id");

            builder.Property(rt => rt.Token)
                .HasColumnName("token")
                .IsRequired();

            builder.Property(rt => rt.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(rt => rt.ExpiresAt)
                .HasColumnName("expires_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(rt => rt.RevokedAt)
                .HasColumnName("revoked_at")
                .HasColumnType("timestamp with time zone");
        }
    }
}
