using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lion.CodeGenerator.Migrations
{
    public partial class AggregateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Gen_PropertyModel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Gen_PropertyModel",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Gen_EntityModel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Gen_EntityModel",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Gen_PropertyModel");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Gen_PropertyModel");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Gen_EntityModel");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Gen_EntityModel");
        }
    }
}
