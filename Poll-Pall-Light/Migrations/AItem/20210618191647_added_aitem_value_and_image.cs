using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations.AItem
{
    public partial class added_aitem_value_and_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isChecked",
                table: "AItems",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<byte[]>(
                name: "APicture",
                table: "AItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "AItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APicture",
                table: "AItems");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AItems");

            migrationBuilder.AlterColumn<bool>(
                name: "isChecked",
                table: "AItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
