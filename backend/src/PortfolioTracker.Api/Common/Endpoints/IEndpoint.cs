using Microsoft.AspNetCore.Routing;

namespace PortfolioTracker.Api.Common.Endpoints;

/// <summary>
/// Implemented once per vertical slice. Keeps route registration next to the
/// feature it belongs to instead of a central Controllers/ folder.
/// </summary>
public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
