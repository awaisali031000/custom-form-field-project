using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomField_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomFormFields",
                columns: table => new
                {
                    CustomFormFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFields", x => x.CustomFormFieldId);
                });

            migrationBuilder.CreateTable(
                name: "CustomFormFieldItem",
                columns: table => new
                {
                    CustomFormFieldItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFormFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFieldItem", x => x.CustomFormFieldItemId);
                    table.ForeignKey(
                        name: "FK_CustomFormFieldItem_CustomFormFields_CustomFormFieldId",
                        column: x => x.CustomFormFieldId,
                        principalTable: "CustomFormFields",
                        principalColumn: "CustomFormFieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFieldItem_CustomFormFieldId",
                table: "CustomFormFieldItem",
                column: "CustomFormFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFormFieldItem");

            migrationBuilder.DropTable(
                name: "CustomFormFields");
        }
    }
}
