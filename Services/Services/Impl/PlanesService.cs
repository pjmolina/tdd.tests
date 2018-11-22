using System.Linq;
using Unir.Aggregates.Asignaturas;
using Unir.Aggregates.Estudios;
using Unir.Aggregates.Planes;

namespace Unir.Services.Impl
{
    public class PlanesService : IPlanesService
    {
        private readonly IPlanesRepository _repoPlanes;
        private readonly IAsignaturasRepository _repoAsignaturas;
        private readonly IEstudiosRepository _repoEstudios;

        private readonly IAsignaturasService _serviceAsignatura;

        public PlanesService(IPlanesRepository repoPlanes, 
                             IAsignaturasRepository repoAsignaturas, 
                             IEstudiosRepository repoEstudios,
                             IAsignaturasService serviceAsignatura) 
        {
            _repoPlanes = repoPlanes;
            _repoAsignaturas = repoAsignaturas;
            _repoEstudios = repoEstudios;

            _serviceAsignatura = serviceAsignatura;
        }

        public bool AgregarAsignatura(int idPlan, int idAsignatura)
        {
            var plan = _repoPlanes.Get(idPlan);
            if (plan == null)
                return false;

            var asignatura = _repoAsignaturas.Get(idAsignatura);
            if (asignatura == null)
                return false;

            plan.Asignaturas.Add(new AsignaturaPlan { Asignatura = asignatura });
            if (!IsPlanValido(plan))
            {
                return false;
            }

            _repoPlanes.Commit();

            return true;
        }

        public bool AprobarPlan(int idPlan)
        {
            var plan = _repoPlanes.Get(idPlan);
            if (plan == null)
                return false;

            if (!IsPlanValido(plan))
                return false;

            plan.Aprobado = true;
            return true;
        }

        public bool CrearPlan(string nombre, int idEstudio, int[] idsAsignaturas)
        {
            // Validar argumento nombre y posible existencia en la BBDD
            if (string.IsNullOrEmpty(nombre))
                return false;

            if (_repoPlanes.GetFiltered(p => p.Nombre == nombre).Any())
                return false;

            // Validar existencia argumentos Ids de estudio y asignaturas
            var estudio = _repoEstudios.Get(idEstudio);
            if (estudio == null)
                return false;
            var asignaturas = _serviceAsignatura.GetAsignaturas(idsAsignaturas);
            if (asignaturas == null)
                return false;

            var plan = new Plan();
            plan.Nombre = nombre;
            plan.Estudio = estudio;
            foreach (var asig in asignaturas)
            {
                plan.Asignaturas.Add(new AsignaturaPlan{ Asignatura = asig });
            }

            _repoPlanes.Add(plan);
            _repoPlanes.Commit();
            
            return true;
        }

        public bool IsPlanValido(Plan plan)
        {            
            return plan.Estudio.AprobadoAneca 
                    && plan.Asignaturas.Any(a => a.Asignatura.Optativa)
                    && plan.Asignaturas.Count(a => a.Asignatura.Optativa) <= 3;
        }
    }
}