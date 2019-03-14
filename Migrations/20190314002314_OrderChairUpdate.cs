using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Screend.Migrations
{
    public partial class OrderChairUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderChairs_MovieTickets_MovieTicketId",
                table: "OrderChairs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderChairs_TheaterChairs_TheaterChairId",
                table: "OrderChairs");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChairId",
                table: "OrderChairs");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "OrderChairs");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterChairId",
                table: "OrderChairs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieTicketId",
                table: "OrderChairs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 1,
                column: "RowName",
                value: "A");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 2,
                column: "RowName",
                value: "B");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 3,
                column: "RowName",
                value: "C");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 4,
                column: "RowName",
                value: "D");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 5,
                column: "RowName",
                value: "E");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 6,
                column: "RowName",
                value: "F");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 7,
                column: "RowName",
                value: "G");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 8,
                column: "RowName",
                value: "H");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 9,
                column: "RowName",
                value: "A");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 10,
                column: "RowName",
                value: "B");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 11,
                column: "RowName",
                value: "C");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 12,
                column: "RowName",
                value: "D");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 13,
                column: "RowName",
                value: "E");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 14,
                column: "RowName",
                value: "F");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 15,
                column: "RowName",
                value: "G");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 16,
                column: "RowName",
                value: "H");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 17,
                column: "RowName",
                value: "A");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 18,
                column: "RowName",
                value: "B");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 19,
                column: "RowName",
                value: "C");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 20,
                column: "RowName",
                value: "D");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 21,
                column: "RowName",
                value: "E");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 22,
                column: "RowName",
                value: "F");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 23,
                column: "RowName",
                value: "G");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 24,
                column: "RowName",
                value: "H");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 25,
                column: "RowName",
                value: "A");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 26,
                column: "RowName",
                value: "B");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 27,
                column: "RowName",
                value: "C");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 28,
                column: "RowName",
                value: "D");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 29,
                column: "RowName",
                value: "E");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 30,
                column: "RowName",
                value: "F");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 31,
                column: "RowName",
                value: "A");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 32,
                column: "RowName",
                value: "B");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 33,
                column: "RowName",
                value: "C");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 34,
                column: "RowName",
                value: "D");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 35,
                column: "RowName",
                value: "A");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 36,
                column: "RowName",
                value: "B");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 37,
                column: "RowName",
                value: "C");

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 38,
                column: "RowName",
                value: "D");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderChairs_MovieTickets_MovieTicketId",
                table: "OrderChairs",
                column: "MovieTicketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderChairs_TheaterChairs_TheaterChairId",
                table: "OrderChairs",
                column: "TheaterChairId",
                principalTable: "TheaterChairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderChairs_MovieTickets_MovieTicketId",
                table: "OrderChairs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderChairs_TheaterChairs_TheaterChairId",
                table: "OrderChairs");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TheaterChairId",
                table: "OrderChairs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MovieTicketId",
                table: "OrderChairs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ChairId",
                table: "OrderChairs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "OrderChairs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 1,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 2,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 3,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 4,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 5,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 6,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 7,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 8,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 9,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 10,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 11,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 12,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 13,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 14,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 15,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 16,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 17,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 18,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 19,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 20,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 21,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 22,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 23,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 24,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 25,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 26,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 27,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 28,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 29,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 30,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 31,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 32,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 33,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 34,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 35,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 36,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 37,
                column: "RowName",
                value: null);

            migrationBuilder.UpdateData(
                table: "TheaterRows",
                keyColumn: "Id",
                keyValue: 38,
                column: "RowName",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderChairs_MovieTickets_MovieTicketId",
                table: "OrderChairs",
                column: "MovieTicketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderChairs_TheaterChairs_TheaterChairId",
                table: "OrderChairs",
                column: "TheaterChairId",
                principalTable: "TheaterChairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
