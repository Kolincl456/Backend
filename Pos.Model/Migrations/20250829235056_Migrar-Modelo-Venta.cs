using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Pos.Model.Migrations
{
    /// <inheritdoc />
    public partial class MigrarModeloVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Factura = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "NOW()"),
                    Dni = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    Cliente = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Descuento = table.Column<decimal>(type: "numeric(4,2)", unicode: false, precision: 4, scale: 2, nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "numeric(18,2)", unicode: false, precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    FechaAnulada = table.Column<DateOnly>(type: "date", nullable: true),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioAnula = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdUsuario",
                table: "Ventas",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
