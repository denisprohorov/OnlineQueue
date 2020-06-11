using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace test.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQueue",
                table: "UserQueue");

            migrationBuilder.DropIndex(
                name: "IX_UserQueue_UserId",
                table: "UserQueue");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserQueue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQueue",
                table: "UserQueue",
                columns: new[] { "UserId", "QueueDbModelId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQueue",
                table: "UserQueue");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserQueue",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQueue",
                table: "UserQueue",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserQueue_UserId",
                table: "UserQueue",
                column: "UserId");
        }
    }
}
