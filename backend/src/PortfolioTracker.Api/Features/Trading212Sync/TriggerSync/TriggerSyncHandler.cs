using PortfolioTracker.Infrastructure.Messaging;
using PortfolioTracker.Infrastructure.Messaging.Contracts;

namespace PortfolioTracker.Api.Features.Trading212Sync.TriggerSync;

public sealed class TriggerSyncHandler(IMessagePublisher publisher)
{
    public async Task<TriggerSyncResponse> HandleAsync(CancellationToken cancellationToken)
    {
        var message = new Trading212SyncRequested(Guid.NewGuid(), DateTimeOffset.UtcNow);
        await publisher.PublishAsync(message, cancellationToken);

        return new TriggerSyncResponse(message.CorrelationId);
    }
}
