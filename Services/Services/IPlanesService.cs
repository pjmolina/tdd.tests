using Unir.Aggregates.Planes;

namespace Unir.Services
{
    public interface IPlanesService
    {
        // Crea un plan asociado a un estudio y un grupo de asignaturas
        // Valida que se trate como mínimo de 3 asignaturas
        bool CrearPlan(string nombre, int idEstudio, int[] idsAsignaturas);

        // Establece al plan como Aprobado.
        // Verifica la validez del plan
        bool AprobarPlan(int idPlan);

        // Añade una asignatura a un Plan
        // Verifica la validez del plan
        bool AgregarAsignatura(int idPlan, int idAsignatura);

        // Verifica que el estudio esté aprobado por la ANECA 
        // y que el plan tenga entre una y tres asignaturas optativas
        bool IsPlanValido(Plan plan);
    }
}