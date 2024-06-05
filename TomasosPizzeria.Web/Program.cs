using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.Infrastructure.Data.Repository;
using TomasosPizzeria.Infrastructure.ErrorHandler;
using TomasosPizzeria.Infrastructure.Services;
using TomasosPizzeria.UseCases.Interfaces;
using TomasosPizzeria.UseCases.Interfaces.Repository;
using TomasosPizzeria.Web.Services;

namespace TomasosPizzeria.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        builder.Services.AddApplicationInsightsTelemetry();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAuthorization();
        builder.Services.AddSwaggerConfig();
        builder.Services.AddMediatR();
        
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        
        // Azure KeyVault & EntityFramework
        var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
        var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
        var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
        var keyVaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryId");

        var credential = new ClientSecretCredential(keyVaultDirectoryId.Value!.ToString(),
            keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString());

        builder.Configuration.AddAzureKeyVault(keyVaultURL.Value!.ToString(), keyVaultClientId.Value.ToString(),
            keyVaultClientSecret.Value.ToString(), new DefaultKeyVaultSecretManager());

        var client = new SecretClient(new Uri(keyVaultURL.Value.ToString()), credential);
        
        builder.Services.AddEntityFramework(client);
        builder.Services.AddIdentity(builder.Configuration);

        
        // Add scoped services
        builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
        builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
        builder.Services.AddScoped<IDishRepo, DishRepo>();
        builder.Services.AddScoped<IOrderRepo, OrderRepo>();
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<ITokenProvider, TokenProvider>();
        builder.Services.AddScoped<IErrorHandler, ErrorHandler>();
        builder.Services.AddScoped<RoleManager<IdentityRole>>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.MapIdentityApi<ApplicationUser>();
        
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            Identity.CreateRoles(services).Wait();
        }

        app.Run();
    }
}
