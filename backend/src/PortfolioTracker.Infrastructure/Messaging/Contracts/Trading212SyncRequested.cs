namespace PortfolioTracker.Infrastructure.Messaging.Contracts;

/// <summary>
/// Published when a Trading212 replication run should happen. Consumed by
/// PortfolioTracker.Scraper.
/// </summary>
public sealed record 
    Trading212SyncRequested(Guid CorrelationId, DateTimeOffset RequestedAtUtc);
