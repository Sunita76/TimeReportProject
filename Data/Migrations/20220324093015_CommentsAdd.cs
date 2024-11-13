using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportProject.Data.Migrations
{
    public partial class CommentsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "ConsultantProjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "ConsultantProjects");
        }
    }
}
