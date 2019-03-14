using Microsoft.EntityFrameworkCore.Migrations;

namespace Screend.Migrations
{
    public partial class MovieTicketSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Age", "Description", "Director", "Genre", "Img", "Language", "Rating", "Runtime", "Title" },
                values: new object[,]
                {
                    { 1, "PG-13", "Earth's future has been riddled by disasters, famines, and droughts. There is only one way to ensure mankind's survival: Interstellar travel. A newly discovered wormhole in the far reaches of our solar system allows a team of astronauts to go where no man has gone before, a planet that may have the right environment to sustain human life.", "Christopher Nolan", "Adventure,Drama,Sci-Fi", "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg", "EN", "", 169, "Interstellar" },
                    { 2, "PG-13", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", "Christopher Nolan", "Action,Adventure,Sci-Fi,Thriller", "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg", "EN", "", 148, "Inception" },
                    { 3, "PG-13", "The story of the legendary rock band Queen and lead singer Freddie Mercury, leading up to their famous performance at Live Aid (1985).", "Bryan Singer", "Biography,Drama,Music", "https://m.media-amazon.com/images/M/MV5BNDg2NjIxMDUyNF5BMl5BanBnXkFtZTgwMzEzNTE1NTM@._V1_SX300.jpg", "EN", "", 134, "Bohemian Rhapsody" },
                    { 4, "R", "Hank Palmer is a successful defense attorney in Chicago, who is getting a divorce. When His brother calls with the news that their mother has died, Hank returns to his childhood home to attend the funeral. Despite the brittle bond between Hank and the Judge, Hank must come to his father's aid and defend him in court. Here, Hank discovers the truth behind the case, which binds together the dysfunctional family and reveals the struggles and secrecy of the family.", "David Dobkin", "Crime,Drama", "https://m.media-amazon.com/images/M/MV5BMTcyNzIxOTIwMV5BMl5BanBnXkFtZTgwMzE0NjQwMjE@._V1_SX300.jpg", "EN", "", 141, "The Judge" },
                    { 5, "PG-13", "Harry, Ron, and Hermione continue their quest of finding and destroying the Dark Lord's three remaining Horcruxes, the magical items responsible for his immortality. But as the mystical Deathly Hallows are uncovered, and Voldemort finds out about their mission, the biggest battle begins and life as they know it will never be the same again.", "David Yates", "Adventure,Drama,Fantasy,Mystery", "https://m.media-amazon.com/images/M/MV5BMjIyZGU4YzUtNDkzYi00ZDRhLTljYzctYTMxMDQ4M2E0Y2YxXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg", "EN", "", 130, "Harry Potter and the Deathly Hallows: Part 2" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieTickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieTickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieTickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieTickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

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
