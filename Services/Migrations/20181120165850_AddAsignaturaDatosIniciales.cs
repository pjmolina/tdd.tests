using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddAsignaturaDatosIniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "Id", "Nombre", "Optativa", "PlanId" },
                values: new object[] { 3, "Matemática Numérica", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Asignatura",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
