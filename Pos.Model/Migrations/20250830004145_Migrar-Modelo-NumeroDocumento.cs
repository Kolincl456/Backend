using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Pos.Model.Migrations
{
    /// <inheritdoc />
    public partial class MigrarModeloNumeroDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroDocumentos",
                columns: table => new
                {
                    IdNumeroDocumento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Documento = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroDocumentos", x => x.IdNumeroDocumento);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroDocumentos_Documento",
                table: "NumeroDocumentos",
                column: "Documento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroDocumentos");
        }
    }
}
