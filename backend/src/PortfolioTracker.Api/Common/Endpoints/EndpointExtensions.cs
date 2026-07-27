using System.Reflection;

namespace PortfolioTracker.Api.Common.Endpoints;

public static class EndpointExtensions
{
    /// <summary>
    /// Registers every <see cref="IEndpoint"/> implementation, plus every
    /// *Handler class (the request/handler pairs each slice defines), found
    /// in this assembly. No mediator/dispatcher involved: endpoints resolve
    /// their handler straight from DI.
    /// </summary>
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var endpointTypes = assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false } && typeof(IEndpoint).IsAssignableFrom(t));

        foreach (var type in endpointTypes)
            services.AddScoped(typeof(IEndpoint), type);

        var handlerTypes = assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false } && t.Name.EndsWith("Handler", StringComparison.Ordinal));

        foreach (var type in handlerTypes)
            services.AddScoped(type);

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var endpoints = scope.ServiceProvider.GetServices<IEndpoint>();

        foreach (var endpoint in endpoints)
            endpoint.MapEndpoint(app);

        return app;
    }
}
