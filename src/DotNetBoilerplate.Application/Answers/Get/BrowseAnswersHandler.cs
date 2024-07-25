using DotNetBoilerplate.Core.Answers;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using System.Linq;

namespace DotNetBoilerplate.Application.Answers.Get;

internal sealed class BrowseAnswersHandler(
    IAnswerRepository answerRepository    
) : IQueryHandler<BrowseAnswersQuery, List<AnswerDto>>
{
    public async Task<List<AnswerDto>> HandleAsync(BrowseAnswersQuery query)
    {
        var answers = await answerRepository.BrowseByFormId(query.formId);
        
        return answers.Select(answer => new AnswerDto(
                answer.Id,
                answer.UserId,
                answer.FormId,
                answer.QuestionId,
                answer.RatingAnswer,
                answer.TextAnswer
            )).ToList();
    }
}

public record AnswerDto(Guid Id, Guid UserId, Guid FormId, Guid QuestionId, int? RatingAnswer, string? TextAnswer);