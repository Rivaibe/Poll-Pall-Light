using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poll_Pall_Light.Migrations.QItem
{
    public partial class added_qitem_value_and_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "QPicture",
                table: "Qitems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Qitems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QPicture",
                table: "Qitems");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Qitems");
        }
    }
}
