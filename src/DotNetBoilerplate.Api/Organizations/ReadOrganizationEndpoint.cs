using DotNetBoilerplate.Application.Organizations.Read;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Organizations
{
    public class ReadOrganizationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all organizations");
        }

        private static async Task<Ok<List<OrganizationDto>>> Handle(
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new ReadOrganizationCommand();

            var result = await commandDispatcher.DispatchAsync<ReadOrganizationCommand, List<OrganizationDto>>(command, ct);

            return TypedResults.Ok(result);
        }
    }
}
