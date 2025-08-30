using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Pos.Model.Migrations
{
    /// <inheritdoc />
    public partial class MigrarModeloCategoriaProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoBarra = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "numeric(18,2)", unicode: false, precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "integer", unicode: false, nullable: false, defaultValue: 0),
                    StockMinimo = table.Column<int>(type: "integer", unicode: false, nullable: false, defaultValue: 5),
                    Estado = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CategoriaIdCategoria = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CodigoBarra",
                table: "Productos",
                column: "CodigoBarra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Descripcion",
                table: "Productos",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
