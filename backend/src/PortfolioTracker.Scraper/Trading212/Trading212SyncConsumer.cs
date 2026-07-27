using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PortfolioTracker.Infrastructure.Messaging;
using PortfolioTracker.Infrastructure.Messaging.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PortfolioTracker.Scraper.Trading212;

/// <summary>
/// The only piece that knows about RabbitMQ for this slice: it listens for
/// <see cref="Trading212SyncRequested"/> messages and hands each one to
/// <see cref="Trading212SyncJob"/>.
/// </summary>
public sealed class Trading212SyncConsumer(
    RabbitMqConnection connection,
    IServiceScopeFactory scopeFactory,
    ILogger<Trading212SyncConsumer> logger) : BackgroundService
{
    private IChannel? _channel;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueName = RabbitMqQueueNames.For<Trading212SyncRequested>();
        var conn = await connection.GetConnectionAsync(stoppingToken);
        _channel = await conn.CreateChannelAsync(cancellationToken: stoppingToken);

        await _channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            cancellationToken: stoppingToken);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (_, ea) =>
        {
            try
            {
                var message = JsonSerializer.Deserialize<Trading212SyncRequested>(ea.Body.Span);
                if (message is not null)
                {
                    await using var scope = scopeFactory.CreateAsyncScope();
                    var job = scope.ServiceProvider.GetRequiredService<Trading212SyncJob>();
                    await job.RunAsync(message, stoppingToken);
                }

                await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false, cancellationToken: stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to process Trading212SyncRequested message");
                await _channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: true, cancellationToken: stoppingToken);
            }
        };

        await _channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: false,
            consumer: consumer,
            cancellationToken: stoppingToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_channel is not null)
            await _channel.CloseAsync(cancellationToken);

        await base.StopAsync(cancellationToken);
    }
}
