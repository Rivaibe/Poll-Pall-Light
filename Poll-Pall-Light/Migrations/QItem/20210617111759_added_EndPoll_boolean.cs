using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations.QItem
{
    public partial class added_EndPoll_boolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EndPoll",
                table: "Qitems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPoll",
                table: "Qitems");
        }
    }
}
