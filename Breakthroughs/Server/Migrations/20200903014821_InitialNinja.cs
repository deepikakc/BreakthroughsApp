using Microsoft.EntityFrameworkCore.Migrations;

namespace Breakthroughs.Server.Migrations
{
    public partial class InitialNinja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Skills = table.Column<string>(maxLength: 2000, nullable: true),
                    SkillsBT = table.Column<string>(maxLength: 2000, nullable: true),
                    Attribute = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}
