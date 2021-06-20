using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations
{
    public partial class added_poll_is_private_cap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPrivate",
                table: "Polls",
                newName: "IsPrivate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPrivate",
                table: "Polls",
                newName: "isPrivate");
        }
    }
}
