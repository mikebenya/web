using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProyectoMorenita.Migrations
{
    public partial class zenky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    CLIENTE_ID = table.Column<string>(nullable: false),
                    CLIENTE_NOMBRE1 = table.Column<string>(nullable: true),
                    CLIENTE_NOMBRE2 = table.Column<string>(nullable: true),
                    CLIENTE_APELLIDO1 = table.Column<string>(nullable: true),
                    CLIENTE_APELLIDO2 = table.Column<string>(nullable: true),
                    CLIENTE_CALLE = table.Column<string>(nullable: true),
                    CLIENTE_CASA = table.Column<string>(nullable: true),
                    CLIENTE_BARRIO = table.Column<string>(nullable: true),
                    CLIENTE_FECHAN = table.Column<DateTime>(nullable: true),
                    CLIENTE_TELEFONO = table.Column<string>(nullable: true),
                    CLIENTE_EMAIL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.CLIENTE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    PRODUCTO_ID = table.Column<string>(nullable: false),
                    PRODUCTO_NOMBRE = table.Column<string>(nullable: true),
                    PRODUCTO_COSTO = table.Column<double>(nullable: false),
                    PRODUCTO_PRECIO = table.Column<double>(nullable: false),
                    PRODUCTO_DESCRIPCION = table.Column<string>(nullable: true),
                    PRODUCTO_IMAGEN = table.Column<string>(nullable: true),
                    PRODUCTO_IVA = table.Column<double>(nullable: false),
                    PRODUCTO_ESTADO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.PRODUCTO_ID);
                });

            migrationBuilder.CreateTable(
                name: "VENDEDOR",
                columns: table => new
                {
                    VENDEDOR_ID = table.Column<string>(nullable: false),
                    VENDEDOR_NOMBRE1_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_NOMBRE2_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_APELLIDO1_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_APELLIDO2_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_CALLE_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_CASA_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_BARRIO_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_TELEFONO_VEN = table.Column<string>(nullable: true),
                    VENDEDOR_USUARIO = table.Column<string>(nullable: true),
                    VENDEDOR_CONTRASENA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDEDOR", x => x.VENDEDOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "FACTURAMAESTRO",
                columns: table => new
                {
                    MAESTRO_ID = table.Column<string>(nullable: false),
                    MAESTRO_FECHA = table.Column<DateTime>(nullable: true),
                    MAESTRO_TOTAL = table.Column<double>(nullable: false),
                    CLIENTE_ID = table.Column<string>(nullable: true),
                    VENDEDOR_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURAMAESTRO", x => x.MAESTRO_ID);
                    table.ForeignKey(
                        name: "FK_FACTURACLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalTable: "CLIENTE",
                        principalColumn: "CLIENTE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FACTURAVENDEDOR_ID",
                        column: x => x.VENDEDOR_ID,
                        principalTable: "VENDEDOR",
                        principalColumn: "VENDEDOR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACTURADETALLE",
                columns: table => new
                {
                    DETALLE_ID = table.Column<string>(nullable: false),
                    DETALLE_CANTIDAD = table.Column<int>(nullable: false),
                    DETALLE_PRECIO = table.Column<double>(nullable: false),
                    DETALLE_FECHA = table.Column<DateTime>(nullable: true),
                    DETALLE_SUBTOTAL = table.Column<double>(nullable: false),
                    PRODUCTO_ID = table.Column<string>(nullable: true),
                    MAESTRO_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURADETALLE", x => x.DETALLE_ID);
                    table.ForeignKey(
                        name: "FK_DETALLEMAESTRO_ID",
                        column: x => x.MAESTRO_ID,
                        principalTable: "FACTURAMAESTRO",
                        principalColumn: "MAESTRO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLEPRODUCTO_ID",
                        column: x => x.PRODUCTO_ID,
                        principalTable: "PRODUCTO",
                        principalColumn: "PRODUCTO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_MAESTRO_ID",
                table: "FACTURADETALLE",
                column: "MAESTRO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_PRODUCTO_ID",
                table: "FACTURADETALLE",
                column: "PRODUCTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURACLIENTE_ID",
                table: "FACTURAMAESTRO",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAVENDEDOR_ID",
                table: "FACTURAMAESTRO",
                column: "VENDEDOR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FACTURADETALLE");

            migrationBuilder.DropTable(
                name: "FACTURAMAESTRO");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "VENDEDOR");
        }
    }
}
