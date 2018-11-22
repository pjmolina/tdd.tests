using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Unir.Repositories.Impl.Context
{
    public class PlanesContextDesignTimeFactory : IDesignTimeDbContextFactory<PlanesDbContext>
    {
        public PlanesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlanesDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\v14.0;Database=PlanesDb;Trusted_Connection=True;ConnectRetryCount=0");

            return new PlanesDbContext(optionsBuilder.Options);
        }
    }
}