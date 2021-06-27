using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrejtimiId",
                table: "Drejtime",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "QytetetQytetiId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Qytetet",
                columns: table => new
                {
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QytetiName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qytetet", x => x.QytetiId);
                });

            migrationBuilder.InsertData(
                table: "Drejtime",
                columns: new[] { "Id", "Drejtimi" },
                values: new object[] { 1, "CSE" });

            migrationBuilder.InsertData(
                table: "Nivelis",
                columns: new[] { "Niveli_Id", "Name" },
                values: new object[] { 1, "Barchelor" });

            migrationBuilder.InsertData(
                table: "Qytetet",
                columns: new[] { "QytetiId", "QytetiName" },
                values: new object[] { 1, "Ferizaj" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Color", "Date", "Default", "Name" },
                values: new object[,]
                {
                    { 1, "#ff0000", null, false, "Admin" },
                    { 2, "#36dd08", null, true, "Student" },
                    { 3, "#2283d8", null, false, "Profesor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_QytetetQytetiId",
                table: "Users",
                column: "QytetetQytetiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Qytetet_QytetetQytetiId",
                table: "Users",
                column: "QytetetQytetiId",
                principalTable: "Qytetet",
                principalColumn: "QytetiId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Qytetet_QytetetQytetiId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Qytetet");

            migrationBuilder.DropIndex(
                name: "IX_Users_QytetetQytetiId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Drejtime",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nivelis",
                keyColumn: "Niveli_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "QytetetQytetiId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Drejtime",
                newName: "DrejtimiId");
        }
    }
}
