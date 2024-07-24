using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Answers.Create;

public sealed record AddAnswerToQuestionCommand(Guid FormId, Guid QuestionId, int? RatingAnswer, string? TextAnswer) : ICommand<Guid>;