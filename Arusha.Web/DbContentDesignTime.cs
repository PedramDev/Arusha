using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arusha.Domain
{
    public class DbContentDesignTime : IDesignTimeDbContextFactory<ArushaContext>
    {
        public ArushaContext CreateDbContext(string[] args)
        {
            var connectionString = ConnectionStringExtensions.MainConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<ArushaContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ArushaContext(optionsBuilder.Options);
        }
    }
}
