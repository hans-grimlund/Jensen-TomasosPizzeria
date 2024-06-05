namespace TomasosPizzeria.Web.Services;

public static class MediatR
{
    public static void AddMediatR(this IServiceCollection services)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
}