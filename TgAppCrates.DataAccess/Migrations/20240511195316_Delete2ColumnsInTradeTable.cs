using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgAppCrates.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Delete2ColumnsInTradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardName",
                table: "TradeMarket");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "TradeMarket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardName",
                table: "TradeMarket",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "TradeMarket",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
