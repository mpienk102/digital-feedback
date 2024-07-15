using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Projects.Create;
using DotNetBoilerplate.Application.Projects.Update;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Projects;

internal sealed class UpdateProjectEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Update project details");
    }

    private static async Task<IResult> Handle(
        [FromRoute] Guid id,
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new UpdateProjectCommand(id, request.Name, request.Description);

        await commandDispatcher.DispatchAsync(command, ct);


        return TypedResults.Ok(new Response(id));
    }
    internal sealed record Response(
        Guid Id
    );
    private sealed class Request
    {
        [Required] public string Name { get; init; }
        [Required] public string Description { get; init; }
    }
}