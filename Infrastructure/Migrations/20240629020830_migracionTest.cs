using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migracionTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProducts_ProductsInOrderIdOrdersWithProductsId_ProductsInOrderId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_OrdersWithProductsId1_OrdersWithProductsIdProductsInOrderId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrdersWithProductsId1_OrdersWithProductsIdProductsInOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductsInOrderIdOrdersWithProductsId_ProductsInOrderId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersWithProductsId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrdersWithProductsIdProductsInOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsInOrderId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductsInOrderIdOrdersWithProductsId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersWithProductsId1",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdersWithProductsIdProductsInOrderId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsInOrderId1",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsInOrderIdOrdersWithProductsId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrdersWithProductsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsInOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrdersWithProductsId, x.ProductsInOrderId });
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrdersWithProductsId1", "OrdersWithProductsIdProductsInOrderId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrdersWithProductsId1", "OrdersWithProductsIdProductsInOrderId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OrdersWithProductsId1", "OrdersWithProductsIdProductsInOrderId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersWithProductsId1_OrdersWithProductsIdProductsInOrderId",
                table: "Products",
                columns: new[] { "OrdersWithProductsId1", "OrdersWithProductsIdProductsInOrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsInOrderIdOrdersWithProductsId_ProductsInOrderId1",
                table: "Orders",
                columns: new[] { "ProductsInOrderIdOrdersWithProductsId", "ProductsInOrderId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderProducts_ProductsInOrderIdOrdersWithProductsId_ProductsInOrderId1",
                table: "Orders",
                columns: new[] { "ProductsInOrderIdOrdersWithProductsId", "ProductsInOrderId1" },
                principalTable: "OrderProducts",
                principalColumns: new[] { "OrdersWithProductsId", "ProductsInOrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_OrdersWithProductsId1_OrdersWithProductsIdProductsInOrderId",
                table: "Products",
                columns: new[] { "OrdersWithProductsId1", "OrdersWithProductsIdProductsInOrderId" },
                principalTable: "OrderProducts",
                principalColumns: new[] { "OrdersWithProductsId", "ProductsInOrderId" });
        }
    }
}
