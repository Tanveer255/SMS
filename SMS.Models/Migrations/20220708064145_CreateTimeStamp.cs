using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Models.Migrations
{
    public partial class CreateTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Courses",
                newName: "UpdateTimeStamp");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Courses",
                newName: "CreateTimeStamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateTimeStamp",
                table: "Courses",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreateTimeStamp",
                table: "Courses",
                newName: "CreateDate");
        }
    }
}
