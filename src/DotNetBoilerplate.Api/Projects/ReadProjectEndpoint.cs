using DotNetBoilerplate.Application.Projects.Read;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Projects
{
    public class ReadProjectEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all projects");
        }

        private static async Task<Ok<List<ProjectDto>>> Handle(
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new ReadProjectCommand();

            var result = await commandDispatcher.DispatchAsync<ReadProjectCommand, List<ProjectDto>>(command, ct);
        
            return TypedResults.Ok(result);
        }
    }
}
