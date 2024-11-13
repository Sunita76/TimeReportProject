using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportProject.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConsultantName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantProjects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLunchTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLunchTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantProjects", x => new { x.ID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_ConsultantProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantProjects_ProjectID",
                table: "ConsultantProjects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantProjects_UserId",
                table: "ConsultantProjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantProjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropColumn(
                name: "ConsultantName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
