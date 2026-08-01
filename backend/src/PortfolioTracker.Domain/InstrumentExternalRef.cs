namespace PortfolioTracker.Domain;

public class InstrumentExternalRef
{
    public required Guid Id { get; init; }
    public required Guid InstrumentId { get; init; }
    public required BrokerType Broker { get; init; }
    public required string ExternalId { get; init; } // T212 ticker ("AAPL_US_EQ") or IBKR conid ("265598") as a string
}