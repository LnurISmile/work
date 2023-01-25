using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.data.Concrete.EfCore;
using work.mvc.Identity;

namespace work.mvc.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }

                using (var workContext = scope.ServiceProvider.GetRequiredService<WorkContext>())
                {
                    try
                    {
                        workContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }
            }

            return host;
        }
    }
}
