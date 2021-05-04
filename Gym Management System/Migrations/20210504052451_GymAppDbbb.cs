using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagementSystem.Migrations
{
    public partial class GymAppDbbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Workouts");
        }
    }
}
