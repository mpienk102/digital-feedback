using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Projects.Update;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Core.Projects;
using static DotNetBoilerplate.Core.Projects.Project;
using System.Text.Json.Serialization;

namespace DotNetBoilerplate.Api.Projects
{
    internal sealed class UpdateProjectStatusEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("projects/{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Update project status");
        }

        private static async Task<IResult> Handle(
            [FromRoute] Guid id,
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new UpdateProjectStatusCommand(id, request.Status);

            await commandDispatcher.DispatchAsync(command, ct);

            return TypedResults.Ok(new Response(id));
        }

        internal sealed record Response(Guid Id);

        private sealed class Request
        {
            [JsonConverter(typeof(JsonStringEnumConverter))]
            public ProjectStatus Status { get; set; }
        }
    }
}
