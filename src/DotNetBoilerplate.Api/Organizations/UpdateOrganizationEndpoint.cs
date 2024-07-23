using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Organizations.Create;
using DotNetBoilerplate.Application.Organizations.Update;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.Organizations;

internal sealed class UpdateOrganizationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Update organization");
    }

    private static async Task<IResult> Handle(
        [FromRoute] Guid id,
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new UpdateOrganizationCommand(id, request.Name);

        await commandDispatcher.DispatchAsync(command, ct);


        return TypedResults.Ok(new Response(id));

        // return TypedResults.Ok(new Response(id, request.Name));
    }
    internal sealed record Response(
        Guid Id
    );
    private sealed class Request
    {
        [Required] public string Name { get; init; }
    }
}