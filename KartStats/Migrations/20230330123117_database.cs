using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartStats.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "UserAdmin");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "UserAdmin");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "UserAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserAdmin");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "UserAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "UserAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
