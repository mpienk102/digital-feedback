using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Employees
{
    public class BrowseEmployeesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all employees");
        }

        private static async Task<Ok<List<EmployeeDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            [AsParameters] QueryParams queryParams,
            CancellationToken ct
        )
        {
            var query = new BrowseEmployeesQuery
            {
                Role = queryParams.Role
            };

            var result = await queryDispatcher.QueryAsync( query, ct );

            return TypedResults.Ok( result );
        }

        public sealed class QueryParams
        {
            [FromQuery] public RoleInOrganization.Role Role { get; init; }
        }
    }
}
