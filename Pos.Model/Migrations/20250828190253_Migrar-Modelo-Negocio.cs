using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Pos.Model.Migrations
{
    /// <inheritdoc />
    public partial class MigrarModeloNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Negocios",
                columns: table => new
                {
                    IdNegocio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RUC = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    RazonSocial = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Propietario = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Descuento = table.Column<decimal>(type: "numeric(4,2)", unicode: false, precision: 4, scale: 2, nullable: false, defaultValue: 0m),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocios", x => x.IdNegocio);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Negocios");
        }
    }
}
