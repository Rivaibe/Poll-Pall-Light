using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations
{
    public partial class added_poll_check_variables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "QBool",
                table: "PollVariables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QImage",
                table: "PollVariables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QNumber",
                table: "PollVariables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QText",
                table: "PollVariables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QBool",
                table: "PollVariables");

            migrationBuilder.DropColumn(
                name: "QImage",
                table: "PollVariables");

            migrationBuilder.DropColumn(
                name: "QNumber",
                table: "PollVariables");

            migrationBuilder.DropColumn(
                name: "QText",
                table: "PollVariables");
        }
    }
}
