using DotNetBoilerplate.Application.Answers.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace DotNetBoilerplate.Api.Answers
{
    public class BrowseAnswersEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{formId:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get all questions from given form");
        }

        private static async Task<Ok<List<AnswerDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            [FromRoute] Guid formId,
            CancellationToken ct
        )
        {
            var query = new BrowseAnswersQuery(formId);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
