using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhasV0.Migrations
{
    /// <inheritdoc />
    public partial class ProjetoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfertasViagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RotaId = table.Column<int>(type: "int", nullable: false),
                    DataIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVolta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasViagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertasViagem_Rota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertasViagem_RotaId",
                table: "OfertasViagem",
                column: "RotaId");

            migrationBuilder.InsertData(
        table: "Rota",
        columns: new[] { "Origem", "Destino" },
        values: new object[,]
        {
            { "São Paulo", "Curitiba" },
            { "Manaus", "Rio Branco" },
            { "Juiz de Fora", "Rio de Janeiro" },
            { "Recife", "Vitória" }
        });

            migrationBuilder.InsertData(
        table: "OfertasViagem",
        columns: new[] { "RotaId", "DataIda", "DataVolta", "Preco" },
        values: new object[,]
        {
            { 1, new DateTime(2024, 1, 20), new DateTime(2024, 1, 25), 300.50 },
            { 2, new DateTime(2024, 2, 5), new DateTime(2024, 2, 10), 250.75 },
            { 3, new DateTime(2024, 3, 15), new DateTime(2024, 3, 20), 400.00 },
            { 4, new DateTime(2024, 4, 1), new DateTime(2024, 4, 6), 350.25 }
        });
    }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertasViagem");

            migrationBuilder.DropTable(
                name: "Rota");
        }
    }
}
