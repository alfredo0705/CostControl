using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostControl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "MonetaryFunds");

            migrationBuilder.AddColumn<int>(
                name: "MonetaryFundId1",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonetaryFundId1",
                table: "Deposits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_MonetaryFundId1",
                table: "Expenses",
                column: "MonetaryFundId1");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_MonetaryFundId1",
                table: "Deposits",
                column: "MonetaryFundId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId1",
                table: "Deposits",
                column: "MonetaryFundId1",
                principalTable: "MonetaryFunds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId1",
                table: "Expenses",
                column: "MonetaryFundId1",
                principalTable: "MonetaryFunds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId1",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId1",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_MonetaryFundId1",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_MonetaryFundId1",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "MonetaryFundId1",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "MonetaryFundId1",
                table: "Deposits");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "MonetaryFunds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
