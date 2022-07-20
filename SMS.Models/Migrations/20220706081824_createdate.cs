using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Models.Migrations
{
    public partial class createdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Courses",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Courses",
                newName: "CreatedDate");
        }
    }
}
