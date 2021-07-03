using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class seadi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "fromUserId",
                table: "Warnings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DrejtimiId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_fromUserId",
                table: "Warnings",
                column: "fromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users",
                column: "DrejtimiId",
                principalTable: "Drejtime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Users_fromUserId",
                table: "Warnings",
                column: "fromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Users_fromUserId",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Warnings_fromUserId",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "fromUserId",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Emails");

            migrationBuilder.AlterColumn<int>(
                name: "DrejtimiId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users",
                column: "DrejtimiId",
                principalTable: "Drejtime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
