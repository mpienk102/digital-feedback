using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Forms.Create;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Forms;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Forms
{
    internal sealed class CreateFormEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", Handle)
                .RequireAuthorization()
                .WithSummary("Create form");
        }

        private static async Task<Ok<Response>> Handle(
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new CreateFormCommand(request.Name, request.Description, request.ProjectId);

            var result = await commandDispatcher
                .DispatchAsync<CreateFormCommand, Guid>(command, ct);

            return TypedResults.Ok(new Response(result));
        }

        internal sealed record Response(Guid Id);

        private sealed class Request
        {
            [Required] public string Name { get; init; }
            [Required] public string Description { get; init; }
            [Required] public Guid ProjectId { get; init; }
        }
    }
}
