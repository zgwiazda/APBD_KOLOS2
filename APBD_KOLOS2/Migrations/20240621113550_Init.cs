using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_KOLOS2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Object_Type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Object",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Warehouse_ID = table.Column<int>(type: "int", nullable: false),
                    Object_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Object_Object_Type_Object_Type_ID",
                        column: x => x.Object_Type_ID,
                        principalTable: "Object_Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Object_Warehouse_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Object_Owner",
                columns: table => new
                {
                    Object_ID = table.Column<int>(type: "int", nullable: false),
                    Owner_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object_Owner", x => new { x.Object_ID, x.Owner_ID });
                    table.ForeignKey(
                        name: "FK_Object_Owner_Object_Object_ID",
                        column: x => x.Object_ID,
                        principalTable: "Object",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Object_Owner_Owner_Owner_ID",
                        column: x => x.Owner_ID,
                        principalTable: "Owner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Object_Type",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Type 1" },
                    { 2, "Type 2" }
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "ID", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "123456789" },
                    { 2, "Jane", "Smith", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Warehouse A" },
                    { 2, "Warehouse B" }
                });

            migrationBuilder.InsertData(
                table: "Object",
                columns: new[] { "ID", "Height", "Object_Type_ID", "Warehouse_ID", "Width" },
                values: new object[,]
                {
                    { 1, 2.34m, 1, 1, 1.23m },
                    { 2, 3.45m, 2, 2, 2.34m }
                });

            migrationBuilder.InsertData(
                table: "Object_Owner",
                columns: new[] { "Object_ID", "Owner_ID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Object_Object_Type_ID",
                table: "Object",
                column: "Object_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Object_Warehouse_ID",
                table: "Object",
                column: "Warehouse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Object_Owner_Owner_ID",
                table: "Object_Owner",
                column: "Owner_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Object_Owner");

            migrationBuilder.DropTable(
                name: "Object");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Object_Type");

            migrationBuilder.DropTable(
                name: "Warehouse");
        }
    }
}
