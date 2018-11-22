using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AsignaturasPlanesManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignatura_Plan_PlanId",
                table: "Asignatura");

            migrationBuilder.DropIndex(
                name: "IX_Asignatura_PlanId",
                table: "Asignatura");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Asignatura");

            migrationBuilder.CreateTable(
                name: "AsignaturaPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AsignaturaId = table.Column<int>(nullable: true),
                    PlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignaturaPlan_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsignaturaPlan_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaPlan_AsignaturaId",
                table: "AsignaturaPlan",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaPlan_PlanId",
                table: "AsignaturaPlan",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignaturaPlan");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Asignatura",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_PlanId",
                table: "Asignatura",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignatura_Plan_PlanId",
                table: "Asignatura",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
