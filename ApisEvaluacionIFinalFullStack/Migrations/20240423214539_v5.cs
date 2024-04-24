using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApisEvaluacionIFinalFullStack.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PedidosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidosId = table.Column<int>(type: "int", nullable: false),
                    LibrosId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosDetalle_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosDetalle_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_LibrosId",
                table: "PedidosDetalle",
                column: "LibrosId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_PedidosId",
                table: "PedidosDetalle",
                column: "PedidosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosDetalle");

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
    }
}
