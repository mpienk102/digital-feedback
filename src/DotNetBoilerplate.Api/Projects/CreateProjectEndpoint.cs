using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Projects.Create;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Projects
{
    internal sealed class CreateProjectEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", Handle)
                .RequireAuthorization()
                .WithSummary("Create project");
        }

        private static async Task<Ok<Response>> Handle(
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new CreateProjectCommand(request.Name, request.Description, request.Status, request.OrganizationId, request.CreatorId, request.CreatedAt);

            var result = await commandDispatcher
                .DispatchAsync<CreateProjectCommand, Guid>(command, ct);

            return TypedResults.Ok(new Response(result));
        }

        internal sealed record Response(
            Guid Id
        );

        private sealed class Request
        {
            [Required] public string Name { get; init; }
            [Required] public string Description { get; init; }
            [Required] public string Status { get; init; }
            [Required] public Guid OrganizationId { get; init; }
            [Required] public Guid CreatorId { get; init; }
            [Required] public DateTimeOffset CreatedAt { get; init; }
        }
    }
}
