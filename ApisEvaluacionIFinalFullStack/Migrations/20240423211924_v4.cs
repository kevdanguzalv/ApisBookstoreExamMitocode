using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApisEvaluacionIFinalFullStack.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosPedidos");

            migrationBuilder.AddColumn<int>(
                name: "LibrosId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_LibrosId",
                table: "Pedidos",
                column: "LibrosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Libros_LibrosId",
                table: "Pedidos",
                column: "LibrosId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Libros_LibrosId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_LibrosId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LibrosId",
                table: "Pedidos");

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
    }
}
