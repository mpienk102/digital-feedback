using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNetBoilerplate.Core.Forms;
using DotNetBoilerplate.Core.Questions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Application.Forms.Exceptions;

namespace DotNetBoilerplate.Api.Questions
{
    internal sealed class GetQuestionsByFormIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{formId}", Handle)
                .RequireAuthorization()
                .WithSummary("Get all questions for a form by formId");
        }

        private static async Task<Ok<Response>> Handle(
            [FromRoute] Guid formId,
            [FromServices] IQuestionRepository questionRepository,
            [FromServices] IFormRepository formRepository,
            CancellationToken ct
        )
        {
            var form = await formRepository.GetByIdAsync( formId );

            if (form is null) throw new FormNotFoundException(formId);

            var questions = await questionRepository.GetQuestionsByFormIdAsync(formId, ct);
            var response = questions.Select(q => new QuestionDto(q.Id, q.QuestionText, q.QuestionType, q.CreatedAt)).ToList();
            return TypedResults.Ok(new Response(response));
        }

        internal sealed record Response(
            List<QuestionDto> Questions
        );

        internal sealed record QuestionDto(
            Guid Id,
            string QuestionText,
            QuestionTypeInForm.Type QuestionType,
            DateTimeOffset CreatedAt
        );
    }
}
