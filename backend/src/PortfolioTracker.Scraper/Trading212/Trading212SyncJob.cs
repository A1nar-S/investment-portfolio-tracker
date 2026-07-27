using Microsoft.Extensions.Logging;
using PortfolioTracker.Infrastructure.Messaging.Contracts;

namespace PortfolioTracker.Scraper.Trading212;

/// <summary>
/// The actual replication work, deliberately decoupled from whatever triggers it.
/// Today it's called by <see cref="Trading212SyncConsumer"/> off a RabbitMQ message;
/// a future scheduler (e.g. Hangfire) can call RunAsync directly with no changes here.
/// </summary>
public sealed class Trading212SyncJob(ILogger<Trading212SyncJob> logger)
{
    public Task RunAsync(Trading212SyncRequested request, CancellationToken cancellationToken = default)
    {
        // TODO: call the Trading212 API client and upsert results into local tables
        // once the client and persistence schema exist.
        logger.LogInformation(
            "Would replicate Trading212 data now (correlation {CorrelationId}, requested at {RequestedAtUtc})",
            request.CorrelationId,
            request.RequestedAtUtc);

        return Task.CompletedTask;
    }
}
