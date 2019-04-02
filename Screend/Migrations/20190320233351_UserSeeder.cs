using Microsoft.EntityFrameworkCore.Migrations;

namespace Screend.Migrations
{
    public partial class UserSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Users",
                columns: new[] { "Id", "AccountType", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, 0, "order", "order", "order", "order" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

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
