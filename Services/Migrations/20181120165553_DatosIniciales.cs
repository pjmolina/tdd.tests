using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class DatosIniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "Id", "Nombre", "Optativa", "PlanId" },
                values: new object[] { 1, "Análisis Matemático", false, null });

            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "Id", "Nombre", "Optativa", "PlanId" },
                values: new object[] { 2, "BI", true, null });

            migrationBuilder.InsertData(
                table: "Estudio",
                columns: new[] { "Id", "AprobadoAneca", "Nombre" },
                values: new object[] { 1, true, "Matemática" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Asignatura",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Asignatura",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estudio",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
