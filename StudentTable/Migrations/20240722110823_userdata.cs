using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTable.Migrations
{
    /// <inheritdoc />
    public partial class userdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentsId",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "DepartmentsName",
                table: "Departments",
                newName: "DepartmentName");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "Departments",
                newName: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "DepartmentsName");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "DepartmentsId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId",
                table: "Instructors",
                type: "int",
                nullable: true);
        }
    }
}
