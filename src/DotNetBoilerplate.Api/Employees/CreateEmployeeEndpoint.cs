using DotNetBoilerplate.Application.Employees.Create;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotNetBoilerplate.Api.Employees
{
    internal sealed class CreateEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", Handle)
                .RequireAuthorization()
                .WithSummary("Create employee");
        }

        private static async Task<Ok<Response>> Handle(
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new CreateEmployeeCommand(request.UserId, request.OrganizationId);

            var result = await commandDispatcher
                .DispatchAsync<CreateEmployeeCommand, Guid>(command, ct);

            return TypedResults.Ok(new Response(result));
        }

        internal sealed record Response(
            Guid Id    
        );

        private sealed class Request
        {
            [Required] public Guid UserId { get; init; }
            [Required] public Guid OrganizationId { get; init; }
        }
    }
}
