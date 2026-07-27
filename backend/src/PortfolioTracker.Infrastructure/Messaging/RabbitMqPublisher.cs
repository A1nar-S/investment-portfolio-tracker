using System.Text.Json;
using RabbitMQ.Client;

namespace PortfolioTracker.Infrastructure.Messaging;

public sealed class RabbitMqPublisher(RabbitMqConnection connection) : IMessagePublisher
{
    public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : notnull
    {
        var queueName = RabbitMqQueueNames.For<TMessage>();

        var conn = await connection.GetConnectionAsync(cancellationToken);
        await using var channel = await conn.CreateChannelAsync(cancellationToken: cancellationToken);

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            cancellationToken: cancellationToken);

        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: queueName,
            mandatory: false,
            body: body,
            cancellationToken: cancellationToken);
    }
}
