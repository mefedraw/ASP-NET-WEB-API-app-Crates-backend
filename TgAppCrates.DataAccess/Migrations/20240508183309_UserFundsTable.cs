using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgAppCrates.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserFundsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFunds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TgId = table.Column<string>(type: "text", nullable: false),
                    Funds = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFunds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFunds");
        }
    }
}
