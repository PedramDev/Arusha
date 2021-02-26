using Arusha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arusha.Web.Extensions
{

    public static class DbContextServiceExtension
    {
        public static DbContextOptions<ArushaContext> dbContextOptions;
        public static void AddContext(this IServiceCollection services)
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<ArushaContext>();
            dbContextOptionBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            dbContextOptions = dbContextOptionBuilder.UseSqlServer(ConnectionStringExtensions.MainConnectionString,
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)).Options;
            services.AddContext<ArushaContext>(x => x.UseSqlServer(ConnectionStringExtensions.MainConnectionString));
        }
        public static void AddContext<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext
        {
            services.AddDbContextPool<T>(options);
        }
    }
}
