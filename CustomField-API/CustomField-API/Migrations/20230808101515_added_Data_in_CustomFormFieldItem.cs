using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomField_API.Migrations
{
    public partial class added_Data_in_CustomFormFieldItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "CustomFormFieldItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldId",
                principalTable: "CustomFormFields",
                principalColumn: "CustomFormFieldId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "CustomFormFieldItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldId",
                principalTable: "CustomFormFields",
                principalColumn: "CustomFormFieldId");
        }
    }
}
