using System.Collections.Generic;
using Unir.Aggregates.Planes;

namespace Unir.Aggregates.Asignaturas
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Optativa { get; set; }

        public virtual ICollection<AsignaturaPlan> AsignaturasPlanes { get; set; }
    }
}