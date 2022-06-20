using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdPost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_IdPost",
                        column: x => x.IdPost,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name", "Publisher" },
                values: new object[,]
                {
                    { 1, "CunterStrike", "Valve" },
                    { 2, "Fortnite", "Epic Games" },
                    { 3, "Leauge of Legends", "Riot Games" },
                    { 4, "Rust", "ktos?" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Description", "Email", "Login", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(715), "Lubie CS GO", "adres@o2.pl", "Czarek12", "bedzieHash" },
                    { 2, new DateTime(1997, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(743), "Lubie CS GO", "tendrugiUser@gmail.com", "kozak5222", "bedzieHash" },
                    { 3, new DateTime(1992, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(746), "Lubie CS GO", "Zielony@o2.pl", "Garo", "bedzieHash" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Context", "IdGame", "IdUser", "Title" },
                values: new object[,]
                {
                    { 1, "jak w temacie", 1, 1, "Ale CunterStrike jest kozak" },
                    { 2, "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi", 1, 1, "CUNTER STRIKE" },
                    { 3, "jak w temacie", 1, 1, "CZY CUNTERSTRIKE JEST LEPSZE OD ESCAPE FROM TARKOV" },
                    { 4, "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi", 1, 1, "REPORT GARO" },
                    { 5, " are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", 1, 1, "CZY KTOS TO CZYTA?" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Context", "Date", "IdPost", "IdUser" },
                values: new object[,]
                {
                    { 1, "Komentarz 1", new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4158), 1, 1 },
                    { 2, "Komentarz 2", new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4168), 1, 1 },
                    { 3, "Komentarz 3", new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4170), 1, 1 },
                    { 4, "Komentarz 4", new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4172), 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdPost",
                table: "Comments",
                column: "IdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUser",
                table: "Comments",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdGame",
                table: "Posts",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdUser",
                table: "Posts",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
