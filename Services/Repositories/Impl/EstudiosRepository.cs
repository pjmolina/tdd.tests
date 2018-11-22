using Microsoft.EntityFrameworkCore;
using Unir.Aggregates.Asignaturas;
using Unir.Aggregates.Estudios;

using Unir.Repositories.Impl.Context;

namespace Unir.Repositories.Impl
{
    public class EstudiosRepository : GenericRepository<Estudio>, IEstudiosRepository
    {
        public EstudiosRepository(PlanesDbContext context) : base(context)
        {
        }
    }
}