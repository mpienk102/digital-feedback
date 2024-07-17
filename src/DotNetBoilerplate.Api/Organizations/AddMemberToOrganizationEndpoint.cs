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
            app.MapPut("", Handle)
                .RequireAuthorization()
                .WithSummary("Add member to organization");
        }
        private static async Task<IResult> Handle(
            [FromServices] ICommandDispatcher commandDispatcher,
            [FromBody] Request request,
            CancellationToken ct
        )
        {
            var command = new AddMemberToOrganizationCommand(request.UserId, request.OrganizationId, request.Role);

            await commandDispatcher.DispatchAsync(command);

            return TypedResults.Ok();
        }
        private sealed class Request
        {
            [Required] public Guid UserId { get; init; }

            [Required] public Guid OrganizationId { get; init; }

            [JsonConverter(typeof(JsonStringEnumConverter))] public RoleInOrganization.Role Role { get; init; }
        }
    }
}
