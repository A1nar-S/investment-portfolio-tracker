namespace PortfolioTracker.Infrastructure.Messaging;

public interface IMessagePublisher
{
    /// <summary>
    /// Serializes <paramref name="message"/> to JSON and publishes it to a queue
    /// named after <typeparamref name="TMessage"/>.
    /// </summary>
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : notnull;
}
