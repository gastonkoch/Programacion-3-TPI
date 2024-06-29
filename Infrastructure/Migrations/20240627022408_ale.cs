using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderNotificationUser");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderNotifications",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderNotifications",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Koch");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "LastName", "Name", "UserType" },
                values: new object[] { "alejandro@gmail.com", "Di Stefano", "Alejandro", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastName",
                value: "Gomez");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastName", "UserType" },
                values: new object[] { "Lopez", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LastName", "Password" },
                values: new object[] { "Franco", "123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "RegisterDate", "UserType" },
                values: new object[] { 7, "admin", "", "admin", "admin", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersWithProductsId1_OrdersWithProductsIdProductsInOrderId",
                table: "Products",
                columns: new[] { "OrdersWithProductsId1", "OrdersWithProductsIdProductsInOrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsInOrderIdOrdersWithProductsId_ProductsInOrderId1",
                table: "Orders",
                columns: new[] { "ProductsInOrderIdOrdersWithProductsId", "ProductsInOrderId1" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotifications_UserId",
                table: "OrderNotifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderNotifications_Users_UserId",
                table: "OrderNotifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderNotifications_Users_UserId",
                table: "OrderNotifications");

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

            migrationBuilder.DropIndex(
                name: "IX_OrderNotifications_UserId",
                table: "OrderNotifications");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderNotifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderNotificationUser",
                columns: table => new
                {
                    OrderNotificationsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotificationUser", x => new { x.OrderNotificationsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OrderNotificationUser_OrderNotifications_OrderNotificationsId",
                        column: x => x.OrderNotificationsId,
                        principalTable: "OrderNotifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderNotificationUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "5");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RegisterDate", "UserType" },
                values: new object[,]
                {
                    { 2, "maria@gmail.com", "Maria", "2", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "ana@gmail.com", "Ana", "4", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotificationUser_UserId",
                table: "OrderNotificationUser",
                column: "UserId");
        }
    }
}
