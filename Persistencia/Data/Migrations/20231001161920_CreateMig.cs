using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Presentacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContacto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoDocumento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdDepartamentoFk",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contactoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoContactoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactoPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contactoPersona_TipoContacto_IdTipoContactoFk",
                        column: x => x.IdTipoContactoFk,
                        principalTable: "TipoContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleMovInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    precio = table.Column<double>(type: "double", nullable: false),
                    IdMovimientoInvFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovInventario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stock = table.Column<int>(type: "int", nullable: false),
                    stockMin = table.Column<int>(type: "int", nullable: false),
                    stockMax = table.Column<int>(type: "int", nullable: false),
                    IdPresentacionFk = table.Column<int>(type: "int", nullable: false),
                    IdDetalleMovInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventario_DetalleMovInventario_IdDetalleMovInventarioFk",
                        column: x => x.IdDetalleMovInventarioFk,
                        principalTable: "DetalleMovInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventario_Presentacion_IdPresentacionFk",
                        column: x => x.IdPresentacionFk,
                        principalTable: "Presentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "formaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMovimientoInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formaPago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamentoRecetado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRecetaMedicaFk = table.Column<int>(type: "int", nullable: false),
                    IdInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentoRecetado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentoRecetado_inventario_IdInventarioFk",
                        column: x => x.IdInventarioFk,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fechaVencimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    fechaMovimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoInventario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoDocumentoFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdMovimientoInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_Rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_movimientoInventario_IdMovimientoInventarioFk",
                        column: x => x.IdMovimientoInventarioFk,
                        principalTable: "movimientoInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipoDocumento_IdTipoDocumentoFk",
                        column: x => x.IdTipoDocumentoFk,
                        principalTable: "tipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipoPersona_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "tipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoMovimientoInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMovimientoInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimientoInventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tipoMovimientoInventario_movimientoInventario_IdMovimientoIn~",
                        column: x => x.IdMovimientoInventarioFk,
                        principalTable: "movimientoInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    Cantidad = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    fechaCaducidad = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IdMarcaFk = table.Column<int>(type: "int", nullable: false),
                    IdInventarioFk = table.Column<int>(type: "int", nullable: false),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    MovimientoInventarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_inventario_IdInventarioFk",
                        column: x => x.IdInventarioFk,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_marca_IdMarcaFk",
                        column: x => x.IdMarcaFk,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_movimientoInventario_MovimientoInventarioId",
                        column: x => x.MovimientoInventarioId,
                        principalTable: "movimientoInventario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Producto_persona_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecetaMedica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaEmicion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "DateTime", nullable: false),
                    detalle = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDoctorFk = table.Column<int>(type: "int", nullable: false),
                    IdPacienteFk = table.Column<int>(type: "int", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: false),
                    IdMovimientoInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetaMedica_inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaMedica_movimientoInventario_IdMovimientoInventarioFk",
                        column: x => x.IdMovimientoInventarioFk,
                        principalTable: "movimientoInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaMedica_persona_IdDoctorFk",
                        column: x => x.IdDoctorFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaMedica_persona_IdPacienteFk",
                        column: x => x.IdPacienteFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombreuser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_persona_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productoProveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productoProveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productoProveedor_Producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productoProveedor_persona_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdUserFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.IdRolFk, x.IdUserFk });
                    table.ForeignKey(
                        name: "FK_userRol_Rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamentoFk",
                table: "ciudad",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_contactoPersona_IdPersonaFk",
                table: "contactoPersona",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_contactoPersona_IdTipoContactoFk",
                table: "contactoPersona",
                column: "IdTipoContactoFk");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFk",
                table: "departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovInventario_IdMovimientoInvFk",
                table: "DetalleMovInventario",
                column: "IdMovimientoInvFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdCiudadFk",
                table: "direccion",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdPersonaFk",
                table: "direccion",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_formaPago_IdMovimientoInventarioFk",
                table: "formaPago",
                column: "IdMovimientoInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_IdDetalleMovInventarioFk",
                table: "inventario",
                column: "IdDetalleMovInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_IdPresentacionFk",
                table: "inventario",
                column: "IdPresentacionFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentoRecetado_IdInventarioFk",
                table: "medicamentoRecetado",
                column: "IdInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentoRecetado_IdRecetaMedicaFk",
                table: "medicamentoRecetado",
                column: "IdRecetaMedicaFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_PersonaId",
                table: "movimientoInventario",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdMovimientoInventarioFk",
                table: "persona",
                column: "IdMovimientoInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdRolFk",
                table: "persona",
                column: "IdRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoDocumentoFk",
                table: "persona",
                column: "IdTipoDocumentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoPersonaFk",
                table: "persona",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdInventarioFk",
                table: "Producto",
                column: "IdInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdMarcaFk",
                table: "Producto",
                column: "IdMarcaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdPersonaFk",
                table: "Producto",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MovimientoInventarioId",
                table: "Producto",
                column: "MovimientoInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_productoProveedor_IdPersonaFk",
                table: "productoProveedor",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_productoProveedor_IdProductoFk",
                table: "productoProveedor",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_IdDoctorFk",
                table: "RecetaMedica",
                column: "IdDoctorFk");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_IdMovimientoInventarioFk",
                table: "RecetaMedica",
                column: "IdMovimientoInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_IdPacienteFk",
                table: "RecetaMedica",
                column: "IdPacienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_InventarioId",
                table: "RecetaMedica",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_UserId",
                table: "refreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tipoMovimientoInventario_IdMovimientoInventarioFk",
                table: "tipoMovimientoInventario",
                column: "IdMovimientoInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_user_IdPersonaFk",
                table: "user",
                column: "IdPersonaFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRol_IdUserFk",
                table: "userRol",
                column: "IdUserFk");

            migrationBuilder.AddForeignKey(
                name: "FK_contactoPersona_persona_IdPersonaFk",
                table: "contactoPersona",
                column: "IdPersonaFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleMovInventario_movimientoInventario_IdMovimientoInvFk",
                table: "DetalleMovInventario",
                column: "IdMovimientoInvFk",
                principalTable: "movimientoInventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_direccion_persona_IdPersonaFk",
                table: "direccion",
                column: "IdPersonaFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_formaPago_movimientoInventario_IdMovimientoInventarioFk",
                table: "formaPago",
                column: "IdMovimientoInventarioFk",
                principalTable: "movimientoInventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentoRecetado_RecetaMedica_IdRecetaMedicaFk",
                table: "medicamentoRecetado",
                column: "IdRecetaMedicaFk",
                principalTable: "RecetaMedica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_persona_PersonaId",
                table: "movimientoInventario",
                column: "PersonaId",
                principalTable: "persona",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_persona_PersonaId",
                table: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "contactoPersona");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "formaPago");

            migrationBuilder.DropTable(
                name: "medicamentoRecetado");

            migrationBuilder.DropTable(
                name: "productoProveedor");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropTable(
                name: "tipoMovimientoInventario");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "TipoContacto");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "RecetaMedica");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "DetalleMovInventario");

            migrationBuilder.DropTable(
                name: "Presentacion");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "tipoDocumento");

            migrationBuilder.DropTable(
                name: "tipoPersona");
        }
    }
}
