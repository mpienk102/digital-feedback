using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBoilerplate.Core.Questions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;
using DotNetBoilerplate.Shared.Time;

namespace DotNetBoilerplate.Application.Questions.Create
{
    internal sealed class CreateQuestionHandler(
        IQuestionRepository questionRepository,
        IContext context,
        IClock clock
    ) : ICommandHandler<CreateQuestionCommand, Guid>
    {
        public async Task<Guid> HandleAsync(CreateQuestionCommand command)
        {
            var question = Question.Create(
                command.formId,
                context.Identity.Id,
                command.questionText,
                command.questionType,
                clock.Now()
            );

            await questionRepository.AddAsync(question);

            return question.Id;
        }
    }
}
