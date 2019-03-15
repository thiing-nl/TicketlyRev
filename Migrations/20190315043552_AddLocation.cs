using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Screend.Migrations
{
    public partial class AddLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Theaters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationMovieId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationMovie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationMovie_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tilburg" },
                    { 2, "Breda" }
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
                table: "LocationMovie",
                columns: new[] { "Id", "LocationId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 3, 1, 2 },
                    { 5, 1, 3 },
                    { 7, 1, 4 },
                    { 9, 1, 5 },
                    { 2, 2, 1 },
                    { 4, 2, 2 },
                    { 6, 2, 3 },
                    { 8, 2, 4 },
                    { 10, 2, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 6,
                column: "LocationId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Theaters_LocationId",
                table: "Theaters",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_LocationId",
                table: "Schedules",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationMovieId",
                table: "Orders",
                column: "LocationMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMovie_LocationId",
                table: "LocationMovie",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMovie_MovieId",
                table: "LocationMovie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_LocationMovie_LocationMovieId",
                table: "Orders",
                column: "LocationMovieId",
                principalTable: "LocationMovie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Location_LocationId",
                table: "Schedules",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theaters_Location_LocationId",
                table: "Theaters",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_LocationMovie_LocationMovieId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Location_LocationId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Theaters_Location_LocationId",
                table: "Theaters");

            migrationBuilder.DropTable(
                name: "LocationMovie");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Theaters_LocationId",
                table: "Theaters");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_LocationId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LocationMovieId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Theaters");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "LocationMovieId",
                table: "Orders");

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
        }
    }
}
