using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedActivityCitytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityCityId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityCity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityCityId",
                table: "Activities",
                column: "ActivityCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityCity_ActivityCityId",
                table: "Activities",
                column: "ActivityCityId",
                principalTable: "ActivityCity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityCity_ActivityCityId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityCity");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityCityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityCityId",
                table: "Activities");
        }
    }
}
