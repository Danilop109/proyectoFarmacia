using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamentoRecetado_recetaMedica_IdRecetaMedicaFk",
                table: "medicamentoRecetado");

            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_recetaMedica_IdRecetaMedicaFk",
                table: "movimientoInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_recetaMedica_inventario_IdInventarioFk",
                table: "recetaMedica");

            migrationBuilder.DropForeignKey(
                name: "FK_recetaMedica_inventario_InventarioId",
                table: "recetaMedica");

            migrationBuilder.DropForeignKey(
                name: "FK_recetaMedica_persona_IdDoctorFk",
                table: "recetaMedica");

            migrationBuilder.DropForeignKey(
                name: "FK_recetaMedica_persona_IdPacienteFk",
                table: "recetaMedica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recetaMedica",
                table: "recetaMedica");

            migrationBuilder.RenameTable(
                name: "recetaMedica",
                newName: "RecetaMedica");

            migrationBuilder.RenameIndex(
                name: "IX_recetaMedica_InventarioId",
                table: "RecetaMedica",
                newName: "IX_RecetaMedica_InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_recetaMedica_IdPacienteFk",
                table: "RecetaMedica",
                newName: "IX_RecetaMedica_IdPacienteFk");

            migrationBuilder.RenameIndex(
                name: "IX_recetaMedica_IdInventarioFk",
                table: "RecetaMedica",
                newName: "IX_RecetaMedica_IdInventarioFk");

            migrationBuilder.RenameIndex(
                name: "IX_recetaMedica_IdDoctorFk",
                table: "RecetaMedica",
                newName: "IX_RecetaMedica_IdDoctorFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecetaMedica",
                table: "RecetaMedica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentoRecetado_RecetaMedica_IdRecetaMedicaFk",
                table: "medicamentoRecetado",
                column: "IdRecetaMedicaFk",
                principalTable: "RecetaMedica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_RecetaMedica_IdRecetaMedicaFk",
                table: "movimientoInventario",
                column: "IdRecetaMedicaFk",
                principalTable: "RecetaMedica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_inventario_IdInventarioFk",
                table: "RecetaMedica",
                column: "IdInventarioFk",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_inventario_InventarioId",
                table: "RecetaMedica",
                column: "InventarioId",
                principalTable: "inventario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_persona_IdDoctorFk",
                table: "RecetaMedica",
                column: "IdDoctorFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaMedica_persona_IdPacienteFk",
                table: "RecetaMedica",
                column: "IdPacienteFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamentoRecetado_RecetaMedica_IdRecetaMedicaFk",
                table: "medicamentoRecetado");

            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_RecetaMedica_IdRecetaMedicaFk",
                table: "movimientoInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_inventario_IdInventarioFk",
                table: "RecetaMedica");

            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_inventario_InventarioId",
                table: "RecetaMedica");

            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_persona_IdDoctorFk",
                table: "RecetaMedica");

            migrationBuilder.DropForeignKey(
                name: "FK_RecetaMedica_persona_IdPacienteFk",
                table: "RecetaMedica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecetaMedica",
                table: "RecetaMedica");

            migrationBuilder.RenameTable(
                name: "RecetaMedica",
                newName: "recetaMedica");

            migrationBuilder.RenameIndex(
                name: "IX_RecetaMedica_InventarioId",
                table: "recetaMedica",
                newName: "IX_recetaMedica_InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_RecetaMedica_IdPacienteFk",
                table: "recetaMedica",
                newName: "IX_recetaMedica_IdPacienteFk");

            migrationBuilder.RenameIndex(
                name: "IX_RecetaMedica_IdInventarioFk",
                table: "recetaMedica",
                newName: "IX_recetaMedica_IdInventarioFk");

            migrationBuilder.RenameIndex(
                name: "IX_RecetaMedica_IdDoctorFk",
                table: "recetaMedica",
                newName: "IX_recetaMedica_IdDoctorFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recetaMedica",
                table: "recetaMedica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentoRecetado_recetaMedica_IdRecetaMedicaFk",
                table: "medicamentoRecetado",
                column: "IdRecetaMedicaFk",
                principalTable: "recetaMedica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_recetaMedica_IdRecetaMedicaFk",
                table: "movimientoInventario",
                column: "IdRecetaMedicaFk",
                principalTable: "recetaMedica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recetaMedica_inventario_IdInventarioFk",
                table: "recetaMedica",
                column: "IdInventarioFk",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recetaMedica_inventario_InventarioId",
                table: "recetaMedica",
                column: "InventarioId",
                principalTable: "inventario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_recetaMedica_persona_IdDoctorFk",
                table: "recetaMedica",
                column: "IdDoctorFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recetaMedica_persona_IdPacienteFk",
                table: "recetaMedica",
                column: "IdPacienteFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
