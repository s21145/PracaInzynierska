using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class statsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameRakings_Games_GameId",
                table: "UserGameRakings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameRakings_Users_UserId",
                table: "UserGameRakings");

            migrationBuilder.DropIndex(
                name: "IX_UserGameRakings_GameId",
                table: "UserGameRakings");

            migrationBuilder.DropIndex(
                name: "IX_UserGameRakings_UserId",
                table: "UserGameRakings");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserGameRakings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserGameRakings");

            migrationBuilder.CreateTable(
                name: "StatsNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "Name",
                value: "CounterStrike");

            migrationBuilder.InsertData(
                table: "StatsNames",
                columns: new[] { "Id", "IdGame", "Name" },
                values: new object[,]
                {
                    { 1, 1, "total_kills" },
                    { 2, 1, "total_deaths" },
                    { 3, 1, "total_kills_headshot" },
                    { 4, 1, "total_wins" },
                    { 5, 1, "total_matches_played" },
                    { 6, 1, "total_shots_hit" },
                    { 7, 1, "total_shots_fired" },
                    { 8, 1, "total_time_played" },
                    { 9, 1, "total_mvps" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 12, 9, 9, 48, 41, 767, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.CreateIndex(
                name: "IX_UserGameRakings_IdGame",
                table: "UserGameRakings",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameRakings_IdUser",
                table: "UserGameRakings",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_StatsNames_IdGame",
                table: "StatsNames",
                column: "IdGame");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameRakings_Games_IdGame",
                table: "UserGameRakings",
                column: "IdGame",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameRakings_Users_IdUser",
                table: "UserGameRakings",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameRakings_Games_IdGame",
                table: "UserGameRakings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameRakings_Users_IdUser",
                table: "UserGameRakings");

            migrationBuilder.DropTable(
                name: "StatsNames");

            migrationBuilder.DropIndex(
                name: "IX_UserGameRakings_IdGame",
                table: "UserGameRakings");

            migrationBuilder.DropIndex(
                name: "IX_UserGameRakings_IdUser",
                table: "UserGameRakings");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "UserGameRakings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserGameRakings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "Name",
                value: "CunterStrike");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 12, 9, 8, 55, 26, 75, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.CreateIndex(
                name: "IX_UserGameRakings_GameId",
                table: "UserGameRakings",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameRakings_UserId",
                table: "UserGameRakings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameRakings_Games_GameId",
                table: "UserGameRakings",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameRakings_Users_UserId",
                table: "UserGameRakings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
