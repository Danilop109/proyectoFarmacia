using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class HopeTheLastoneMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_inventario_IdInventarioFk",
                table: "RecetaMedica");

            migrationBuilder.RenameColumn(
                name: "IdInventarioFk",
                table: "RecetaMedica",
                newName: "InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_RecetaMedica_IdInventarioFk",
                table: "RecetaMedica",
                newName: "IX_RecetaMedica_InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_inventario_InventarioId",
                table: "RecetaMedica",
                column: "InventarioId",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_inventario_InventarioId",
                table: "RecetaMedica");

            migrationBuilder.RenameColumn(
                name: "InventarioId",
                table: "RecetaMedica",
                newName: "IdInventarioFk");

            migrationBuilder.RenameIndex(
                name: "IX_RecetaMedica_InventarioId",
                table: "RecetaMedica",
                newName: "IX_RecetaMedica_IdInventarioFk");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_inventario_IdInventarioFk",
                table: "RecetaMedica",
                column: "IdInventarioFk",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
