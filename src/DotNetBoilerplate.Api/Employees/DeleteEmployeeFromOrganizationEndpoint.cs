using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Application.Employees.Delete;

namespace DotNetBoilerplate.Api.Employees
{
    internal sealed class DeleteEmployeeFromOrganizationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("{employeeId:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Delete employee from organization");
        }

        private static async Task<Ok<Response>> Handle(
            Guid employeeId,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
            )
        {
            var command = new DeleteEmployeeFromOrganizationCommand(employeeId);

            await commandDispatcher
                .DispatchAsync<DeleteEmployeeFromOrganizationCommand>(command, ct);

            return TypedResults.Ok(new Response());
        }
        internal sealed record Response();

    }
}