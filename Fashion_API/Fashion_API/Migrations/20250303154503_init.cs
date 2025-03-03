using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fashion_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hexCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "size",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_categories_productTypes_productTypeId",
                        column: x => x.productTypeId,
                        principalTable: "productTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productVariants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    colorId = table.Column<int>(type: "int", nullable: false),
                    sizeId = table.Column<int>(type: "int", nullable: false),
                    imageKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariants", x => x.id);
                    table.UniqueConstraint("AK_productVariants_imageKey", x => x.imageKey);
                    table.ForeignKey(
                        name: "FK_productVariants_colors_colorId",
                        column: x => x.colorId,
                        principalTable: "colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productVariants_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productVariants_size_sizeId",
                        column: x => x.sizeId,
                        principalTable: "size",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productGalleries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productGalleries", x => x.id);
                    table.ForeignKey(
                        name: "FK_productGalleries_productVariants_imageKey",
                        column: x => x.imageKey,
                        principalTable: "productVariants",
                        principalColumn: "imageKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productVariantId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductStocks_productVariants_productVariantId",
                        column: x => x.productVariantId,
                        principalTable: "productVariants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "colors",
                columns: new[] { "id", "hexCode", "name" },
                values: new object[,]
                {
                    { 1, "#000000", "Đen" },
                    { 2, "#FFFFFF", "Trắng" },
                    { 3, "#0000FF", "Xanh Dương" },
                    { 4, "#FF0000", "Đỏ" },
                    { 5, "#008000", "Xanh Lá" }
                });

            migrationBuilder.InsertData(
                table: "productTypes",
                columns: new[] { "id", "name", "slug" },
                values: new object[,]
                {
                    { 1, "Áo", "ao" },
                    { 2, "Quần", "quan" },
                    { 3, "Nón", "non" },
                    { 4, "Phụ kiện", "phu-kien" }
                });

            migrationBuilder.InsertData(
                table: "size",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" },
                    { 4, "XL" },
                    { 5, "2XL" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name", "productTypeId", "slug" },
                values: new object[,]
                {
                    { 1, "Áo thun", 1, "ao-thun" },
                    { 2, "Áo sơ mi", 1, "ao-so-mi" },
                    { 3, "Quần thun", 2, "quan-thun" },
                    { 4, "Quần kaki", 2, "quan-kaki" },
                    { 5, "Mũ lưỡi trai", 3, "mu-luoi-trai" },
                    { 6, "Túi xách", 4, "tui-xach" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "categoryId", "description", "discount", "name", "price", "slug" },
                values: new object[,]
                {
                    { 1, 1, "mo ta", 5.0, "pÁo thun", 500000.0, "ao-thun" },
                    { 2, 2, "mo ta", 0.0, "pÁo sơ mi", 520000.0, "ao-so-mi" },
                    { 3, 3, "mo ta", 15.0, "pQuần thun", 400000.0, "quan-thun" },
                    { 4, 4, "mo ta", 5.0, "pQuần kaki", 460000.0, "quan-kaki" },
                    { 5, 5, "mo ta", 5.0, "pMũ lưỡi trai", 500000.0, "mu-luoi-trai" },
                    { 6, 6, "mo ta ", 5.0, "púi xách", 500000.0, "tui-xach" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_productTypeId",
                table: "categories",
                column: "productTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_productGalleries_imageKey",
                table: "productGalleries",
                column: "imageKey");

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryId",
                table: "products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_productVariantId",
                table: "ProductStocks",
                column: "productVariantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_colorId",
                table: "productVariants",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_productId",
                table: "productVariants",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_sizeId",
                table: "productVariants",
                column: "sizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productGalleries");

            migrationBuilder.DropTable(
                name: "ProductStocks");

            migrationBuilder.DropTable(
                name: "productVariants");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "size");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "productTypes");
        }
    }
}
