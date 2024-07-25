using DotNetBoilerplate.Core.Answers;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Answers.Create
{
    internal sealed class AddAnswerToQuestionHandler (
        IAnswerRepository answerRepository,
        IContext context
    ) : ICommandHandler<AddAnswerToQuestionCommand, Guid>
    {
        public async Task<Guid> HandleAsync(AddAnswerToQuestionCommand command)
        {
            var answer = Answer.Create(
                context.Identity.Id,
                command.FormId,
                command.QuestionId,
                command.RatingAnswer,
                command.TextAnswer
            );

            await answerRepository.AddAsync( answer );
            return answer.Id;
        }

    }
}
