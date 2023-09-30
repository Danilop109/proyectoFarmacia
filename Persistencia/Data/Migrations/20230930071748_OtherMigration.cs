using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class OtherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_inventario_InventarioId",
                table: "RecetaMedica");

            migrationBuilder.DropIndex(
                name: "IX_RecetaMedica_InventarioId",
                table: "RecetaMedica");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "RecetaMedica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "RecetaMedica",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_InventarioId",
                table: "RecetaMedica",
                column: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_inventario_InventarioId",
                table: "RecetaMedica",
                column: "InventarioId",
                principalTable: "inventario",
                principalColumn: "Id");
        }
    }
}
