using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CreatedActicityCategorytableandaddedrelationshiptoit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityCategoryId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityCategoryId",
                table: "Activities",
                column: "ActivityCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityCategory_ActivityCategoryId",
                table: "Activities",
                column: "ActivityCategoryId",
                principalTable: "ActivityCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityCategory_ActivityCategoryId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityCategory");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityCategoryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityCategoryId",
                table: "Activities");
        }
    }
}
