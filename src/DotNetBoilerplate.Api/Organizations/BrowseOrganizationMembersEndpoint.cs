using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Application.Organizations.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Organizations
{
    public class BrowseOrganizationMembersEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{organizationId:guid}/members", Handle)
                .RequireAuthorization()
                .WithSummary("Get all organization members");
        }

        private static async Task<Ok<List<EmployeeListDto>>> Handle(
            [FromRoute] Guid organizationId,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new BrowseOrganizationMembersQuery(organizationId);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
