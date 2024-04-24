using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApisEvaluacionIFinalFullStack.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDetalle_Pedidos_FacturasId",
                table: "PedidosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDetalle_FacturasId",
                table: "PedidosDetalle");

            migrationBuilder.DropColumn(
                name: "FacturasId",
                table: "PedidosDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_PedidosId",
                table: "PedidosDetalle",
                column: "PedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDetalle_Pedidos_PedidosId",
                table: "PedidosDetalle",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDetalle_Pedidos_PedidosId",
                table: "PedidosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDetalle_PedidosId",
                table: "PedidosDetalle");

            migrationBuilder.AddColumn<int>(
                name: "FacturasId",
                table: "PedidosDetalle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_FacturasId",
                table: "PedidosDetalle",
                column: "FacturasId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDetalle_Pedidos_FacturasId",
                table: "PedidosDetalle",
                column: "FacturasId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}
