using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Low = table.Column<int>(type: "int", nullable: false),
                    High = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<float>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TaxRates",
                columns: new[] { "Id", "High", "Low", "Rate", "Type" },
                values: new object[,]
                {
                    { 1, 49020, 0, 15f, 0 },
                    { 2, 98040, 49020, 20.5f, 0 },
                    { 3, 151978, 98040, 26f, 0 },
                    { 4, 216511, 151978, 29f, 0 },
                    { 5, 1000000000, 216511, 33f, 0 },
                    { 6, 46295, 0, 15f, 1 },
                    { 7, 92580, 46295, 20f, 1 },
                    { 8, 112655, 92580, 24f, 1 },
                    { 9, 100000000, 112655, 25.75f, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRates");
        }
    }
}
