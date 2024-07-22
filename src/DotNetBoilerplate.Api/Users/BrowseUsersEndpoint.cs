using DotNetBoilerplate.Application.Users.Read;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Users
{
    public class BrowseUsersEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("users", Handle)
                .RequireAuthorization()
                .WithSummary("Get all users");
        }

        private static async Task<Ok<List<UserDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new BrowseUsersQuery();
            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
