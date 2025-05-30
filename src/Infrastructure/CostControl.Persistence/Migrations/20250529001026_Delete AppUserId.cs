using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostControl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAppUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MonetaryFunds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "MonetaryFunds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
