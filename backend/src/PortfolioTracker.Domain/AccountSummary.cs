namespace PortfolioTracker.Domain;

public record AccountSummary(
    Money Cash,
    Money InvestmentsValue,
    Money TotalValue,
    Money UnrealizedPnl,
    Money RealizedPnl);
