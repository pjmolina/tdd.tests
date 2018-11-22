using System.Collections.Generic;
using Unir.Aggregates.Asignaturas;
using Unir.Aggregates.Estudios;

namespace Unir.Aggregates.Planes
{
    public class Plan
    {
        public Plan()
        {
            Asignaturas = new List<AsignaturaPlan>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Aprobado { get; set; }

        public virtual Estudio Estudio { get; set; }
        public virtual ICollection<AsignaturaPlan> Asignaturas { get; set; }
    }
}