using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApisEvaluacionIFinalFullStack.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Pedidos_PedidosId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PedidosId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "Libros");

            migrationBuilder.CreateTable(
                name: "LibrosPedidos",
                columns: table => new
                {
                    LibrosId = table.Column<int>(type: "int", nullable: false),
                    PedidosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosPedidos", x => new { x.LibrosId, x.PedidosId });
                    table.ForeignKey(
                        name: "FK_LibrosPedidos_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosPedidos_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosPedidos_PedidosId",
                table: "LibrosPedidos",
                column: "PedidosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosPedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidosId",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PedidosId",
                table: "Libros",
                column: "PedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Pedidos_PedidosId",
                table: "Libros",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}
