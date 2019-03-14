using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Screend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TheaterArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Has3D = table.Column<bool>(nullable: false),
                    WheelchairAccessible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AccountType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    TheaterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheaterRows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TheaterId = table.Column<int>(nullable: false),
                    RowName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheaterRows_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Paid = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MollieId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "TheaterChairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChairNumber = table.Column<int>(nullable: false),
                    TheaterRowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterChairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheaterChairs_TheaterRows_TheaterRowId",
                        column: x => x.TheaterRowId,
                        principalTable: "TheaterRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderArticles_TheaterArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "TheaterArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderArticles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderChairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    TheaterChairId = table.Column<int>(nullable: false),
                    MovieTicketId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderChairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderChairs_MovieTickets_MovieTicketId",
                        column: x => x.MovieTicketId,
                        principalTable: "MovieTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderChairs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderChairs_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderChairs_TheaterChairs_TheaterChairId",
                        column: x => x.TheaterChairId,
                        principalTable: "TheaterChairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "Has3D", "Name", "WheelchairAccessible" },
                values: new object[,]
                {
                    { 1, true, "Zaal 1", true },
                    { 2, true, "Zaal 2", true },
                    { 3, false, "Zaal 3", true },
                    { 4, false, "Zaal 4", true },
                    { 5, false, "Zaal 5", false },
                    { 6, false, "Zaal 6", false }
                });

            migrationBuilder.InsertData(
                table: "TheaterRows",
                columns: new[] { "Id", "RowName", "TheaterId" },
                values: new object[,]
                {
                    { 1, "A", 1 },
                    { 22, "F", 3 },
                    { 23, "G", 3 },
                    { 24, "H", 3 },
                    { 25, "A", 4 },
                    { 26, "B", 4 },
                    { 27, "C", 4 },
                    { 28, "D", 4 },
                    { 29, "E", 4 },
                    { 30, "F", 4 },
                    { 31, "A", 5 },
                    { 32, "B", 5 },
                    { 33, "C", 5 },
                    { 34, "D", 5 },
                    { 35, "A", 6 },
                    { 36, "B", 6 },
                    { 21, "E", 3 },
                    { 20, "D", 3 },
                    { 19, "C", 3 },
                    { 18, "B", 3 },
                    { 2, "B", 1 },
                    { 3, "C", 1 },
                    { 4, "D", 1 },
                    { 5, "E", 1 },
                    { 6, "F", 1 },
                    { 7, "G", 1 },
                    { 8, "H", 1 },
                    { 37, "C", 6 },
                    { 9, "A", 2 },
                    { 11, "C", 2 },
                    { 12, "D", 2 },
                    { 13, "E", 2 },
                    { 14, "F", 2 },
                    { 15, "G", 2 },
                    { 16, "H", 2 },
                    { 17, "A", 3 },
                    { 10, "B", 2 },
                    { 38, "D", 6 }
                });

            migrationBuilder.InsertData(
                table: "TheaterChairs",
                columns: new[] { "Id", "ChairNumber", "TheaterRowId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 355, 10, 24 },
                    { 354, 9, 24 },
                    { 353, 8, 24 },
                    { 352, 7, 24 },
                    { 351, 6, 24 },
                    { 350, 5, 24 },
                    { 349, 4, 24 },
                    { 348, 3, 24 },
                    { 347, 2, 24 },
                    { 346, 1, 24 },
                    { 345, 15, 23 },
                    { 344, 14, 23 },
                    { 343, 13, 23 },
                    { 356, 11, 24 },
                    { 342, 12, 23 },
                    { 340, 10, 23 },
                    { 339, 9, 23 },
                    { 338, 8, 23 },
                    { 337, 7, 23 },
                    { 336, 6, 23 },
                    { 335, 5, 23 },
                    { 334, 4, 23 },
                    { 333, 3, 23 },
                    { 332, 2, 23 },
                    { 331, 1, 23 },
                    { 330, 15, 22 },
                    { 329, 14, 22 },
                    { 328, 13, 22 },
                    { 341, 11, 23 },
                    { 357, 12, 24 },
                    { 358, 13, 24 },
                    { 359, 14, 24 },
                    { 388, 8, 27 },
                    { 387, 7, 27 },
                    { 386, 6, 27 },
                    { 385, 5, 27 },
                    { 384, 4, 27 },
                    { 383, 3, 27 },
                    { 382, 2, 27 },
                    { 381, 1, 27 },
                    { 380, 10, 26 },
                    { 379, 9, 26 },
                    { 378, 8, 26 },
                    { 377, 7, 26 },
                    { 376, 6, 26 },
                    { 375, 5, 26 },
                    { 374, 4, 26 },
                    { 373, 3, 26 },
                    { 372, 2, 26 },
                    { 371, 1, 26 },
                    { 370, 10, 25 },
                    { 369, 9, 25 },
                    { 368, 8, 25 },
                    { 367, 7, 25 },
                    { 366, 6, 25 },
                    { 365, 5, 25 },
                    { 364, 4, 25 },
                    { 363, 3, 25 },
                    { 362, 2, 25 },
                    { 361, 1, 25 },
                    { 360, 15, 24 },
                    { 327, 12, 22 },
                    { 389, 9, 27 },
                    { 326, 11, 22 },
                    { 324, 9, 22 },
                    { 290, 5, 20 },
                    { 289, 4, 20 },
                    { 288, 3, 20 },
                    { 287, 2, 20 },
                    { 286, 1, 20 },
                    { 285, 15, 19 },
                    { 284, 14, 19 },
                    { 283, 13, 19 },
                    { 282, 12, 19 },
                    { 281, 11, 19 },
                    { 280, 10, 19 },
                    { 279, 9, 19 },
                    { 278, 8, 19 },
                    { 291, 6, 20 },
                    { 277, 7, 19 },
                    { 275, 5, 19 },
                    { 274, 4, 19 },
                    { 273, 3, 19 },
                    { 272, 2, 19 },
                    { 271, 1, 19 },
                    { 270, 15, 18 },
                    { 269, 14, 18 },
                    { 268, 13, 18 },
                    { 267, 12, 18 },
                    { 266, 11, 18 },
                    { 265, 10, 18 },
                    { 264, 9, 18 },
                    { 263, 8, 18 },
                    { 276, 6, 19 },
                    { 292, 7, 20 },
                    { 293, 8, 20 },
                    { 294, 9, 20 },
                    { 323, 8, 22 },
                    { 322, 7, 22 },
                    { 321, 6, 22 },
                    { 320, 5, 22 },
                    { 319, 4, 22 },
                    { 318, 3, 22 },
                    { 317, 2, 22 },
                    { 316, 1, 22 },
                    { 315, 15, 21 },
                    { 314, 14, 21 },
                    { 313, 13, 21 },
                    { 312, 12, 21 },
                    { 311, 11, 21 },
                    { 310, 10, 21 },
                    { 309, 9, 21 },
                    { 308, 8, 21 },
                    { 307, 7, 21 },
                    { 306, 6, 21 },
                    { 305, 5, 21 },
                    { 304, 4, 21 },
                    { 303, 3, 21 },
                    { 302, 2, 21 },
                    { 301, 1, 21 },
                    { 300, 15, 20 },
                    { 299, 14, 20 },
                    { 298, 13, 20 },
                    { 297, 12, 20 },
                    { 296, 11, 20 },
                    { 295, 10, 20 },
                    { 325, 10, 22 },
                    { 262, 7, 18 },
                    { 390, 10, 27 },
                    { 392, 2, 28 },
                    { 485, 5, 36 },
                    { 484, 4, 36 },
                    { 483, 3, 36 },
                    { 482, 2, 36 },
                    { 481, 1, 36 },
                    { 480, 10, 35 },
                    { 479, 9, 35 },
                    { 478, 8, 35 },
                    { 477, 7, 35 },
                    { 476, 6, 35 },
                    { 475, 5, 35 },
                    { 474, 4, 35 },
                    { 473, 3, 35 },
                    { 486, 6, 36 },
                    { 472, 2, 35 },
                    { 470, 15, 34 },
                    { 469, 14, 34 },
                    { 468, 13, 34 },
                    { 467, 12, 34 },
                    { 466, 11, 34 },
                    { 465, 10, 34 },
                    { 464, 9, 34 },
                    { 463, 8, 34 },
                    { 462, 7, 34 },
                    { 461, 6, 34 },
                    { 460, 5, 34 },
                    { 459, 4, 34 },
                    { 458, 3, 34 },
                    { 471, 1, 35 },
                    { 487, 7, 36 },
                    { 488, 8, 36 },
                    { 489, 9, 36 },
                    { 518, 13, 38 },
                    { 517, 12, 38 },
                    { 516, 11, 38 },
                    { 515, 10, 38 },
                    { 514, 9, 38 },
                    { 513, 8, 38 },
                    { 512, 7, 38 },
                    { 511, 6, 38 },
                    { 510, 5, 38 },
                    { 509, 4, 38 },
                    { 508, 3, 38 },
                    { 507, 2, 38 },
                    { 506, 1, 38 },
                    { 505, 15, 37 },
                    { 504, 14, 37 },
                    { 503, 13, 37 },
                    { 502, 12, 37 },
                    { 501, 11, 37 },
                    { 500, 10, 37 },
                    { 499, 9, 37 },
                    { 498, 8, 37 },
                    { 497, 7, 37 },
                    { 496, 6, 37 },
                    { 495, 5, 37 },
                    { 494, 4, 37 },
                    { 493, 3, 37 },
                    { 492, 2, 37 },
                    { 491, 1, 37 },
                    { 490, 10, 36 },
                    { 457, 2, 34 },
                    { 391, 1, 28 },
                    { 456, 1, 34 },
                    { 454, 14, 33 },
                    { 420, 10, 30 },
                    { 419, 9, 30 },
                    { 418, 8, 30 },
                    { 417, 7, 30 },
                    { 416, 6, 30 },
                    { 415, 5, 30 },
                    { 414, 4, 30 },
                    { 413, 3, 30 },
                    { 412, 2, 30 },
                    { 411, 1, 30 },
                    { 410, 10, 29 },
                    { 409, 9, 29 },
                    { 408, 8, 29 },
                    { 421, 1, 31 },
                    { 407, 7, 29 },
                    { 405, 5, 29 },
                    { 404, 4, 29 },
                    { 403, 3, 29 },
                    { 402, 2, 29 },
                    { 401, 1, 29 },
                    { 400, 10, 28 },
                    { 399, 9, 28 },
                    { 398, 8, 28 },
                    { 397, 7, 28 },
                    { 396, 6, 28 },
                    { 395, 5, 28 },
                    { 394, 4, 28 },
                    { 393, 3, 28 },
                    { 406, 6, 29 },
                    { 422, 2, 31 },
                    { 423, 3, 31 },
                    { 424, 4, 31 },
                    { 453, 13, 33 },
                    { 452, 12, 33 },
                    { 451, 11, 33 },
                    { 450, 10, 33 },
                    { 449, 9, 33 },
                    { 448, 8, 33 },
                    { 447, 7, 33 },
                    { 446, 6, 33 },
                    { 445, 5, 33 },
                    { 444, 4, 33 },
                    { 443, 3, 33 },
                    { 442, 2, 33 },
                    { 441, 1, 33 },
                    { 440, 10, 32 },
                    { 439, 9, 32 },
                    { 438, 8, 32 },
                    { 437, 7, 32 },
                    { 436, 6, 32 },
                    { 435, 5, 32 },
                    { 434, 4, 32 },
                    { 433, 3, 32 },
                    { 432, 2, 32 },
                    { 431, 1, 32 },
                    { 430, 10, 31 },
                    { 429, 9, 31 },
                    { 428, 8, 31 },
                    { 427, 7, 31 },
                    { 426, 6, 31 },
                    { 425, 5, 31 },
                    { 455, 15, 33 },
                    { 261, 6, 18 },
                    { 260, 5, 18 },
                    { 259, 4, 18 },
                    { 94, 4, 7 },
                    { 93, 3, 7 },
                    { 92, 2, 7 },
                    { 91, 1, 7 },
                    { 90, 15, 6 },
                    { 89, 14, 6 },
                    { 88, 13, 6 },
                    { 87, 12, 6 },
                    { 86, 11, 6 },
                    { 85, 10, 6 },
                    { 84, 9, 6 },
                    { 83, 8, 6 },
                    { 82, 7, 6 },
                    { 95, 5, 7 },
                    { 81, 6, 6 },
                    { 79, 4, 6 },
                    { 78, 3, 6 },
                    { 77, 2, 6 },
                    { 76, 1, 6 },
                    { 75, 15, 5 },
                    { 74, 14, 5 },
                    { 73, 13, 5 },
                    { 72, 12, 5 },
                    { 71, 11, 5 },
                    { 70, 10, 5 },
                    { 69, 9, 5 },
                    { 68, 8, 5 },
                    { 67, 7, 5 },
                    { 80, 5, 6 },
                    { 96, 6, 7 },
                    { 97, 7, 7 },
                    { 98, 8, 7 },
                    { 127, 7, 9 },
                    { 126, 6, 9 },
                    { 125, 5, 9 },
                    { 124, 4, 9 },
                    { 123, 3, 9 },
                    { 122, 2, 9 },
                    { 121, 1, 9 },
                    { 120, 15, 8 },
                    { 119, 14, 8 },
                    { 118, 13, 8 },
                    { 117, 12, 8 },
                    { 116, 11, 8 },
                    { 115, 10, 8 },
                    { 114, 9, 8 },
                    { 113, 8, 8 },
                    { 112, 7, 8 },
                    { 111, 6, 8 },
                    { 110, 5, 8 },
                    { 109, 4, 8 },
                    { 108, 3, 8 },
                    { 107, 2, 8 },
                    { 106, 1, 8 },
                    { 105, 15, 7 },
                    { 104, 14, 7 },
                    { 103, 13, 7 },
                    { 102, 12, 7 },
                    { 101, 11, 7 },
                    { 100, 10, 7 },
                    { 99, 9, 7 },
                    { 66, 6, 5 },
                    { 128, 8, 9 },
                    { 65, 5, 5 },
                    { 63, 3, 5 },
                    { 29, 14, 2 },
                    { 28, 13, 2 },
                    { 27, 12, 2 },
                    { 26, 11, 2 },
                    { 25, 10, 2 },
                    { 24, 9, 2 },
                    { 23, 8, 2 },
                    { 22, 7, 2 },
                    { 21, 6, 2 },
                    { 20, 5, 2 },
                    { 19, 4, 2 },
                    { 18, 3, 2 },
                    { 17, 2, 2 },
                    { 30, 15, 2 },
                    { 16, 1, 2 },
                    { 14, 14, 1 },
                    { 13, 13, 1 },
                    { 12, 12, 1 },
                    { 11, 11, 1 },
                    { 10, 10, 1 },
                    { 9, 9, 1 },
                    { 8, 8, 1 },
                    { 7, 7, 1 },
                    { 6, 6, 1 },
                    { 5, 5, 1 },
                    { 4, 4, 1 },
                    { 3, 3, 1 },
                    { 2, 2, 1 },
                    { 15, 15, 1 },
                    { 31, 1, 3 },
                    { 32, 2, 3 },
                    { 33, 3, 3 },
                    { 62, 2, 5 },
                    { 61, 1, 5 },
                    { 60, 15, 4 },
                    { 59, 14, 4 },
                    { 58, 13, 4 },
                    { 57, 12, 4 },
                    { 56, 11, 4 },
                    { 55, 10, 4 },
                    { 54, 9, 4 },
                    { 53, 8, 4 },
                    { 52, 7, 4 },
                    { 51, 6, 4 },
                    { 50, 5, 4 },
                    { 49, 4, 4 },
                    { 48, 3, 4 },
                    { 47, 2, 4 },
                    { 46, 1, 4 },
                    { 45, 15, 3 },
                    { 44, 14, 3 },
                    { 43, 13, 3 },
                    { 42, 12, 3 },
                    { 41, 11, 3 },
                    { 40, 10, 3 },
                    { 39, 9, 3 },
                    { 38, 8, 3 },
                    { 37, 7, 3 },
                    { 36, 6, 3 },
                    { 35, 5, 3 },
                    { 34, 4, 3 },
                    { 64, 4, 5 },
                    { 129, 9, 9 },
                    { 130, 10, 9 },
                    { 131, 11, 9 },
                    { 225, 15, 15 },
                    { 224, 14, 15 },
                    { 223, 13, 15 },
                    { 222, 12, 15 },
                    { 221, 11, 15 },
                    { 220, 10, 15 },
                    { 219, 9, 15 },
                    { 218, 8, 15 },
                    { 217, 7, 15 },
                    { 216, 6, 15 },
                    { 215, 5, 15 },
                    { 214, 4, 15 },
                    { 213, 3, 15 },
                    { 226, 1, 16 },
                    { 212, 2, 15 },
                    { 210, 15, 14 },
                    { 209, 14, 14 },
                    { 208, 13, 14 },
                    { 207, 12, 14 },
                    { 206, 11, 14 },
                    { 205, 10, 14 },
                    { 204, 9, 14 },
                    { 203, 8, 14 },
                    { 202, 7, 14 },
                    { 201, 6, 14 },
                    { 200, 5, 14 },
                    { 199, 4, 14 },
                    { 198, 3, 14 },
                    { 211, 1, 15 },
                    { 227, 2, 16 },
                    { 228, 3, 16 },
                    { 229, 4, 16 },
                    { 258, 3, 18 },
                    { 257, 2, 18 },
                    { 256, 1, 18 },
                    { 255, 15, 17 },
                    { 254, 14, 17 },
                    { 253, 13, 17 },
                    { 252, 12, 17 },
                    { 251, 11, 17 },
                    { 250, 10, 17 },
                    { 249, 9, 17 },
                    { 248, 8, 17 },
                    { 247, 7, 17 },
                    { 246, 6, 17 },
                    { 245, 5, 17 },
                    { 244, 4, 17 },
                    { 243, 3, 17 },
                    { 242, 2, 17 },
                    { 241, 1, 17 },
                    { 240, 15, 16 },
                    { 239, 14, 16 },
                    { 238, 13, 16 },
                    { 237, 12, 16 },
                    { 236, 11, 16 },
                    { 235, 10, 16 },
                    { 234, 9, 16 },
                    { 233, 8, 16 },
                    { 232, 7, 16 },
                    { 231, 6, 16 },
                    { 230, 5, 16 },
                    { 197, 2, 14 },
                    { 196, 1, 14 },
                    { 195, 15, 13 },
                    { 194, 14, 13 },
                    { 160, 10, 11 },
                    { 159, 9, 11 },
                    { 158, 8, 11 },
                    { 157, 7, 11 },
                    { 156, 6, 11 },
                    { 155, 5, 11 },
                    { 154, 4, 11 },
                    { 153, 3, 11 },
                    { 152, 2, 11 },
                    { 151, 1, 11 },
                    { 150, 15, 10 },
                    { 149, 14, 10 },
                    { 148, 13, 10 },
                    { 147, 12, 10 },
                    { 146, 11, 10 },
                    { 145, 10, 10 },
                    { 144, 9, 10 },
                    { 143, 8, 10 },
                    { 142, 7, 10 },
                    { 141, 6, 10 },
                    { 140, 5, 10 },
                    { 139, 4, 10 },
                    { 138, 3, 10 },
                    { 137, 2, 10 },
                    { 136, 1, 10 },
                    { 135, 15, 9 },
                    { 134, 14, 9 },
                    { 133, 13, 9 },
                    { 132, 12, 9 },
                    { 161, 11, 11 },
                    { 519, 14, 38 },
                    { 162, 12, 11 },
                    { 164, 14, 11 },
                    { 193, 13, 13 },
                    { 192, 12, 13 },
                    { 191, 11, 13 },
                    { 190, 10, 13 },
                    { 189, 9, 13 },
                    { 188, 8, 13 },
                    { 187, 7, 13 },
                    { 186, 6, 13 },
                    { 185, 5, 13 },
                    { 184, 4, 13 },
                    { 183, 3, 13 },
                    { 182, 2, 13 },
                    { 181, 1, 13 },
                    { 180, 15, 12 },
                    { 179, 14, 12 },
                    { 178, 13, 12 },
                    { 177, 12, 12 },
                    { 176, 11, 12 },
                    { 175, 10, 12 },
                    { 174, 9, 12 },
                    { 173, 8, 12 },
                    { 172, 7, 12 },
                    { 171, 6, 12 },
                    { 170, 5, 12 },
                    { 169, 4, 12 },
                    { 168, 3, 12 },
                    { 167, 2, 12 },
                    { 166, 1, 12 },
                    { 165, 15, 11 },
                    { 163, 13, 11 },
                    { 520, 15, 38 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticles_ArticleId",
                table: "OrderArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticles_OrderId",
                table: "OrderArticles",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderChairs_MovieTicketId",
                table: "OrderChairs",
                column: "MovieTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderChairs_OrderId",
                table: "OrderChairs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderChairs_ScheduleId",
                table: "OrderChairs",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderChairs_TheaterChairId",
                table: "OrderChairs",
                column: "TheaterChairId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_MovieId",
                table: "Schedules",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TheaterId",
                table: "Schedules",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterChairs_TheaterRowId",
                table: "TheaterChairs",
                column: "TheaterRowId");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterRows_TheaterId",
                table: "TheaterRows",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderArticles");

            migrationBuilder.DropTable(
                name: "OrderChairs");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "TheaterArticles");

            migrationBuilder.DropTable(
                name: "MovieTickets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "TheaterChairs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TheaterRows");

            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}
