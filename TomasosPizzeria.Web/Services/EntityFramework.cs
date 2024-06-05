using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using TomasosPizzeria.Infrastructure.Context;

namespace TomasosPizzeria.Web.Services;

public static class EntityFramework
{
    public static void AddEntityFramework(this IServiceCollection services, SecretClient client)
    {
        services.AddDbContextFactory<TomasosContext>(options =>
            options.UseSqlServer(client.GetSecret("SQL-ConnectionString").Value.Value.ToString()));
        
        services.AddDbContext<TomasosContext>(options =>
            options.UseSqlServer(client.GetSecret("SQL-ConnectionString").Value.Value.ToString()));
    }
}