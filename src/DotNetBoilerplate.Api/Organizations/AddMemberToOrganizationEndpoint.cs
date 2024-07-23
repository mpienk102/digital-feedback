using DotNetBoilerplate.Application.Organizations.Update;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotNetBoilerplate.Api.Organizations
{
    internal sealed class AddMemberToOrganizationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("{OrganizationId:guid}/members", Handle)
                .RequireAuthorization()
                .WithSummary("Add member to organization");
        }
        private static async Task<IResult> Handle(
            [FromServices] ICommandDispatcher commandDispatcher,
            [FromRoute] System.Guid OrganizationId,
            [FromBody] Request request,
            CancellationToken ct
        )
        {
            var command = new AddMemberToOrganizationCommand(request.UserId, OrganizationId, request.Role);

            await commandDispatcher.DispatchAsync<AddMemberToOrganizationCommand, System.Guid>(command);

            return TypedResults.Ok();
        }
        private sealed class Request
        {
            [Required] public System.Guid UserId { get; init; }


            [JsonConverter(typeof(JsonStringEnumConverter))] public RoleInOrganization.Role Role { get; init; }
        }
    }
}
