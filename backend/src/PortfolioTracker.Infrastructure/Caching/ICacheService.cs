namespace PortfolioTracker.Infrastructure.Caching;

/// <summary>
/// Cache-aside helper over IDistributedCache (Redis-backed). Query slices that
/// read replicated data should go through this instead of hitting the DB directly.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Returns the cached value for <paramref name="key"/> if present; otherwise
    /// calls <paramref name="factory"/>, caches the result for <paramref name="ttl"/>, and returns it.
    /// </summary>
    Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        TimeSpan ttl,
        CancellationToken cancellationToken = default);

    /// <summary>Removes a cached entry, e.g. after the underlying data is replicated/updated.</summary>
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
