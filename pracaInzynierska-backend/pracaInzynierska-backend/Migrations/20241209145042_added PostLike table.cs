using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class addedPostLiketable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLikes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_PostLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 12, 9, 15, 50, 41, 804, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 12, 9, 15, 50, 41, 804, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1994, 12, 9, 15, 50, 41, 804, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostId",
                table: "PostLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_UserId",
                table: "PostLikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 8, 19, 13, 25, 17, 542, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 8, 19, 13, 25, 17, 541, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 8, 19, 13, 25, 17, 541, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1994, 8, 19, 13, 25, 17, 541, DateTimeKind.Local).AddTicks(807));
        }
    }
}
