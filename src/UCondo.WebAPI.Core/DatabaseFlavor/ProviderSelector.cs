using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static UCondo.WebAPI.Core.DatabaseFlavor.ProviderConfiguration;

namespace UCondo.WebAPI.Core.DatabaseFlavor
{
    public static class ProviderSelector
    {
        public static IServiceCollection ConfigureProviderForContext<TContext>(
            this IServiceCollection services,
            (DatabaseType, string) options) where TContext : DbContext
        {
            var (database, connString) = options;
            Build(connString);
            return database switch
            {
                DatabaseType.SqlServer => services.PersistStore<TContext>(With.SqlServer),

                _ => throw new ArgumentOutOfRangeException(nameof(database), database, null)
            };
        }

        public static Action<DbContextOptionsBuilder> WithProviderAutoSelection((DatabaseType, string) options)
        {
            var (database, connString) = options;
            Build(connString);
            return database switch
            {
                DatabaseType.SqlServer => With.SqlServer,

                _ => throw new ArgumentOutOfRangeException(nameof(database), database, null)
            };
        }
        
    }
}
