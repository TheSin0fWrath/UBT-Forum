using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JuridikVD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridikVD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridikVD_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuridikVP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridikVP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridikVP_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuridikVT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridikVT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridikVT_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuridikVDR",
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
                    table.PrimaryKey("PK_JuridikVDR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridikVDR_JuridikVD_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "JuridikVD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridikVDR_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JuridikVPR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_JuridikVPR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JuridikVPR_JuridikVP_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "JuridikVP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridikVPR_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JuridikVTR",
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
                    table.PrimaryKey("PK_JuridikVTR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridikVTR_JuridikVT_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "JuridikVT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridikVTR_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVD_UserId",
                table: "JuridikVD",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVDR_ThreadId",
                table: "JuridikVDR",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVDR_UserId",
                table: "JuridikVDR",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVP_UserId",
                table: "JuridikVP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVPR_ThreadId",
                table: "JuridikVPR",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVPR_UserId",
                table: "JuridikVPR",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVT_UserId",
                table: "JuridikVT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVTR_ThreadId",
                table: "JuridikVTR",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridikVTR_UserId",
                table: "JuridikVTR",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuridikVDR");

            migrationBuilder.DropTable(
                name: "JuridikVPR");

            migrationBuilder.DropTable(
                name: "JuridikVTR");

            migrationBuilder.DropTable(
                name: "JuridikVD");

            migrationBuilder.DropTable(
                name: "JuridikVP");

            migrationBuilder.DropTable(
                name: "JuridikVT");
        }
    }
}
