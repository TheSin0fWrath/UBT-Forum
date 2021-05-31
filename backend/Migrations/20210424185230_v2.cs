using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CSEVD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSEVD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVD_UsersInfos_UserId1",
                        column: x => x.UserId1,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CSEVP",
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
                    table.PrimaryKey("PK_CSEVP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVP_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CSEVT",
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
                    table.PrimaryKey("PK_CSEVT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVT_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CSEVDR",
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
                    table.PrimaryKey("PK_CSEVDR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVDR_CSEVD_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "CSEVD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CSEVDR_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CSEVTR",
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
                    table.PrimaryKey("PK_CSEVTR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSEVTR_CSEVT_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "CSEVT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CSEVTR_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSEVD_UserId1",
                table: "CSEVD",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CSEVDR_ThreadId",
                table: "CSEVDR",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_CSEVDR_UserId",
                table: "CSEVDR",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CSEVT_UserId",
                table: "CSEVT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CSEVTR_ThreadId",
                table: "CSEVTR",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_CSEVTR_UserId",
                table: "CSEVTR",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CSEVDR");

            migrationBuilder.DropTable(
                name: "CSEVPR");

            migrationBuilder.DropTable(
                name: "CSEVTR");

            migrationBuilder.DropTable(
                name: "CSEVD");

            migrationBuilder.DropTable(
                name: "CSEVP");

            migrationBuilder.DropTable(
                name: "CSEVT");
        }
    }
}
