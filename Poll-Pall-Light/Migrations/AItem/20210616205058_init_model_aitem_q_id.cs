using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations.AItem
{
    public partial class init_model_aitem_q_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QID",
                table: "AItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QID",
                table: "AItems");
        }
    }
}
