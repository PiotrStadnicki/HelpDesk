using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskApi.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Slas_SlaId",
                table: "Problems");

            migrationBuilder.DropTable(
                name: "Slas");

            migrationBuilder.DropIndex(
                name: "IX_Problems_SlaId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "SlaId",
                table: "Problems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlaId",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Slas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLaTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_SlaId",
                table: "Problems",
                column: "SlaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Slas_SlaId",
                table: "Problems",
                column: "SlaId",
                principalTable: "Slas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
