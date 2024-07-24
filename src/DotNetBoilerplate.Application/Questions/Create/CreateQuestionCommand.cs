
using System.Windows.Input;
using DotNetBoilerplate.Core.Questions;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Questions.Create
{
    public sealed record CreateQuestionCommand(Guid formId, string questionText, QuestionTypeInForm.Type questionType) : ICommand<Guid>;
}
