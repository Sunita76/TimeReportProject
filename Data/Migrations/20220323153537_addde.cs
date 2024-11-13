using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportProject.Data.Migrations
{
    public partial class addde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects",
                columns: new[] { "UserID", "ProjectID", "EntryDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects",
                columns: new[] { "UserID", "ProjectID" });
        }
    }
}
