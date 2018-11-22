using Microsoft.EntityFrameworkCore;
using Unir.Aggregates.Asignaturas;
using Unir.Repositories.Impl.Context;

namespace Unir.Repositories.Impl
{
    public class AsignaturasRepository : GenericRepository<Asignatura>, IAsignaturasRepository
    {
        public AsignaturasRepository(PlanesDbContext context) : base(context)
        {
        }
    }
}