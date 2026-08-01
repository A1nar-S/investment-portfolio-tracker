namespace PortfolioTracker.Domain;

public record Money(decimal Amount, string Currency); // Currency - ISO 4217, e.g. "USD"