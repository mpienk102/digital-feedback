using DotNetBoilerplate.Application.Projects.Read;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Projects
{
    public class ReadProjectByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get project by id");
        }

        private static async Task<Ok<ProjectDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new ReadProjectByIdCommand(id);

            var result = await commandDispatcher.DispatchAsync<ReadProjectByIdCommand, ProjectDto>(command, ct);

            return TypedResults.Ok(result);
        }
    }
}
