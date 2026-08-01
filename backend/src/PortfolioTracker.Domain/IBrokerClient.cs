namespace PortfolioTracker.Domain;

public interface IBrokerClient
{
    Task<IReadOnlyCollection<Instrument>> GetAvailableInstrumentsAsync(
        BrokerConnection connection,
        CancellationToken cancellationToken = default);

    Task<AccountSummary> GetAccountSummaryAsync(
        BrokerConnection connection,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Position>> GetPositionsAsync(
        BrokerConnection connection,
        CancellationToken cancellationToken = default);
    
    IAsyncEnumerable<Transaction> GetTransactionHistoryAsync(
        BrokerConnection connection,
        DateTimeOffset? since,
        CancellationToken cancellationToken = default);
}