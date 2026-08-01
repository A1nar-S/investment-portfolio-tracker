namespace PortfolioTracker.Domain;

public class Instrument
{
    public required Guid Id { get; init; }
    public required string Isin { get; init; }
    public required string Symbol { get; init; } // For example: AAPL_US_EQ
    public required string Name { get; init; }
    public required string Currency { get; init; } // Currency - ISO 4217, e.g. "USD"
    public required AssetClass AssetClass { get; init; }
    public IReadOnlyCollection<InstrumentExternalRef> ExternalRefs { get; init; } = [];
}