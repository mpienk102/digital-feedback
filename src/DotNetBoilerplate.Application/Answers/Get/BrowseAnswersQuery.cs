using DotNetBoilerplate.Core.Answers;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Answers.Get;

public sealed record BrowseAnswersQuery(Guid formId) : IQuery<List<AnswerDto>>;