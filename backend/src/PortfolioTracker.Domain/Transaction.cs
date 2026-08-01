namespace PortfolioTracker.Domain;

public class Transaction
{
    public required Guid Id { get; init; }
    public required Guid BrokerConnectionId { get; init; }
    public Guid? InstrumentId { get; init; } // Null for deposit, withdrawal, interest
    public required TransactionType Type { get; init; }
    public decimal? Quantity { get; init; }
    public Money? Price { get; init; }
    public required Money Amount { get; init; }
    public required string ExternalId { get; init; }
    public required DateTimeOffset OccurredAt { get; init; }
}