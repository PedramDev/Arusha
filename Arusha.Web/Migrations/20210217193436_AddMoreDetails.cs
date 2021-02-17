using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arusha.Web.Migrations
{
    public partial class AddMoreDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariantPriceSellHistory_Variant_VariantId",
                table: "VariantPriceSellHistory");

            migrationBuilder.DropTable(
                name: "VariantPriceBuyHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantPriceSellHistory",
                table: "VariantPriceSellHistory");

            migrationBuilder.RenameTable(
                name: "VariantPriceSellHistory",
                newName: "VariantPriceHistory");

            migrationBuilder.RenameIndex(
                name: "IX_VariantPriceSellHistory_VariantId",
                table: "VariantPriceHistory",
                newName: "IX_VariantPriceHistory_VariantId");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Variant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Variant",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingCost",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ShippingMethodId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "VariantPriceHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantPriceHistory",
                table: "VariantPriceHistory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyVariant",
                columns: table => new
                {
                    PropertiesId = table.Column<int>(type: "int", nullable: false),
                    VariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyVariant", x => new { x.PropertiesId, x.VariantsId });
                    table.ForeignKey(
                        name: "FK_PropertyVariant_Property_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyVariant_Variant_VariantsId",
                        column: x => x.VariantsId,
                        principalTable: "Variant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variant_ColorId",
                table: "Variant",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingMethodId",
                table: "Order",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyVariant_VariantsId",
                table: "PropertyVariant",
                column: "VariantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingMethod_ShippingMethodId",
                table: "Order",
                column: "ShippingMethodId",
                principalTable: "ShippingMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Variant_Color_ColorId",
                table: "Variant",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantPriceHistory_Variant_VariantId",
                table: "VariantPriceHistory",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingMethod_ShippingMethodId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Variant_Color_ColorId",
                table: "Variant");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantPriceHistory_Variant_VariantId",
                table: "VariantPriceHistory");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "PropertyVariant");

            migrationBuilder.DropTable(
                name: "ShippingMethod");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Variant_ColorId",
                table: "Variant");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingMethodId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantPriceHistory",
                table: "VariantPriceHistory");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Variant");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Variant");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingCost",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingMethodId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "VariantPriceHistory");

            migrationBuilder.RenameTable(
                name: "VariantPriceHistory",
                newName: "VariantPriceSellHistory");

            migrationBuilder.RenameIndex(
                name: "IX_VariantPriceHistory_VariantId",
                table: "VariantPriceSellHistory",
                newName: "IX_VariantPriceSellHistory_VariantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantPriceSellHistory",
                table: "VariantPriceSellHistory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VariantPriceBuyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantPriceBuyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantPriceBuyHistory_Variant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariantPriceBuyHistory_VariantId",
                table: "VariantPriceBuyHistory",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantPriceSellHistory_Variant_VariantId",
                table: "VariantPriceSellHistory",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
