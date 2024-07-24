using DotNetBoilerplate.Application.Answers.Create;
using DotNetBoilerplate.Core.Questions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Api.Answers
{
    internal sealed class AddAnswerToQuestionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("{QuestionId:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Add answer to question");
        }

        private static async Task<IResult> Handle(
            [FromServices] ICommandDispatcher commandDispatcher,
            [FromServices] IQuestionRepository questionRepository,
            [FromQuery] Guid FormId,
            [FromRoute] Guid QuestionId,
            [FromBody] Request request,
            CancellationToken ct
        )
        {
            var type = await questionRepository.GetQuestionTypeAsync(QuestionId);

            AddAnswerToQuestionCommand command;

            if (type == QuestionTypeInForm.Type.rating)
            {
                if (request.RatingAnswer == null)
                {
                    return TypedResults.BadRequest("RatingAnswer is required for rating type questions.");
                }
                command = new AddAnswerToQuestionCommand(FormId, QuestionId, request.RatingAnswer, null);
            }
            else
            {
                if (request.TextAnswer == null)
                {
                    return TypedResults.BadRequest("TextAnswer is required for text type questions.");
                }
                command = new AddAnswerToQuestionCommand(FormId, QuestionId, null, request.TextAnswer);
            }

            await commandDispatcher.DispatchAsync<AddAnswerToQuestionCommand, Guid>(command);

            return TypedResults.Ok();
        }

        private sealed class Request
        {
            public int? RatingAnswer { get; init; }
            public string? TextAnswer { get; init; }
        }
    }
}
