using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Contact.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigration<T>(this WebApplication app) where T : DbContext
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<T>();
            db.Database.Migrate();
        }
    }
}
