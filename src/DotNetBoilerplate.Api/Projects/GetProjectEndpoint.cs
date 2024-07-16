using DotNetBoilerplate.Application.Projects.Read;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Projects
{
    public class GetProjectEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all projects");
        }

        private static async Task<Ok<List<ProjectDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            [AsParameters] QueryParams queryParams,
            CancellationToken ct
        )
        {
            var query = new GetProjectQuery
            {
                Status = queryParams.Status // przekazanie statusu do zapytania
            };

            var result = await queryDispatcher.QueryAsync(query, ct);
        
            return TypedResults.Ok(result);
        }
        public sealed class QueryParams
        {
            [FromQuery] public Project.ProjectStatus Status { get; init; }
        }
    }
}
