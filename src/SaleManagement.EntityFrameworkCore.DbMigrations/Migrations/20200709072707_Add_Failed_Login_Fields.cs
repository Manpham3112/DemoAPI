using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleManagement.Migrations
{
    public partial class Add_Failed_Login_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedLoginsNumber",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLockedDate",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedLoginsNumber",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LastLockedDate",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "AbpUsers");
        }
    }
}
