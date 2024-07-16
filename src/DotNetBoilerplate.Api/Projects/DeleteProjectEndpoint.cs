using DotNetBoilerplate.Application.Projects.Delete;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static DotNetBoilerplate.Core.Projects.Project;

namespace DotNetBoilerplate.Api.Projects
{
    internal sealed class DeleteProjectEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("{projectId:guid}", Handle)
               .RequireAuthorization()
               .WithSummary("Delete project by ID");
        }

        private static async Task<Ok<Response>> Handle(
            Guid projectId,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new DeleteProjectCommand(projectId);

            await commandDispatcher
                .DispatchAsync<DeleteProjectCommand>(command, ct);

            return TypedResults.Ok(new Response());
        }
        internal sealed record Response();
    }
}