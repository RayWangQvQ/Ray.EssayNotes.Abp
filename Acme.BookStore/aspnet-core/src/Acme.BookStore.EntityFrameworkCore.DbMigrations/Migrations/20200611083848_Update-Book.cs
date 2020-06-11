using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.BookStore.Migrations
{
    public partial class UpdateBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppBook",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppBook",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppBook",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppBook");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppBook");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppBook");
        }
    }
}
