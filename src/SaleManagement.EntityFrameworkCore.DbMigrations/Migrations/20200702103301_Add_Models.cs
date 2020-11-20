using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleManagement.Migrations
{
    public partial class Add_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleReceipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportReceiptDetails",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ImportReceiptId = table.Column<Guid>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<float>(nullable: false),
                    DistributorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceiptDetails", x => new { x.ImportReceiptId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ImportReceiptDetails_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportReceiptDetails_ImportReceipts_ImportReceiptId",
                        column: x => x.ImportReceiptId,
                        principalTable: "ImportReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportReceiptDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleReceiptDetails",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    SaleReceiptId = table.Column<Guid>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleReceiptDetails", x => new { x.SaleReceiptId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SaleReceiptDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleReceiptDetails_SaleReceipts_SaleReceiptId",
                        column: x => x.SaleReceiptId,
                        principalTable: "SaleReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceiptDetails_DistributorId",
                table: "ImportReceiptDetails",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceiptDetails_ProductId",
                table: "ImportReceiptDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleReceiptDetails_ProductId",
                table: "SaleReceiptDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportReceiptDetails");

            migrationBuilder.DropTable(
                name: "SaleReceiptDetails");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "ImportReceipts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SaleReceipts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AbpUsers");
        }
    }
}
