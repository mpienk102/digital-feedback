using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Employees
{
    public class GetEmployeeByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get employee by id");
        }

        private static async Task<Ok<EmployeeDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetEmployeeByIdQuery(id);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
