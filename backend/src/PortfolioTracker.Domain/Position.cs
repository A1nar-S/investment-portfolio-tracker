namespace PortfolioTracker.Domain;

public class Position
{
    public required Guid Id { get; set; }
    public required Guid BrokerConnectionId { get; set; }
    public required Guid InstrumentId { get; set; }
    public required decimal Quantity { get; set; }
    public required Money AverageCost { get; set; }
    public required Money CurrentValue { get; set; }
    public required Money UnrealizedPnl { get; set; }
    public required DateTimeOffset AsOf  { get; set; }
}