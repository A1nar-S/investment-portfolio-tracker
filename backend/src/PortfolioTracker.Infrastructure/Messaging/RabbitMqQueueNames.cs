namespace PortfolioTracker.Infrastructure.Messaging;

/// <summary>
/// One durable queue per message type, named after the type itself, so
/// publisher and consumer never need to agree on a name out of band.
/// </summary>
public static class RabbitMqQueueNames
{
    public static string For<TMessage>() => typeof(TMessage).Name;
}
