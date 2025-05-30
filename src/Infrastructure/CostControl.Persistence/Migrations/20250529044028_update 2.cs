using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostControl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId1",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId",
                table: "Expenses");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId",
                table: "Deposits",
                column: "MonetaryFundId",
                principalTable: "MonetaryFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId",
                table: "Expenses",
                column: "MonetaryFundId",
                principalTable: "MonetaryFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId",
                table: "Expenses");

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
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId",
                table: "Deposits",
                column: "MonetaryFundId",
                principalTable: "MonetaryFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_MonetaryFunds_MonetaryFundId1",
                table: "Deposits",
                column: "MonetaryFundId1",
                principalTable: "MonetaryFunds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId",
                table: "Expenses",
                column: "MonetaryFundId",
                principalTable: "MonetaryFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_MonetaryFunds_MonetaryFundId1",
                table: "Expenses",
                column: "MonetaryFundId1",
                principalTable: "MonetaryFunds",
                principalColumn: "Id");
        }
    }
}
