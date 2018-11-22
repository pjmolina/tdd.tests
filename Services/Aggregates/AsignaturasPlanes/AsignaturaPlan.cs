using System.Collections.Generic;
using Unir.Aggregates.Planes;

namespace Unir.Aggregates.Asignaturas
{
    public class AsignaturaPlan
    {
        public int Id { get; set; }

        public virtual Asignatura Asignatura { get; set; }
        public virtual Plan Plan { get; set; }
    }
}