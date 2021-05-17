using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RA02.Services
{
    public static class ServiceExtentions
    {
        /// <summary>
        /// Configure MS Sql connection or Sqlite conection from appsettings.json
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            #region MsSqlServer

            var connectionString = config["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            #endregion MsSqlServer

        }

        /// <summary>
        /// Adds a scoped service of the type specified in TService with an implementation type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            
        }

    }
}
