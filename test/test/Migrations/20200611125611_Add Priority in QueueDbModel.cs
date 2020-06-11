using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class AddPriorityinQueueDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Queues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Queues");
        }
    }
}
