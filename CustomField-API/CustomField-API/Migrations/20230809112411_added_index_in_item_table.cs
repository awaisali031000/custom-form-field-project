using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomField_API.Migrations
{
    public partial class added_index_in_item_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "CustomFormFieldItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "CustomFormFieldItems");
        }
    }
}
