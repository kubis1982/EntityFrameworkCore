using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Persistance.SqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Seven");

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "Seven",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleUnit",
                schema: "Seven",
                columns: table => new
                {
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleUnit", x => new { x.ArticleId, x.Unit });
                    table.ForeignKey(
                        name: "FK_ArticleUnit_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "Seven",
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleUnit",
                schema: "Seven");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "Seven");
        }
    }
}
