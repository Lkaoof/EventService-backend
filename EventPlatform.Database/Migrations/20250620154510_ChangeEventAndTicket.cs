using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlatform.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEventAndTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_tickets",
                table: "events");

            migrationBuilder.AddColumn<long>(
                name: "available_count",
                table: "tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "available_count",
                table: "tickets");

            migrationBuilder.AddColumn<long>(
                name: "total_tickets",
                table: "events",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
