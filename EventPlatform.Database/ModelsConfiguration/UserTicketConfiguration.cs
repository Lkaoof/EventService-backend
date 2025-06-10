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
    public class UserTicketConfiguration : IEntityTypeConfiguration<UserTicket>
    {
        public void Configure(EntityTypeBuilder<UserTicket> builder)
        {
            builder.ToTable("user_tickets");

            builder.HasKey(ut => ut.Id);
            builder.Property(ut => ut.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(ut => ut.Price)
                .HasColumnName("price")
                .HasColumnType("numeric(10,2)");

            builder.Property(ut => ut.TicketStatus)
                .HasColumnName("ticket_status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
