using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportProject.Data.Migrations
{
    public partial class cha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartLunchTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndLunchTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "ConsultantProjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ProjectTimeReportProjectUser",
                columns: table => new
                {
                    ProjectsProjectID = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTimeReportProjectUser", x => new { x.ProjectsProjectID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectTimeReportProjectUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTimeReportProjectUser_Projects_ProjectsProjectID",
                        column: x => x.ProjectsProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTimeReportProjectUser_UsersId",
                table: "ProjectTimeReportProjectUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects");

            migrationBuilder.DropTable(
                name: "ProjectTimeReportProjectUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartLunchTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "ConsultantProjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ConsultantProjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndLunchTime",
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
                columns: new[] { "ID", "ProjectID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
