using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTable.Migrations
{
    /// <inheritdoc />
    public partial class userDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRole_UserRoles_UserRolesUserRoleID",
                table: "UserUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRole_Users_UsersUserId",
                table: "UserUserRole");

            migrationBuilder.AlterColumn<int>(
                name: "UsersUserId",
                table: "UserUserRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserRolesUserRoleID",
                table: "UserUserRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRole_UserRoles_UserRolesUserRoleID",
                table: "UserUserRole",
                column: "UserRolesUserRoleID",
                principalTable: "UserRoles",
                principalColumn: "UserRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRole_Users_UsersUserId",
                table: "UserUserRole",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRole_UserRoles_UserRolesUserRoleID",
                table: "UserUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRole_Users_UsersUserId",
                table: "UserUserRole");

            migrationBuilder.AlterColumn<int>(
                name: "UsersUserId",
                table: "UserUserRole",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserRolesUserRoleID",
                table: "UserUserRole",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRole_UserRoles_UserRolesUserRoleID",
                table: "UserUserRole",
                column: "UserRolesUserRoleID",
                principalTable: "UserRoles",
                principalColumn: "UserRoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRole_Users_UsersUserId",
                table: "UserUserRole",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
