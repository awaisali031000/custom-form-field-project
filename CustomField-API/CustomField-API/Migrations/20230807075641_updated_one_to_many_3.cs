using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomField_API.Migrations
{
    public partial class updated_one_to_many_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomFormFieldId",
                table: "CustomFormFieldItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems",
                column: "CustomFormFieldId",
                principalTable: "CustomFormFields",
                principalColumn: "CustomFormFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldItems_CustomFormFields_CustomFormFieldId",
                table: "CustomFormFieldItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomFormFieldId",
                table: "CustomFormFieldItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
