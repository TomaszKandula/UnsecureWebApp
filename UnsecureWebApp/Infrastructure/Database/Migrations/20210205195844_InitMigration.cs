using Microsoft.EntityFrameworkCore.Migrations;

namespace UnsecureWebApp.Infrastructure.Database.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(maxLength: 255, nullable: false),
                    HashedPassword = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SerialNo = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Laptops__UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "HashedPassword" },
                values: new object[] { 1, "jonny@example.com", "password1234" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "HashedPassword" },
                values: new object[] { 2, "bravo@example.com", "admin2020" });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "SerialNo", "UserId" },
                values: new object[] { 1, "Lenovo", "C02L456987", 1 });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "SerialNo", "UserId" },
                values: new object[] { 2, "Dell", "123AB458GH", 2 });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "SerialNo", "UserId" },
                values: new object[] { 3, "HP", "PO54654PUXR", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_UserId",
                table: "Laptops",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
