using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncmentsReplays");

            migrationBuilder.DropTable(
                name: "Announcments");

            migrationBuilder.CreateTable(
                name: "CSEVP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ttile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSEVP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVP_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CSEVPR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSEVPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVPR_CSEVP_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "CSEVP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CSEVPR_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSEVP_UserId",
                table: "CSEVP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CSEVPR_ThreadId",
                table: "CSEVPR",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_CSEVPR_UserId",
                table: "CSEVPR",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CSEVPR");

            migrationBuilder.DropTable(
                name: "CSEVP");

            migrationBuilder.CreateTable(
                name: "Announcments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    AnnouncmentsId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: false),
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
    }
}
