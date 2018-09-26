using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RawQuery.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Category", "IsPrivate", "Title" },
                values: new object[] { 1, "C#", false, "C# 8 ロードマップ" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Category", "IsPrivate", "Title" },
                values: new object[] { 2, "JavaScript", false, "Array.some と Array.includes の使い分け" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Category", "IsPrivate", "Title" },
                values: new object[] { 3, "C#", true, "秘密のポートフォリオ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
