using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations
{
    public partial class added_poll_is_private : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPrivate",
                table: "Polls",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPrivate",
                table: "Polls");
        }
    }
}
