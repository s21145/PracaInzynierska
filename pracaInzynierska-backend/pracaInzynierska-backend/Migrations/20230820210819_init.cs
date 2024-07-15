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
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SteamId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentRefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SteamId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "StatsNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatsNames_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendLists_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_FriendLists_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "UserGameRakings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameRakings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGameRakings_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameRakings_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGameStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGameStats_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameStats_Users_IdUser",
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
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "GameId", "ImagePath", "Name", "Publisher", "SteamId" },
                values: new object[,]
                {
                    { 1, "../../images/games/csgo.jpg", "CounterStrike", "Valve", null },
                    { 2, "../../images/games/valorant.jpg", "Fortnite", "Epic Games", null },
                    { 3, "../../images/games/lol.png", "Leauge of Legends", "Riot Games", null },
                    { 4, "../../images/games/rust.jpg", "Rust", "ktos?", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "CurrentRefreshToken", "Description", "Email", "IconPath", "Login", "Password", "RefreshTokenExp", "SteamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(5490), null, "Lubie CS GO", "adres@o2.pl", "../../images/users/default.png", "Czarek12", "bedzieHash", null, null },
                    { 2, new DateTime(1998, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(5505), null, "Lubie CS GO", "tendrugiUser@gmail.com", "../../images/users/default.png", "kozak5222", "bedzieHash", null, null },
                    { 3, new DateTime(1993, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(5508), null, "Lubie CS GO", "Zielony@o2.pl", "../../images/users/default.png", "Garo", "bedzieHash", null, null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "IdGame", "IdUser", "Title" },
                values: new object[,]
                {
                    { 1, "jak w temacie", 1, 1, "Ale CunterStrike jest kozak" },
                    { 2, "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi", 1, 1, "CUNTER STRIKE" },
                    { 3, "jak w temacie", 1, 1, "CZY CUNTERSTRIKE JEST LEPSZE OD ESCAPE FROM TARKOV" },
                    { 4, "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi", 1, 1, "REPORT GARO" },
                    { 5, " are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", 1, 1, "CZY KTOS TO CZYTA?" }
                });

            migrationBuilder.InsertData(
                table: "StatsNames",
                columns: new[] { "Id", "IdGame", "Name", "PublicName" },
                values: new object[,]
                {
                    { 1, 1, "total_kills", "Kills" },
                    { 2, 1, "total_deaths", "Deaths" },
                    { 3, 1, "total_kills_headshot", "Headshots" },
                    { 4, 1, "total_wins", "Wins" },
                    { 5, 1, "total_matches_played", "Matches" },
                    { 6, 1, "total_shots_hit", "Hit Shots" },
                    { 7, 1, "total_shots_fired", "Fired Shots" },
                    { 8, 1, "total_time_played", "Play Time" },
                    { 9, 1, "total_mvps", "MVP" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "Date", "IdPost", "IdUser" },
                values: new object[,]
                {
                    { 1, "Komentarz 1", new DateTime(2023, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(7631), 1, 1 },
                    { 2, "Komentarz 2", new DateTime(2023, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(7642), 1, 1 },
                    { 3, "Komentarz 3", new DateTime(2023, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(7644), 1, 1 },
                    { 4, "Komentarz 4", new DateTime(2023, 8, 20, 23, 8, 19, 421, DateTimeKind.Local).AddTicks(7645), 1, 1 }
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
                name: "IX_FriendLists_FriendId",
                table: "FriendLists",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_OwnerId",
                table: "FriendLists",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdGame",
                table: "Posts",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdUser",
                table: "Posts",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_StatsNames_IdGame",
                table: "StatsNames",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameRakings_IdGame",
                table: "UserGameRakings",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameRakings_IdUser",
                table: "UserGameRakings",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameStats_IdGame",
                table: "UserGameStats",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameStats_IdUser",
                table: "UserGameStats",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FriendLists");

            migrationBuilder.DropTable(
                name: "StatsNames");

            migrationBuilder.DropTable(
                name: "UserGameRakings");

            migrationBuilder.DropTable(
                name: "UserGameStats");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
