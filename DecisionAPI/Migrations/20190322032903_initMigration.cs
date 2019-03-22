using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DecisionAPI.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes2", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Description", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Bulgakov", "The Master and Margarita (Russian: Мастер и Маргарита) is a novel by Russian writer Mikhail Bulgakov, written in the Soviet Union between 1928 and 1940.", "Master and Margarita", null },
                    { 2, "Tolstoy", "War and Peace is a novel by the Russian author Leo Tolstoy. It is regarded as a central work of world literature and one of Tolstoy's finest literary achievements.", "War and Peace ", null }
                });

            migrationBuilder.InsertData(
                table: "Quotes2",
                columns: new[] { "Id", "Author", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Bulgakov", "The Master and Margarita (Russian: Мастер и Маргарита) is a novel by Russian writer Mikhail Bulgakov, written in the Soviet Union between 1928 and 1940.", "Master and Margarita" },
                    { 2, "Tolstoy", "War and Peace is a novel by the Russian author Leo Tolstoy. It is regarded as a central work of world literature and one of Tolstoy's finest literary achievements.", "War and Peace " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Quotes2");
        }
    }
}
