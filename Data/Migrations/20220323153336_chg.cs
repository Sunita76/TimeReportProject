using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportProject.Data.Migrations
{
    public partial class chg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantProjects_AspNetUsers_UserId",
                table: "ConsultantProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects");

            migrationBuilder.DropTable(
                name: "ProjectTimeReportProjectUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects");

            migrationBuilder.DropIndex(
                name: "IX_ConsultantProjects_UserId",
                table: "ConsultantProjects");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ConsultantProjects");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ConsultantProjects",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ConsultantProjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects",
                columns: new[] { "UserID", "ProjectID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantProjects_AspNetUsers_UserID",
                table: "ConsultantProjects",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantProjects_AspNetUsers_UserID",
                table: "ConsultantProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantProjects",
                table: "ConsultantProjects");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ConsultantProjects",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "ConsultantProjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ConsultantProjects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "ConsultantProjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_ConsultantProjects_UserId",
                table: "ConsultantProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTimeReportProjectUser_UsersId",
                table: "ProjectTimeReportProjectUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantProjects_AspNetUsers_UserId",
                table: "ConsultantProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantProjects_Projects_ProjectID",
                table: "ConsultantProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");
        }
    }
}
