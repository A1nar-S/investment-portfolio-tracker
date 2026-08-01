namespace PortfolioTracker.Domain;

public class BrokerConnection
{
    public required Guid Id { get; init; }
    public required Guid UserId { get; init; }
    public required BrokerType Broker { get; init; }
    public required string ExternalAccountId { get; init; } // brokers account id
    public required string DisplayName { get; set; }
    public required DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? LastSyncedAt { get; set; }
}