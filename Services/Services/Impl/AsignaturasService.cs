using System.Collections.Generic;
using System.Linq;
using Unir.Aggregates.Asignaturas;

namespace Unir.Services.Impl
{
    public class AsignaturasService : IAsignaturasService
    {
        private readonly IAsignaturasRepository _repoAsignaturas;

        public AsignaturasService(IAsignaturasRepository repoAsignaturas) 
        {
            _repoAsignaturas = repoAsignaturas;
        }

        public List<Asignatura> GetAsignaturas(int[] ids)
        {
            var asignaturas = _repoAsignaturas.GetFiltered(a => ids.Contains(a.Id));
            if (asignaturas.Count != ids.Length)
                return null;

            return asignaturas;
        }
    }
}