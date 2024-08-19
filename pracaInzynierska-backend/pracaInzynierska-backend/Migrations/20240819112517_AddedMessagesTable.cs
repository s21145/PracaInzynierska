using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class AddedMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Message_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1994, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1421));
        }
    }
}
