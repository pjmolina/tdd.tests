using System.Collections.Generic;
using Unir.Aggregates.Asignaturas;

namespace Unir.Services
{
    public interface IAsignaturasService
    {
        List<Asignatura> GetAsignaturas(int[] ids);
    }
}