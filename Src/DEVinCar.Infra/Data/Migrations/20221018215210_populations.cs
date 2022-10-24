using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinCar.Infra.Data.Migrations
{
    public partial class populations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SuggestedPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleCars_Cars_Id",
                        column: x => x.Id,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleCars_Sales_Id",
                        column: x => x.Id,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryForecast = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Name", "SuggestedPrice" },
                values: new object[,]
                {
                    { 1, "Camaro Chevrolet", 60000m },
                    { 2, "Maverick Ford", 20000m },
                    { 3, "Astra Chevrolet", 30000m },
                    { 4, "Hilux Toyota", 20000m },
                    { 5, "Bravo Fiat", 20000m },
                    { 6, "BR800 Gurgel", 10000m },
                    { 7, "147 Fiat", 50000m },
                    { 8, "Del Rey Ford", 10000m },
                    { 9, "Mustang Ford", 70000m },
                    { 10, "Belina Ford", 20000m }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Initials", "Name" },
                values: new object[,]
                {
                    { 1, "AC", "Acre" },
                    { 2, "AL", "Alagoas" },
                    { 3, "AP", "Amapá" },
                    { 4, "AM", "Amazonas" },
                    { 5, "BA", "Bahia" },
                    { 6, "CE", "Ceará" },
                    { 7, "DF", "Distrito Federal" },
                    { 8, "ES", "Espírito Santo" },
                    { 9, "GO", "Goiás" },
                    { 10, "MA", "Maranhão" },
                    { 11, "MT", "Mato Grosso" },
                    { 12, "MS", "Mato Grosso do Sul" },
                    { 13, "MG", "Minas Gerais" },
                    { 14, "PA", "Pará" },
                    { 15, "PB", "Paraíba" },
                    { 16, "PR", "Paraná" },
                    { 17, "PE", "Pernambuco" },
                    { 18, "PI", "Piauí" },
                    { 19, "RJ", "Rio de Janeiro" },
                    { 20, "RN", "Rio Grande do Norte" },
                    { 21, "RS", "Rio Grande do Sul" },
                    { 22, "RO", "Rondônia" },
                    { 23, "RR", "Roraima" },
                    { 24, "SC", "Santa Catarina" },
                    { 25, "SP", "São Paulo" },
                    { 26, "SE", "Sergipe" },
                    { 27, "TO", "Tocantins" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Password", "Permission" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jose@email.com", "Jose", "123456opp78dfg", 2 },
                    { 2, new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "andrea@email.com", "Andrea", "987dasd654321d", 0 },
                    { 3, new DateTime(2005, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "adao@email.com", "Adao", "2589as89898ddf", 1 },
                    { 4, new DateTime(2001, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "andre@email.com", "andre", "asasdd45uiodfg", 1 },
                    { 5, new DateTime(2011, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcos@email.com", "Marcos", "asd45uidfg121o", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Password", "Permission" },
                values: new object[,]
                {
                    { 6, new DateTime(2008, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manuela@email.com", "Manuela", "asd45dfgu789io", 0 },
                    { 7, new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vania@email.com", "Vania", "asd454563213ui", 0 },
                    { 8, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "carla@email.com", "carla", "asdfgd45ui121o", 0 },
                    { 9, new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malena@email.com", "Malena", "asd45ui898odfg", 0 },
                    { 10, new DateTime(2011, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marize@email.com", "Marize", "asd45uidfgdfgo", 0 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, "Jaragua do sul", 24 },
                    { 2, "Joinville", 24 },
                    { 3, "Florianopolis", 24 },
                    { 4, "Lages", 24 },
                    { 5, "São Paulo", 25 },
                    { 6, "Maringá", 16 },
                    { 7, "Curitiba", 16 },
                    { 8, "Manaus", 4 },
                    { 9, "Porto Alegre", 21 },
                    { 10, "Charqueadas", 21 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BuyerId", "SaleDate", "SellerId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 3, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, 5, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 4, 7, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 5, 9, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 6, 3, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 5, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 7, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 9, 9, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 10, 1, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Cep", "CityId", "Complement", "Number", "Street" },
                values: new object[,]
                {
                    { 1, "89260200", 1, "avenida dos javeiros", 55, "Bertha weege" },
                    { 2, "99260450", 2, "bóson de higgs", 44, "Macarena    " },
                    { 3, "88245640", 3, "rutherford bohr ", 787, "Mundial frei" },
                    { 4, "79260500", 4, "paradoxo dos gemeos", 554, "Alvin Bross" },
                    { 5, "87289890", 5, "paradoxo de bootstrap", 578, "Nickson nelma" },
                    { 6, "49245500", 6, "gato de schrödinger", 544, "jk matilda" },
                    { 7, "89567520", 7, "efeito fantasmagorico", 33, "horizons blue" },
                    { 8, "84256500", 8, "max plank", 323, "apargatas" },
                    { 9, "86260560", 9, "stephen hawking", 678, "medianeira" },
                    { 10, "89960450", 10, "de volta para o futuro", 123, "bartinduum" }
                });

            migrationBuilder.InsertData(
                table: "SaleCars",
                columns: new[] { "Id", "Amount", "CarId", "SaleId", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 60000m },
                    { 2, 1, 2, 2, 20000m },
                    { 3, 1, 3, 3, 30000m },
                    { 4, 3, 1, 4, 60000m },
                    { 5, 1, 4, 5, 20000m },
                    { 6, 1, 7, 6, 50000m },
                    { 7, 2, 9, 7, 70000m },
                    { 8, 1, 6, 8, 10000m },
                    { 9, 2, 3, 9, 30000m },
                    { 10, 1, 9, 10, 70000m }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "AddressId", "DeliveryForecast", "SaleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2, 2, new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 3, 3, new DateTime(2005, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 4, 4, new DateTime(2001, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 5, 5, new DateTime(2011, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, 6, new DateTime(2008, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 7, 7, new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 8, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, 9, new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, 10, new DateTime(2011, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_AddressId",
                table: "Deliveries",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_SaleId",
                table: "Deliveries",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerId",
                table: "Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SellerId",
                table: "Sales",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "SaleCars");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
