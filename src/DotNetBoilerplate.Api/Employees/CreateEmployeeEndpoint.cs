using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Employees.Create;
using DotNetBoilerplate.Application.Organizations.Create;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static DotNetBoilerplate.Core.Employees.Role;

namespace DotNetBoilerplate.Api.Employees
{
    internal sealed class CreateEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", Handle)
                .RequireAuthorization()
                .WithSummary("Create Employee");
        }

        private static async Task<Ok<Response>> Handle(
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {

            var command = new CreateEmployeeCommand(request.OrganizationId, request.Role);
            var result = await commandDispatcher
                .DispatchAsync<CreateEmployeeCommand, Guid>(command, ct);
            return TypedResults.Ok(new Response(result));
        }

        internal sealed record Response(
            Guid Id
            );

        private sealed class Request
        {
            [Required] public Guid OrganizationId { get; init; }
            [Required] public RoleInOrganization Role { get; init; }
        }
    }

}
