using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BangazonBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserUid = table.Column<string>(type: "text", nullable: false),
                    CustomerUserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Zip = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.UserUid);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    UserUid = table.Column<string>(type: "text", nullable: false),
                    SellerUserName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    StateOrCountry = table.Column<string>(type: "text", nullable: false),
                    ProductsSold = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.UserUid);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerUserUid = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentMethods_Customers_CustomerUserUid",
                        column: x => x.CustomerUserUid,
                        principalTable: "Customers",
                        principalColumn: "UserUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SellerUserUid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerUserUid",
                        column: x => x.SellerUserUid,
                        principalTable: "Sellers",
                        principalColumn: "UserUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerUserUid = table.Column<string>(type: "text", nullable: false),
                    SellerUserUid = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductTotal = table.Column<int>(type: "integer", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerPaymentMethodId = table.Column<int>(type: "integer", nullable: false),
                    Open = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Filled = table.Column<bool>(type: "boolean", nullable: false),
                    Shipped = table.Column<bool>(type: "boolean", nullable: false),
                    DateShipped = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerPaymentMethods_CustomerPaymentMethodId",
                        column: x => x.CustomerPaymentMethodId,
                        principalTable: "CustomerPaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerUserUid",
                        column: x => x.CustomerUserUid,
                        principalTable: "Customers",
                        principalColumn: "UserUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Sellers_SellerUserUid",
                        column: x => x.SellerUserUid,
                        principalTable: "Sellers",
                        principalColumn: "UserUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "UserUid", "Address", "City", "CustomerUserName", "Email", "FirstName", "ImageUrl", "LastName", "State", "Zip" },
                values: new object[,]
                {
                    { "1", "123 Main st", "Midland", "TestCust1", "brook@email.com", "Test1", "https://img.freepik.com/free-vector/cute-rat-face-with-smiley-face_1308-146750.jpg?t=st=1741049605~exp=1741053205~hmac=995443f80f9f469eb7671d40911a8551d91981b3c05e96bbefcc26ab1c0d56d0&w=740", "Brook", "NC", 20451 },
                    { "2", "671 Main St", "Greenville", "TestCust2", "bee@email.com", "Test2", "https://img.freepik.com/free-vector/cute-mouse-cartoon-character_1308-140064.jpg?t=st=1741049847~exp=1741053447~hmac=164e23b0d9c44047635d3b19a774d338cbe09db323b73f287e0cfb70de7f0570&w=74", "Bee", "NC", 45643 }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "UserUid", "City", "Email", "ImageUrl", "ProductsSold", "SellerUserName", "StateOrCountry" },
                values: new object[,]
                {
                    { "21", "Cleveland", "cats@mail.com", "https://cdn.pixabay.com/photo/2021/11/22/04/28/animal-6815808_1280.jpg", true, "Cats R Us", "OH" },
                    { "22", "London", "Petsfood@mail.com", "https://cdn.pixabay.com/photo/2014/05/21/18/08/dog-bones-350092_640.jpg", true, "All Pets Food", "England" },
                    { "23", "Austin", "birds@mail.com", "https://cdn.pixabay.com/photo/2020/01/03/22/14/birdhouse-4739277_640.jpg", false, "The Bird Store", "TX" }
                });

            migrationBuilder.InsertData(
                table: "CustomerPaymentMethods",
                columns: new[] { "Id", "CustomerUserUid", "Details", "PaymentMethod" },
                values: new object[,]
                {
                    { 601, "1", "applepay_user_1234", "ApplePay" },
                    { 602, "2", "googlepay_user_5678", "GooglePay" },
                    { 603, "1", "paypal_user_test@example.com", "PayPal" },
                    { 604, "2", "4111-XXXX-XXXX-1234", "CreditCard" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity", "SellerUserUid" },
                values: new object[,]
                {
                    { 201, "Your cat will love this", "https://pixabay.com/photos/cat-toy-to-play-domestic-cat-4994140/", "Cat Toy", 5m, 5, "21" },
                    { 202, "Yummy", "https://cdn.pixabay.com/photo/2014/05/21/18/08/dog-bones-350092_640.jpg", "Dog Treats", 8m, 1, "22" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerPaymentMethodId", "CustomerUserUid", "DateCreated", "DateShipped", "Filled", "Open", "OrderTotal", "ProductId", "ProductTotal", "SellerUserUid", "Shipped" },
                values: new object[,]
                {
                    { 401, 601, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(36), null, false, true, 5m, 201, 1, "21", false },
                    { 402, 602, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(40), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(337), true, false, 10m, 202, 2, "22", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethods_CustomerUserUid",
                table: "CustomerPaymentMethods",
                column: "CustomerUserUid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerPaymentMethodId",
                table: "Orders",
                column: "CustomerPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserUid",
                table: "Orders",
                column: "CustomerUserUid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerUserUid",
                table: "Orders",
                column: "SellerUserUid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerUserUid",
                table: "Products",
                column: "SellerUserUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CustomerPaymentMethods");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
