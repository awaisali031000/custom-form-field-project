using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomField_API.Migrations
{
    public partial class added_custom_Form_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItem_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomFormFieldItem",
                table: "CustomFormFieldItem");

            migrationBuilder.RenameTable(
                name: "CustomFormFieldItem",
                newName: "CustomFormFieldItems");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFormFieldItem_CustomFormFieldId",
                table: "CustomFormFieldItems",
                newName: "IX_CustomFormFieldItems_CustomFormFieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomFormFieldItems",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldItemId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomFormFieldItems",
                table: "CustomFormFieldItems");

            migrationBuilder.RenameTable(
                name: "CustomFormFieldItems",
                newName: "CustomFormFieldItem");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFormFieldItems_CustomFormFieldId",
                table: "CustomFormFieldItem",
                newName: "IX_CustomFormFieldItem_CustomFormFieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomFormFieldItem",
                table: "CustomFormFieldItem",
                column: "CustomFormFieldItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldItem_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItem",
                column: "CustomFormFieldId",
                principalTable: "CustomFormFields",
                principalColumn: "CustomFormFieldId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
