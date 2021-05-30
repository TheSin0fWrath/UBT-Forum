using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "arkitekturVD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arkitekturVD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_arkitekturVD_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "arkitekturVP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arkitekturVP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arkitekturVP_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "arkitekturVT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arkitekturVT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arkitekturVT_UsersInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "arkitekturVDR",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreadID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MyPropertyUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arkitekturVDR", x => x.id);
                    table.ForeignKey(
                        name: "FK_arkitekturVDR_arkitekturVP_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "arkitekturVP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_arkitekturVDR_UsersInfos_MyPropertyUserId",
                        column: x => x.MyPropertyUserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "arkitekturVPR",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreadID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MyPropertyUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arkitekturVPR", x => x.id);
                    table.ForeignKey(
                        name: "FK_arkitekturVPR_arkitekturVP_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "arkitekturVP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_arkitekturVPR_UsersInfos_MyPropertyUserId",
                        column: x => x.MyPropertyUserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "arkitekturVTR",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreadID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MyPropertyUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arkitekturVTR", x => x.id);
                    table.ForeignKey(
                        name: "FK_arkitekturVTR_arkitekturVP_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "arkitekturVP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_arkitekturVTR_UsersInfos_MyPropertyUserId",
                        column: x => x.MyPropertyUserId,
                        principalTable: "UsersInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVD_UserId",
                table: "arkitekturVD",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVDR_MyPropertyUserId",
                table: "arkitekturVDR",
                column: "MyPropertyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVDR_ThreadID",
                table: "arkitekturVDR",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVP_UserId",
                table: "arkitekturVP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVPR_MyPropertyUserId",
                table: "arkitekturVPR",
                column: "MyPropertyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVPR_ThreadID",
                table: "arkitekturVPR",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVT_UserId",
                table: "arkitekturVT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVTR_MyPropertyUserId",
                table: "arkitekturVTR",
                column: "MyPropertyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_arkitekturVTR_ThreadID",
                table: "arkitekturVTR",
                column: "ThreadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arkitekturVD");

            migrationBuilder.DropTable(
                name: "arkitekturVDR");

            migrationBuilder.DropTable(
                name: "arkitekturVPR");

            migrationBuilder.DropTable(
                name: "arkitekturVT");

            migrationBuilder.DropTable(
                name: "arkitekturVTR");

            migrationBuilder.DropTable(
                name: "arkitekturVP");
        }
    }
}
