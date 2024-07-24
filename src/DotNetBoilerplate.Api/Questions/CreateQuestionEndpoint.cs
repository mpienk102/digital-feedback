using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Questions.Create;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Questions
{
    internal sealed class CreateQuestionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", Handle)
                .RequireAuthorization()
                .WithSummary("Create question");
        }

        private static async Task<Ok<Response>> Handle(
            [FromBody] Request request,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new CreateQuestionCommand(request.formId, request.questionText);

            var result = await commandDispatcher
                .DispatchAsync<CreateQuestionCommand, Guid>(command, ct);

            return TypedResults.Ok(new Response(result));
        }

        internal sealed record Response(
            Guid Id
        );

        private sealed class Request
        {
            [Required] public Guid formId { get; init; }
            [Required] public string questionText { get; init; }
        }
    }
}
