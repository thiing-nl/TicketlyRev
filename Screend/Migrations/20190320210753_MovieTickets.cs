using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Screend.Migrations
{
    public partial class MovieTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderChairs_MovieTickets_MovieTicketId",
                table: "OrderChairs");

            migrationBuilder.DropTable(
                name: "MovieTickets");

            migrationBuilder.RenameColumn(
                name: "MovieTicketId",
                table: "OrderChairs",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderChairs_MovieTicketId",
                table: "OrderChairs",
                newName: "IX_OrderChairs_TicketId");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTicket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ScheduleId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleTicket_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleTicket_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
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

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 8.5, "Normaal < 120min" },
                    { 2, 9.0, "Normaal > 120min" },
                    { 3, 11.0, "3D Film < 120min" },
                    { 4, 11.5, "3D Film > 120min" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTicket_ScheduleId",
                table: "ScheduleTicket",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTicket_TicketId",
                table: "ScheduleTicket",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderChairs_Tickets_TicketId",
                table: "OrderChairs",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderChairs_Tickets_TicketId",
                table: "OrderChairs");

            migrationBuilder.DropTable(
                name: "ScheduleTicket");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "OrderChairs",
                newName: "MovieTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderChairs_TicketId",
                table: "OrderChairs",
                newName: "IX_OrderChairs_MovieTicketId");

            migrationBuilder.CreateTable(
                name: "MovieTickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MovieTickets",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Normaal < 120min", 8.5 },
                    { 2, "Normaal > 120min", 9.0 },
                    { 3, "3D Film < 120min", 11.0 },
                    { 4, "3D Film > 120min", 11.5 }
                });

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
