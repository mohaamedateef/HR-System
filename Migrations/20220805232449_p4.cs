using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Migrations
{
    public partial class p4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_CurrentUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_otherUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Employees_EmployeeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CurrentUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_EmployeeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_otherUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "otherUserId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentUserId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "otherUserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentUserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CurrentUserId",
                table: "Messages",
                column: "CurrentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EmployeeId",
                table: "Messages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_otherUserId",
                table: "Messages",
                column: "otherUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_CurrentUserId",
                table: "Messages",
                column: "CurrentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_otherUserId",
                table: "Messages",
                column: "otherUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Employees_EmployeeId",
                table: "Messages",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
