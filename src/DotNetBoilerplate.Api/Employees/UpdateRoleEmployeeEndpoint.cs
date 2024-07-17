using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Employees.Update;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static DotNetBoilerplate.Core.Employees.RoleInOrganization;

namespace DotNetBoilerplate.Api.Employees
{
    internal sealed class UpdateRoleEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("employees/{id:guid}/role", Handle)
                .RequireAuthorization()
                .WithSummary("Update employee role");
        }

        private static async Task<IResult> Handle(
            [FromRoute] Guid id,
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new UpdateRoleCommand(id, request.OrganizationId, request.NewRole);
            await commandDispatcher.DispatchAsync(command, ct);
            return TypedResults.Ok(new Response(id));
        }

        internal sealed record Response(Guid Id);

        private sealed class Request
        {
            [Required] public Guid OrganizationId { get; init; }
            [Required] public Role NewRole { get; init; }
        }
    }
}
