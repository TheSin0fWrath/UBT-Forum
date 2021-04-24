using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class initilv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserInfoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcments_UsersInfos_UserInfoUserId",
                        column: x => x.UserInfoUserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncmentsReplays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    AnnouncmentsId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncmentsReplays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncmentsReplays_Announcments_AnnouncmentsId",
                        column: x => x.AnnouncmentsId,
                        principalTable: "Announcments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnouncmentsReplays_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcments_UserId",
                table: "Announcments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcments_UserInfoUserId",
                table: "Announcments",
                column: "UserInfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncmentsReplays_AnnouncmentsId",
                table: "AnnouncmentsReplays",
                column: "AnnouncmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncmentsReplays_UserId",
                table: "AnnouncmentsReplays",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncmentsReplays");

            migrationBuilder.DropTable(
                name: "Announcments");
        }
    }
}
