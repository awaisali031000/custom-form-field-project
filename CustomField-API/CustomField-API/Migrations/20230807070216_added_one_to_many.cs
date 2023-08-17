using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomField_API.Migrations
{
    public partial class added_one_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormFieldItems_CustomFormFieldId",
                table: "CustomFormFieldItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldItemId",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldItemId",
                principalTable: "CustomFormFields",
                principalColumn: "CustomFormFieldId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldItemId",
                table: "CustomFormFieldItems");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFieldItems_CustomFormFieldId",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldId",
                principalTable: "CustomFormFields",
                principalColumn: "CustomFormFieldId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
