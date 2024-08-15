using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTable.Migrations
{
    /// <inheritdoc />
    public partial class dbsetupp : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUserRole",
                table: "UserUserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserUserRole_UserRolesUserRoleID",
                table: "UserUserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserUserRole_UsersUserId",
                table: "UserUserRole");

            migrationBuilder.DropColumn(
                name: "UserRolesUserRoleID",
                table: "UserUserRole");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "UserUserRole");

            migrationBuilder.RenameTable(
                name: "UserUserRole",
                newName: "UserUserRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUserRoles",
                table: "UserUserRoles",
                column: "UserUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRoles_UserId",
                table: "UserUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRoles_UserRoleId",
                table: "UserUserRoles",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRoles_UserRoles_UserRoleId",
                table: "UserUserRoles",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRoles_Users_UserId",
                table: "UserUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRoles_UserRoles_UserRoleId",
                table: "UserUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRoles_Users_UserId",
                table: "UserUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUserRoles",
                table: "UserUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserUserRoles_UserId",
                table: "UserUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserUserRoles_UserRoleId",
                table: "UserUserRoles");

            migrationBuilder.RenameTable(
                name: "UserUserRoles",
                newName: "UserUserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ModifiedDate",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedDate",
                table: "Users",
                type: "date",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "UserRolesUserRoleID",
                table: "UserUserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "UserUserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUserRole",
                table: "UserUserRole",
                column: "UserUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_UserRolesUserRoleID",
                table: "UserUserRole",
                column: "UserRolesUserRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_UsersUserId",
                table: "UserUserRole",
                column: "UsersUserId");

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
    }
}
