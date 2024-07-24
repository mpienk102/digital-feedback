
using System.Windows.Input;
using DotNetBoilerplate.Core.Questions;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Questions.Create
{
    public sealed record GetQuestionCommand(Guid formId, string questionText) : ICommand<Guid>;
}
