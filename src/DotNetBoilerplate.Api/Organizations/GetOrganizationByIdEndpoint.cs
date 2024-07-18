using DotNetBoilerplate.Application.Organizations.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Organizations;

public class GetOrganizationByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Get organization by Id");
    }

    private static async Task<Ok<OrganizationDto>> Handle(
        [FromRoute] Guid id,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken ct
    )
    {
        var query = new GetByIdQuery(id);

        var result = await queryDispatcher.QueryAsync(query, ct);

        return TypedResults.Ok(result);
    }
}