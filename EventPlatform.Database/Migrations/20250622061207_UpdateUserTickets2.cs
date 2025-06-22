using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlatform.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTickets2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "user_tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "user_tickets",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
