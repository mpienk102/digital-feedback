using DotNetBoilerplate.Application.Organizations.Read;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Organizations
{
    public class ReadOrganizationByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get organization by Id");
        }

        private static async Task<Ok<OrganizationDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new ReadByIdCommand(id);

            var result = await commandDispatcher.DispatchAsync<ReadByIdCommand, OrganizationDto>(command, ct);

            return TypedResults.Ok(result);
        }
    }
}
