using Microsoft.Extensions.DependencyInjection;
using PortfolioTracker.Scraper.Trading212;

namespace PortfolioTracker.Scraper;

public static class DependencyInjection
{
    public static IServiceCollection AddScraper(this IServiceCollection services)
    {
        services.AddScoped<Trading212SyncJob>();
        services.AddHostedService<Trading212SyncConsumer>();

        return services;
    }
}
