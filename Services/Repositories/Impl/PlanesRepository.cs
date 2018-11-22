using Microsoft.EntityFrameworkCore;
using Unir.Aggregates.Asignaturas;
using Unir.Aggregates.Estudios;
using Unir.Aggregates.Planes;

using Unir.Repositories.Impl.Context;

namespace Unir.Repositories.Impl
{
    public class PlanesRepository : GenericRepository<Plan>, IPlanesRepository
    {
        public PlanesRepository(PlanesDbContext context) : base(context)
        {
        }
    }
}