using PortfolioTracker.Api.Common.Endpoints;

namespace PortfolioTracker.Api.Features.Trading212Sync.TriggerSync;

public sealed class TriggerSyncEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/trading212/sync", async (TriggerSyncHandler handler, CancellationToken cancellationToken) =>
            {
                var response = await handler.HandleAsync(cancellationToken);
                return Results.Accepted(value: response);
            })
            .WithName("TriggerTrading212Sync")
            .WithTags("Trading212Sync");
    }
}
